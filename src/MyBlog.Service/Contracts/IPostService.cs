using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlog.Service.Contracts
{
    /// <summary>
    /// IPostService Interface
    /// </summary>
    public interface IPostService : IBaseService
    {
        /// <summary>
        /// Adds the post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <param name="tagsId">The concatenated tags identifier .</param>
        void AddPost(PostEntity post, string tagsId);

        /// <summary>
        /// Edits the post.
        /// </summary>
        /// <param name="editedPost">The edited post.</param>
        /// <param name="tagsId">The concatenated tags identifier .</param>
        void EditPost(PostEntity editedPost, string tagsId);

        /// <summary>
        /// Deletes the post.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void DeletePost(Expression<Func<PostEntity, bool>> predicate);

        /// <summary>
        /// Gets the post.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <returns>PostEntity.</returns>
        PostEntity GetPost(int postId);

        /// <summary>
        /// Gets the post.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>PostEntity.</returns>
        PostEntity GetPost(Expression<Func<PostEntity, bool>> predicate, params Expression<Func<PostEntity, object>>[] includes);

        /// <summary>
        /// Gets the posts.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;PostEntity&gt;.</returns>
        IEnumerable<PostEntity> GetPosts(Expression<Func<PostEntity, bool>> predicate = null, params Expression<Func<PostEntity, object>>[] includes);

        IEnumerable<PostEntity> GetPosts<TKey>(Expression<Func<PostEntity, bool>> predicate,
            Expression<Func<PostEntity, TKey>> selector, SortOrder sortOrder,
            params Expression<Func<PostEntity, object>>[] includes);

        Task<IEnumerable<PostEntity>> GetPostsAsync<TKey>(Expression<Func<PostEntity, bool>> predicate,
            Expression<Func<PostEntity, TKey>> selector, SortOrder sortOrder,
            params Expression<Func<PostEntity, object>>[] includes);
    }
}