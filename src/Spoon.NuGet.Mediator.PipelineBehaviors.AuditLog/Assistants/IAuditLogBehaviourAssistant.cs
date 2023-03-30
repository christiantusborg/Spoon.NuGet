namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Assistants
{
    /// <summary>
    /// Interface IAuditLogBehaviourAssistant
    /// </summary>
    public interface IAuditLogBehaviourAssistant
    {
        /// <summary>
        /// Determines whether [has pipeline behavior audit log] [the specified request].
        /// </summary>
        /// <typeparam name="TRequest">The type of the t request.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if [has pipeline behavior audit log] [the specified request]; otherwise, <c>false</c>.</returns>
        bool HasPipelineBehaviorAuditLog<TRequest>(TRequest request);

        /// <summary>
        /// Determines whether [has audit log exclude attribute].
        /// </summary>
        /// <typeparam name="TRequest">The type of the t request.</typeparam>
        /// <returns><c>true</c> if [has audit log exclude attribute]; otherwise, <c>false</c>.</returns>
        bool HasAuditLogExcludeAttribute<TRequest>();

        /// <summary>
        /// Gets the audit log time.
        /// </summary>
        /// <returns>DateTime.</returns>
        DateTime GetAuditLogTime();

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetUserId();

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetIpAddress();

        /// <summary>
        /// Determines whether [is audit log ip address allowed].
        /// </summary>
        /// <returns><c>true</c> if [is audit log ip address allowed]; otherwise, <c>false</c>.</returns>
        bool IsAuditLogIpAddressAllowed();

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetLocation();

        /// <summary>
        /// Determines whether [is audit log location allowed].
        /// </summary>
        /// <returns><c>true</c> if [is audit log location allowed]; otherwise, <c>false</c>.</returns>
        bool IsAuditLogLocationAllowed();
    }
}