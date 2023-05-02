namespace Spoon.NuGet.Core.ExceptionLogFilters;

using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;


/// <summary>
/// This class provides an exception filter that logs any unhandled exceptions.
/// </summary>
public class ExceptionLogFilter : ExceptionFilterAttribute
{
    /// <summary>
    /// Overrides the base implementation of <see cref="ExceptionFilterAttribute.OnException"/> to log the unhandled exception.
    /// </summary>
    /// <param name="context">The exception context.</param>
    public override void OnException(ExceptionContext context)
    {
        Log.Error("ExceptionLogFilter {0}", context.Exception);
    }
}
