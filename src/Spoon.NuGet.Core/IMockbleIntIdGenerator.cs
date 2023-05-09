namespace Spoon.NuGet.Core;

/// <summary>
/// Interface for a class that provides a mockable int .NewGuid() method. This is useful for unit testing code that uses Guids.
/// </summary>
public interface IMockbleIntIdGenerator
{
    /// <summary>
    /// Generates a new int id.
    /// </summary>
    /// <returns>A new int id.</returns>
    int NewId();
}