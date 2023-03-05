using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet("{userId}", Name = "GetUserAsync")]
        public async Task<IActionResult> GetAsync(Guid userId)
        {
            return Ok();
        }

        [HttpGet("tenant/{tenantId}", Name = "GetUsersByTenantAsync")]
        public async Task<IActionResult> GetUsersByTenantAsync(Guid tenantId)
        {
            return Ok();
        }
    }
}