using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyBlog.Service.Contracts
{
    /// <summary>
    /// ITagService Interface
    /// </summary>
    public interface ITagService : IBaseService
    {
        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        void AddTag(TagEntity tag);

        /// <summary>
        /// Edits the tag.
        /// </summary>
        /// <param name="editedTag">The edited tag.</param>
        void EditTag(TagEntity editedTag);

        /// <summary>
        /// Deletes the tag.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void DeleteTag(Expression<Func<TagEntity, bool>> predicate);

        /// <summary>
        /// Deletes the tag.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        void DeleteTag(int tagId);

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns>TagEntity.</returns>
        TagEntity GetTag(int tagId);

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TagEntity.</returns>
        TagEntity GetTag(Expression<Func<TagEntity, bool>> predicate);

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IEnumerable&lt;TagEntity&gt;.</returns>
        IEnumerable<TagEntity> GetTags(Expression<Func<TagEntity, bool>> predicate = null);
    }
}