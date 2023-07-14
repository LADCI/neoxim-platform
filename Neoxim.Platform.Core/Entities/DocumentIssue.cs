using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class DocumentIssue : BaseEntity
    {
        protected DocumentIssue()
        {
            Comments = new List<DocumentIssueComment>();
        }

        public static DocumentIssue CreateNew(Document document, string name, string description, string imageUrl)
        {
            var issue = new DocumentIssue
            {
                Document = document
            };

            issue.SetName(name);
            issue.SetDescription(description);
            issue.SetSnapshotImage(imageUrl);

            return issue;
        }

        public string Name { get; protected set; }
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Description { get; protected set; }
        public void SetDescription(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string SnapshotImageUrl { get; set; }
        private void SetSnapshotImage(string image)
        {
            SnapshotImageUrl = image;
        }

        public Document Document { get; set; }

        public ICollection<DocumentIssueComment> Comments { get; set; }
        public void AddComment(DocumentIssueComment comment)
        {
            Comments.Add(comment ?? throw new ArgumentNullException(nameof(comment)));
        }
    }
}