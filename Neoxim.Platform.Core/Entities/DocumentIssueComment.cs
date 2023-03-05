using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class DocumentIssueComment : BaseEntity
    {
        protected DocumentIssueComment()
        {
        }

        public static DocumentIssueComment CreateNew(Guid authorId, DocumentIssue issue, string text)
        {
            return new DocumentIssueComment
            {
                AuthorId = authorId,
                Issue = issue,
                Text = text ?? throw new ArgumentNullException(nameof(text))
            };
        }

        public string Text { get; set; }

        public DocumentIssue Issue { get; set; }

        public Guid AuthorId { get; set; }
    }
}