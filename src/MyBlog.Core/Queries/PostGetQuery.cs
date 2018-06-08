using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Queries
{
    public class PostGetQuery : IRequest<PostEntity>
    {
        public int PostId { get; set; }
    }

    public class PostGetActiveQuery : IRequest<PostEntity>
    {
        public PostGetActiveQuery(int postId, string postSlug)
        {
            PostId = postId;
            PostSlug = postSlug;
        }

        public int PostId { get; }

        public string PostSlug { get; }
    }
}