namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue;

using Assistants;
using Interfaces;
using LogInterceptor;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
///     Class PermissionBehaviour. This class cannot be inherited.
///     Implements the <see cref="IPipelineBehavior{TRequest,TResponse}" />.
/// </summary>
/// <typeparam name="TRequest">The type of the t request.</typeparam>
/// <typeparam name="TResponse">The type of the t response.</typeparam>
/// <seealso cref="IPipelineBehavior{TRequest, TResponse}" />
[LogInterceptorDefaultLogLevel(LogLevel.Debug)]
public sealed class MessageQueuePipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IMessageQueueSenderService _messageQueueService;
    private readonly IMessageQueueBehaviourAssistant _messageQueueBehaviourAssistant;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MessageQueuePipelineBehaviour{TRequest,TResponse}" /> class.
    /// </summary>
    /// <param name="messageQueueService"></param>
    /// <param name="messageQueueBehaviourAssistant"></param>
    public MessageQueuePipelineBehaviour(IMessageQueueSenderService messageQueueService, IMessageQueueBehaviourAssistant messageQueueBehaviourAssistant)
    {
        this._messageQueueService = messageQueueService;
        this._messageQueueBehaviourAssistant = messageQueueBehaviourAssistant;
    }

    /// <summary>
    ///     Pipeline handler. Perform any additional behavior and await the <paramref name="next" /> delegate as necessary.
    /// </summary>
    /// <param name="request">Incoming request.</param>
    /// <param name="next">
    ///     Awaitable delegate for the next action in the pipeline. Eventually this delegate represents the
    ///     handler.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Awaitable task returning the <typeparamref name="TResponse" />.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        if (!this._messageQueueBehaviourAssistant.HasPipelineBehaviorMessageQueue(request))
        {
            return response;
        }

        if (this._messageQueueBehaviourAssistant.HasMessageQueueExcludeAttribute<TResponse>())
        {
            return response;
        }

        if (!this._messageQueueBehaviourAssistant.GetEitherResponse(response, out var responseRaw))
            return response;

        if(responseRaw is null)
            return response;
        
        var serializedResponse = this._messageQueueBehaviourAssistant.GetSerializedResponse(responseRaw);
        
        var message = new QueueMessage
        {
            Message = serializedResponse,
            Sender = "",
            MessageType = responseRaw.GetType().Name ,
        };
        
        await this._messageQueueService.SendMessageAsync(message);

        return response;
    }
}