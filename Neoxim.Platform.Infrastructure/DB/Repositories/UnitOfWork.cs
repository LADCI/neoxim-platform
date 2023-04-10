using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Infrastructure.DB.Contexts;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Infrastructure.DB.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _ctx;
        private readonly MediatR.IMediator _mediator;

        public UnitOfWork(ApplicationDbContext ctx, MediatR.IMediator mediator)
        {
            _ctx = ctx;
            _mediator = mediator;

            UsersRepository = new Repository<User>(ctx);
            TenantsRepository = new Repository<Tenant>(ctx);
            ProjectsRepository = new Repository<Project>(ctx);
            FoldersRepository = new Repository<Folder>(ctx);
            DocumentsRepository = new Repository<Document>(ctx);
        }

        public IRepository<User> UsersRepository  { get; }

        public IRepository<Tenant> TenantsRepository  { get; }

        public IRepository<Project> ProjectsRepository { get; }

        public IRepository<Folder> FoldersRepository  { get; }

        public IRepository<Document> DocumentsRepository  { get; }

        public async Task SaveChangesAsync(CancellationToken cancellationToken, params BaseEvent[] events)
        {
            await _ctx.SaveChangesAsync(cancellationToken);

            events?.ToList().ForEach(x => _mediator.Publish(x));
        }
    }
}