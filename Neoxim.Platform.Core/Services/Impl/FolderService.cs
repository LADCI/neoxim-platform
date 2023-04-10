using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;

namespace Neoxim.Platform.Core.Services.Impl
{
    public class FolderService : IFolderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemClock _systemClock;

        public FolderService(IUnitOfWork unitOfWork, ISystemClock systemClock)
        {
            _unitOfWork = unitOfWork;
            _systemClock = systemClock;
        }

        public async Task<IEnumerable<FolderModel>> GetListByTenantAsync(Guid tenantId, bool asTree, CancellationToken cancellationToken)
        {
            var folders = await _unitOfWork.FoldersRepository.GetAllAsync(x => x.Tenant.Id == tenantId, cancellationToken,
                i => i.Tenant,
                i => i.Parent,
                i => i.Childs
            );

            var models = folders.OrderBy(x => x.Name).Select(x => new FolderModel(x));

            if(asTree)
            {
                var topLevelModels = models.Where(x => x.ParentId == null).ToList();
                topLevelModels.SelectMany(x => x.Childs.OrderBy(y => y.Name)).ToList().ForEach(x =>
                {
                    LoadChildren(x, models);
                });

                static void LoadChildren(FolderModel x, IEnumerable<FolderModel> models, int cpt = 0, int maxLevel = 10)
                {
                    if (!x.Childs.Any())
                    {
                        var children = models.Where(y => y.ParentId == x.Id).OrderBy(z => z.Name).ToList();
                        children.ForEach(y => {
                            if(cpt < maxLevel)
                            {
                                x.Childs.Add(y);
                                LoadChildren(y, children, ++cpt);
                            }
                        });
                        
                    }
                }

                return topLevelModels;
            }
            else
            {
                return models;
            }
        }

        public async Task<FolderModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var folder = await _unitOfWork.FoldersRepository.GetAsync(id, cancellationToken,
                i => i.Tenant,
                i => i.Parent,
                i => i.Childs 
            );
            return new FolderModel(folder);
        }

        public async Task<FolderModel> CreateAsync(string name, Guid tenantId, Guid? parentId)
        {
            var tenant = await _unitOfWork.TenantsRepository.GetAsync(tenantId, default);

            Folder? parent = null;
            if(parentId is not null)
                parent = await _unitOfWork.FoldersRepository.GetAsync(parentId.Value, default);

            var folder = Folder.CreateNew(name, tenant, parent);

            await _unitOfWork.FoldersRepository.CreateAsync(folder);

            await _unitOfWork.SaveChangesAsync(default, folder.Events.ToArray());

            return new FolderModel(folder);
        }
    }
}