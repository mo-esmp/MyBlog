using MediatR;
using MyBlog.Core.Commands;
using MyBlog.Core.Entities;
using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Extensions;
using MyBlog.Infrastructure.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class PostCommandHandler : IAsyncRequestHandler<PostAddCommand>
    {
        private readonly DataContext _context;

        public PostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(PostAddCommand message)
        {
            var post = message.Post;

            post.CreateDate = DateTime.Now;
            post.Slug = post.Slug ?? UrlHelper.GenerateSlug(post.Title);
            post.ContentSummary = post.Content.TruncateHtml(500, "...");
            post.PostTags = new Collection<PostTagEntity>();
            foreach (var tagId in message.TagIds)
                post.PostTags.Add(new PostTagEntity { TagId = tagId });

            await _context.AddAsync(post);
        }
    }
}