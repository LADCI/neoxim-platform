using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Entities;

namespace Neoxim.Platform.Core.Models
{
    public class TenantClaimModel
    {
        public TenantClaimModel()
        {
            
        }

        public TenantClaimModel(TenantClaim entity)
        {
            if(entity is null) return;

            Id = entity.Id;
            Name = entity.Name;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}