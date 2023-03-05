using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Events;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public sealed class Project : BaseAggregateEntity
    {
        protected Project()
        {
            Documents = new List<Document>();
        }

        public static Project CreateNew(
            Tenant tenant,
            string name,
            string description,
            ProjectTypeEnum type,
            ProjectConstructionTypeEnum constructionType,
            ProjectContractTypeEnum contractType,
            string customer,
            DateTimeOffset start,
            DateTimeOffset end)
        {
            var project = new Project();

            project.SetTenant(tenant);
            project.SetName(name);
            project.SetDescription(description);
            project.SetType(type);
            project.SetConstructionType(constructionType);
            project.SetContractType(contractType);
            project.SetCustomer(customer);
            project.SetStartDate(start);
            project.SetEndDate(end);

            project.Events.Add(new CreatedEvent(Enums.EventSourceEnum.PROJECT, project));

            return project;
        }

        public string Name { get; protected set; }
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Description { get; protected set; }
        public void SetDescription(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public ProjectTypeEnum Type { get; protected set; }
        public void SetType(ProjectTypeEnum type)
        {
            Type = type;
        }

        public ProjectConstructionTypeEnum ConstructionType { get; protected set; }
        public void SetConstructionType(ProjectConstructionTypeEnum constructionType)
        {
            ConstructionType = constructionType;
        }

        public ProjectContractTypeEnum ContractType { get; protected set; }
        public void SetContractType(ProjectContractTypeEnum contractType)
        {
            ContractType = contractType;
        }
        public Amount Amount { get; protected set; }
        public void SetAmount(Amount amount)
        {
            Amount = amount;
        }

        public DateTimeOffset StartDate { get; protected set; }
        public void SetStartDate(DateTimeOffset startDate)
        {
            if(startDate >= EndDate)
                throw new ArgumentException("Start date must be less than start date.");

            StartDate = startDate;
        }

        public DateTimeOffset EndDate { get; protected set; }
        public void SetEndDate(DateTimeOffset endDate)
        {
            if(endDate <= StartDate)
                throw new ArgumentException("End date must be greater than start date.");

            EndDate = endDate;
        }

        public string Customer { get; protected set; }
        public void SetCustomer(string customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public Tenant Tenant { get; protected set; }
        public void SetTenant(Tenant tenant)
        {
            Tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
        }

        public ICollection<Document> Documents { get; protected set; }
        public void AddDocument(Document document)
        {
            if(document is null)
                return;

            Documents.Add(document);
        }
    }
}