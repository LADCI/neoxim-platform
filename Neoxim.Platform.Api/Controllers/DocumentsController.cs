using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        [HttpGet("{documentId}", Name = "GetDocumentAsync")]
        public async Task<IActionResult> GetAsync(Guid documentId)
        {
            return Ok();
        }

        [HttpGet("tenant/{tenantId}", Name = "GetDocumentsByTenantAsync")]
        public async Task<IActionResult> GetDocumentsForTenantAsync(Guid tenantId)
        {
            return Ok();
        }

        [HttpGet("folder/{folderId}", Name = "GetDocumentsByFolderAsync")]
        public async Task<IActionResult> GetDocumentsForFolderAsync(Guid folderId)
        {
            return Ok();
        }

        [HttpPost("", Name = "PostDocumentAsync")]
        public async Task<IActionResult> PostAsync([FromBody] object createDocumentModel)
        {
            return Ok();    
        }

        [HttpPatch("{documentId}", Name = "PatchDocumentAsync")]
        public async Task PutAsync(Guid documentId, [FromBody] object updateDocumentModel)
        {
            
        }

        [HttpDelete("{documentId}", Name = "DeleteDocumentAsync")]
        public async Task DeleteAsync(string documentId)
        {
            
        }
    }
}