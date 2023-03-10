using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class FolderInClaimCfg : Cfg<FolderInClaim>
    {
        public FolderInClaimCfg(): base("folders_in_claims")
        {
        }

        public override void Configure(EntityTypeBuilder<FolderInClaim> builder)
        {
            base.Configure(builder);

            //...
        }
    }
}