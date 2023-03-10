using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class SubscriptionCfg : Cfg<Subscription>
    {
        public SubscriptionCfg(): base("subscriptions")
        {
        }

        public override void Configure(EntityTypeBuilder<Subscription> builder)
        {
            base.Configure(builder);

            //...
            builder.OwnsOne(x => x.UnitAmount, GetAmountOwnedNavigationBuilder());

            builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(x => x.EndDate).HasColumnName("end_date").IsRequired(false);
        }
    }
}