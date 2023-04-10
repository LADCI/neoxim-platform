using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Exceptions;
using Neoxim.Platform.Core.Helpers;

namespace Neoxim.Platform.Core.Services.Impl;

public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISystemClock _systemClock;

    public ProjectService(IUnitOfWork unitOfWork, ISystemClock systemClock)
    {
        _unitOfWork = unitOfWork;
        _systemClock = systemClock;
    }

    public async Task<ProjectModel> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectsRepository.GetAsync(id, cancellationToken,
            i => i.Tenant
        );
        return new ProjectModel(project);
    }

    public async Task<IEnumerable<ProjectModel>> GetListByTenantAsync(Guid tenantId, CancellationToken cancellationToken)
    {
        var projects = await _unitOfWork.ProjectsRepository.GetAllAsync(cancellationToken,
            i => i.Tenant
        );
        return projects.Select(x => new ProjectModel(x));
    }

    public async Task<ProjectModel> CreateAsync(string name, string description, Guid tenantId, ProjectTypeEnum projectType, ProjectConstructionTypeEnum constructionType, ProjectContractTypeEnum contactType, Amount amount, DateTimeOffset start, DateTimeOffset end, string customer)
    {
        var tenant = await _unitOfWork.TenantsRepository.GetAsync(tenantId, default);

        await CheckIfProjectAlreadyExists(name, tenantId);

        var project = Project.CreateNew(tenant, name, description, amount, projectType, constructionType, contactType, customer, start, end);

        await _unitOfWork.ProjectsRepository.CreateAsync(project);
        await _unitOfWork.SaveChangesAsync(default, project.Events.ToArray());

        return new ProjectModel(project);
    }

    private async Task CheckIfProjectAlreadyExists(string name, Guid tenantId)
    {
        var projects = await _unitOfWork.ProjectsRepository.GetAllAsync(x => x.Tenant.Id == tenantId, default, i => i.Tenant);
        if (projects.Any(x => x.Name.RemoveAccents().Equals(name.RemoveAccents(), StringComparison.OrdinalIgnoreCase)))
        {
            throw new ObjectAlreadyExistsException(name, nameof(Project));
        }
    }
}
