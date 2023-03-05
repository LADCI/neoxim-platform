using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class FolderInProfile : BaseEntity
    {
        public Folder Folder { get; protected set; }
        public Profile Profile { get; protected set; }
    }
}