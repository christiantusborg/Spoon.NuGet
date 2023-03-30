namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Interfaces.DefaultImplementation
{
    /// <summary>
    /// Class AuditContextManager.
    /// Implements the <see cref="IAuditContextManager" />
    /// </summary>
    /// <seealso cref="IAuditContextManager" />
    public class AuditContextManagerNothingDefault: IAuditContextManager
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetUserId()
        {
            return string.Empty;
        }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns>string.</returns>
        public string GetIpAddress()
        {
            return string.Empty;
        }
    }
}