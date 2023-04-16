using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers
{
    /// <summary>
    /// Users
    /// </summary>
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : BaseApiController
    {
        private readonly IProjectService _projectService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="projectService"></param>
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Get project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProjectAsync")]
        [ProducesResponseType(typeof(ProjectModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _projectService.GetAsync(id, cancellationToken);
                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Error);
            }
        }

        /// <summary>
        /// Get projects for a tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("tenant/{tenantId}", Name = "GetProjectsByTenantAsync")]
        [ProducesResponseType(typeof(IEnumerable<ProjectModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProjectsByTenantAsync(Guid tenantId, CancellationToken cancellationToken)
        {
            var result = await _projectService.GetListByTenantAsync(tenantId, cancellationToken);
            return Ok(result);
        }


        /// <summary>
        /// Create new project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("", Name = "PostProjectAsync")]
        [ProducesResponseType(typeof(ProjectModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] CreateProjectModel model)
        {
            try
            {
                var result = await _projectService.CreateAsync(
                    model.Name,
                    model.Description,
                    model.TenantId,
                    model.Type,
                    model.ConstructionType,
                    model.ContractType,
                    model.Amount,
                    model.StartDate,
                    model.EndDate,
                    model.Customer
                );

                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return BadRequest(ex.Error);
            }
            catch(ObjectAlreadyExistsException ex)
            {
                return BadRequest(ex.Error);
            }
        }

        /// <summary>
        /// Update project information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}", Name = "PatchProjectAsync")]
        public async Task<IActionResult> PatchAsync(Guid id, [FromBody] UpdateProjectModel model)
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
        /// Delete a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteProjectAsync")]
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