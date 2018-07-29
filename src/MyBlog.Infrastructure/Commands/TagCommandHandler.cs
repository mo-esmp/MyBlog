using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using MyBlog.Infrastructure.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class TagCommandHandler :
        IRequestHandler<TagAddCommand>,
        IRequestHandler<TagEditCommand>,
        IRequestHandler<TagRemoveCommand>
    {
        private readonly DataContext _context;

        public TagCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(TagAddCommand message, CancellationToken cancellationToken)
        {
            var tag = message.Tag;
            tag.Slug = UrlHelper.GenerateSlug(tag.Name);

            if (await _context.Tags.AnyAsync(t => t.Slug == tag.Slug, cancellationToken))
                return Unit.Value;

            _context.Add(tag);

            return Unit.Value;
        }

        public async Task<Unit> Handle(TagEditCommand message, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(message.Tag.Id);
            if (tag == null)
                return Unit.Value;

            tag.Name = message.Tag.Name;
            tag.Slug = UrlHelper.GenerateSlug(tag.Name);

            return Unit.Value;
        }

        public async Task<Unit> Handle(TagRemoveCommand message, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(message.TagId);
            if (tag == null)
                return Unit.Value;

            _context.Tags.Remove(tag);

            return Unit.Value;
        }
    }
}