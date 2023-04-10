using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Services;

public interface IProjectService
{
    Task<ProjectModel> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<ProjectModel>> GetListByTenantAsync(Guid tenantId, CancellationToken cancellationToken);

    Task<ProjectModel> CreateAsync(
        string name,
        string description,
        Guid tenantId,
        ProjectTypeEnum projectType,
        ProjectConstructionTypeEnum constructionType,
        ProjectContractTypeEnum contactType,
        Amount amount,
        DateTimeOffset start,
        DateTimeOffset end,
        string customer
    );
}
