using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/folders")]
    public class FoldersController : ControllerBase
    {
        [HttpGet("{folderId}", Name = "GetFolderAsync")]
        public async Task<IActionResult> GetAsync(Guid folderId)
        {
            return Ok();
        }

        [HttpGet("tenant/{tenantId}", Name = "GetFoldersByTenantAsync")]
        public async Task<IActionResult> GetFoldersForTenantAsync(Guid tenantId)
        {
            return Ok();
        }
    }
}