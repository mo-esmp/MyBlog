using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class MessageCommandHandler :
        IAsyncRequestHandler<MessagesRemoveCommand>
    {
        private readonly DataContext _context;

        public MessageCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(MessagesRemoveCommand message)
        {
            var messages = await _context.Messages
                .Where(m => message.MessageIds.Contains(m.Id))
                .ToListAsync();

            if (messages.Any())
                _context.Messages.RemoveRange(messages);
        }
    }
}