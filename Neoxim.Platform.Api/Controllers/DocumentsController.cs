using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Api.Constants;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : BaseApiController
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
        [Authorize(Policy = ClaimsConstant.Type.UPLOAD)]
        public async Task<IActionResult> PostAsync([FromBody] object createDocumentModel)
        {
            return Ok();
        }

        [HttpPatch("{documentId}", Name = "PatchDocumentAsync")]
        [Authorize(Policy = ClaimsConstant.Type.WRITE)]
        public async Task PutAsync(Guid documentId, [FromBody] object updateDocumentModel)
        {
            
        }

        [HttpDelete("{documentId}", Name = "DeleteDocumentAsync")]
        [Authorize(Policy = ClaimsConstant.Type.WRITE)]
        public async Task DeleteAsync(string documentId)
        {
            
        }
    }
}