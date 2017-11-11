using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Commands
{
    public class PostEditCommand : IRequest
    {
        public PostEntity Post { get; set; }
    }
}