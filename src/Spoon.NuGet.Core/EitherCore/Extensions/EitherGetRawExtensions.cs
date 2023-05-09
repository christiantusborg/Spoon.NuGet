namespace Spoon.NuGet.Core.EitherCore.Extensions;

using Enums;
using Microsoft.AspNetCore.Http;

/// <summary>
///     Provides extension methods for working with
///     <see>
///         <cref>Either{TLeft, TRight}</cref>
///     </see>
///     instances to get the raw response.
/// </summary>
public static class EitherGetRawExtensions
{
    /// <summary>
    ///     Attempts to get the raw response from the specified
    ///     <see>
    ///         <cref>Either{TLeft, TRight}</cref>
    ///     </see>
    ///     instance and returns a value indicating whether the operation was successful.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="either">
    ///     The
    ///     <see>
    ///         <cref>Either{TLeft, TRight}</cref>
    ///     </see>
    ///     instance to get the response from.
    /// </param>
    /// <param name="responseRaw">
    ///     When this method returns, contains the raw response from the <paramref name="either" />
    ///     instance, or the default value of <typeparamref name="TResponse" /> if the operation was unsuccessful.
    /// </param>
    /// <param name="iResult">
    ///     When this method returns, contains an <see cref="IResult" /> instance representing the error
    ///     response, or <c>null</c> if the operation was successful.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the operation was successful and <paramref name="responseRaw" /> contains the raw response from
    ///     the <paramref name="either" /> instance; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryGetResponseRaw<TResponse>(this Either<TResponse> either, out TResponse? responseRaw, out IResult? iResult)
    {
        if (either.EitherEnum != EitherEnum.Success)
        {
            iResult = either.GetFaulted().ToResult();
            responseRaw = default;
            return false;
        }

        if (either.success is null)
            throw new ArgumentNullException("Getinge.NuGet.Core.EitherCore.Exceptions.ExceptionBase" + nameof(either.success));

        responseRaw = either.success;
        iResult = null;
        return true;
    }
}