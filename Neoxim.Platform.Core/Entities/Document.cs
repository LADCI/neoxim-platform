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

            document.SetName(title);
            document.SetDescription(description);
            document.SetUrl("UNDEFINED");
            document.SetFolder(folder);

            return document;
        }


        public DocumentTypeEnum Type { get; protected set; }

        public string Name { get; protected set; }
        private void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Description { get; protected set; }
        private void SetDescription(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string Url { get; protected set; }
        public void SetUrl(string url)
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