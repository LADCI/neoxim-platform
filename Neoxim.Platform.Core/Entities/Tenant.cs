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
        }

        public static Tenant CreateNew(string name, Contact contact)
        {
            var tenant = new Tenant();

            tenant.SetName(name);
            tenant.SetContact(contact);

            return tenant;
        }

        public string Name { get; protected set; }
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Contact Contact { get; protected set; }
        public void SetContact(Contact contact)
        {
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public ICollection<Project> Projects { get; protected set; } = null!;
        public ICollection<User> Users { get; protected set; } = null!;

        public ICollection<Subscription> Subscriptions { get; protected set; } = null!;
        public void AddSubscription(Subscription subscription)
        {
            Subscriptions.Add(subscription ?? throw new ArgumentNullException(nameof(subscription)));
        }
    }
}