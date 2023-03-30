namespace Spoon.NuGet.Core
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides extension methods for the IServiceCollection interface to register core dependencies.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds core dependencies to the service collection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the dependencies to.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IMockbleDateTime, MockbleDateTimeDefault>();
            services.AddTransient<IMockbleGuidGenerator, MockbleGuidGenerator>();
            return services;
        }
    }
}