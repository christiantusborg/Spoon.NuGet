namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Config;

/// <summary>
///  Class MessageQueuePipelineOptions.
/// </summary>
public class MessageQueueDefaultConfig
{
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string RabbitMqUri { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string RabbitMqUserName { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string RabbitMqPassword { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required string RabbitMqVirtualHost { get; set; }
    /// <summary>
    ///  Gets the message queue pipeline assistant options.
    /// </summary>
    public required int RabbitMqPort { get; set; }
}