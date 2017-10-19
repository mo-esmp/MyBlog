using MediatR;

namespace MyBlog.Core.Commands
{
    public class TagRemoveCommand : IRequest
    {
        public int TagId { get; set; }
    }
}