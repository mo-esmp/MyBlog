using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Commands
{
    public class TagEditCommand : IRequest
    {
        public TagEntity Tag { get; set; }
    }
}