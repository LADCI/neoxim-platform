using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class User : BaseAggregateEntity
    {
        protected User()
        {
        }

        public static User CreateNew(UserName userName, Contact contact, Tenant tenant)
        {
            var user = new User
            {
                Name = userName,
                Contact = contact,
                Tenant = tenant
            };

            return user;
        }

        public UserName Name { get; protected set; }
        public Contact Contact { get; protected set; }

        public Tenant Tenant { get; protected set; }
        public ICollection<UserInClaim> UsersInClaims { get; protected set; }
    }
}