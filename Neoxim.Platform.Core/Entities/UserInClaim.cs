using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class UserInClaim : BaseEntity
    {
        public User User { get; protected set; }
        public TenantClaim Claim { get; protected set; }

        public static UserInClaim CreateNew(User user, TenantClaim tenantClaim)
        {
            return new UserInClaim
            {
                User = user ?? throw new ArgumentNullException(nameof(user)),
                Claim = tenantClaim ?? throw new ArgumentNullException(nameof(tenantClaim))
            };
        }
    }
}