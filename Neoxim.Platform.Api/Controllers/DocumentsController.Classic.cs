using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers
{
    public partial class DocumentsController
    {
        /// <summary>
        /// Download document bucket (urn) for visualization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> <summary>
        //[HttpPost("download/classic")]
        //[ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        private async Task<IActionResult> DownloadClassicDocumentAsync([FromBody] DownloadDocumentModel model)
        {
            try
            {
                var key = $"KEY_{model.DocumentId}";
    
                var (fileContents, documentType) = await _memoryCache.GetOrCreateAsync(key, 
                    async (entry) => 
                    {
                        // Cache
                        entry.AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(CACHE_EXPIRATION_DURATION);
                            
                        // Act 
                        var document = await _documentService.GetAsync(model.DocumentId, default);
                        var inputBytes = await _storageService.DownloadFileAsync(document.Url, default);
    
                        return (inputBytes, $"application/{document.Type}".ToLower());      
                    }
                );
    
                return Ok(new FileContentResult(fileContents, documentType));
            }
            catch (ObjectNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}