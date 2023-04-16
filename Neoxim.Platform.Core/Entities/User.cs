using Neoxim.Platform.Core.Events;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class User : BaseAggregateEntity
    {
        protected User()
        {
            UsersInClaims = new List<UserInClaim>();
        }

        public static User CreateNew(UserName userName, Contact contact, Tenant tenant, List<TenantClaim> claims)
        {
            var user = new User
            {
                Name = userName,
                Contact = contact,
                Tenant = tenant
            };

            claims?.ForEach(claim => user.UsersInClaims.Add(UserInClaim.CreateNew(user, claim)));

            user.Events.Add(new CreatedEvent(Enums.EventSourceEnum.USER, user));

            return user;
        }

        public UserName Name { get; protected set; }
        public Contact Contact { get; protected set; }

        public Tenant Tenant { get; protected set; }
        public ICollection<UserInClaim> UsersInClaims { get; protected set; }
    }
}