namespace EF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;

    using EF.Models;

    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Database entity type
    /// </typeparam>
    public class GenericRepository<TEntity>: IGenericRepository<TEntity>//, IDisposable
        where TEntity : class, IEntity
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext databaseContext;

        /// <summary>
        /// The database set.
        /// </summary>
        private readonly DbSet<TEntity> databaseSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public GenericRepository(ApplicationDbContext context)
        {
            this.databaseContext = context;
            this.databaseSet = this.databaseContext.Set<TEntity>();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     List of all entities.
        /// </returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            //return this.databaseSet.AsNoTracking().ToList();
            return this.databaseSet.ToList();
        }

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     List of filtered entities.
        /// </returns>
        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            //return this.databaseSet.AsNoTracking().Where(predicate).ToList();
            return this.databaseSet.Where(predicate).ToList();
        }

        /// <summary>
        /// The find by key.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>Entity.
        /// </returns>
        public virtual TEntity FindByKey(int id)
        {
            // TODO: replace with Expression
            //return this.databaseSet.AsNoTracking().SingleOrDefault(e => e.Id == id);
            return this.databaseSet.SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        /// </exception>
        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///             An attempt was made to use unsupported behavior such as executing multiple asynchronous commands concurrently
        /// on the same context instance.</exception>
        /// <exception cref="ObjectDisposedException">The context or connection have been disposed.</exception>
        /// <exception cref="InvalidOperationException">
        ///             Some error occurred attempting to process entities in the context either before or after sending commands
        ///             to the database.
        /// </exception>
        public virtual void Insert(TEntity entity)
        {
            this.databaseSet.Add(entity);
            this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Update(TEntity entity)
        {
            this.databaseSet.Attach(entity);
            this.SetEntityStateModified(entity);
            this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// The set entity state modified.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void SetEntityStateModified(TEntity entity)
        {
            this.databaseContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// The all include.
        /// </summary>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     List of entities with included entities.
        /// </returns>
        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return this.GetAllIncluding(includeProperties).ToList();
        }

        /// <summary>
        /// The find by include.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     List of filtered entities with included entities.
        /// </returns>
        public IEnumerable<TEntity> FindByInclude(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Delete(TEntity entity)
        {
            this.databaseSet.Remove(entity);
            this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// The get all including.
        /// </summary>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>Query with included entities.
        /// </returns>
        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = this.databaseSet.AsNoTracking();
            return includeProperties.Aggregate(
                queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }
    }
}