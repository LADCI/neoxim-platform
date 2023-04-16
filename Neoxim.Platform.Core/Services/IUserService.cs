using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Models;

namespace Neoxim.Platform.Core.Services
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<UserModel>> GetListByTenantAsync(Guid tenantId, CancellationToken cancellationToken);
        Task<UserModel> CreateAsync(string firstName, string lastName, GenderEnum gender, string email, string phone, string address, Guid tenantId, List<Guid> claims);
    }
}