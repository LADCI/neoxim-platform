using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class Folder : BaseAggregateEntity
    {
        protected Folder()
        {
            Childs = new List<Folder>();
            Documents = new List<Document>();
            FoldersInClaims = new List<FolderInClaim>();
        }

        public static Folder CreateNew(string name, Tenant tenant, Folder? parent)
        {
            var folder = new Folder();

            folder.SetName(name);
            folder.SetTenant(tenant);
            folder.SetParent(parent);

            return folder;
        }


        public string Name { get; protected set; } = null!;
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Folder? Parent { get; protected set; }
        public void SetParent(Folder? folder)
        {
            Parent = folder;
        }

        public Tenant Tenant { get; protected set; }
        public void SetTenant(Tenant tenant)
        {
            Tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
        }

        public ICollection<Folder> Childs { get; protected set; }

        public ICollection<Document> Documents { get; protected set; }
        public ICollection<FolderInClaim> FoldersInClaims { get; protected set; }
    }
}