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
            
        }
        public string Name { get; protected set; } = null!;

        public Folder? Parent { get; protected set; }

        public Tenant Tenant { get; protected set; }

        public ICollection<Folder> Childs { get; protected set; }

        public ICollection<Document> Documents { get; protected set; }
    }
}