using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class UserCfg : Cfg<User>
    {
        public UserCfg(): base("users")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            //...
            builder.Ignore(x => x.Events);

            builder.OwnsOne(x => x.Name, GetUserNameOwnedNavigationBuilder());
            builder.OwnsOne(x => x.Contact, GetContactOwnedNavigationBuilder());

            builder.HasMany(x => x.UsersInClaims).WithOne(x => x.User).HasForeignKey("user_id");
        }
    }
}