using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;

namespace Neoxim.Platform.Core.Models
{
    public class DocumentModel
    {
        public DocumentModel(Document entity, Guid tenantId, Guid projectId, Guid forderId)
        {
            if(entity == null) return;

            Id = entity.Id;
            Name = entity.Name;
            Type = entity.Type;
            Description = entity.Description;
            Url = entity.Url;
            TenantId = tenantId;
            ProjectId = projectId;
            FolderId = forderId;
        }

        public Guid Id { get; set; }
        
        public DocumentTypeEnum Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Guid TenantId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FolderId { get; set; }

        public ICollection<DocumentIssueModel> Issues { get; set; }
    }

    public class CreateDocumentModel
    {
        public DocumentTypeEnum Type { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public Guid TenantId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FolderId { get; set; }
    }
}