namespace Spoon.NuGet.Core.Application;

using Spoon.NuGet.Core.Domain;

/// <summary>
///   Class DefaultSearchSpecification. This class cannot be inherited.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class DefaultSearchSpecification<TEntity> : Specification<TEntity> where TEntity : Entity
{
    /// <inheritdoc />
    public DefaultSearchSpecification(List<Filter> filters, List<Sorting> sortField, int skip, int take, bool includeDeleted) 
    {
        
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
    
}