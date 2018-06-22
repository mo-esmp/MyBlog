using MediatR;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class CommentCommandHandler :
        IAsyncRequestHandler<CommentAddCommand>,
        IAsyncRequestHandler<CommentApproveCommand>

    {
        private readonly DataContext _context;

        public CommentCommandHandler(DataContext context)
        {
            _context = context;
        }

        public Task Handle(CommentAddCommand message)
        {
            var comment = message.Comment;

            if (!comment.IsAdmin)
                comment.IsApproved = false;

            _context.Comments.Add(comment);

            return Task.CompletedTask;
        }

        public async Task Handle(CommentApproveCommand message)
        {
            var comment = await _context.Comments.FindAsync(message.CommentId);

            if (comment == null)
                return;

            comment.IsApproved = true;
            comment.IsNew = false;
        }
    }
}