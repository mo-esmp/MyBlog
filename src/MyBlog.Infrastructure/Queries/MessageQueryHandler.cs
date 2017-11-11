using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Queries
{
    public class MessageQueryHandler :
        IAsyncRequestHandler<MessageGetsQuery, IEnumerable<ContactMessageEntity>>,
        IAsyncRequestHandler<MessageGetQuery, ContactMessageEntity>
    {
        private readonly DataContext _context;

        public MessageQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactMessageEntity>> Handle(MessageGetsQuery message)
        {
            return await _context.Messages
                .AsNoTracking()
                .OrderByDescending(m => m.CreateDate)
                .ToListAsync();
        }

        public async Task<ContactMessageEntity> Handle(MessageGetQuery message)
        {
            return await _context.Messages
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == message.MessageId);
        }
    }
}