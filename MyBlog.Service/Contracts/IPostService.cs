using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyBlog.Service.Contracts
{
    public interface IPostService : IBaseService
    {
        void AddPost(PostEntity post);

        void EditPost(PostEntity editedPost);

        void DeletePost(Expression<Func<PostEntity, bool>> predicate);

        void DeletePost(int postId);

        PostEntity GetPost(int postId);

        PostEntity GetPost(Expression<Func<PostEntity, bool>> predicate, params Expression<Func<PostEntity, object>>[] includes);

        IEnumerable<PostEntity> GetPosts(Expression<Func<PostEntity, bool>> predicate = null, params Expression<Func<PostEntity, object>>[] includes);
    }
}