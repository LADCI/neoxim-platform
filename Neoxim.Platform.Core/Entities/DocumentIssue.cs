using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class DocumentIssue : BaseEntity
    {
        protected DocumentIssue()
        {
            Comments = new List<DocumentIssueComment>();
        }

        public static DocumentIssue CreateNew(Document document, string name, string description, byte[] image)
        {
            var issue = new DocumentIssue
            {
                Document = document
            };

            issue.SetName(name);
            issue.SetDescription(description);
            issue.SetSnapshotImage(image);

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

        public byte[] SnapshotImage { get; set; }
        private void SetSnapshotImage(byte[] image)
        {
            SnapshotImage = image;
        }

        public Document Document { get; set; }

        public ICollection<DocumentIssueComment> Comments { get; set; }
        public void AddComment(DocumentIssueComment comment)
        {
            Comments.Add(comment ?? throw new ArgumentNullException(nameof(comment)));
        }
    }
}