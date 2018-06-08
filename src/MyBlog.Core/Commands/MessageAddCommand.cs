using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Commands
{
    public class MessageAddCommand : IRequest
    {
        public MessageAddCommand(ContactMessageEntity message)
        {
            ContactMessage = message;
        }

        public ContactMessageEntity ContactMessage { get; }
    }
}