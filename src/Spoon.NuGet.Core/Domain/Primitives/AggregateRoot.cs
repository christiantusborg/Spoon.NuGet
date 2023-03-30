namespace Spoon.NuGet.Core.Domain.Primitives;

/// <summary>
/// Class AggregateRoot.
/// Implements the <see cref="Entity" />.
/// </summary>
/// <seealso cref="Entity" />
public abstract class AggregateRoot : Entity
{
    /// <summary>
    /// The domain events.
    /// </summary>
    private readonly List<IDomainEvent> domainEvents = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    protected AggregateRoot(Guid id)
        
        {
        }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot" /> class.
    /// </summary>
    protected AggregateRoot()
    {
    }

    /// <summary>
    /// Gets the domain events.
    /// </summary>
    /// <returns>IReadOnlyCollection&lt;IDomainEvent&gt;.</returns>
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => this.domainEvents.ToList();

    /// <summary>
    /// Clears the domain events.
    /// </summary>
    public void ClearDomainEvents() => this.domainEvents.Clear();

    /// <summary>
    /// Raises the domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
        this.domainEvents.Add(domainEvent);
}
