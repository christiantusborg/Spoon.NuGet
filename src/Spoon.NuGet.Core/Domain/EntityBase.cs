namespace Spoon.NuGet.Core.Domain;

/// <summary>
///  Class EntityBase with softdelete and create.
/// </summary>
public abstract class EntityBase : Entity
{
    /// <summary>
    /// Created at.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Created or modified at.
    /// </summary>
    public DateTime? ModifiedAt { get; set; }
    /// <summary>
    /// Soft deleted at.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

}