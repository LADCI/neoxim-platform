using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class DocumentIssueCfg : Cfg<DocumentIssue>
    {
        public DocumentIssueCfg(): base("document_issues")
        {
        }

        public override void Configure(EntityTypeBuilder<DocumentIssue> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => x.Name).IsUnique();

            //...
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text").IsRequired();
            builder.Property(x => x.SnapshotImageUrl).HasColumnName("snapshot").IsRequired();

            builder.HasMany(x => x.Comments).WithOne(x => x.Issue).HasForeignKey("issue_id");
        }
    }
}