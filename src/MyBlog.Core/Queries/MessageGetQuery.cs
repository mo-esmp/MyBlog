using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Queries
{
    public class MessageGetQuery : IRequest<ContactMessageEntity>
    {
        public int MessageId { get; set; }
    }
}