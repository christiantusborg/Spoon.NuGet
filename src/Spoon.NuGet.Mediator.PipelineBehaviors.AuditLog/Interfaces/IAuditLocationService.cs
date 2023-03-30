namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Interfaces
{
    /// <summary>
    /// Interface IAuditLocationService
    /// </summary>
    public interface IAuditLocationService
    {

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>System.String.</returns>
        string GetLocation(string ipAddress);
    }
}