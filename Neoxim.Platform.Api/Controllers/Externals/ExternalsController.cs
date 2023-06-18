using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Infrastructure.Externals.Autodesk;

namespace Neoxim.Platform.Api.Controllers.Externals
{
    [ApiController]
    [Route("api/ext-providers")]
    public partial class ExternalsController : ControllerBase
    {
        private readonly APS _aps;
        public ExternalsController(APS aps)
        {
            _aps = aps;  
        }
    }
}