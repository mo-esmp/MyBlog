using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Queries
{
    public class PostQueryHandler :
        IAsyncRequestHandler<PostPagedGetsQuery, Tuple<IEnumerable<PostEntity>, int>>,
        IAsyncRequestHandler<PostGetsQuery, IEnumerable<PostEntity>>,
        IAsyncRequestHandler<PostGetQuery, PostEntity>
    {
        private readonly DataContext _context;

        public PostQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Tuple<IEnumerable<PostEntity>, int>> Handle(PostPagedGetsQuery message)
        {
            var skip = message.Page > 0 ? (message.Page - 1) * 5 : 0;

            var postCount = _context.Posts.CountAsync(p => p.IsActive);
            var posts = _context.Posts
                .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
                .AsNoTracking()
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.CreateDate)
                .Skip(skip)
                .Take(5)
                .ToListAsync();

            await Task.WhenAll(posts, postCount);

            return Tuple.Create(posts.Result.AsEnumerable(), postCount.Result);
        }

        public async Task<IEnumerable<PostEntity>> Handle(PostGetsQuery message)
        {
            return await _context.Posts.AsNoTracking().ToListAsync();
        }

        public async Task<PostEntity> Handle(PostGetQuery message)
        {
            return await _context.Posts.AsNoTracking().SingleOrDefaultAsync(t => t.Id == message.PostId);
        }
    }
}