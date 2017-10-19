using System.Collections.Generic;

namespace MyBlog.Core.Entities
{
    public class TagEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public ICollection<PostTagEntity> PostTags { get; set; }
    }
}