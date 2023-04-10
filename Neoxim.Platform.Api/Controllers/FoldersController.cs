using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/folders")]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FoldersController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        /// <summary>
        /// Get folder by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetFolderAsync")]
        [ProducesResponseType(typeof(FolderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _folderService.GetAsync(id, cancellationToken);
                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Error);
            }
        }

        [HttpGet("tenant/{tenantId}", Name = "GetFoldersByTenantAsync")]
        [ProducesResponseType(typeof(IEnumerable<FolderModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFoldersForTenantAsync(Guid tenantId, [FromQuery] bool asTree, CancellationToken cancellationToken)
        {
            var result = await _folderService.GetListByTenantAsync(tenantId, asTree, cancellationToken);
            return Ok(result);
        }

        [HttpPost("", Name = "PostFolderAsync")]
        [ProducesResponseType(typeof(FolderModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync([FromBody] CreateFolderModel model)
        {
            var result = await _folderService.CreateAsync(model.Name, model.TenantId, model.ParentId);
            return Ok(result);
        }
    }
}