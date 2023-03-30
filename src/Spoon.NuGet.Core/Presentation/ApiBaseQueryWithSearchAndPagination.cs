namespace Spoon.NuGet.Core.Presentation;

using Domain;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Class ApiBaseQueryWithSearchAndPagination.
/// </summary>
public abstract class ApiBaseQueryWithSearchAndPagination
{
    private readonly List<Filter> _filters = new ();

    /// <summary>
    /// </summary>
    public List<Filter> Filters
    {
        get => this._filters;
        init => this._filters = value;
    }

    /// <summary>
    /// Gets the skip.
    /// </summary>
    /// <value>The skip.</value>
    [FromQuery]
    public int Skip => (this.Page - 1) * this.PageLength;

    /// <summary>
    /// Gets the take.
    /// </summary>
    /// <value>The take.</value>
    [FromQuery]
    public int Take => this.PageLength;

    /// <summary>
    /// Gets the page.
    /// </summary>
    /// <value>The page.</value>
    public int Page { get; set; }

    /// <summary>
    /// Gets the length of the page.
    /// </summary>
    /// <value>The length of the page.</value>
    public int PageLength { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="filter"></param>
    public void AddFilter(Filter filter)
    {
        this._filters.Add(filter);
    }

    /// <summary>
    /// Sets the page.
    /// </summary>
    /// <param name="page">The page.</param>
    public void SetPage(int page)
    {
        this.Page = page;
    }

    /// <summary>
    /// Sets the length of the page.
    /// </summary>
    /// <param name="pageLength">Length of the page.</param>
    public void SetPageLength(int pageLength)
    {
        this.PageLength = pageLength;
    }    
}