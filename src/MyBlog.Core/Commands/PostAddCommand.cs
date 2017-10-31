using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Commands
{
    public class PostAddCommand : IRequest
    {
        public PostEntity Post { get; set; }

        public int[] TagIds { get; set; }
    }
}