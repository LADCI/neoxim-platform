using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class TenantClaim : BaseEntity
    {
        protected TenantClaim()
        {
        }

        public static TenantClaim CreateNew(string name, string description)
        {
            var claim = new TenantClaim();

            claim.SetName(name);
            claim.SetDescription(description);

            return claim;
        }

        public string Name { get; protected set; }
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Description { get; protected set; }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public Guid TenantId { get; protected set; }
        public Tenant Tenant { get; protected set; }
        public void SetTenant(Tenant tenant)
        {
            Tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
        }

        public ICollection<FolderInClaim> FoldersInClaims { get; protected set; }
        public ICollection<UserInClaim> UsersInClaims { get; protected set; }
    }
}