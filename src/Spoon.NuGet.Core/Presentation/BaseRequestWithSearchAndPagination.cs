namespace Spoon.NuGet.Core.Presentation;

using System.Reflection;
using Domain;
using Microsoft.AspNetCore.Http;

/// <summary>
///     Class BaseRequestWithSearchAndPagination.
/// </summary>
public abstract class BaseRequestWithSearchAndPagination
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseRequestWithSearchAndPagination" /> class.
    /// </summary>
    public List<Filter>? Filters { get; init; }

    /// <summary>
    ///     Gets or sets the page.
    /// </summary>
    public List<Sorting>? SortField { get; init; }

    /// <summary>
    ///     Gets or sets the Include deleted.
    /// </summary>
    public bool IncludeDeleted { get; init; }

    /// <summary>
    ///     Gets or sets the page.
    /// </summary>
    public int Page { get; init; }

    /// <summary>
    ///     Gets or sets the length of the page.
    /// </summary>
    public int PageLength { get; init; }


    /// <summary>
    ///     Sets the page.
    /// </summary>
    /// <summary>
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public interface IExtensionBinder<TSelf> where TSelf : IExtensionBinder<TSelf>
    {
        /// <summary>
        ///     The method discovered by RequestDelegateFactory on types used as parameters of route
        ///     handler delegates to support custom binding.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext" />.</param>
        /// <param name="parameter">The <see cref="ParameterInfo" /> for the parameter being bound to.</param>
        /// <returns>The value to assign to the parameter.</returns>
        static abstract ValueTask<TSelf?> BindAsync(HttpContext context, ParameterInfo parameter);
    }
}