namespace Spoon.NuGet.Core.EitherCore.Extensions;

using Enums;
using Mapster;
using Microsoft.AspNetCore.Mvc;

/// <summary>
///     Provides extension methods for converting an <see cref="Either{T}" /> to an <see cref="IActionResult" />.
/// </summary>
public static class EitherActionResultExtensions
{
    /// <summary>
    ///     Converts the specified <see cref="Either{T}" /> to an <see cref="IActionResult" />.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    /// <param name="either">The <see cref="Either{T}" /> instance to convert.</param>
    /// <param name="noContent">
    ///     Whether to return a <see cref="NoContentResult" /> instead of an <see cref="ObjectResult" />
    ///     when the response object is null.
    /// </param>
    /// <returns>An <see cref="IActionResult" /> instance representing the <see cref="Either{T}" />.</returns>
    public static IActionResult ToActionResult<TResponse>(this Either<TResponse> either, bool noContent = false)
    {
        if (either.EitherEnum != EitherEnum.Success)
            return either.GetFaulted().ToActionResult();

        if (noContent)
            return new NoContentResult();

        if (either.success is null)
            throw new ArgumentNullException("SilverGetinge.NuGet.Basic.Exceptions.ExceptionBase" + nameof(either.success));

        var x = typeof(TResponse).GetProperties();


        if (x.Length > 0)
        {
            var response = either.success.Adapt<TResponse>();


            var successResult = new ObjectResult(BaseHttpStatusCodes.Status200OK)
            {
                StatusCode = BaseHttpStatusCodes.Status200OK,
                Value = response,
            };
            return successResult;
        }

        var createdObject = Activator.CreateInstance(typeof(TResponse));
        return new ObjectResult(BaseHttpStatusCodes.Status200OK)
        {
            StatusCode = BaseHttpStatusCodes.Status200OK,
            Value = createdObject,
        };
    }
}