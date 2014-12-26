using System.Collections.Generic;

namespace MyBlog.Domain
{
    public class TagEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }
    }
}