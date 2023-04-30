namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Assistants
{
    /// <summary>
    /// Interface IAuditLogBehaviourAssistant
    /// </summary>
    public interface IMessageQueueBehaviourAssistant
    {
        /// <summary>
        /// Determines whether [has pipeline behavior audit log] [the specified request].
        /// </summary>
        /// <typeparam name="TResponse">The type of the t request.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if [has pipeline behavior audit log] [the specified request]; otherwise, <c>false</c>.</returns>
        bool HasPipelineBehaviorMessageQueue<TResponse>(TResponse request);

        /// <summary>
        /// Determines whether [has audit log exclude attribute].
        /// </summary>
        /// <typeparam name="TResponse">The type of the t request.</typeparam>
        /// <returns><c>true</c> if [has audit log exclude attribute]; otherwise, <c>false</c>.</returns>
        bool HasMessageQueueExcludeAttribute<TResponse>();

        /// <summary>
        ///  Gets the either response. 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="responseRaw"></param>
        /// <returns></returns>
        bool GetEitherResponse<TResponse>(TResponse response, out object? responseRaw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseRaw"></param>
        /// <returns></returns>
        string GetSerializedResponse(object responseRaw);
    }
}