namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue;

using Assistants;
using Config;
using Interfaces;
using Interfaces.DefaultImplementation;
using LogInterceptor;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for adding the MessageQueue pipeline behaviour to the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the MessageQueue pipeline behaviour.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="optionsAction">The optional pipeline options.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddMessageQueuePipelineBehaviour(this IServiceCollection services, Action<MessageQueuePipelineOptions>? optionsAction = null)
    {
        // Create a new instance of MessageQueuePipelineOptions and apply any options provided by optionsAction
        var options = new MessageQueuePipelineOptions();
        optionsAction?.Invoke(options);
        
        // Ensure that an IMessageQueueBehaviourAssistant is specified, either through options or a default implementation
        if(options.OverwriteBehaviourAssistant is null )
            options.OverwriteBehaviourAssistant = new MessageQueueDefaultBehaviourAssistant();
        
        // Add the behaviour assistant to the service collection
        AddBehaviourAssistant(services, options);

        // Ensure that an IMessageQueueSenderService is specified, either through options or by getting the configuration from the service provider
        if (options.MessageQueueServiceImplementation is null)
        {
            // Gets the MessageQueueDefaultConfig from the configuration.
            var config = GetMessageQueueDefaultConfig(services);

            // Create a new instance of MessageQueueDefaultSenderService using the configuration
            options.MessageQueueServiceImplementation = new MessageQueueDefaultSenderService(config);
        }

        // Add the message queue sender service implementation to the service collection
        AddMessageQueueServiceImplementation(services, options);

        // Add the MessageQueuePipelineBehaviour to the service collection as a transient IPipelineBehavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MessageQueuePipelineBehaviour<,>));
        
        return services;
    }

    /// <summary>
    ///  Gets the MessageQueueDefaultConfig from the configuration.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static MessageQueueDefaultConfig GetMessageQueueDefaultConfig(IServiceCollection services)
    {
        // get an instance of the IServiceProvider
        var serviceProvider = services.BuildServiceProvider();

        // get the IConfiguration instance from the IServiceProvider
        var configuration = serviceProvider.GetService<IConfiguration>();

        if (configuration is null)
            throw new Exception("IConfiguration is null");

        // Get the MessageQueueDefaultConfig from the configuration
        var config = configuration.GetSection("MessageQueueDefaultConfig").Get<MessageQueueDefaultConfig>();

        if (config is null)
            throw new Exception("MessageQueueDefaultConfig is null");
        return config;
    }

    /// <summary>
    /// Adds the IMessageQueueBehaviourAssistant to the service collection, either as a singleton or an intercepted singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="options">The pipeline options.</param>    
    private static void AddBehaviourAssistant(IServiceCollection services, MessageQueuePipelineOptions options)
    {
            // Add the IMessageQueueBehaviourAssistant as a singleton or an intercepted singleton, depending on whether log interception is enabled
            if (options.UseLogInterceptor)
            {
                // Add the intercepted singleton
                services.AddInterceptedSingleton<IMessageQueueBehaviourAssistant, LogInterceptorDefault>(options.OverwriteBehaviourAssistant!);
            }
            else
            {
                // Add the singleton
                services.AddSingleton(options.OverwriteBehaviourAssistant!);
            }
    }

    /// <summary>
    /// Adds the IMessageQueueSenderService to the service collection, either as a singleton or an intercepted singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="options">The pipeline options.</param>
    private static void AddMessageQueueServiceImplementation(IServiceCollection services, MessageQueuePipelineOptions options)
    {
        if (options.UseLogInterceptor)
        {
            // Add the intercepted singleton
            services.AddInterceptedSingleton<IMessageQueueSenderService, LogInterceptorDefault>(options.MessageQueueServiceImplementation!);
        }
        else
        {
            // Add the singleton
            services.AddSingleton(options.MessageQueueServiceImplementation!);
        }
    }
}