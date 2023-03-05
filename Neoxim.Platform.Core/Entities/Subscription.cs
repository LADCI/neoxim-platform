using Neoxim.Platform.Core.Events;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Core.Entities
{
    public class Subscription : BaseEntity
    {
        protected Subscription()
        {
        }

        public static Subscription CreateNew(Tenant tenant, Amount unitAmount, DateTimeOffset startDate)
        {
            var subscription = new Subscription();

            subscription.SetUnitAmount(unitAmount);
            subscription.SetStartDate(startDate);
            subscription.SetTenant(tenant);

            return subscription;
        }

        public Amount UnitAmount { get; protected set; }
        public void SetUnitAmount(Amount unitAmount)
        {
            UnitAmount = unitAmount ?? throw new ArgumentNullException(nameof(unitAmount));
        }

        public DateTimeOffset StartDate { get; protected set; }
        public void SetStartDate(DateTimeOffset startDate)
        {
            if(startDate >= EndDate)
                throw new ArgumentException("Start date must be less than start date.");

            StartDate = startDate;
        }

        public DateTimeOffset? EndDate { get; protected set; }
        public void SetEndDate(DateTimeOffset? endDate)
        {
            if(endDate <= StartDate)
                throw new ArgumentException("End date must be greater than start date.");

            EndDate = endDate;
        }

        public Tenant Tenant { get; protected set; } = null!;
        public void SetTenant(Tenant tenant)
        {
            Tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
        }
    }
}