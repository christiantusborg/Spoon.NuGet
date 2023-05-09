#pragma warning disable CS8618
namespace Spoon.NuGet.Core.Application;

using Domain;

/// <summary>
///     Class MediatorBaseSearch. This class cannot be inherited.
/// </summary>
public class MediatorBaseCommandSearch : MediatorBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MediatorBaseCommandSearch" /> class.
    /// </summary>
    /// <param name="command"></param>
    public MediatorBaseCommandSearch(Type command) : base(command)
    {
    }

    /// <summary>
    ///     Gets or sets the filters.
    /// </summary>
    public List<Filter> Filters { get; init; }

    /// <summary>
    ///     Gets or sets the sort field.
    /// </summary>
    public List<Sorting> SortField { get; init; }

    /// <summary>
    ///     Gets or sets the Include deleted.
    /// </summary>
    public bool IncludeDeleted { get; init; }

    /// <summary>
    ///     Gets or sets the page.
    /// </summary>
    public int Page { private get; init; }

    /// <summary>
    ///     Gets or sets the page size.
    /// </summary>
    public int PageLength { private get; init; }

    /// <summary>
    ///     Gets the skip.
    /// </summary>
    /// <value>The skip.</value>
    public int Skip => (this.Page - 1) * this.PageLength;

    /// <summary>
    ///     Gets the take.
    /// </summary>
    /// <value>The take.</value>
    public int Take => this.PageLength;
}