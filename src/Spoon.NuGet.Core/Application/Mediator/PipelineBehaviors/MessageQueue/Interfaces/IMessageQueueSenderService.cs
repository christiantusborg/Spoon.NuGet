namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Interfaces;

/// <summary>
///   Interface IMessageQueueService
/// </summary>
public interface IMessageQueueSenderService
{
    /// <summary>
    ///  Sends the message.
    /// </summary>
    /// <param name="message"></param>
    public Task SendMessageAsync(IQueueMessage message);
}