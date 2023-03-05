using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Authorize(Policy = "ActiveSubscription")]
    public abstract class BaseApiController : ControllerBase
    {
        
    }
}