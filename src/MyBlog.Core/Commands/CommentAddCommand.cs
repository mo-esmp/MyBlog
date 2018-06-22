using MediatR;
using MyBlog.Core.Entities;

namespace MyBlog.Core.Commands
{
    public class CommentAddCommand : IRequest
    {
        public CommentAddCommand(CommentEntity comment)
        {
            Comment = comment;
        }

        public CommentEntity Comment { get; }
    }

    public class CommentApproveCommand : IRequest
    {
        public CommentApproveCommand(int commentId)
        {
            CommentId = commentId;
        }

        public int CommentId { get; }
    }
}