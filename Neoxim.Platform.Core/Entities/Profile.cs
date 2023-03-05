using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class Profile : BaseEntity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public ICollection<FolderInProfile> FoldersInProfiles { get; protected set; }
        public ICollection<UserInProfile> UsersInProfiles { get; protected set; }
    }
}