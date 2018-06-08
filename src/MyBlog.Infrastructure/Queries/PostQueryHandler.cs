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
        IAsyncRequestHandler<PostGetsPagedQuery, Tuple<IEnumerable<PostEntity>, int>>,
        IAsyncRequestHandler<PostGetsQuery, IEnumerable<PostEntity>>,
        IAsyncRequestHandler<PostGetActiveQuery, PostEntity>,
        IAsyncRequestHandler<PostGetQuery, PostEntity>
    {
        private readonly DataContext _context;

        public PostQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Tuple<IEnumerable<PostEntity>, int>> Handle(PostGetsPagedQuery message)
        {
            var skip = message.Page > 0 ? (message.Page - 1) * 5 : 0;

            var query = message.TagSlug != null
                ? _context.Posts.Where(p => p.IsActive && p.PostTags.Any(pt => pt.Tag.Slug == message.TagSlug))
                : _context.Posts.Where(p => p.IsActive);

            var postCount = query.CountAsync();
            var posts = query
                .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
                .AsNoTracking()
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

        public Task<PostEntity> Handle(PostGetQuery message)
        {
            return _context.Posts
                .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == message.PostId);
        }

        public Task<PostEntity> Handle(PostGetActiveQuery message)
        {
            return _context.Posts
                .Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.IsActive && p.Id == message.PostId);
        }
    }
}