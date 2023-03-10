using Microsoft.EntityFrameworkCore;
using Neoxim.Platform.Infrastructure.DB.Configurations;

namespace Neoxim.Platform.Infrastructure.DB.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("nxm");

            //...
            modelBuilder.ApplyConfiguration(new DocumentCfg());
            modelBuilder.ApplyConfiguration(new DocumentIssueCfg());
            modelBuilder.ApplyConfiguration(new DocumentIssueCommentCfg());
            modelBuilder.ApplyConfiguration(new FolderCfg());
            modelBuilder.ApplyConfiguration(new FolderInClaimCfg());
            modelBuilder.ApplyConfiguration(new ProjectCfg());
            modelBuilder.ApplyConfiguration(new SubscriptionCfg());
            modelBuilder.ApplyConfiguration(new TenantCfg());
            modelBuilder.ApplyConfiguration(new TenantClaimCfg());
            modelBuilder.ApplyConfiguration(new UserCfg());
            modelBuilder.ApplyConfiguration(new UserInClaimCfg());
        }
    }
}