using Autodesk.Forge.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Neoxim.Platform.Infrastructure.Externals.Autodesk;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers.Externals
{
    public partial class ExternalsController
    {
        /// <summary>
        /// APS - Get access token
        /// </summary>
        /// <returns></returns>
        [HttpGet("autodesk-forge/auth/token")]
        [ProducesResponseType(typeof(AccessToken), StatusCodes.Status200OK)]
        public async Task<IActionResult> AutodeskGetAccessTokenAsync()
        {
            var token = await _aps.GetPublicTokenAsync();
            return Ok(new AccessToken(token.AccessToken, (long)Math.Round((token.ExpiresAt - DateTime.UtcNow).TotalSeconds)));
        }

        /// <summary>
        /// APS - Get models
        /// </summary>
        /// <returns></returns>
        [HttpGet("autodesk-forge/models")]
        [ProducesResponseType(typeof(IEnumerable<BucketObject>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetModelsAsync()
        {
            var objects = await _aps.GetObjectsAsync();
            var result = objects.Select(o => new BucketObject(o.ObjectKey, APS.Base64Encode(o.ObjectId)));
            return Ok(result);
        }

        [HttpGet("autodesk-forge/models/{urn}/status")]
        [ProducesResponseType(typeof(TranslationStatus), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetModelStatus(string urn)
        {
            try
            {
                var status = await _aps.GetTranslationStatus(urn);
                return Ok(status);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    return Ok(new TranslationStatus("n/a", "", new List<string>()));
                else
                    return BadRequest(ex.Message);
            }
        }

        // [HttpPost("autodesk-forge/models/form")]
        // [ProducesResponseType(typeof(BucketObject), StatusCodes.Status200OK)]
        // public async Task<IActionResult> UploadAndTranslateModelAsync([FromForm] UploadModelForm form)
        // {
        //     using var stream = new MemoryStream();
        //     await form.File.CopyToAsync(stream);
        //     stream.Position = 0;
        //     var obj = await _aps.UploadModel(form.File.FileName, stream);
        //     var job = await _aps.TranslateModel(obj.ObjectId, form.Entrypoint);

        //     return Ok(new BucketObject(obj.ObjectKey, job.Urn));
        // }

        /// <summary>
        /// Generate document bucket (urn) for visualization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> <summary>
        [HttpPost("autodesk-forge/models/bucket-urn")]
        [ProducesResponseType(typeof(BucketObject), StatusCodes.Status200OK)]
        public async Task<IActionResult> GenerateBucketAsync([FromBody] LoadDocumentModel model)
        {
            try
            {
                var key = $"KEY_{model.documentId}";
    
                var (obj, job) = await _memoryCache.GetOrCreateAsync(key, 
                    async (entry) => 
                    {
                        // Cache
                        entry.AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(CACHE_EXPIRATION_DURATION);
                            
                        // Act 
                        var document = await _documentService.GetAsync(model.documentId, default);
                        var inputBytes = await _storageService.DownloadFileAsync(document.Url, default);
    
                        using var stream = new MemoryStream();            
                        stream.Write(inputBytes, 0, inputBytes.Length);
                            
                        var name = $"{document.Id}.{document.Type}".ToLower();
    
                        var obj = await _aps.UploadModel(name, stream);
                        var job = await _aps.TranslateModel(obj.ObjectId, null);
    
                        return (obj, job);      
                    }
                );
    
                return Ok(new BucketObject(obj.ObjectKey, job.Urn));
            }
            catch (ObjectNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}