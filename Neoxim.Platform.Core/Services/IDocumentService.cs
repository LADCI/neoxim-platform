using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Models;

namespace Neoxim.Platform.Core.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentModel>> GetListByTenantAsync(Guid tenantId, bool asTree, CancellationToken cancellationToken);
        Task<DocumentModel> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<DocumentModel> CreateAsync(DocumentTypeEnum type, string title, string description, Guid tenantId, Guid projectId, Guid folderId);
        Task SetUrlAsync(Guid id, string url);
    }
}