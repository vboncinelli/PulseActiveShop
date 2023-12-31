using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Dal.Sql.Contexts;
using PulseActiveShop.Dal.Sql.Entities;
using PulseActiveShop.Dal.Sql.Mappers;
using System.Linq.Expressions;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public abstract class BaseRepository<TEntity, TEntityCollection, TDalEntity> : IRepository<TEntity, TEntityCollection>
        where TEntity:BaseEntity, new()
        where TEntityCollection : BaseEntityCollection<TEntity>, new()
        where TDalEntity : BaseDalEntity, new()

    {
        protected readonly IConfiguration _configuration;
        private string[]? _includedEntities = null;

        /// <summary>
        /// Constructor for BaseRepository class.
        /// </summary>
        /// <param name="configuration">Connection manager object.</param>
        /// <param name="includedEntities">Array of included entities.</param>
        /// <returns>
        /// N/A
        /// </returns>
        public BaseRepository(IConfiguration configuration, string[]? includedEntities = null)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _includedEntities = includedEntities;
        }

        /// <summary>
        /// Retrieves an entity with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID, or null if no such entity exists.</returns>
        public virtual async Task<TEntity?> FindAsync(int id)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var dalEntity = await context
                        .Set<TDalEntity>()
                        .FirstOrDefaultAsync(e => e.Id == id);

                    if (dalEntity == null) return null;

                    return dalEntity.ToCore<TEntity, TDalEntity>();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Checks if an entity with the given id exists in the database.
        /// </summary>
        /// <param name="id">The id of the entity to check.</param>
        /// <returns>True if the entity exists, false otherwise.</returns>
        public virtual async Task<bool> ExistsAsync(int id)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    return await context.Set<TDalEntity>().AnyAsync(e => e.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Retrieves a paginated collection of entities from the database.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A paginated collection of entities.</returns>
        public virtual async Task<TEntityCollection> GetAllAsync(int page, int pageSize)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var query = context.Set<TDalEntity>().AsQueryable();

                    return await ExecutePaginatedQueryAsync(query, page, pageSize, this._includedEntities);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }


        public virtual async Task<TEntityCollection> FilterAsync(int[] ids, int page = 1, int pageSize = int.MaxValue)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var query = context.Set<TDalEntity>().Where(e => ids.Contains(e.Id)).AsQueryable();

                    return await ExecutePaginatedQueryAsync(query, page, pageSize, this._includedEntities);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Inserts an entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var dalEntity = entity.ToDal<TDalEntity, TEntity>();

                    var attached = context.Set<TDalEntity>().Attach(dalEntity);

                    attached.State = EntityState.Added;

                    await context.SaveChangesAsync();

                    return dalEntity.ToCore<TEntity, TDalEntity>();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Updates an entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var dalEntity = entity.ToDal<TDalEntity, TEntity>();

                    var attached = context.Set<TDalEntity>().Attach(dalEntity);

                    attached.State = EntityState.Modified;

                    await context.SaveChangesAsync();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Asynchronously deletes an entity with the specified id.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        public virtual async Task DeleteAsync(int id)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var deletedRows = await context.Set<TDalEntity>().Where(e => e.Id == id).ExecuteDeleteAsync(); //TODO: test

                    if (deletedRows == 0)
                        throw new EntityNotFoundException("ENTITY_NOT_FOUND");
                }
            }
            catch (EntityNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Counts the number of entities in the database asynchronously.
        /// </summary>
        /// <returns>The number of entities in the database.</returns>
        public virtual async Task<int> CountAsync()
        {
            try
            {
                using (var context = this.GetContext())
                {
                    return await context.Set<TDalEntity>().AsQueryable().CountAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Inserts a collection of entities asynchronously.
        /// </summary>
        /// <param name="collection">The collection of entities to insert.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task AddBulkAsync(TEntityCollection collection)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var list = new List<TDalEntity>();

                    foreach (var item in collection)
                        list.Add(item.ToDal<TDalEntity, TEntity>());

                    context.Set<TDalEntity>().AddRange(list);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Updates a collection of entities asynchronously.
        /// </summary>
        /// <param name="collection">The collection of entities to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task UpdateBulkAsync(TEntityCollection collection)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var list = new List<TDalEntity>();

                    foreach (var item in collection)
                        list.Add(item.ToDal<TDalEntity, TEntity>());

                    context.Set<TDalEntity>().UpdateRange(list);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Executes a paginated query and returns a collection of entities.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="includedEntities">The included entities.</param>
        /// <returns>A collection of entities.</returns>
        protected async Task<TEntityCollection> ExecutePaginatedQueryAsync(IQueryable<TDalEntity> query, int page, int pageSize, string[]? includedEntities = null, Expression<Func<TDalEntity, string>>? orderPredicate = null)
        {
            if (includedEntities != null)
            {
                foreach (var included in includedEntities)
                {
                    query = query.Include(included);
                }
            }

            if (orderPredicate == null)
                query = this.GetDefaultOrdering(query);
            else
                query = query.OrderBy(orderPredicate);

            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var itemsCount = await query.CountAsync();

            var collection = new TEntityCollection();

            foreach (var item in items)
                collection.Add(item.ToCore<TEntity, TDalEntity>());

            collection.Page = page;
            collection.PageSize = pageSize;
            collection.TotalItemCount = itemsCount;

            return collection;
        }

        /// <summary>
        /// Applies a where condition to the given query if the where predicate is not null.
        /// </summary>
        /// <param name="query">The query to apply the where condition to.</param>
        /// <param name="wherePredicate">The where predicate to apply.</param>
        /// <returns>The query with the applied where condition.</returns>
        protected IQueryable<TDalEntity> ApplyWhereCondition(IQueryable<TDalEntity> query, Expression<Func<TDalEntity, bool>>? wherePredicate)
        {
            return wherePredicate is null ? query : query.Where(wherePredicate);
        }

        /// <summary>
        /// Applies an order by predicate to a queryable.
        /// </summary>
        /// <param name="query">The queryable.</param>
        /// <param name="orderPredicate">The order by predicate.</param>
        /// <param name="ascending">Whether the order should be ascending.</param>
        /// <returns>The queryable with the order by predicate applied.</returns>
        protected IQueryable<TDalEntity> ApplyOrderByPredicate<TOrderKey>(IQueryable<TDalEntity> query, Expression<Func<TDalEntity, TOrderKey>>? orderPredicate, bool ascending = true)
        {
            if (orderPredicate is null)
                return query;

            return ascending ? query.OrderBy(orderPredicate) : query.OrderByDescending(orderPredicate);
        }

        /// <summary>
        /// Gets the DashboardContext from the connection string.
        /// </summary>
        /// <returns>The DashboardContext.</returns>
        protected virtual DbContext GetContext()
        {
            var connectionString = this._configuration.GetConnectionString("PulseShop");

            return new ShopContext(connectionString!);
        }

        /// <summary>
        /// Gets the default ordering for a queryable.
        /// </summary>
        /// <param name="query">The queryable.</param>
        /// <returns>The queryable with the default ordering applied.</returns>
        protected abstract IQueryable<TDalEntity> GetDefaultOrdering(IQueryable<TDalEntity> query);
    }
}
