using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Neoxim.Platform.Api.Constants;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.Infrastructure.Externals.Autodesk;

namespace Neoxim.Platform.Api.Controllers
{
    public record DownloadDocumentModel(Guid DocumentId);

    /// <summary>
    /// Documents
    /// </summary>
    [ApiController]
    [Route("api/documents")]
    public partial class DocumentsController : BaseApiController
    {
        private readonly APS _aps;
        private readonly IDocumentService _documentService;
        private readonly IStorageService _storageService;
        private readonly IMemoryCache _memoryCache;
        private readonly int CACHE_EXPIRATION_DURATION = 24;

        public DocumentsController(
            IDocumentService documentService, 
            IStorageService storageService,
            IMemoryCache memoryCache, 
            APS aps)
        {
            _documentService = documentService;
            _storageService = storageService;
            _memoryCache = memoryCache;
            _aps = aps; 
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("tenant/{tenantId}", Name = "GetDocumentsByTenantAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DocumentModel>))]
        public async Task<IActionResult> GetDocumentsForTenantAsync(Guid tenantId, CancellationToken cancellationToken)
        {
            var result = await _documentService.GetListByTenantAsync(tenantId, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Get documents by folder identifier
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("project/{projectId}", Name = "GetDocumentsByProjectAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DocumentModel>))]
        public async Task<IActionResult> GetDocumentsForProjectAsync(Guid projectId, CancellationToken cancellationToken)
        {
            var result = await _documentService.GetListByProjectAsync(projectId, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Get documents by folder identifier
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("folder/{folderId}", Name = "GetDocumentsByFolderAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DocumentModel>))]
        public async Task<IActionResult> GetDocumentsForFolderAsync(Guid folderId, CancellationToken cancellationToken)
        {
            var result = await _documentService.GetListByFolderAsync(folderId, cancellationToken);
            return Ok(result);
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
        /// Download document for a given type
        /// </summary>
        /// <returns></returns>
        [HttpPost("download/{documentType}")]
        [ProducesResponseType(typeof(Externals.BucketObject), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> DownloadDocumentAsync([FromRoute] DocumentTypeEnum documentType, [FromBody] DownloadDocumentModel model)
        {
            if(DocumentTypeEnum.IS_APS_MODELS.HasFlag(documentType))
            {
                return await DownloadBimDocumentAsync(model);
            }
            else
            {
                return await DownloadClassicDocumentAsync(model);
            }
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