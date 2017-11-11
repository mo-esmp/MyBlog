using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Extensions;
using MyBlog.Infrastructure.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class PostCommandHandler :
        IAsyncRequestHandler<PostAddCommand>,
        IAsyncRequestHandler<PostEditCommand>,
        IAsyncRequestHandler<PostRemoveCommand>
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
            post.ContentSummary = post.Content.TruncateHtml(500, "...");
            if (string.IsNullOrEmpty(post.Slug))
                post.Slug = UrlHelper.GenerateSlug(post.Title);

            //foreach (var tagId in message.TagIds)
            //    post.PostTags.Add(new PostTagEntity { TagId = tagId });

            await _context.AddAsync(post);
        }

        public async Task Handle(PostEditCommand message)
        {
            var editedPost = message.Post;
            var postDb = await _context.Posts
                .Include(p => p.PostTags)
                .SingleOrDefaultAsync(t => t.Id == editedPost.Id);

            if (postDb == null)
                return;

            postDb.Content = editedPost.Content;
            postDb.ContentSummary = editedPost.Content.TruncateHtml(500, "...");
            postDb.IsActive = editedPost.IsActive;
            postDb.Title = editedPost.Title;
            postDb.UpdateDte = DateTime.Now;

            if (string.IsNullOrEmpty(editedPost.Slug))
                editedPost.Slug = UrlHelper.GenerateSlug(editedPost.Title);

            _context.PostTags.RemoveRange(postDb.PostTags.Except(editedPost.PostTags, t => t.TagId));
            _context.PostTags.AddRange(editedPost.PostTags.Except(postDb.PostTags, t => t.TagId));
        }

        public async Task Handle(PostRemoveCommand message)
        {
            var post = await _context.Posts
                .Include(p => p.PostTags)
                .SingleOrDefaultAsync(p => p.Id == message.PostId);

            if (post == null)
                return;

            _context.Posts.Remove(post);

            if (post.PostTags == null || !post.PostTags.Any())
                return;

            _context.PostTags.RemoveRange(post.PostTags);
        }
    }
}