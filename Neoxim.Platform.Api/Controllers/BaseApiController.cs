using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Api.Constants;

namespace Neoxim.Platform.Api.Controllers
{
    /// <summary>
    /// Ctor.
    /// </summary>
    [ApiController]
    [Authorize(Policy = ClaimsConstant.Type.SUBSCRIPTION_ACTIVE)]
    [Authorize(Policy = ClaimsConstant.Type.READ)]
    public abstract class BaseApiController : ControllerBase
    {
    }
}