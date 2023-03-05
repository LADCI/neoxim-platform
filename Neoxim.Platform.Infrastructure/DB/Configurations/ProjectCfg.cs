using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Infrastructure.DB.Configurations.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations
{
    public class ProjectCfg : Cfg<Project>
    {
        public ProjectCfg(): base("projects")
        {
        }

        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => new {x.Name}).IsUnique(false);
            builder.Ignore(x => x.Events);

            //...
            builder.OwnsOne(x => x.Amount, GetAmountOwnedNavigationBuilder());

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text").IsRequired();
            builder.Property(x => x.Customer).HasColumnName("customer").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Type).HasConversion<string>().HasColumnName("type").HasMaxLength(128).IsRequired();
            builder.Property(x => x.ConstructionType).HasConversion<string>().HasColumnName("construction_type").HasMaxLength(128).IsRequired();
            builder.Property(x => x.ContractType).HasConversion<string>().HasColumnName("contract_type").HasMaxLength(128).IsRequired();
            builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(x => x.EndDate).HasColumnName("end_date").IsRequired();

            builder.HasMany(x => x.Documents).WithOne(x => x.Project).HasForeignKey("project_id");
        }
    }
}