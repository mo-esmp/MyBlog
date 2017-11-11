using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Queries
{
    public class PostGetQuery : IRequest<PostEntity>
    {
        public int PostId { get; set; }
    }
}