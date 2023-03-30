namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Interfaces
{

    /// <summary>
    /// Interface IAuditContextManager
    /// </summary>
    public interface IAuditContextManager
    {

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
    }
}