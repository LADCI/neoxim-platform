using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Models
{
    public class TenantModel
    {
        public TenantModel()
        {
        }

        public TenantModel(Tenant entity)
        {
            if(entity is null) return;

            Id = entity.Id;
            CreationDate = entity.CreationDate;
            LastChangesDate = entity.LastChangesDate;
            Name = entity.Name;
            Contact = entity.Contact;
            Status = entity.Status;
            Claims = entity.Claims.OrderBy(x => x.Name).Select(x => new TenantClaimModel(x));
            HasActiveSubscription = entity.Subscriptions.Any(x => x.EndDate == null);
            Subscriptions = entity.Subscriptions.OrderByDescending(x => x.CreationDate).Select(x => new SubscriptionModel(x));
        }

        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset LastChangesDate { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public TenantStatusEnum Status { get; set; }
        public bool HasActiveSubscription { get; set; }
        public IEnumerable<TenantClaimModel> Claims { get; set; }
        public IEnumerable<SubscriptionModel> Subscriptions { get; set; }
    }

    public class CreateTenantModel
    {
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Amount SubscriptionUnitAmount { get; set; }
    }

    public class UpdateTenantModel
    {
        public string Name { get; set; }
        public Contact Contact { get; set; }

        public Amount SubscriptionUnitAmount { get; set; }
    }
}