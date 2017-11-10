using MediatR;
using MyBlog.Core.Entities;
using System.Collections.Generic;

namespace MyBlog.Core.Queries
{
    public class PostGetsQuery : IRequest<IEnumerable<PostEntity>>
    {
    }
}