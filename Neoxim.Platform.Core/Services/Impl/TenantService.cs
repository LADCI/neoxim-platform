using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.Services.Impl
{
    public class TenantService : ITenantService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TenantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}