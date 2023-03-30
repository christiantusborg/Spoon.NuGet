namespace Spoon.NuGet.Core.Domain.Primitives;

using MediatR;

/// <summary>
/// Interface IDomainEvent
/// Extends the <see cref="INotification" />.
/// </summary>
/// <seealso cref="INotification" />
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public Guid Id { get; init; }
}
