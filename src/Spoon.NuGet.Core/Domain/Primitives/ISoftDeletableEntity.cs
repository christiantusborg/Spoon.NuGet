namespace Spoon.NuGet.Core.Domain.Primitives;

/// <summary>
/// Interface ISoftDeletableEntity.
/// </summary>
public interface ISoftDeletableEntity
{
    /// <summary>
    /// Gets or sets the deleted on UTC.
    /// </summary>
    /// <value>The deleted on UTC.</value>
    DateTime? DeletedAt { get; set; }
}