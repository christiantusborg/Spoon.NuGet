namespace Spoon.NuGet.Core.Presentation;

using Microsoft.AspNetCore.OutputCaching;

/// <summary>
/// 
/// </summary>
public static class OutputCacheBuilderExtensions
{  /// <summary>
       /// Maps all endpoints that implement the <see cref="ICacheMarker"/> interface from the specified types.
       /// </summary>
       /// <param name="app">The <see cref="OutputCacheOptions"/> instance to map endpoints to.</param>
       /// <param name="types">The list of <see cref="Type"/> instances to scan for endpoint implementations.</param>
       /// <returns>The <see cref="OutputCacheOptions"/> instance.</returns>
        public static OutputCacheOptions AddCacheOptions(this OutputCacheOptions app, params Type[] types)
    {
        var markerType = typeof(ICacheMarker);
        foreach (var type in types)
        {
            var assembly = type.Assembly;
            foreach (var exportedType in assembly.ExportedTypes.Where(x => markerType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract))
            {
                var endpointMarkerInstance = (ICacheMarker)Activator.CreateInstance(exportedType)!;
                endpointMarkerInstance.AddCacheOptions(app);
            }
        }

        // Return the endpoint route builder.
        return app;
    }
}
