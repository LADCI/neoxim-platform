using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Infrastructure.DB.Configurations.Base
{
    public class Cfg<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        private readonly string _tableName;

        protected Cfg(string tableName)
        {
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(_tableName);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("creation_date").IsRequired();
            builder.Property(x => x.LastChangesDate).HasColumnName("last_changes_date").IsRequired();
        }

        protected Action<OwnedNavigationBuilder<TEntity, Core.ValueObjects.Contact>> GetContactOwnedNavigationBuilder()
        {
            return i =>
            {
                i.Property(p => p.Email).HasColumnName("contact_email").HasMaxLength(128).IsRequired();
                i.Property(p => p.Phone).HasColumnName("contact_phone").HasMaxLength(64).IsRequired();
                i.Property(p => p.Address).HasColumnName("contact_address").HasMaxLength(128).IsRequired();
            };
        }

        protected Action<OwnedNavigationBuilder<TEntity, Core.ValueObjects.UserName>> GetUserNameOwnedNavigationBuilder()
        {
            return i =>
            {
                i.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(128).IsRequired();
                i.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(64).IsRequired();
                i.Property(p => p.Gender).HasColumnName("gender").HasConversion<string>().HasMaxLength(6).IsRequired();
            };
        }

        protected Action<OwnedNavigationBuilder<TEntity, Core.ValueObjects.Amount>> GetAmountOwnedNavigationBuilder()
        {
            return i =>
            {
                i.Property(p => p.Value).HasColumnName("amount_value").IsRequired();
                i.Property(p => p.Currency).HasColumnName("amount_currency").HasConversion<string>().HasMaxLength(6).IsRequired();
            };
        }
    }
}