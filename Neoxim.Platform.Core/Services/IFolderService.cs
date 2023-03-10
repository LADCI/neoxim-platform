using Neoxim.Platform.Core.Models;

namespace Neoxim.Platform.Core.Services
{
    public interface IFolderService
    {
        Task<IEnumerable<FolderModel>> GetListByTenantAsync(Guid tenantId, bool asTree, CancellationToken cancellationToken);
        Task<FolderModel> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<FolderModel> CreateAsync(string name, Guid tenantId, Guid? parentId);
    }
}