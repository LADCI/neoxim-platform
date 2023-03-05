
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        public IRepository<User> UsersRepository { get; }
        public IRepository<Tenant> TenantsRepository { get; }
        public IRepository<Project> ProjectsRepository { get; }
        public IRepository<Folder> FoldersRepository { get; }
        public IRepository<Document> DocumentsRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken, params BaseEvent[] events);
    }
}