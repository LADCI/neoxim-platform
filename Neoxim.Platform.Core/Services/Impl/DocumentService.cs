using Microsoft.EntityFrameworkCore;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;

namespace Neoxim.Platform.Core.Services.Impl
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DocumentModel> CreateAsync(DocumentTypeEnum type, string title, string description, Guid tenantId, Guid projectId, Guid folderId)
        {
            var tenant = await _unitOfWork.TenantsRepository.GetAsync(tenantId, 
                includes: (query) => query
                    .Include(x => x.Projects)
                    .Include(x => x.Folders),
                default
            );
            var project = tenant.Projects.Single(p => p.Id == projectId);
            var folder = tenant.Folders.Single(p => p.Id == folderId);

            var document = Document.CreateNew(type, title, description, tenant, project, folder);

            await _unitOfWork.DocumentsRepository.CreateAsync(document);

            await _unitOfWork.SaveChangesAsync(default);

            return new DocumentModel(document, tenantId, projectId, folderId);
        }

        public async Task<DocumentModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var document = await _unitOfWork.DocumentsRepository.GetAsync(id, 
                includes: (query) => query
                    .Include(x => x.Tenant)
                    .Include(x => x.Project)
                    .Include(x => x.Folder)
                , default
            );

            return new DocumentModel(document, document.Tenant.Id, document.Project.Id, document.Folder.Id);
        }


        public async Task<IEnumerable<DocumentModel>> GetListByTenantAsync(Guid tenantId, CancellationToken cancellationToken)
        {
            var documents = await _unitOfWork.DocumentsRepository.GetAllAsync(x => x.Tenant.Id == tenantId, 
                includes: (query) => query
                    .Include(x => x.Tenant)
                    .Include(x => x.Project)
                    .Include(x => x.Folder)
                , default
            );

            return documents.Select(x => new DocumentModel(x, x.Tenant.Id, x.Project.Id, x.Folder.Id));
        }
        public async Task<IEnumerable<DocumentModel>> GetListByFolderAsync(Guid folderId, CancellationToken cancellationToken)
        {
            var documents = await _unitOfWork.DocumentsRepository.GetAllAsync(x => x.Folder.Id == folderId, 
                includes: (query) => query
                    .Include(x => x.Tenant)
                    .Include(x => x.Project)
                    .Include(x => x.Folder)
                , default
            );

            return documents.Select(x => new DocumentModel(x, x.Tenant.Id, x.Project.Id, x.Folder.Id));
        }

        public async Task<IEnumerable<DocumentModel>> GetListByProjectAsync(Guid projectId, CancellationToken cancellationToken)
        {
            var documents = await _unitOfWork.DocumentsRepository.GetAllAsync(x => x.Project.Id == projectId, 
                includes: (query) => query
                    .Include(x => x.Tenant)
                    .Include(x => x.Project)
                    .Include(x => x.Folder)
                , default
            );

            return documents.Select(x => new DocumentModel(x, x.Tenant.Id, x.Project.Id, x.Folder.Id));
        }

        public async Task SetUrlAsync(Guid id, string url)
        {
            var document = await _unitOfWork.DocumentsRepository.GetAsync(id, default);
            document.SetUrl(url);

            await _unitOfWork.DocumentsRepository.UpdateAsync(document);
            
            await _unitOfWork.SaveChangesAsync(default, document.Events.ToArray());
        }
    }
}