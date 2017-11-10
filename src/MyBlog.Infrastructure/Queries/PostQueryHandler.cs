using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Queries
{
    public class PostQueryHandler
        : IAsyncRequestHandler<PostGetsQuery, IEnumerable<PostEntity>>
    {
        private readonly DataContext _context;

        public PostQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostEntity>> Handle(PostGetsQuery message)
        {
            return await _context.Posts.AsNoTracking().ToListAsync();
        }
    }
}