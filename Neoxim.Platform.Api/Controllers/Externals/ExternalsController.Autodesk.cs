using Autodesk.Forge.Client;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Infrastructure.Externals.Autodesk;

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

        [HttpPost("autodesk-forge/models")]
        [ProducesResponseType(typeof(BucketObject), StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadAndTranslateModelAsync([FromForm] UploadModelForm form)
        {
            using var stream = new MemoryStream();
            await form.File.CopyToAsync(stream);
            stream.Position = 0;
            var obj = await _aps.UploadModel(form.File.FileName, stream);
            var job = await _aps.TranslateModel(obj.ObjectId, form.Entrypoint);
            return Ok(new BucketObject(obj.ObjectKey, job.Urn));
        }
    }
}