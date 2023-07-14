using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.Core.Models
{
    public class DocumentIssueModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] SnapshotImage { get; set; }
        public Guid DocumentId { get; set; }

        public ICollection<DocumentIssueCommentModel> Comments { get; set; }
    }
}