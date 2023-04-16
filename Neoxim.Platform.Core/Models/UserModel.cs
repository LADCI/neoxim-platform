using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Models
{
    public class UserModel
    {
        public UserModel(User entity)
        {
            if(entity == null) return;

            Id = entity.Id;
            FirstName = entity.Name.FirstName;
            LastName = entity.Name.LastName;
            Gender = entity.Name.Gender;

            Email = entity.Contact.Email;
            Phone = entity.Contact.Phone;
            Address = entity.Contact.Address;

            TenantId = entity.Tenant.Id;
            Claims = entity.UsersInClaims.Select(x => new UserClaimModel(x.Claim.Id, x.Claim.Name, x.CreationDate)).ToList();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Guid TenantId { get; set; }
        public IEnumerable<UserClaimModel> Claims { get; set; }
    }

    public record UserClaimModel(Guid id, string name, DateTimeOffset date);

    public class CreateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Guid TenantId { get; set; }
        public IEnumerable<Guid> Claims { get; set; }
    }
}