namespace Spoon.NuGet.EitherCore.Extensions;

using Exceptions;
using Microsoft.AspNetCore.Http;

/// <summary>
///     Provides extension methods for working with <see cref="EitherException" /> instances to create
///     <see cref="IResult" /> objects.
/// </summary>
public static class EitherExceptionResultExtensions
{
    /// <summary>
    ///     Converts the specified <see cref="EitherException" /> instance to an <see cref="IResult" /> object.
    /// </summary>
    /// <param name="eitherException">The <see cref="EitherException" /> instance to convert.</param>
    /// <returns>An <see cref="IResult" /> object representing the data from the <paramref name="eitherException" />.</returns>
    public static IResult ToResult(this EitherException eitherException)
    {
        var expandoObjCollection = eitherException.ExpandoObjCollection();

        var httpStatusCode = GetHttpStatusCode(eitherException);

        var result = Results.Json(expandoObjCollection, null, null, httpStatusCode);

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