using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class TenantCfg : Cfg<Tenant>
    {
        public TenantCfg(): base("tenants")
        {
        }

        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Ignore(x => x.Events);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Status).HasColumnName("status").HasConversion<string>().HasMaxLength(64).IsRequired();

            builder.OwnsOne(x => x.Contact, GetContactOwnedNavigationBuilder());

            builder.HasMany(x => x.Projects).WithOne(x => x.Tenant).HasForeignKey("tenant_id");
            builder.HasMany(x => x.Users).WithOne(x => x.Tenant).HasForeignKey("tenant_id");
            builder.HasMany(x => x.Subscriptions).WithOne(x => x.Tenant).HasForeignKey("tenant_id");
            builder.HasMany(x => x.Claims).WithOne(x => x.Tenant).HasForeignKey(x => x.TenantId).HasConstraintName("tenant_id");
            builder.HasMany(x => x.Folders).WithOne(x => x.Tenant).HasForeignKey("tenant_id");
            builder.HasMany(x => x.Documents).WithOne(x => x.Tenant).HasForeignKey("tenant_id");
        }
    }
}