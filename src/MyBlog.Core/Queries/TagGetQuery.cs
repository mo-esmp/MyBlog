using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Queries
{
    public class TagGetQuery : IRequest<TagEntity>
    {
        public int TagId { get; set; }
    }
}