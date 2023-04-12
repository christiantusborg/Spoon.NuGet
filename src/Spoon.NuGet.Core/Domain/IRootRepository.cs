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
    /// Gets the by identifier.
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Searches the specified specification.
    /// </summary>
    /// <param name="specification">The specification.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
    Task<List<TEntity>> SearchAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

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

    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous save operation. The task result contains
    /// the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Adds and save an object. Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="entity">The object to be added.</param>
    /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous save operation. The task result contains
    /// the number of state entries written to the database.</returns>
    Task<int> AddAndSaveChangesAsync(TEntity entity, CancellationToken cancellationToken = default);
}
