using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet("{projectId}", Name = "GetProjectAsync")]
        public async Task<IActionResult> GetAsync(Guid projectId)
        {
            return Ok();
        }

        [HttpGet("tenant/{tenantId}", Name = "GetProjectsByTenantAsync")]
        public async Task<IActionResult> GetProjectsByTenantAsync(Guid tenantId)
        {
            return Ok();
        }
    }
}