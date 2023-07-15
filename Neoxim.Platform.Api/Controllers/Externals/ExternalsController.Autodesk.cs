using Autodesk.Forge.Client;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Infrastructure.Externals.Autodesk;

namespace Neoxim.Platform.Api.Controllers.Externals
{
    public record AccessToken(string access_token, long expires_in);
    public record BucketObject(string name, string urn);

    public partial class ExternalsController
    {
        /// <summary>
        /// APS - Get access token
        /// </summary>
        /// <returns></returns>
        [HttpGet("aps/auth/token")]
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
        [HttpGet("aps/models")]
        [ProducesResponseType(typeof(IEnumerable<BucketObject>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetModelsAsync()
        {
            var objects = await _aps.GetObjectsAsync();
            var result = objects.Select(o => new BucketObject(o.ObjectKey, APS.Base64Encode(o.ObjectId)));
            return Ok(result);
        }

        /// <summary>
        /// Get document translation status
        /// </summary>
        /// <param name="urn"></param>
        /// <returns></returns>
        [HttpGet("aps/models/{urn}/status")]
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

        /// <summary>
        /// Upload model - for test only
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns> <summary>
        [HttpPost("aps/models")]
        [ProducesResponseType(typeof(BucketObject), StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadAndTranslateModelAsync([FromForm] IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;
            var obj = await _aps.UploadModel(file.FileName, stream);
            var job = await _aps.TranslateModel(obj.ObjectId);

            return Ok(new BucketObject(obj.ObjectKey, job.Urn));
        }
    }
}