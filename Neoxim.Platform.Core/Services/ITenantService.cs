using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Services
{
    public interface ITenantService
    {
        Task<TenantModel> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TenantModel>> GetAllAsync(CancellationToken cancellationToken);

        Task<TenantModel> CreateAsync(string name, Contact contact, Amount subscriptionUnitMount);
    }
}