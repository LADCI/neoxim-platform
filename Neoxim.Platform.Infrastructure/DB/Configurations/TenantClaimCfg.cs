using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class TenantClaimCfg : Cfg<TenantClaim>
    {
        public TenantClaimCfg(): base("tenant_claims")
        {
        }

        public override void Configure(EntityTypeBuilder<TenantClaim> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => new {x.Name, x.TenantId}, "IX_tenant_claims_name_tenant_id").IsUnique(true);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(256).IsRequired();
            builder.Property(x => x.TenantId).HasColumnName("tenant_id").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text").IsRequired();

            builder.HasMany(x => x.FoldersInClaims).WithOne(x => x.Claim).HasForeignKey("claim_id").IsRequired();
            builder.HasMany(x => x.UsersInClaims).WithOne(x => x.Claim).HasForeignKey("claim_id").IsRequired();
        }
    }
}