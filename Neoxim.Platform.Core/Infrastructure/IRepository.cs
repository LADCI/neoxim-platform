
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Neoxim.Platform.SharedKernel.Base;


namespace Neoxim.Platform.Core.Infrastructure
{
    public interface IRepository<TAggregate> : ICommandRepository<TAggregate>, IQueryRepository<TAggregate> where TAggregate : BaseAggregateEntity
    {
    }

    public interface ICommandRepository<TAggregate> where TAggregate : BaseAggregateEntity
    {
         Task<TAggregate> CreateAsync(TAggregate aggregate);
         Task UpdateAsync(TAggregate aggregate);
         Task DeleteAsync(Guid id);
    }

    public interface IQueryRepository<TAggregate> where TAggregate : BaseAggregateEntity
    {
         Task<ICollection<TAggregate>> GetAllAsync(CancellationToken token, params Expression<Func<TAggregate, object>>[] includes);
         Task<ICollection<TAggregate>> GetAllAsync(Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token);

         Task<ICollection<TAggregate>> GetAllAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken token, params Expression<Func<TAggregate, object>>[] includes);
         Task<ICollection<TAggregate>> GetAllAsync(Expression<Func<TAggregate, bool>> predicate, Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token);

         Task<TAggregate> GetAsync(Guid id, CancellationToken token, params Expression<Func<TAggregate, object>>[] includes);
         Task<TAggregate> GetAsync(Guid id, Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token);

         Task<TAggregate> GetAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken token, params Expression<Func<TAggregate, object>>[] includes);
         Task<TAggregate> GetAsync(Expression<Func<TAggregate, bool>> predicate, Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> includes, CancellationToken token);
    }
}