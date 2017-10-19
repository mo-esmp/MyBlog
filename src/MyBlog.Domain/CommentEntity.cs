using System.Collections.Generic;

namespace MyBlog.Domain
{
    public class CommentEntity : BaseEntity
    {
        public bool IsEnabled { get; set; }

        public bool CreateDate { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public PostEntity Post { get; set; }

        public int? ParentId { get; set; }

        public CommentEntity Parent { get; set; }

        public virtual ICollection<CommentEntity> Children { get; set; }
    }
}