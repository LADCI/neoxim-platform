using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Models
{
    public class SubscriptionModel
    {
        public SubscriptionModel()
        {
            
        }

        public SubscriptionModel(Subscription entity)
        {
            if(entity is null) return;

            Id = entity.Id;
            CreationDate = entity.CreationDate;
            UnitAmount = entity.UnitAmount;
            StartDate = entity.StartDate;
            EndDate = entity.EndDate;
        }

        public Guid Id { get; set; }

        public Amount UnitAmount { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
   }
}