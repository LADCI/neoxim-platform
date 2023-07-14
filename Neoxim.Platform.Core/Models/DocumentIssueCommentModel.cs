using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.Core.Models
{
    public class DocumentIssueCommentModel
    {
        public string Text { get; set; }
        public Guid IssueId { get; set; }
        public Guid AuthorId { get; set; }
    }
}