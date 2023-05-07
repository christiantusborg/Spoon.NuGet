namespace Spoon.NuGet.Core.Application;

using System.Linq.Expressions;
using Domain;

/// <summary>
///  Get by name specification.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public sealed class GetByNameSpecification<TEntity> : Specification<TEntity>  where TEntity : Entity
{
    /// <inheritdoc />
    public GetByNameSpecification(string name, bool includeDeleted = false) : this(name, null, includeDeleted)
    {
    }
    
    /// <inheritdoc />
    public GetByNameSpecification(string name,List<Expression<Func<TEntity, object>>>? includeExpressions, bool includeDeleted = false)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = name,
                PropertyName = "Name",
            },
        };
        
        this.AddFilters(filters);

        if (includeExpressions is not null)
        {
            foreach (var includeExpression in includeExpressions)
            {
                this.AddInclude(includeExpression);
            }
        }        

        this.AddSkip(0);

        this.AddTake(1);
    }
}