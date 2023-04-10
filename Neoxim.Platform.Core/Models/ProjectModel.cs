using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Models
{
    public class ProjectModel
    {
        public ProjectModel()
        {
        }

        public ProjectModel(Project entity)
        {
            if(entity == null) return;

            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Type = entity.Type;
            ConstructionType = entity.ConstructionType;
            ContractType = entity.ContractType;
            Amount = entity.Amount;
            StartDate = entity.StartDate;
            EndDate = entity.EndDate;
            Customer = entity.Customer;
            TenantId = entity.Tenant.Id;
        }

        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public ProjectTypeEnum Type { get;  set; }
        public ProjectConstructionTypeEnum ConstructionType { get;  set; }
        public ProjectContractTypeEnum ContractType { get;  set; }
        public Amount Amount { get;  set; }
        public DateTimeOffset StartDate { get;  set; }
        public DateTimeOffset EndDate { get;  set; }
        public string Customer { get;  set; }
        public Guid TenantId { get;  set; }
        //public ICollection<Document> Documents { get;  set; }
    }

    public class CreateProjectModel
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public ProjectTypeEnum Type { get;  set; }
        public ProjectConstructionTypeEnum ConstructionType { get;  set; }
        public ProjectContractTypeEnum ContractType { get;  set; }
        public Amount Amount { get;  set; }
        public DateTimeOffset StartDate { get;  set; }
        public DateTimeOffset EndDate { get;  set; }
        public string Customer { get;  set; }
        public Guid TenantId { get;  set; }
    }

    public class UpdateProjectModel : CreateFolderModel
    {
    }
}