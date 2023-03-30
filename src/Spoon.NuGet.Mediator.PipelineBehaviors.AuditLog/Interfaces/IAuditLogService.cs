namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuditLogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nessage"></param>
        /// <returns></returns>
        Task SendAsync(AuditLogMessage nessage);
    }
}