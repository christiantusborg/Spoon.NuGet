namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog
{
    using Assistants;
    using Interceptors.LogInterceptor;
    using Interfaces;
    using Interfaces.DefaultImplementation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Class ServiceCollectionExtensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the AuditLog pipeline behaviour.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddAuditLogPipelineBehaviour(this IServiceCollection services) 
        {
            services.AddInterceptedSingleton<IAuditLogBehaviourAssistant, AuditLogBehaviourAssistant, LogInterceptorDefault>();
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditLogPipelineBehaviour<,>));

            return services;
        }
        
        /// <summary>
        ///     Adds the AuditLog pipeline behaviour default config .
        ///     AuditLogServiceNothingDefault - Do nothing.
        ///     AuditContextManagerNothingDefault - Do nothing.
        ///     AuditLocationServiceNothingDefault - Do nothing.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddAuditLogPipelineBehaviourDefault(this IServiceCollection services) 
        {
            services.AddTransient<IAuditLogService, AuditLogServiceNothingDefault>();
            services.AddTransient<IAuditContextManager, AuditContextManagerNothingDefault>();
            services.AddTransient<IAuditLocationService, AuditLocationServiceNothingDefault>();
            
            services.AddInterceptedSingleton<IAuditLogBehaviourAssistant, AuditLogBehaviourAssistant, LogInterceptorDefault>();
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditLogPipelineBehaviour<,>));

            return services;
        }        
    }
}