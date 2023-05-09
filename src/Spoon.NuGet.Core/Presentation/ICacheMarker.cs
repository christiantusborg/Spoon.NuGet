namespace Spoon.NuGet.Core.Presentation;

using Microsoft.AspNetCore.OutputCaching;

/// <summary>
/// If added the AddCacheOptions is called during startup.
/// </summary>
public interface ICacheMarker
{
    /// <summary>
    /// Maps one or more endpoints to the specified <paramref name="app"/> builder and returns it.
    /// </summary>
    /// <param name="app">The <see cref="OutputCacheOptions"/> builder to map endpoints to.</param>
    /// <returns>The same <paramref name="app"/> builder after endpoints have been added.</returns>
    OutputCacheOptions AddCacheOptions(OutputCacheOptions app);
}