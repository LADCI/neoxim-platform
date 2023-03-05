using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    public class SubscriptionsController : ControllerBase
    {
        [HttpGet("{subscriptionId}", Name = "GetSubscriptionAsync")]
        public async Task<IActionResult> GetAsync(Guid subscriptionId)
        {
            return Ok();
        }

        [HttpGet("tenant/{tenantId}", Name = "GetSubscriptionsByTenantAsync")]
        public async Task<IActionResult> GetSubscriptionsByTenantAsync(Guid tenantId)
        {
            return Ok();
        }
    }
}