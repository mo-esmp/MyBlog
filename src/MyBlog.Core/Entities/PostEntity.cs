using System;
using System.Collections.Generic;

namespace MyBlog.Core.Entities
{
    public class PostEntity : BaseEntity
    {
        public bool IsActive { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ContentSummary { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDte { get; set; }

        public ICollection<PostTagEntity> PostTags { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }
    }
}