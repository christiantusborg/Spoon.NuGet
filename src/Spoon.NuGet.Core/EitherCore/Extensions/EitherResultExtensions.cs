namespace Spoon.NuGet.Core.EitherCore.Extensions;

using Enums;
using Mapster;
using Microsoft.AspNetCore.Http;

/// <summary>
///     Provides extension methods for working with <see cref="Either{TResponse}" /> instances and <see cref="IResult" />
///     instances.
/// </summary>
public static class EitherResultExtensions
{
    /// <summary>
    ///     Converts the specified <see cref="Either{TResponse}" /> instance to an <see cref="IResult" /> instance.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response contained in the <see cref="Either{TResponse}" /> instance.</typeparam>
    /// <param name="either">The <see cref="Either{TResponse}" /> instance to convert.</param>
    /// <param name="type">The <see cref="Type" /> to use for creating the response object.</param>
    /// <param name="noContent">
    ///     Whether to return a <see cref="Results.NoContent" /> instance if the <paramref name="either" />
    ///     instance contains no response object.
    /// </param>
    /// <returns>An <see cref="IResult" /> instance representing the data contained in the <paramref name="either" /> instance.</returns>
    public static IResult ToResult<TResponse>(this Either<TResponse> either, Type type, bool noContent = false)
    {
        if (either.EitherEnum != EitherEnum.Success)
            return either.GetFaulted().ToResult();

        if (noContent)
            return Results.NoContent();

        if (either.success is null)
            throw new ArgumentNullException("Getinge.NuGet.EitherCore.Exceptions.ExceptionBase" + nameof(either.success));

        var properties = typeof(TResponse).GetProperties();

        if (properties.Length > 0)
        {
            var responseTyped = Activator.CreateInstance(type);
            var response = either.success.Adapt(responseTyped);

            return Results.Ok(response);
        }

        var responseObject = Activator.CreateInstance(type);

        return Results.Ok(responseObject);
    }

    /// <summary>
    ///     Converts the specified <see cref="Either{TResponse}" /> instance to a <see cref="Results.NoContent" /> instance.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response contained in the <see cref="Either{TResponse}" /> instance.</typeparam>
    /// <param name="either">The <see cref="Either{TResponse}" /> instance to convert.</param>
    /// <returns>A <see cref="Results.NoContent" /> instance.</returns>
    public static IResult ToNoContent<TResponse>(this Either<TResponse> either)
    {
        if (either.EitherEnum != EitherEnum.Success)
            return either.GetFaulted().ToResult();

        return Results.NoContent();
    }
}