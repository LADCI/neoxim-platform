using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Api.Constants;

namespace Neoxim.Platform.Api.Controllers
{
    /// <summary>
    /// Documents
    /// </summary>
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : BaseApiController
    {
        /// <summary>
        /// Get document by id
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        [HttpGet("{documentId}", Name = "GetDocumentAsync")]
        public async Task<IActionResult> GetAsync(Guid documentId)
        {
            return Ok();
        }

        /// <summary>
        /// Get documents by tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        [HttpGet("tenant/{tenantId}", Name = "GetDocumentsByTenantAsync")]
        public async Task<IActionResult> GetDocumentsForTenantAsync(Guid tenantId)
        {
            return Ok();
        }

        /// <summary>
        /// Get documents by folder identifier
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns></returns>
        [HttpGet("folder/{folderId}", Name = "GetDocumentsByFolderAsync")]
        public async Task<IActionResult> GetDocumentsForFolderAsync(Guid folderId)
        {
            return Ok();
        }

        /// <summary>
        /// Create new document
        /// </summary>
        /// <param name="createDocumentModel"></param>
        /// <returns></returns>
        [HttpPost("", Name = "PostDocumentAsync")]
        [Authorize(Policy = ClaimsConstant.Type.UPLOAD)]
        public async Task<IActionResult> PostAsync([FromBody] object createDocumentModel)
        {
            return Ok();
        }

        /// <summary>
        /// Update document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="updateDocumentModel"></param>
        /// <returns></returns>
        [HttpPatch("{documentId}", Name = "PatchDocumentAsync")]
        [Authorize(Policy = ClaimsConstant.Type.WRITE)]
        public async Task<IActionResult> PutAsync(Guid documentId, [FromBody] object updateDocumentModel)
        {
            return Ok();
        }

        /// <summary>
        /// Delete document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        [HttpDelete("{documentId}", Name = "DeleteDocumentAsync")]
        [Authorize(Policy = ClaimsConstant.Type.WRITE)]
        public async Task<IActionResult> DeleteAsync(string documentId)
        {
            return Ok();
        }
    }
}