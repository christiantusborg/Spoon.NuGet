namespace Spoon.NuGet.Core.Domain;

using System.Linq.Expressions;

/// <summary>
/// Class Specification.
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
public abstract class Specification<TEntity>
    where TEntity : Entity
{
    /// <summary>
    /// Gets the filters.
    /// </summary>
    /// <value>The filters.</value>
    public List<Filter>? Filters { get; private set; }

    /// <summary>
    /// Gets the include expressions.
    /// </summary>
    /// <value>The include expressions.</value>
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new ();

    /// <summary>
    /// Gets the where expression.
    /// </summary>
    /// <value>The where expression.</value>
    public Expression<Func<TEntity, bool>>? WhereExpression { get; private set; }

    /// <summary>
    /// Gets the skip.
    /// </summary>
    /// <value>The skip.</value>
    public int Skip { get; private set; }

    /// <summary>
    /// Gets the take.
    /// </summary>
    /// <value>The take.</value>
    public int Take { get; private set; }

    /// <summary>
    /// Gets the sortFields.
    /// </summary>
    /// <value>The sortFields.</value>
    public List<Sorting>? SortFields { get; private set; }


    /// <summary>
    /// Adds the include.
    /// </summary>
    /// <param name="includeExpression">The include expression.</param>
    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
        this.IncludeExpressions.Add(includeExpression);

    /// <summary>
    /// Adds the order by.
    /// </summary>
    /// <param name="whereExpression">The order by expression.</param>
    protected void AddWhere(
        Expression<Func<TEntity, bool>> whereExpression) =>
        this.WhereExpression = whereExpression;

    /// <summary>
    /// Adds the filters.
    /// </summary>
    /// <param name="sortFields">The filters.</param>
    protected void AddSortFields(
        List<Sorting> sortFields) =>
        this.SortFields = sortFields;

    /// <summary>
    /// Adds the filters.
    /// </summary>
    /// <param name="filters">The filters.</param>
    protected void AddFilters(
        List<Filter> filters) =>
        this.Filters = filters;    

    /// <summary>
    /// Adds the skip.
    /// </summary>
    /// <param name="skip">The skip.</param>
    protected void AddSkip(int skip) =>
        this.Skip = skip;

    /// <summary>
    /// Adds the take.
    /// </summary>
    /// <param name="take">The take.</param>
    protected void AddTake(int take) =>
        this.Take = take;
}