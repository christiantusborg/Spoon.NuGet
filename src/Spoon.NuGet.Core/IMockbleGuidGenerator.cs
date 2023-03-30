namespace Spoon.NuGet.Core;

/// <summary>
/// Interface for a class that provides a mockable Guid.NewGuid() method. This is useful for unit testing code that uses Guids.
/// </summary>
public interface IMockbleGuidGenerator
{
    /// <summary>
    /// Generates a new Guid.
    /// </summary>
    /// <returns>A new Guid.</returns>
    Guid NewGuid();
}