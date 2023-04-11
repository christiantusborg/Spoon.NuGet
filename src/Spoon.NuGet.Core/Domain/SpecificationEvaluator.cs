namespace Spoon.NuGet.Core.Domain;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class SpecificationEvaluator.
/// </summary>
public static class SpecificationEvaluator
{
    /// <summary>
    /// Gets the query.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <param name="inputQueryable">The input queryable.</param>
    /// <param name="specification">The specification.</param>
    /// <returns>IQueryable&lt;TEntity&gt;.</returns>
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> inputQueryable,
        Specification<TEntity> specification)
        where TEntity : Entity
    {
        IQueryable<TEntity> queryable = inputQueryable;

        if (specification.Filters != null)
        {
            var whereBuilderExtensionResult = WhereBuilderExtension.GetExpression<TEntity>(specification.Filters);

            if (whereBuilderExtensionResult is not null)
                queryable = queryable.Where(whereBuilderExtensionResult);
        }

        queryable = specification.IncludeExpressions.Aggregate(
            queryable,
            (current, includeExpression) =>
                current.Include(includeExpression));

        // apply sorting
        if (specification.SortFields != null && specification.SortFields.Count > 0)
        {
            IOrderedQueryable<TEntity> orderedQuery = null!;
            foreach (var sorting in specification.SortFields)
            {
                var property = typeof(TEntity).GetProperty(sorting.SortField);
                if (property != null)
                {
                    if (sorting.Direction == SortDirection.Descending)
                    {
                        orderedQuery = orderedQuery != null ? orderedQuery.ThenByDescending(u => property.GetValue(u, null)) : queryable.OrderByDescending(u => property.GetValue(u, null));
                    }
                    else
                    {
                        orderedQuery = orderedQuery != null ? orderedQuery.ThenBy(u => property.GetValue(u, null)) : queryable.OrderBy(u => property.GetValue(u, null));
                    }
                }
            }
            queryable = orderedQuery ?? queryable;
        }



        queryable = queryable.Skip(specification.Skip);

        queryable = queryable.Take(specification.Take);

        return queryable;
    }
}
