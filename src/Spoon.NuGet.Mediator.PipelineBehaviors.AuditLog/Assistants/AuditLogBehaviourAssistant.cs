namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Assistants
{
    using Attributes;
    using Core;
    using Interceptors.LogInterceptor;
    using Interfaces;
    using Mediator.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// </summary>
    [LogInterceptorDefaultLogLevel(LogLevel.Debug)]
    public class AuditLogBehaviourAssistant : IAuditLogBehaviourAssistant
    {
        private readonly IAuditContextManager _auditContextManager;
        private readonly IAuditLocationService _auditLocationService;
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly IConfiguration _configuration;


        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogBehaviourAssistant"/> class.
        /// </summary>
        /// <param name="auditContextManager">The audit context manager.</param>
        /// <param name="auditLocationService">The audit location service.</param>
        /// <param name="mockbleDateTime">The mockble date time.</param>
        /// <param name="configuration"></param>
        public AuditLogBehaviourAssistant(IAuditContextManager auditContextManager, IAuditLocationService auditLocationService, IMockbleDateTime mockbleDateTime, IConfiguration configuration)
        {
            this._auditContextManager = auditContextManager;
            this._auditLocationService = auditLocationService;
            this._mockbleDateTime = mockbleDateTime;
            this._configuration = configuration;
        }

        /// <summary>
        /// Determines whether [has pipeline behavior audit log] [the specified request].
        /// </summary>
        /// <typeparam name="TRequest">The type of the t request.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if [has pipeline behavior audit log] [the specified request]; otherwise, <c>false</c>.</returns>
        public bool HasPipelineBehaviorAuditLog<TRequest>(TRequest request)
        {
            var has = request is IPipelineBehaviorAuditLog;
            return has;
        }

        /// <summary>
        /// Determines whether [has audit log exclude attribute].
        /// </summary>
        /// <typeparam name="TRequest">The type of the t request.</typeparam>
        /// <returns><c>true</c> if [has audit log exclude attribute]; otherwise, <c>false</c>.</returns>
        public bool HasAuditLogExcludeAttribute<TRequest>()
        {
            var has = typeof(TRequest).IsDefined(typeof(AuditLogExcludeAttribute), true);
            return has;
        }

        /// <summary>
        /// Gets the audit log time.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime GetAuditLogTime()
        {
            return this._mockbleDateTime.UtcNow;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetUserId()
        {
            return this._auditContextManager.GetUserId();
        }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetIpAddress()
        {
            return this._auditContextManager.GetIpAddress();
        }

        /// <summary>
        /// Determines whether [is audit log ip address allowed].
        /// </summary>
        /// <returns><c>true</c> if [is audit log ip address allowed]; otherwise, <c>false</c>.</returns>
        public bool IsAuditLogIpAddressAllowed()
        {
            var excludeIpAddress = this._configuration.GetSection("AuditLogPipeline:ExcludeIpAddress").Value;

            if (!Boolean.TryParse(excludeIpAddress, out var excludeIpAddressBool))
                return true;
            
            return excludeIpAddressBool;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetLocation()
        {
            var ipAddress = this._auditContextManager.GetIpAddress();
            return this._auditLocationService.GetLocation(ipAddress);
        }

        /// <summary>
        /// Determines whether [is audit log location allowed].
        /// </summary>
        /// <returns><c>true</c> if [is audit log location allowed]; otherwise, <c>false</c>.</returns>
        public bool IsAuditLogLocationAllowed()
        {
            var locationAllowed = this._configuration.GetSection("AuditLogPipeline:LocationAllowed").Value;

            if (!Boolean.TryParse(locationAllowed, out var locationAllowedBool))
                return true;
            
            return locationAllowedBool;
        }
    }
}