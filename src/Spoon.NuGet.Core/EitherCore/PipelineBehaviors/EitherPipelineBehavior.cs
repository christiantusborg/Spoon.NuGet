namespace Spoon.NuGet.Core.EitherCore.PipelineBehaviors;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Contracts;
using Enums;
using Exceptions;
using MediatR;

/// <summary>
///     Pipeline behavior that handles the response when the response is of type Either{T}.
///     If the response is an EitherError, an EitherException is thrown instead of returning the result.
/// </summary>
/// <typeparam name="TRequest">The type of the request being handled.</typeparam>
/// <typeparam name="TResponse">The type of the response from the request.</typeparam>
public sealed class EitherPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    ///     Handles the request and response.
    /// </summary>
    /// <param name="request">The request being handled.</param>
    /// <param name="next">The next handler in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token for the request.</param>
    /// <returns>The response from the request.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var responseResult = await next();

        if (typeof(TResponse).GetGenericTypeDefinition() != typeof(Either<>))
            return responseResult;

        var responseResultType = responseResult!.GetType();

        var eitherEnum = GetEitherEnum(responseResultType, responseResult);

        if (eitherEnum != EitherEnum.EitherError)
            return responseResult;

        var eitherError = GetEitherError(responseResultType, responseResult);

        var ext = new EitherException(
            request,
            eitherError.Origin,
            eitherError.Message,
            eitherError.StatusCode);

        var responseType = next.GetType();
        var responseInnerType = responseType.GetGenericArguments()[0];

        var result = (TResponse)Activator.CreateInstance(responseInnerType, ext) !;

        return result;
    }

    /// <summary>
    ///     Gets the EitherError message from the response.
    /// </summary>
    /// <param name="resultType">The type of the response.</param>
    /// <param name="result">The response object.</param>
    /// <returns>The EitherError message.</returns>
    private static EitherErrorMessage GetEitherError(IReflect resultType, [DisallowNull] TResponse result)
    {
        var eitherErrorField =
            resultType.GetField("EitherError", BindingFlags.NonPublic | BindingFlags.Instance);

        var eitherError = (EitherErrorMessage)eitherErrorField!.GetValue(result) !;
        return eitherError;
    }

    /// <summary>
    ///     Gets the EitherEnum from the response.
    /// </summary>
    /// <param name="resultType">The type of the response.</param>
    /// <param name="result">The response object.</param>
    /// <returns>The EitherEnum value.</returns>
    private static EitherEnum GetEitherEnum(IReflect resultType, [DisallowNull] TResponse result)
    {
        var eitherEnumField =
            resultType.GetField("EitherEnum", BindingFlags.NonPublic | BindingFlags.Instance);

        var eitherEnum = (EitherEnum)eitherEnumField!.GetValue(result) !;
        return eitherEnum;
    }
}