namespace Spoon.NuGet.EitherCore;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PipelineBehaviors;

/// <summary>
///     Extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the <see cref="EitherPipelineBehavior{TRequest,TResponse}" /> to the service collection as a transient
    ///     instance.
    /// </summary>
    /// <param name="services">The service collection to add the behavior to.</param>
    /// <returns>The service collection with the behavior added.</returns>
    public static IServiceCollection AddEitherPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EitherPipelineBehavior<,>));

        return services;
    }
}