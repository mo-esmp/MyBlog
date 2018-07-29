using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class MessageCommandHandler :
        IRequestHandler<MessageAddCommand>,
        IRequestHandler<MessagesRemoveCommand>
    {
        private readonly DataContext _context;

        public MessageCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(MessagesRemoveCommand message, CancellationToken cancellationToken)
        {
            var messages = await _context.Messages
                .Where(m => message.MessageIds.Contains(m.Id))
                .ToListAsync(cancellationToken);

            if (messages.Any())
                _context.Messages.RemoveRange(messages);

            return Unit.Value;
        }

        public Task<Unit> Handle(MessageAddCommand message, CancellationToken cancellationToken)
        {
            message.ContactMessage.IsNew = true;
            message.ContactMessage.CreateDate = DateTime.Now;
            _context.Messages.Add(message.ContactMessage);

            return Unit.Task;
        }
    }
}