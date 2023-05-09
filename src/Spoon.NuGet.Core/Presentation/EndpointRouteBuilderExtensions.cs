namespace Spoon.NuGet.Core.Presentation;

using Microsoft.AspNetCore.Routing;

/// <summary>
/// Provides extension methods to register endpoints.
/// </summary>
public static class EndpointRouteBuilderExtensions
{
    /// <summary>
    /// Maps all endpoints that implement the <see cref="IEndpointMarker"/> interface from the specified types.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> instance to map endpoints to.</param>
    /// <param name="types">The list of <see cref="Type"/> instances to scan for endpoint implementations.</param>
    /// <returns>The <see cref="IEndpointRouteBuilder"/> instance.</returns>
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app, params Type[] types)
    {
        var markerType = typeof(IEndpointMarker);
        foreach (var type in types)
        {
            var assembly = type.Assembly;
            foreach (var exportedType in assembly.ExportedTypes.Where(x => markerType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract))
            {
                var endpointMarkerInstance = (IEndpointMarker)Activator.CreateInstance(exportedType)!;
                endpointMarkerInstance.Map(app);
            }
        }

        // Return the endpoint route builder.
        return app;
    }
}
