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
    /// Gets the entity that matches the specified specification.
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> CountAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await this.ApplySpecification(specification).CountAsync(cancellationToken);
    }

    /// <summary>
    /// Searches for entities that match the specified specification.
    /// </summary>
    /// <param name="specification">The specification used to match the entities.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation. The task result contains a list of matching entities.</returns>
    public async Task<List<TEntity>> SearchAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await this.ApplySpecification(specification).ToListAsync(cancellationToken);
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
    /// <summary>
    /// Saves all changes made in this context to the database. 
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous save operation. The task result contains the
    ///     number of state entries written to the database.
    /// </returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await this._dbContext.SaveChangesAsync(cancellationToken);
    }
    /// <summary>
    /// Adds and save an object.
    /// </summary>
    /// <param name="entity">The object to be added.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous save operation. The task result contains the
    ///     number of state entries written to the database.
    /// </returns>
    public async Task<int> AddAndSaveChangesAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        this.Add(entity);
        return await this.SaveChangesAsync(cancellationToken);

    }
}
