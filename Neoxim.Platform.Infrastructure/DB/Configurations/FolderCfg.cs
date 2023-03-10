using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class FolderCfg : Cfg<Folder>
    {
        public FolderCfg(): base("folders")
        {
        }

        public override void Configure(EntityTypeBuilder<Folder> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Ignore(x => x.Events);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(128).IsRequired();

            builder.HasMany(x => x.Childs).WithOne(x => x.Parent).HasForeignKey("parent_id").IsRequired(false);

            builder.HasMany(x => x.Documents).WithOne(x => x.Folder).HasForeignKey("folder_id");
            builder.HasMany(x => x.FoldersInClaims).WithOne(x => x.Folder).HasForeignKey("folder_id");
        }
    }
}