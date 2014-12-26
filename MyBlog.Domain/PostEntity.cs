using System;
using System.Collections.Generic;

namespace MyBlog.Domain
{
    public class PostEntity : BaseEntity
    {
        public bool IsEnabled { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDte { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }
    }
}