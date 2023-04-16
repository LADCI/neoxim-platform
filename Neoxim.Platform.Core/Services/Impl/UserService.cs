using System.Runtime.ExceptionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Neoxim.Platform.Core.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UsersRepository.GetAsync(id,
                    includes: (query) => query
                            .Include(x => x.Tenant)
                            .Include(x => x.UsersInClaims)
                                .ThenInclude(y => y.Claim),
                    cancellationToken);
            return new UserModel(user);
        }

        public async Task<IEnumerable<UserModel>> GetListByTenantAsync(Guid tenantId, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UsersRepository.GetAllAsync(
                predicate: x => x.Tenant.Id == tenantId,
                includes: (query) => query
                        .Include(x => x.Tenant)
                        .Include(x => x.UsersInClaims)
                            .ThenInclude(y => y.Claim),
                cancellationToken);

            return users.Select(x => new UserModel(x));
        }

        public async Task<UserModel> CreateAsync(string firstName, string lastName, GenderEnum gender, string email, string phone, string address, Guid tenantId, List<Guid> claims)
        {
            var tenant = await _unitOfWork.TenantsRepository.GetAsync(tenantId, default, i => i.Claims);
            var tenantClaims = tenant.Claims.Where(x => claims.Contains(x.Id)).ToList();

            var user = User.CreateNew(new UserName(firstName, lastName, gender), new Contact(email, phone, address), tenant, tenantClaims);

            await _unitOfWork.UsersRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(default, user.Events.ToArray());

            return new UserModel(user);
        }
    }
}