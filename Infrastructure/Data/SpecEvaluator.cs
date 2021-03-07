using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity>
            defaultQuery, ISpecification<TEntity> spec)
        {
            IQueryable<TEntity> query = defaultQuery;

            if (spec.Filter != null)
                query = query
                    .Where(spec.Filter);

            query = spec.Filters.Aggregate(query, (current, filter) =>
                current.Where(filter));
            
            query = spec.Includes.Aggregate(
                query, (currentState, includeExpr) =>
                    currentState.Include(includeExpr));
            
            return query;
        }
    }
}