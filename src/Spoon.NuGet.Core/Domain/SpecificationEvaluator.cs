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

        if (specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            queryable = queryable.OrderByDescending(
                specification.OrderByDescendingExpression);
        }

        queryable = queryable.Skip(specification.Skip);

        queryable = queryable.Take(specification.Take);

        return queryable;
    }
}
