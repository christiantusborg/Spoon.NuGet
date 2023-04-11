﻿#pragma warning disable CS8618
namespace Spoon.NuGet.Core.Presentation;

using Mediator;
using Spoon.NuGet.Core.Domain;

/// <summary>
/// Class MediatorBaseSearch. This class cannot be inherited.
/// </summary>
public class BasePresentationSearch
{
  
    /// <summary>
    ///   Gets or sets the filters.
    /// </summary>
    public List<Filter> Filters { get; init; }
    /// <summary>
    ///  Gets or sets the sort field.
    /// </summary>
    public List<Sorting> SortField { get; init; }
    /// <summary>
    ///  Gets or sets the Include deleted.
    /// </summary>
    public bool IncludeDeleted { get; init; }
    /// <summary>
    ///  Gets or sets the page.
    /// </summary>
    public int Page {private get; init; }
    /// <summary>
    ///  Gets or sets the page size.
    /// </summary>
    public int PageSize {private get; init; }
    
    /// <summary>
    /// Gets the skip.
    /// </summary>
    /// <value>The skip.</value>
    public int Skip => (this.Page - 1) * this.PageSize;

    /// <summary>
    /// Gets the take.
    /// </summary>
    /// <value>The take.</value>
    public int Take => this.PageSize;

}