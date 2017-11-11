using MediatR;

namespace MyBlog.Core.Commands
{
    public class MessagesRemoveCommand : IRequest
    {
        public int[] MessageIds { get; set; }
    }
}