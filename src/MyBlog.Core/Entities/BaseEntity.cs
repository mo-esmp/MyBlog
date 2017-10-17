namespace MyBlog.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public virtual int Id { get; set; }
    }
}