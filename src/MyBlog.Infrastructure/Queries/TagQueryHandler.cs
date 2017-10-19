using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Queries
{
    public class TagQueryHandler : IAsyncRequestHandler<TagGetsQuery, IEnumerable<TagEntity>>
    {
        private readonly DataContext _context;

        public TagQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagEntity>> Handle(TagGetsQuery message)
        {
            return await _context.Tags.AsNoTracking().ToListAsync();
        }
    }
}