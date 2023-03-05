using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Core.Services;

namespace Neoxim.Platform.Api.Controllers
{
    [ApiController]
    [Route("api/tenants")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="tenantService"></param>
        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }


        [HttpGet("", Name = "GetAllTenantAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok();
        }

        [HttpGet("{tenantId}", Name = "GetTenantAsync")]
        public async Task<IActionResult> GetAsync(Guid tenantId)
        {
            return Ok();
        }

        [HttpPost("", Name = "PostTenantAsync")]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            return Ok();
        }

        [HttpPatch("{tenantId}", Name = "PatchTenantAsync")]
        public async Task PatchAsync(Guid tenantId, [FromBody] object updateModel)
        {
            
        }

        [HttpDelete("{tenantId}", Name = "DeleteTenantAsync")]
        public async Task DeleteAsync(Guid tenantId)
        {
            
        }
    }
}