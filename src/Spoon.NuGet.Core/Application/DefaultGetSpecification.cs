namespace Spoon.NuGet.Core.Application;

using Domain;

/// <summary>
///     Class DefaultGetSpecification.
///     Implements the <see cref="Specification{TEntity}" />
/// </summary>
/// <typeparam name="TEntity">Where TEntity is a Database Entity.</typeparam>
/// <seealso cref="Specification{TEntity}" />
public class DefaultGetSpecification<TEntity> : Specification<TEntity>
    where TEntity : Entity
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DefaultGetSpecification{TEntity}" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="includePropertyName">if set to <c>true</c> [include property name].</param>
    public DefaultGetSpecification(Guid id, bool includePropertyName = true)
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
        this.AddFilters(filters);
        this.AddTake(1);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DefaultGetSpecification{TEntity}" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="includePropertyName">if set to <c>true</c> [include property name].</param>
    public DefaultGetSpecification(int id, bool includePropertyName = true)
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
        this.AddFilters(filters);
        this.AddTake(1);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DefaultGetSpecification{TEntity}" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="includePropertyName">Name of the include property.</param>
    public DefaultGetSpecification(string id, bool includePropertyName = true)
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
        this.AddFilters(filters);
        this.AddTake(1);
    }
}