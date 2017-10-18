using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Queries
{
    public class TagGetsQuery : IRequest<TagEntity>
    {
    }
}