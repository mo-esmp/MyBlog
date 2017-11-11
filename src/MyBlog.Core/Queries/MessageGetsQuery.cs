using MediatR;
using MyBlog.Core.Entities;
using System.Collections.Generic;

namespace MyBlog.Core.Queries
{
    public class MessageGetsQuery : IRequest<IEnumerable<ContactMessageEntity>>
    {
    }
}