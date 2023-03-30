namespace Spoon.NuGet.Core.Domain.Primitives;

/// <summary>
/// Interface IAuditableEntity/.
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// Gets or sets the created on UTC.
    /// </summary>
    /// <value>The created on UTC.</value>
    DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the modified on UTC.
    /// </summary>
    /// <value>The modified on UTC.</value>
    DateTime? ModifiedAt { get; set; }
}