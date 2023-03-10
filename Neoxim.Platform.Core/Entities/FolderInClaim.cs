using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class FolderInClaim : BaseEntity
    {
        public Folder Folder { get; protected set; }
        public TenantClaim Claim { get; protected set; }
    }
}