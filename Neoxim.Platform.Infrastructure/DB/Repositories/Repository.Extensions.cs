using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Neoxim.Platform.SharedKernel.Base;

namespace Neoxim.Platform.Infrastructure.DB.Repositories
{
     public static class RepositoryExtensions
    {
        public static IQueryable<TAggregate> ApplyIncludes<TAggregate>(this IQueryable<TAggregate> query, Expression<Func<TAggregate, object>>[] includes) where TAggregate : BaseAggregateEntity
        {
            if (includes?.Any() == true)
            {
                includes.ToList().ForEach(x => query = query.Include(x));
            }

            return query;
        }
    }
}