using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyBlog.Service.Contracts
{
    public interface ICommentService : IBaseService
    {
        void AddComment(CommentEntity comment);

        void EditComment(CommentEntity editedComment);

        void DeleteComment(Expression<Func<CommentEntity, bool>> predicate);

        void DeleteComment(int commentId);

        CommentEntity GetComment(int commentId);

        CommentEntity GetComment(Expression<Func<CommentEntity, bool>> predicate);

        IEnumerable<CommentEntity> GetComments(Expression<Func<CommentEntity, bool>> predicate = null);
    }
}