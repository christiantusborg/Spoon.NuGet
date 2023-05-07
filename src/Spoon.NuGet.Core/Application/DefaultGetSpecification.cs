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
    private void CreateGetSpecification<T>(T id,
        List<Expression<Func<TEntity, object>>>? includeExpressions,
        Expression<Func<TEntity, bool>>? whereExpression,
        bool includeDeleted = false,
        bool includePropertyName = true)
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

        this.AddFilters(filters);
        this.AddTake(1);
    }
    // int
    
    /// <inheritdoc />
    public DefaultGetSpecification(int id,
        List<Expression<Func<TEntity, object>>>? includeExpressions,
        Expression<Func<TEntity, bool>>? whereExpression,
        bool includeDeleted = false,
        bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, includeExpressions, whereExpression, includeDeleted, includePropertyName);
    }


    /// <inheritdoc />
    public DefaultGetSpecification(int id, List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        if (includeExpressions is null)
        {
            includeExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        this.CreateGetSpecification(id, includeExpressions, null, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(int id, Expression<Func<TEntity, bool>>? whereExpression, bool includeDeleted = false, bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, null, whereExpression, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(int id, bool includeDeleted = false, bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, null, null, includeDeleted, includePropertyName);
    }
    
    // string
    
    /// <inheritdoc />
    public DefaultGetSpecification(string id,
        List<Expression<Func<TEntity, object>>>? includeExpressions,
        Expression<Func<TEntity, bool>>? whereExpression,
        bool includeDeleted = false,
        bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, includeExpressions, whereExpression, includeDeleted, includePropertyName);
    }


    /// <inheritdoc />
    public DefaultGetSpecification(string id, List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        if (includeExpressions is null)
        {
            includeExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        this.CreateGetSpecification(id, includeExpressions, null, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(string id, Expression<Func<TEntity, bool>>? whereExpression, bool includeDeleted = false, bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, null, whereExpression, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(string id, bool includeDeleted = false, bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, null, null, includeDeleted, includePropertyName);
    }    

    // Guid
    
    /// <inheritdoc />
    public DefaultGetSpecification(Guid id,
        List<Expression<Func<TEntity, object>>>? includeExpressions,
        Expression<Func<TEntity, bool>>? whereExpression,
        bool includeDeleted = false,
        bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, includeExpressions, whereExpression, includeDeleted, includePropertyName);
    }


    /// <inheritdoc />
    public DefaultGetSpecification(Guid id, List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false, bool includePropertyName = true)
    {
        if (includeExpressions is null)
        {
            includeExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        this.CreateGetSpecification(id, includeExpressions, null, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(Guid id, Expression<Func<TEntity, bool>>? whereExpression, bool includeDeleted = false, bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, null, whereExpression, includeDeleted, includePropertyName);
    }

    /// <inheritdoc />
    public DefaultGetSpecification(Guid id, bool includeDeleted = false, bool includePropertyName = true)
    {
        this.CreateGetSpecification(id, null, null, includeDeleted, includePropertyName);
    }    

}