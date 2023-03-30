namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Interfaces.DefaultImplementation
{
    /// <summary>
    /// Class AuditLocationService.
    /// Implements the <see cref="IAuditLocationService" />
    /// </summary>
    /// <seealso cref="IAuditLocationService" />
    public class AuditLocationServiceNothingDefault : IAuditLocationService
    {
        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>System.String.</returns>
        public string GetLocation(string ipAddress)
        {
            return string.Empty;
        }
    }
}