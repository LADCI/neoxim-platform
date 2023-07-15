using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Models;

namespace Neoxim.Platform.Core.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentModel>> GetListByTenantAsync(Guid tenantId, CancellationToken cancellationToken);
        Task<IEnumerable<DocumentModel>> GetListByProjectAsync(Guid projectId, CancellationToken cancellationToken);
        Task<IEnumerable<DocumentModel>> GetListByFolderAsync(Guid folderId, CancellationToken cancellationToken);
        Task<DocumentModel> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<DocumentModel> CreateAsync(DocumentTypeEnum type, string title, string description, Guid tenantId, Guid projectId, Guid folderId);
        Task SetUrlAsync(Guid id, string url);
    }
}