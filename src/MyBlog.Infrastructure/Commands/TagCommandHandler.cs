using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Helpers;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    internal class TagCommandHandler
        : IAsyncRequestHandler<TagAddCommand>
    {
        private readonly DataContext _context;

        public TagCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(TagAddCommand message)
        {
            var tag = message.Tag;
            tag.Slug = UrlHelper.GenerateSlug(tag.Name);

            if (await _context.Tags.AnyAsync(t => t.Slug == tag.Slug))
                return;

            _context.Add(tag);
        }
    }
}