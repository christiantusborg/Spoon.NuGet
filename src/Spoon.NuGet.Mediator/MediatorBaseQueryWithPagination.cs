namespace Spoon.NuGet.Mediator;

/// <summary>
/// Class MediatorBaseQueryWithPagination.
/// Implements the <see cref="MediatorBase" />.
/// </summary>
/// <seealso cref="MediatorBase" />
public abstract class MediatorBaseQueryWithPagination : MediatorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatorBaseQueryWithPagination"/> class.
    /// </summary>
    /// <param name="query">The query.</param>
    protected MediatorBaseQueryWithPagination(Type query)
        : base(query)
    {
    }

    /// <summary>
    /// Gets the skip.
    /// </summary>
    /// <value>The skip.</value>
    public int Skip => (this.Page - 1) * this.PageLength;

    /// <summary>
    /// Gets the take.
    /// </summary>
    /// <value>The take.</value>
    public int Take => this.PageLength;

    /// <summary>
    /// Gets the page.
    /// </summary>
    /// <value>The page.</value>
    public int Page { get; init; }

    /// <summary>
    /// Gets the length of the page.
    /// </summary>
    /// <value>The length of the page.</value>
    public int PageLength { get; init; }
}