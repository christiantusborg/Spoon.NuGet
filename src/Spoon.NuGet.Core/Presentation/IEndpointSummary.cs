namespace Spoon.NuGet.Core.Presentation;

/// <summary>
///  Represents the summary to create a category.
/// </summary>
public interface IEndpointSummary
{
    /// <summary>
    ///  Gets the summary.
    /// </summary>
    /// <returns></returns>
    string GetEndpointSummary();
}