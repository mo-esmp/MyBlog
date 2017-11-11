using MediatR;
using MyBlog.Core.Entities;
using System.Collections.Generic;

namespace MyBlog.Core.Queries
{
    public class TagGetsByPostIdQuery : IRequest<IEnumerable<TagEntity>>
    {
        public int PostId { get; set; }
    }
}