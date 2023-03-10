using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class Tenant : BaseAggregateEntity
    {
        protected Tenant()
        {
            Projects = new List<Project>();
            Users = new List<User>();
            Subscriptions = new List<Subscription>();
            Claims = new List<TenantClaim>();
        }

        public static Tenant CreateNew(string name, Contact contact)
        {
            var tenant = new Tenant();

            tenant.SetName(name);
            tenant.SetContact(contact);
            tenant.SetStatus(TenantStatusEnum.CREATED);

            return tenant;
        }

        public string Name { get; protected set; }
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public TenantStatusEnum Status { get; protected set; }
        public void SetStatus(TenantStatusEnum status)
        {
            Status = status;
        }

        public Contact Contact { get; protected set; }
        public void SetContact(Contact contact)
        {
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public ICollection<Project> Projects { get; protected set; } = null!;
        public ICollection<User> Users { get; protected set; } = null!;

        public ICollection<TenantClaim> Claims { get; protected set; } = null!;
        public void AddClaim(TenantClaim claim)
        {
            claim.SetTenant(this);
            Claims.Add(claim ?? throw new ArgumentNullException(nameof(claim)));
        }

        public ICollection<Subscription> Subscriptions { get; protected set; } = null!;
        public void AddSubscription(Subscription subscription)
        {
            subscription.SetTenant(this);
            Subscriptions.Add(subscription ?? throw new ArgumentNullException(nameof(subscription)));
        }

        //
        public ICollection<Folder> Folders { get; protected set; } = null!;
        public ICollection<Document> Documents { get; protected set; } = null!;
    }
}