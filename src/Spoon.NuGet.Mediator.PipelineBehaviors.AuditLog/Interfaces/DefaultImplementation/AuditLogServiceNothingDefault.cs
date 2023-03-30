namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Interfaces.DefaultImplementation
{
    /// <summary>
    /// Class AuditLogService.
    /// Implements the <see cref="IAuditLogService" />
    /// </summary>
    /// <seealso cref="IAuditLogService" />
    public class AuditLogServiceNothingDefault : IAuditLogService
    {
        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="nessage">The nessage.</param>
        /// <returns>Task.</returns>
        public Task SendAsync(AuditLogMessage nessage)
        {
            return Task.CompletedTask;
        }
    }
}