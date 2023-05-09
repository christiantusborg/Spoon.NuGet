namespace Spoon.NuGet.Core.Presentation;

using System.Reflection;
using Domain;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Class ApiBaseQueryWithSearchAndPagination.
/// </summary>
public abstract partial class ApiBaseQueryWithSearchAndPagination
{
    private readonly List<Filter> _filters = new();

    /// <summary>
    /// </summary>
    public List<Filter> Filters
    {
        get => this._filters;
        init => this._filters = value;
    }

    ///// <summary>
    ///// Gets the skip.
    ///// </summary>
    ///// <value>The skip.</value>
    ////[FromQuery]
    //public int Skip => (this.Page - 1) * this.PageLength;

    ///// <summary>
    ///// Gets the take.
    ///// </summary>
    ///// <value>The take.</value>
    ////[FromQuery]
    //public int Take => this.PageLength;

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
//}
//public abstract partial class ApiBaseQueryWithSearchAndPagination
//{
    //}
    ////namespace Getinge.NuGet.Core.Application.Mediator
    ////{
    ////    public class BaseRequestPaging
    ////    {
    ////        public int Page { get; set; } = 1;
    ////        public int PageLength { get; set; } = 50;
    ////    }
    ////    public class BaseRequestSearchAndPaging : BaseRequestPaging
    ////    {
    ////        public bool IncludeDeleteSoftd { get; set; }
    ////    }
    ////}

    //namespace Getinge.WebApiHelper.SharedInfo
    //{
    //using Microsoft.AspNetCore.Http;
    //using System.Reflection;
    //using System.Threading.Tasks;
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public interface IExtensionBinder<TSelf> where TSelf : IExtensionBinder<TSelf>
    {
        /// <summary>
        /// The method discovered by RequestDelegateFactory on types used as parameters of route
        /// handler delegates to support custom binding.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/>.</param>
        /// <param name="parameter">The <see cref="ParameterInfo"/> for the parameter being bound to.</param>
        /// <returns>The value to assign to the parameter.</returns>
        static abstract ValueTask<TSelf?> BindAsync(HttpContext context, ParameterInfo parameter);
    }
}