using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Neoxim.Platform.Api.Controllers.Externals;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers
{
    public partial class DocumentsController
    {
        /// <summary>
        /// Generate document bucket (urn) for visualization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> <summary>
        /// <summary>
        //[HttpPost("download/bim")]
        //[ProducesResponseType(typeof(BucketObject), StatusCodes.Status200OK)]
        private async Task<IActionResult> DownloadBimDocumentAsync([FromBody] DownloadDocumentModel model)
        {
            try
            {
                var key = $"KEY_{model.DocumentId}";
    
                var (obj, job) = await _memoryCache.GetOrCreateAsync(key, 
                    async (entry) => 
                    {
                        // Cache
                        entry.AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(CACHE_EXPIRATION_DURATION);
                            
                        // Act 
                        var document = await _documentService.GetAsync(model.DocumentId, default);
                        var inputBytes = await _storageService.DownloadFileAsync(document.Url, default);
    
                        using var stream = new MemoryStream();            
                        stream.Write(inputBytes, 0, inputBytes.Length);
                            
                        var name = $"{document.Id}.{document.Type}".ToLower();
    
                        var obj = await _aps.UploadModel(name, stream);
                        var job = await _aps.TranslateModel(obj.ObjectId);
    
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