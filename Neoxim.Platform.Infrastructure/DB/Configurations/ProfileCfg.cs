using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class ProfileCfg : Cfg<Profile>
    {
        public ProfileCfg(): base("profiles")
        {
        }

        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text").IsRequired();

            builder.HasMany(x => x.FoldersInProfiles).WithOne(x => x.Profile).HasForeignKey("profile_id").IsRequired(false);

            builder.HasMany(x => x.UsersInProfiles).WithOne(x => x.Profile).HasForeignKey("profile_id");
        }
    }

    public class UserInProfileCfg : Cfg<UserInProfile>
    {
        public UserInProfileCfg(): base("users_in_profiles")
        {
        }

        public override void Configure(EntityTypeBuilder<UserInProfile> builder)
        {
            base.Configure(builder);

            //...
        }
    }

    public class FolderInProfileCfg : Cfg<FolderInProfile>
    {
        public FolderInProfileCfg(): base("folders_in_profiles")
        {
        }

        public override void Configure(EntityTypeBuilder<FolderInProfile> builder)
        {
            base.Configure(builder);

            //...
        }
    }
}