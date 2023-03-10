using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class UserInClaimCfg : Cfg<UserInClaim>
    {
        public UserInClaimCfg(): base("users_in_claims")
        {
        }

        public override void Configure(EntityTypeBuilder<UserInClaim> builder)
        {
            base.Configure(builder);

            //...
        }
    }
}