using System.Net.Mime;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class Document : BaseAggregateEntity
    {
        protected Document()
        {
            Issues = new List<DocumentIssue>();
        }

        public static Document CreateNew(
            DocumentTypeEnum type,
            string title,
            string url,
            string description,
            Tenant tenant,
            Project project,
            Folder folder
            )
        {
            var document = new Document
            {
                Type = type,
                Tenant = tenant,
                Project = project
            };

            document.SetTitle(title);
            document.SetDescription(description);
            document.SetUrl(url);
            document.SetFolder(folder);

            return document;
        }


        public DocumentTypeEnum Type { get; protected set; }

        public string Title { get; protected set; }
        private void SetTitle(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
        public string Description { get; protected set; }
        private void SetDescription(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string Url { get; protected set; }
        private void SetUrl(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public Tenant Tenant { get; protected set; } = null!;
        public Project Project { get; protected set; } = null!;

        public Folder Folder { get; protected set; }
        private void SetFolder(Folder folder)
        {
            Folder = folder ?? throw new ArgumentNullException(nameof(folder));
        }
        public ICollection<DocumentIssue> Issues { get; set; }
    }
}