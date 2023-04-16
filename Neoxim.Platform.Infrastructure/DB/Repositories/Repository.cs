using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Neoxim.Platform.Core.Infrastructure;
using Neoxim.Platform.Infrastructure.DB.Contexts;
using Neoxim.Platform.SharedKernel.Base;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Infrastructure.DB.Repositories
{
    public class Repository<TAggregate> : IRepository<TAggregate> where TAggregate : BaseAggregateEntity
    {
        private readonly DbSet<TAggregate> _dbSet;
        private readonly ApplicationDbContext _ctx;

        public Repository(ApplicationDbContext ctx)
        {
            _dbSet = ctx.Set<TAggregate>();
            _ctx = ctx;
        }

        public async Task<ICollection<TAggregate>> GetAllAsync(CancellationToken token, params Expression<Func<TAggregate, object>>[] includes)
        {
            var query = _dbSet.ApplyIncludes(includes).AsNoTracking();

            return await query.ToListAsync(token);
        }
        public async Task<ICollection<TAggregate>> GetAllAsync(Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token)
        {
            var query = _dbSet.AsNoTracking();

            if(includes != null)
                query = includes(query);

            return await query.ToListAsync(token);
        }

        public async Task<ICollection<TAggregate>> GetAllAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken token, params Expression<Func<TAggregate, object>>[] includes)
        {
            var query = _dbSet.Where(predicate).AsNoTracking();

            query = query.ApplyIncludes(includes);

            return await query.ToListAsync(token);
        }

        public async Task<ICollection<TAggregate>> GetAllAsync(Expression<Func<TAggregate, bool>> predicate, Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token)
        {
            var query = _dbSet.Where(predicate).AsNoTracking();

            if(includes != null)
                query = includes(query);

            return await query.ToListAsync(token);
        }

        public async Task<TAggregate> GetAsync(Guid id, CancellationToken token, params Expression<Func<TAggregate, object>>[] includes)
        {
            var query = _dbSet.Where(x => x.Id == id);

            query = query.ApplyIncludes(includes);

            var entity = await query.SingleOrDefaultAsync(token);

            if(entity == null)
                throw new ObjectNotFoundException(id.ToString(), typeof(TAggregate).Name);

            return entity;
        }

        public async Task<TAggregate> GetAsync(Guid id, Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token)
        {
            var query = _dbSet.Where(x => x.Id == id);

            if(includes != null)
                query = includes(query);

            var entity = await query.SingleOrDefaultAsync(token);

            if(entity == null)
                throw new ObjectNotFoundException(id.ToString(), typeof(TAggregate).Name);

            return entity;
        }

        public async Task<TAggregate> GetAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken token, params Expression<Func<TAggregate, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);

            query = query.ApplyIncludes(includes);

            var entity = await query.SingleAsync(token);

            if(entity == null)
                throw new ObjectNotFoundException("predicate", typeof(TAggregate).Name);

            return entity;
        }

        public async Task<TAggregate> GetAsync(Expression<Func<TAggregate, bool>> predicate, Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token)
        {
            var query = _dbSet.Where(predicate);

            if(includes != null)
                query = includes(query);

            var entity = await query.SingleAsync(token);

            if(entity == null)
                throw new ObjectNotFoundException("predicate", typeof(TAggregate).Name);

            return entity;
        }

        public async Task<TAggregate> CreateAsync(TAggregate aggregate)
        {
            var result = await _dbSet.AddAsync(aggregate);

            return result.Entity;
        }

        public async Task UpdateAsync(TAggregate aggregate)
        {
            await GetAsync(aggregate.Id, default);

            var entry = _ctx.Entry(aggregate);
            entry.State = EntityState.Modified;

            _dbSet.Update(aggregate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await GetAsync(id, default);

            _dbSet.Remove(item);
        }
    }
}