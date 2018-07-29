using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Queries
{
    public class TagQueryHandler :
        IRequestHandler<TagGetsQuery, IEnumerable<TagEntity>>,
        IRequestHandler<TagGetsByPostIdQuery, IEnumerable<TagEntity>>,
        IRequestHandler<TagGetQuery, TagEntity>
    {
        private readonly DataContext _context;

        public TagQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagEntity>> Handle(TagGetsQuery message, CancellationToken cancellationToken)
        {
            return await _context.Tags.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TagEntity>> Handle(TagGetsByPostIdQuery message, CancellationToken cancellationToken)
        {
            return await _context.PostTags
                .AsNoTracking()
                .Where(pt => pt.PostId == message.PostId)
                .Select(pt => pt.Tag)
                .ToListAsync(cancellationToken);
        }

        public async Task<TagEntity> Handle(TagGetQuery message, CancellationToken cancellationToken)
        {
            return await _context.Tags
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == message.TagId, cancellationToken);
        }
    }
}