namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Interfaces;

/// <summary>
///  Interface IMessageQueueSenderService.
/// </summary>
public interface IQueueMessage
{
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public string Sender { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public string MessageType { get; set; }
}