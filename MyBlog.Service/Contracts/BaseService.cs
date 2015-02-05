using MyBlog.Common.Extensions;
using MyBlog.Data.Contracts;
using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlog.Service.Contracts
{
    /// <summary>
    /// Base service for common CRUD operations. this is a replacement for repository pattern.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IQueryableContext _queryableContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity}"/> class.
        /// </summary>
        /// <param name="queryableContext">The queryable context.</param>
        protected BaseService(IQueryableContext queryableContext)
        {
            _queryableContext = queryableContext;
        }

        /// <summary>
        /// Adds the new item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItem(TEntity item)
        {
            if (item == null) return;
            EntitySet().Add(item);
        }

        /// <summary>
        /// Edits the item.
        /// </summary>
        /// <param name="updatedItem">The updated item.</param>
        public void EditItem(TEntity updatedItem)
        {
            if (updatedItem == null) return;
            _queryableContext.SetModified(updatedItem);
        }

        /// <summary>
        /// Edits the item.
        /// </summary>
        /// <param name="originalItem">The original item.</param>
        /// <param name="updatedItem">The updated item.</param>
        public void EditItem(TEntity originalItem, TEntity updatedItem)
        {
            _queryableContext.ApplyCurrentValues(originalItem, updatedItem);
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void DeleteItem(TEntity item)
        {
            if (item == null) return;
            _queryableContext.Attach(item);
            EntitySet().Remove(item);
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public void DeleteItem(Expression<Func<TEntity, bool>> predicate)
        {
            var item = EntitySet().Single(predicate);
            if (item != null)
                EntitySet().Remove(item);
        }

        /// <summary>
        /// Finds the item by using ef find method.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns>`0.</returns>
        public TEntity FindItem(params object[] keys)
        {
            //Declare 'foundedItem' and set it by calling 'Find' method of DbSet
            var foundedItem = EntitySet().Find(keys);

            //Return 'foundedItem'
            return (foundedItem);
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IQueryable{`0}.</returns>
        public IQueryable<TEntity> GetItems(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = predicate == null ? EntitySet() : EntitySet().Where(predicate);
            if (includeProperties != null)
                query = ApplyIncludesOnQuery(query, includeProperties);

            return query;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="keySelector">The property to sort with.</param>
        /// <param name="order">The sort direction.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
        public IQueryable<TEntity> GetItems<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, SortOrder order, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = predicate == null ? EntitySet() : EntitySet().Where(predicate);
            if (includeProperties != null)
                query = ApplyIncludesOnQuery(query, includeProperties);

            query = query.SortBy(keySelector, order);

            return query;
        }

        /// <summary>
        /// Gets the items asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
        public Task<List<TEntity>> GetItemsAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = predicate == null ? EntitySet() : EntitySet().Where(predicate);
            if (includeProperties != null)
                query = ApplyIncludesOnQuery(query, includeProperties);

            return query.ToListAsync();
        }

        /// <summary>
        /// Gets the items asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="keySelector">The property to sort with.</param>
        /// <param name="order">The sort direction.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
        public Task<List<TEntity>> GetItemsAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, SortOrder order, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = predicate == null ? EntitySet() : EntitySet().Where(predicate);
            if (includeProperties != null)
                query = ApplyIncludesOnQuery(query, includeProperties);

            query = query.SortBy(keySelector, order);

            return query.ToListAsync();
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Return TEntity.</returns>
        public TEntity GetItem(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = EntitySet().AsQueryable();
            if (includeProperties != null)
                query = ApplyIncludesOnQuery(query, includeProperties);

            return query.SingleOrDefault(predicate);
        }

        /// <summary>
        /// Gets the item asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Return TEntity.</returns>
        public async Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = EntitySet().AsQueryable();
            if (includeProperties != null)
                query = ApplyIncludesOnQuery(query, includeProperties);

            return await query.SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Gets the first item.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Return TEntity.</returns>
        public TEntity GetFirstItem(Expression<Func<TEntity, int>> sort, Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                       ? EntitySet().OrderByDescending(sort).FirstOrDefault()
                       : EntitySet().Where(predicate).OrderBy(sort).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first item asynchronously.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Return TEntity.</returns>
        public Task<TEntity> GetFirstItemAsync(Expression<Func<TEntity, int>> sort, Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                       ? EntitySet().OrderByDescending(sort).FirstOrDefaultAsync()
                       : EntitySet().Where(predicate).OrderBy(sort).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the last item.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Return TEntity.</returns>
        public TEntity GetLastItem(Expression<Func<TEntity, int>> sort, Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                       ? EntitySet().OrderByDescending(sort).FirstOrDefault()
                       : EntitySet().Where(predicate).OrderByDescending(sort).FirstOrDefault();
        }

        /// <summary>
        /// Gets the last item asynchronously.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Return TEntity.</returns>
        public Task<TEntity> GetLastItemAsync(Expression<Func<TEntity, int>> sort, Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                       ? EntitySet().OrderByDescending(sort).FirstOrDefaultAsync()
                       : EntitySet().Where(predicate).OrderByDescending(sort).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>int</returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null ? EntitySet().Count() : EntitySet().Where(predicate).Count();
        }

        /// <summary>
        /// Counts the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>int</returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null ? EntitySet().CountAsync() : EntitySet().Where(predicate).CountAsync();
        }

        /// <summary>
        /// Any the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns><c>true</c> if sequence contains any elements, otherwise <c>false</c>.</returns>
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null ? EntitySet().Any() : EntitySet().Any(predicate);
        }

        /// <summary>
        /// Any the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns><c>true</c> if sequence contains any elements, otherwise <c>false</c>.</returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null ? EntitySet().AnyAsync() : EntitySet().AnyAsync(predicate);
        }

        /// <summary>
        /// Commits the changes.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public bool Commit()
        {
            return _queryableContext.Commit() > 0;
        }

        /// <summary>
        /// Commits the changes asynchronously.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public Task<int> CommitAsync()
        {
            return _queryableContext.CommitAsync();
        }

        /// <summary>
        /// Commits the and refresh changes.
        /// </summary>
        public void CommitAndRefreshChanges()
        {
            _queryableContext.CommitAndRefreshChanges();
        }

        /// <summary>
        /// Rollbacks the changes.
        /// </summary>
        public void Rollback()
        {
            _queryableContext.RollbackChanges();
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable{`0}.</returns>
        public IEnumerable<TEntity> ExecuteQuery(string sqlQuery, params object[] parameters)
        {
            return _queryableContext.ExecuteQuery<TEntity>(sqlQuery, parameters);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Int32.</returns>
        public int ExecuteCommand(string sqlQuery, params object[] parameters)
        {
            return _queryableContext.ExecuteCommand(sqlQuery, parameters);
        }

        #region Private methods

        /// <summary>
        /// Returns Dbset of an entity.
        /// </summary>
        /// <returns>IDbSet.</returns>
        private IDbSet<TEntity> EntitySet()
        {
            return _queryableContext.EntitySet<TEntity>();
        }

        /// <summary>
        /// Applies the includes on query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IQueryable{`0}.</returns>
        private static IQueryable<TEntity> ApplyIncludesOnQuery(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            //Return Applied Includes query
            return (includeProperties.Aggregate(query, (current, include) => current.Include(include)));
        }

        #endregion Private methods
    }
}