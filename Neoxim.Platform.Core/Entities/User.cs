using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class User : BaseAggregateEntity
    {
        protected User()
        {
        }

        public UserName Name { get; protected set; }
        public Contact Contact { get; protected set; }

        public Tenant Tenant { get; protected set; } = null!;
    }
}