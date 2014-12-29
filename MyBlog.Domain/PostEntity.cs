using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Domain
{
    public class PostEntity : BaseEntity
    {
        public bool IsEnabled { get; set; }

        [DataType(DataType.Url)]
        [ScaffoldColumn(false)]
        public string Slug { get; set; }

        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DataType(DataType.Time)]
        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdateDte { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }
    }
}