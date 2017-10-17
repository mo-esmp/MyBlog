using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Commands
{
    public class TagAddCommand : IRequest
    {
        public TagEntity Tag { get; set; }
    }
}