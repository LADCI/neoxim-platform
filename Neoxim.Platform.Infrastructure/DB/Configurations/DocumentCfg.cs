using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class DocumentCfg : Cfg<Document>
    {
        public DocumentCfg(): base("documents")
        {
        }

        public override void Configure(EntityTypeBuilder<Document> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => new {x.Title}).IsUnique(false);

            builder.Ignore(x => x.Events);

            //...
            builder.Property(x => x.Title).HasColumnName("name").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text").IsRequired();
            builder.Property(x => x.Url).HasColumnName("url").HasMaxLength(512).IsRequired();
            builder.Property(x => x.Type).HasConversion<string>().HasColumnName("type").HasMaxLength(128).IsRequired();
        }
    }
}