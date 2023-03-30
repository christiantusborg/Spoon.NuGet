namespace Spoon.NuGet.Mediator.Interfaces;

using MediatR;

/// <summary>
/// Interface IHandleableRequest
/// Extends the <see cref="IRequest" />.
/// </summary>
/// <typeparam name="TRequest">The type of the t request.</typeparam>
/// <typeparam name="THandler">The type of the t handler.</typeparam>
/// <typeparam name="TResponse">The type of the t response.</typeparam>
/// <seealso cref="IRequest{TResponse}" />
public interface IHandleableRequest<TRequest, THandler, out TResponse> : IRequest<TResponse>
    where TRequest : IRequest<TResponse>
    where THandler : IRequestHandler<TRequest, TResponse>
{
}