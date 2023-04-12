namespace Spoon.NuGet.Mediator.PipelineBehaviors.Validation
{
    using Assistants;
    using EitherCore.PipelineBehaviors;
    using FluentValidation;
    using Interceptors.LogInterceptor;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Options;

    /// <summary>
    ///     Class ServiceCollectionExtensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the validation pipeline behaviour.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction"></param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddValidationPipelineBehaviour(this IServiceCollection services, Action<ValidationPipelineOptions> optionsAction = null)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddValidatorsFromAssemblies(assemblies);

            if (services.Any(d => d.ImplementationType == typeof(EitherPipelineBehavior<,>)))
            {
                throw new InvalidOperationException("EitherPipelineBehavior<,> is was registered before ValidationPipelineBehaviour<,>");
            }

            if (services.Any(d => d.ImplementationType == typeof(ValidationPipelineBehaviour<,>)))
            {
                throw new InvalidOperationException("ValidationPipelineBehaviour<,> is was registered already");
            }

            var options = new ValidationPipelineOptions();
            optionsAction?.Invoke(options);

            if(!options.ValidationPipelineAssistantOptions.ConfigManual) 
            {
                if(options.ValidationPipelineAssistantOptions.UseLogInterceptor)
                    services.AddInterceptedSingleton<IValidationPipelineAssistant, ValidationPipelineAssistant, LogInterceptorDefault>();
                else
                    services.AddSingleton<IValidationPipelineAssistant, ValidationPipelineAssistant>();
            }

            if(!options.SupportAssistantOptions.ConfigManual) 
            {
                if(options.SupportAssistantOptions.UseLogInterceptor)
                    services.AddInterceptedSingleton<ISupportAssistant, SupportAssistant, LogInterceptorDefault>();
                else
                    services.AddSingleton<ISupportAssistant, SupportAssistant>();
            }
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EitherPipelineBehavior<,>));

            return services;
        }
    }
}