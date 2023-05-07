namespace Spoon.NuGet.Core.Application;

using System.Linq.Expressions;
using Domain;

/// <summary>
///     Class DefaultSearchSpecification. This class cannot be inherited.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class DefaultSearchSpecification<TEntity> : Specification<TEntity> where TEntity : Entity
{
    /// <inheritdoc />
    public DefaultSearchSpecification(List<Filter> filters, List<Sorting> sortField,
        List<Expression<Func<TEntity, object>>>? includeExpressions,
        Expression<Func<TEntity, bool>>? whereExpression,    
        int skip, int take, bool includeDeleted)
    {

        if (includeExpressions is not null)
        {
            foreach (var includeExpression in includeExpressions)
            {
                this.AddInclude(includeExpression);
            }
            
        }
        
        
        if (whereExpression is not null)
        {
            this.AddWhere(whereExpression);
        }
        
        if (includeDeleted is false)
        {
            filters.Add(new Filter
            {
                Operation = Operation.NotEqual,
                PropertyName = "DeletedAt",
                Value = null,
            });
        }

        this.AddFilters(filters);
        this.AddSortFields(sortField);

        this.AddSkip(skip);
        this.AddTake(take);
    }
    
    /// <inheritdoc />
    public DefaultSearchSpecification(List<Filter> filters,
        List<Sorting> sortField,
        int skip,
        int take,
        List<Expression<Func<TEntity, object>>> includeExpressions,
        bool includeDeleted) : this(filters, sortField, includeExpressions ,null,skip, take, includeDeleted)
    {
    }
    
    /// <inheritdoc />
    public DefaultSearchSpecification(List<Filter> filters,
        List<Sorting> sortField,
        int skip,
        int take,
        Expression<Func<TEntity, bool>>? whereExpression,
        bool includeDeleted) : this(filters, sortField, null ,whereExpression,skip, take, includeDeleted)
    {
    }    
    
    /// <inheritdoc />
    public DefaultSearchSpecification(List<Filter> filters,
        List<Sorting> sortField,
        int skip,
        int take,
        List<Expression<Func<TEntity, object>>> includeExpressions,
        Expression<Func<TEntity, bool>>? whereExpression,
        bool includeDeleted) : this(filters, sortField, includeExpressions ,whereExpression,skip, take, includeDeleted)
    {
    }
}