using MediatR;

namespace MyBlog.Core.Commands
{
    public class PostRemoveCommand : IRequest
    {
        public int PostId { get; set; }
    }
}