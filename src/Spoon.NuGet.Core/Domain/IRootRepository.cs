namespace Spoon.NuGet.Core.Domain;

/// <summary>
/// The base repository.
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
public interface IRootRepository<TEntity>
    where TEntity : Entity
{
  
    
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="specification">The specification.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;System.Nullable&lt;TEntity&gt;&gt;.</returns>
    Task<TEntity?> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Searches the specified specification.
    /// </summary>
    /// <param name="specification">The specification.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
    Task<List<TEntity>> GetAllAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Remove(TEntity entity);
}
