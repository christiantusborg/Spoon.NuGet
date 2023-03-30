namespace Spoon.NuGet.Mediator;

/// <summary>
/// Class BaseRequestPaging.
/// </summary>
public abstract class BaseRequestPaging
{
    /// <summary>
    /// Gets or sets the page.
    /// </summary>
    /// <value>The page.</value>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Gets or sets the length of the page.
    /// </summary>
    /// <value>The length of the page.</value>
    public int PageLength { get; set; } = 50;
}