namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Interfaces.DefaultImplementation;

using Config;
using LogInterceptor;
using MassTransit;
using Microsoft.Extensions.Logging;

/// <summary>
///  Class MessageQueueService.
/// </summary>

[LogInterceptorDefaultLogLevel(LogLevel.Debug)]
public class MessageQueueDefaultSenderService : IMessageQueueSenderService, IDisposable
{
    private readonly IBusControl _busControl;

    /// <summary>
    ///  Initializes a new instance of the <see cref="MessageQueueDefaultSenderService"/> class.
    /// </summary>
    /// <param name="config"></param>
    public MessageQueueDefaultSenderService(MessageQueueDefaultConfig config)
    {
        this._busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(config.RabbitMqUri), h =>
            {
                h.Username(config.RabbitMqUserName);
                h.Password(config.RabbitMqPassword);
            });
        });

        this._busControl.Start();
    }

    /// <summary>
    ///  Sends the message asynchronous.
    /// </summary>
    /// <param name="message"></param>
    public async Task SendMessageAsync(IQueueMessage message)
    {
        var endpointUri = new Uri($"{this._busControl.Address}/{message.MessageType}");

        var sendEndpoint = await this._busControl.GetSendEndpoint(endpointUri);

        await sendEndpoint.Send(message);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.  
    /// </summary>
    public void Dispose()
    {
        this._busControl?.Stop();
    }
}

