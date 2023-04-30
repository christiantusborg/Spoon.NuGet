namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue;

using Interfaces;

/// <summary>
///  Class MessageQueuePipelineOptions.
/// </summary>
public class QueueMessage : IQueueMessage
{
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string Sender { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string Message { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string MessageType { get; set; }
}