namespace Spoon.NuGet.Core.Presentation;

/// <summary>
///   Class BaseSearchCommandResult. This class cannot be inherited.
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseSearchPresentationResponse<T>
{
    /// <summary>
    /// Gets or sets the total number of items.
    /// </summary>
    public int Total { get; init; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    public List<T> Items { get; init; } = new ();
}