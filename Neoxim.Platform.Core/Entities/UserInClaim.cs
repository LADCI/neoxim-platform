using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class UserInClaim : BaseEntity
    {
        public User User { get; protected set; }
        public TenantClaim Claim { get; protected set; }
    }
}