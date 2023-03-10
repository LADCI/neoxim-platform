
using Neoxim.Platform.Core.Entities;

namespace Neoxim.Platform.Core.Models
{
    public class FolderModel
    {
        public FolderModel()
        {
        }

        public FolderModel(Folder entity)
        {
            if(entity is null) return;

            Id = entity.Id;
            Name = entity.Name;
            TenantId = entity.Tenant?.Id ?? entity.Parent?.Tenant.Id;

            ParentId = entity.Parent?.Id;
            Childs = entity.Childs?.Select(x => new FolderModel(x)).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? TenantId { get; set; }

        public ICollection<FolderModel>? Childs { get; set; }
    }

    public class CreateFolderModel
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public Guid TenantId { get; set; }
    }

    public class UpdateFolderModel
    {
        public string Name { get; set; }

        public Guid TenantId { get; set; }
    }
}