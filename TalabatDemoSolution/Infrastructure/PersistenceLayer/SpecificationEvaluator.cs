using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
            IQueryable<TEntity> inputQuery,
            ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;

            // Apply criteria
            if (specifications.Criteria is not null)
            {
                query = query.Where(specifications.Criteria);
            }


            // Apply ordering
            if (specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }

            if (specifications.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }


            // Apply includes
            if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
            {
                //foreach (var includeExpression in specifications.IncludeExpressions)
                //{
                //    query = query.Include(includeExpression);
                //}

                query = specifications.IncludeExpressions.Aggregate(query, (current, includeExpression) =>
                    current.Include(includeExpression));
            }


            // Apply pagination
            if (specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }

            return query;
        }
    }
}
