#pragma warning disable CS8618
namespace Spoon.NuGet.Core.Presentation;

using Domain;

/// <summary>
///     Class MediatorBaseSearch. This class cannot be inherited.
/// </summary>
public class BasePresentationSearch
{
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
    public int PageSize { private get; init; }
}