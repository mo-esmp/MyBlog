using Elev.Data.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using MyBlog.Data.Contracts;
using MyBlog.Data.Mapping;
using MyBlog.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Data
{
    public class DataContext : IdentityDbContext<User>, IQueryableContext
    {
        #region ctor

        public DataContext()
            : base("Name=DataConnection")
        { }

        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }

        #endregion ctor

        #region DbSets

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<ContactMessageEntity> ContactMessages { get; set; }

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        #endregion DbSets

        #region IQueryableContext members

        public DataContext EfContext
        {
            get { return (this); }
        }

        public DbSet<TEntity> EntitySet<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : BaseEntity
        {
            var entry = Entry(item);

            //attach and set as unchanged
            if (entry.State != EntityState.Unchanged)
                Entry(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : BaseEntity
        {
            //this operation also attach item in object state manager
            var entityInDb = EntitySet<TEntity>().Find(item.Id);
            Entry(entityInDb).CurrentValues.SetValues(item);
            Entry(entityInDb).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : BaseEntity
        {
            //if it is not attached, attach original and set current values
            Entry(original).CurrentValues.SetValues(current);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public int Commit()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            return 0;
        }

        public Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed;

            // If during save concurrency exception has occurred, save changes with new values
            do
            {
                try
                {
                    base.SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.ToList().ForEach(entry => entry.OriginalValues.SetValues(entry.GetDatabaseValues()));
                }
            } while (saveFailed);
        }

        public void RollbackChanges()
        {
            // Set all entities in change tracker as 'unchanged state'
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion IQueryableContext members

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IdConvention());

            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new TagMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}