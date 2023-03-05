using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class DocumentIssueCommentCfg : Cfg<DocumentIssueComment>
    {
        public DocumentIssueCommentCfg(): base("document_issue_comments")
        {
        }

        public override void Configure(EntityTypeBuilder<DocumentIssueComment> builder)
        {
            base.Configure(builder);

            //...
            builder.HasIndex(x => x.AuthorId).IsUnique(false);

            builder.Property(x => x.Text).HasColumnName("text").HasColumnType("text").IsRequired();
            builder.Property(x => x.AuthorId).HasColumnName("author_id").IsRequired();
        }
    }
}