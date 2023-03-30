namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog
{
    using Assistants;
    using Interfaces;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Spoon.NuGet.Interceptors.LogInterceptor;

    /// <summary>
    ///     Class PermissionBehaviour. This class cannot be inherited.
    ///     Implements the <see cref="IPipelineBehavior{TRequest,TResponse}" />.
    /// </summary>
    /// <typeparam name="TRequest">The type of the t request.</typeparam>
    /// <typeparam name="TResponse">The type of the t response.</typeparam>
    /// <seealso cref="IPipelineBehavior{TRequest, TResponse}" />
    [LogInterceptorDefaultLogLevel(LogLevel.Debug)]
    public sealed class AuditLogPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        ///     The claim manager.
        /// </summary>
        private readonly IAuditLogService _auditLogService;

        private readonly IAuditLogBehaviourAssistant _logBehaviourAssistant;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuditLogPipelineBehaviour{TRequest,TResponse}" /> class.
        /// </summary>
        /// <param name="auditLogService">The claim manager.</param>
        /// <param name="logBehaviourAssistant"></param>
        public AuditLogPipelineBehaviour(IAuditLogService auditLogService, IAuditLogBehaviourAssistant logBehaviourAssistant)
        {
            this._auditLogService = auditLogService;
            this._logBehaviourAssistant = logBehaviourAssistant;
        }

        /// <summary>
        ///     Pipeline handler. Perform any additional behavior and await the <paramref name="next" /> delegate as necessary.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="next">
        ///     Awaitable delegate for the next action in the pipeline. Eventually this delegate represents the
        ///     handler.
        /// </param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task returning the <typeparamref name="TResponse" />.</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!this._logBehaviourAssistant.HasPipelineBehaviorAuditLog(request))
            {
                return await next();
            }

            if (this._logBehaviourAssistant.HasAuditLogExcludeAttribute<TRequest>())

            {
                return await next();
            }

            var dateTime = this._logBehaviourAssistant.GetAuditLogTime();

            var currentRequest = typeof(TRequest).Name;

            var contextUserId = this._logBehaviourAssistant.GetUserId();

            var contextIpAddress = this._logBehaviourAssistant.GetIpAddress();
            if (!this._logBehaviourAssistant.IsAuditLogIpAddressAllowed())
            {
                contextIpAddress = "***.****.****.****";
            }

            var contextLocation = this._logBehaviourAssistant.GetLocation();
            if (!this._logBehaviourAssistant.IsAuditLogLocationAllowed())
            {
                contextLocation = "**********";
            }

            var auditLogMessage = new AuditLogMessage
            {
                Event = currentRequest,
                UserId = contextUserId,
                IpAddress = contextIpAddress,
                Location = contextLocation,
                DateTime = dateTime,
            };

            await this._auditLogService.SendAsync(auditLogMessage);

            return await next();
        }
    }
}