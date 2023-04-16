using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers
{
    /// <summary>
    /// Tenant Controllers
    /// </summary>
    [ApiController]
    [Route("api/tenants")]
    public class TenantsController : BaseApiController
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

        /// <summary>
        /// Get all tenants
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("", Name = "GetAllTenantAsync")]
        [ProducesResponseType(typeof(IEnumerable<TenantModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _tenantService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Get tenant by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTenantAsync")]
        [ProducesResponseType(typeof(TenantModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _tenantService.GetAsync(id, cancellationToken);
                return Ok(result);
            }
            catch(ObjectNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create new tenant
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("", Name = "PostTenantAsync")]
        [ProducesResponseType(typeof(TenantModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] CreateTenantModel model)
        {
            try
            {
                var result = await _tenantService.CreateAsync(model.Name, new Contact(model.Contact.Email, model.Contact.Phone, model.Contact.Address), model.SubscriptionUnitAmount);
                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return BadRequest(ex.Error);
            }
        }

        /// <summary>
        /// Update tenant information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}", Name = "PatchTenantAsync")]
        public async Task<IActionResult> PatchAsync(Guid id, [FromBody] UpdateTenantModel model)
        {
            try
            {
                //var result = await _tenantService.GetAsync(id, cancellationToken);
                return Ok();
            }
            catch(ObjectNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a tenant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteTenantAsync")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                //var result = await _tenantService.GetAsync(id, cancellationToken);
                return Ok();
            }
            catch(ObjectNotFoundException)
            {
                return NotFound();
            }
        }
    }
}