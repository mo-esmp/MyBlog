using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MyBlog.Data.Contracts
{
    /// <summary>
    /// Contract for ‘UnitOfWork pattern’
    /// </summary>
    public interface IQueryableContext : IDisposable
    {
        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>The DataContext.</value>
        DataContext EfContext { get; }

        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context,
        /// the ObjectStateManager, and the underlying store.
        /// </summary>
        /// <typeparam>
        ///     <name>TValueObject</name>
        /// </typeparam>
        /// <typeparam name="TEntity">Type of base entity</typeparam>
        /// <returns></returns>
        DbSet<TEntity> EntitySet<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Attach this item into "ObjectStateManager"
        /// </summary>
        /// <typeparam>The type of entity
        ///     <name>TValueObject</name>
        /// </typeparam>
        /// <param name="item">The item </param>
        /// <typeparam name="TEntity">Type of base entity</typeparam>
        void Attach<TEntity>(TEntity item) where TEntity : BaseEntity;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam>The type of entity
        ///     <name>TValueObject</name>
        /// </typeparam>
        /// <param name="item">The entity item to set as modified</param>
        /// <typeparam name="TEntity">Type of base entity</typeparam>
        void SetModified<TEntity>(TEntity item) where TEntity : BaseEntity;

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        /// <typeparam name="TEntity">Type of base entity</typeparam>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : BaseEntity;

        /// <summary>
        /// Execute specific query with underliying persistence store
        /// </summary>
        /// <typeparam name="TEntity">Entity type to map query results</typeparam>
        /// <param name="sqlQuery">
        /// Dialect Query
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer > {0}
        /// </example>
        /// </param>
        /// <param name="parameters">A vector of parameters values</param>
        /// <returns>
        /// Enumerable results
        /// </returns>
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        /// <summary>
        /// Execute arbitrary command into underlaying persistence store
        /// </summary>
        /// <param name="sqlCommand">
        /// Command to execute
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer > {0}
        /// </example>
        ///</param>
        /// <param name="parameters">A vector of parameters values</param>
        /// <returns>The number of affected records</returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);

        /// <summary>
        /// Commit all changes made in a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then an exception is thrown
        ///</remarks>
        int Commit();

        /// <summary>
        /// Commit all changes made in a container asynchronously.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then an exception is thrown
        ///</remarks>
        Task<int> CommitAsync();

        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then 'client changes' are refreshed - Client wins
        ///</remarks>
        void CommitAndRefreshChanges();

        /// <summary>
        /// Rollback tracked changes. See references of UnitOfWork pattern
        /// </summary>
        void RollbackChanges();
    }
}