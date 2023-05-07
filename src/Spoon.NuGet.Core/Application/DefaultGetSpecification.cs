namespace Spoon.NuGet.Core.Application;

using System.Linq.Expressions;
using Domain;

/// <summary>
///     Class DefaultGetSpecification.
///     Implements the <see cref="Specification{TEntity}" />
/// </summary>
/// <typeparam name="TEntity">Where TEntity is a Database Entity.</typeparam>
/// <seealso cref="Specification{TEntity}" />
public class DefaultGetSpecification<TEntity> : Specification<TEntity> where TEntity : Entity
{
    /// <inheritdoc />
    private void CreateGetSpecification<T>(T id, List<Expression<Func<TEntity, object>>> includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        var filters = new List<Filter>
        {
            new ()
            {
                Operation = Operation.Equals,
                Value = id,
                PropertyName = includePropertyName ? typeof(TEntity).Name + "Id" : "Id",
            },
        };

        if (includeDeleted is false)
        {
            filters.Add(new Filter
            {
                Operation = Operation.NotEqual,
                PropertyName = "DeletedAt",
                Value = null,
            });
        }

        
        
        foreach (var includeExpression in includeExpressions)
        {
            this.AddInclude(includeExpression);
        }

        this.AddFilters(filters);
        this.AddTake(1);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(int id, List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        if (includeExpressions is null)
        {
            includeExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        this.CreateGetSpecification(id, includeExpressions, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(string id, List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        if (includeExpressions is null)
        {
            includeExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        this.CreateGetSpecification(id, includeExpressions, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(Guid id, List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        if (includeExpressions is null)
        {
            includeExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        this.CreateGetSpecification(id, includeExpressions, includeDeleted, includePropertyName);
    }
}