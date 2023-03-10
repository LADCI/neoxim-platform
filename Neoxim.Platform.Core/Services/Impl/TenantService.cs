using System.ComponentModel;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.ValueObjects;
using Neoxim.Platform.Core.Helpers;

namespace Neoxim.Platform.Core.Services.Impl
{
    public class TenantService : ITenantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemClock _systemClock;

        public TenantService(IUnitOfWork unitOfWork, ISystemClock systemClock)
        {
            _unitOfWork = unitOfWork;
            _systemClock = systemClock;
        }

        public async Task<IEnumerable<TenantModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var tenants = await _unitOfWork.TenantsRepository.GetAllAsync(cancellationToken,
                i => i.Contact,
                i => i.Claims,
                i => i.Subscriptions
            );

            return tenants.Select(x => new TenantModel(x));
        }

        public async Task<TenantModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var tenant = await _unitOfWork.TenantsRepository.GetAsync(id, cancellationToken,
                i => i.Contact,
                i => i.Claims,
                i => i.Subscriptions
            );

            return new TenantModel(tenant);
        }

        public async Task<TenantModel> CreateAsync(string name, Contact contact, Amount subscriptionUnitMount)
        {
            var tenant = Tenant.CreateNew(name, contact);

            tenant.AddSubscription(Subscription.CreateNew(subscriptionUnitMount, _systemClock.UtcNow));

            Enum.GetValues<TenantClaimEnum>().ToList().ForEach(x =>
            {
                var name = x.ToString();
                string description = x.GetAttributeOf<DescriptionAttribute>().Description ?? x.ToString();

                var claim = TenantClaim.CreateNew(name, description);

                tenant.AddClaim(claim);
            });

            await _unitOfWork.TenantsRepository.CreateAsync(tenant);

            await _unitOfWork.SaveChangesAsync(default, tenant.Events.ToArray());

            return new TenantModel(tenant);
        }
    }
}