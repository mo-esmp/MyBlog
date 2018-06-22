namespace MyBlog.Core.Entities
{
    public class CommentEntity : BaseEntity
    {
        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public bool IsNew { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public int PostId { get; set; }

        public PostEntity Post { get; set; }
    }
}