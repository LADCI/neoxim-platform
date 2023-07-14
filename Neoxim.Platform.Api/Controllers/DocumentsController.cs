using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Api.Constants;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.Services;

namespace Neoxim.Platform.Api.Controllers
{
    /// <summary>
    /// Documents
    /// </summary>
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : BaseApiController
    {
        private readonly IDocumentService _documentService;
        private readonly IStorageService _storageService;

        public DocumentsController(IDocumentService documentService, IStorageService storageService)
        {
            _documentService = documentService;
            _storageService = storageService;
        }


        /// <summary>
        /// Get document by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetDocumentAsync")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var document = await _documentService.GetAsync(id, cancellationToken);

            return Ok(document);
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
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("", Name = "PostDocumentAsync")]
        [Authorize(Policy = ClaimsConstant.Type.UPLOAD)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentModel))]
        public async Task<IActionResult> PostAsync([FromForm] CreateDocumentModel model, IFormFile file)
        {
            var fs = file.OpenReadStream();

            var media = await _documentService.CreateAsync( model.Type, model.Name, model.Description ?? file.FileName, model.TenantId, model.ProjectId, model.FolderId);

            var url = await _storageService.UploadFileAsync(media.TenantId, media.Id, model.Type.ToString(), fs);

            media.Url = url;

            await _documentService.SetUrlAsync(media.Id, url);

            return Ok(media);
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