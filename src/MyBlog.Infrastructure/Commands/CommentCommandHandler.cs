using MediatR;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class CommentCommandHandler :
        IRequestHandler<CommentAddCommand>,
        IRequestHandler<CommentApproveCommand>

    {
        private readonly DataContext _context;

        public CommentCommandHandler(DataContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(CommentAddCommand message, CancellationToken cancellationToken)
        {
            var comment = message.Comment;

            if (!comment.IsAdmin)
                comment.IsApproved = false;

            _context.Comments.Add(comment);

            return Unit.Task;
        }

        public async Task<Unit> Handle(CommentApproveCommand message, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(message.CommentId);

            if (comment == null)
                return Unit.Value;

            comment.IsApproved = true;
            comment.IsNew = false;

            return Unit.Value;
        }
    }
}