    namespace Spoon.NuGet.EitherCore.Extensions;

using Exceptions;
using Microsoft.AspNetCore.Mvc;

/// <summary>
///     Provides extension methods for converting an <see cref="Either{T}" /> to an <see cref="IActionResult" />.
/// </summary>
public static class EitherExceptionActionResultExtensions
{
    /// <summary>
    ///     Converts the specified <see cref="EitherException" /> instance to an <see cref="IActionResult" /> instance.
    /// </summary>
    /// <param name="eitherException">The <see cref="EitherException" /> instance to convert.</param>
    /// <returns>An <see cref="IActionResult" /> instance representing the <paramref name="eitherException" />.</returns>
    public static IActionResult ToActionResult(this EitherException eitherException)
    {
        var expandoObjCollection = eitherException.ExpandoObjCollection();

        var httpStatusCode = GetHttpStatusCode(eitherException);
        var result = new ObjectResult(httpStatusCode)
        {
            StatusCode = httpStatusCode,
            Value = expandoObjCollection,
        };

        return result;
    }

    /// <summary>
    ///     Gets the HTTP status code associated with the specified <see cref="Exception" /> instance.
    /// </summary>
    /// <param name="exception">The <see cref="Exception" /> instance to retrieve the status code for.</param>
    /// <returns>The HTTP status code associated with the <paramref name="exception" />, or 500 if no status code is found.</returns>
    private static int GetHttpStatusCode(Exception exception)
    {
        var httpStatusCode = 500;
        if (exception.Data.Contains("HttpStatusCode"))
            httpStatusCode = (int)(exception.Data["HttpStatusCode"] ?? 500);
        return httpStatusCode;
    }
}