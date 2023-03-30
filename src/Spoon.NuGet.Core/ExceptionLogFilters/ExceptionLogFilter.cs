namespace Spoon.NuGet.Core.ExceptionLogFilters;

using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

/// <summary>
/// Class ExceptionLogFilter.
/// Implements the <see cref="ExceptionFilterAttribute" />.
/// </summary>
/// <seealso cref="ExceptionFilterAttribute" />
public class ExceptionLogFilter : ExceptionFilterAttribute
{
    /// <summary>
    /// Called when [exception].
    /// </summary>
    /// <param name="context">The context.</param>
    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        Log.Error("ExceptionLogFilter {0}", context.Exception);
    }
}