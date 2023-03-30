namespace Spoon.NuGet.Core.Domain;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class RootRepository.
/// Implements the <see cref="IRootRepository{TEntity}" />.
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
/// <seealso cref="IRootRepository{TEntity}" />
public class RootRepository<TEntity> : IRootRepository<TEntity>
    where TEntity : Entity
{
    /// <summary>
    /// The database context.
    /// </summary>
    private readonly DbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="RootRepository{TEntity}" /> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public RootRepository(DbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    /// <summary>
    /// Gets the entity that matches the specified specification.
    /// </summary>
    /// <param name="specification">The specification used to match the entity.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation. The task result contains the matching entity, or null if not found.</returns>
    public async Task<TEntity?> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        
        return await this.ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Searches for entities that match the specified specification.
    /// </summary>
    /// <param name="specification">The specification used to match the entities.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation. The task result contains a list of matching entities.</returns>
    public Task<List<TEntity>> GetAllAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return this.ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Adds the specified entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public void Add(TEntity entity)
    {
        this._dbContext.Set<TEntity>().Add(entity);
    }

    /// <summary>
    /// Removes the specified entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    public void Remove(TEntity entity)
    {
        this._dbContext.Set<TEntity>().Add(entity);
    }

    /// <summary>
    /// Applies the specification to the database context.
    /// </summary>
    /// <param name="specification">The specification to apply.</param>
    /// <returns>An <see cref="IQueryable{T}"/> containing the entities that match the specification.</returns>
    protected IQueryable<TEntity> ApplySpecification(
        Specification<TEntity> specification)
    {
        return SpecificationEvaluator.GetQuery(
            this._dbContext.Set<TEntity>(),
            specification);
    }
}
