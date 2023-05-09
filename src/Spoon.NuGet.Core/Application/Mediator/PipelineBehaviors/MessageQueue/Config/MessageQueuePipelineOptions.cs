namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Config;

using Assistants;
using Interfaces;

/// <summary>
///   Class MessageQueuePipelineOptions.
/// </summary>
public class MessageQueuePipelineOptions
{
   /// <summary>
   ///  Gets the message queue pipeline assistant options.
   /// </summary>
   public bool UseLogInterceptor { get; set; } = true;

   /// <summary>
   ///  Gets the message queue pipeline assistant options.
   /// </summary>
   public IMessageQueueBehaviourAssistant? OverwriteBehaviourAssistant { get; set; } = null;

   /// <summary>
   ///  Gets the message queue pipeline assistant options.
   /// </summary>
   public IMessageQueueSenderService? MessageQueueServiceImplementation { get; set; } = null;
   
   /// <summary>
   ///  Gets the message queue pipeline assistant options.
   /// </summary>
   public MessageQueueDefaultConfig? DefaultConfig { get; set; }
}