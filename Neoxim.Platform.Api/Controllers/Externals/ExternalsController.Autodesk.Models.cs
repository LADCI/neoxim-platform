using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers.Externals
{
    /// <summary>
    /// Access Token
    /// </summary>
    /// <param name="access_token"></param>
    /// <param name="expires_in"></param> <summary>
    /// 
    /// </summary>
    /// <param name="access_token"></param>
    /// <param name="expires_in"></param>
    /// <returns></returns>
    public record AccessToken(string access_token, long expires_in);

    public record BucketObject(string name, string urn);

    public class UploadModelForm
    {
        [FromForm(Name = "model-zip-entrypoint")]
        public string? Entrypoint { get; set; }

        [FromForm(Name = "model-file")]
        public IFormFile File { get; set; }
    }
}