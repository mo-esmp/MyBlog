using MyBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyBlog.Service.Contracts
{
    public interface ITagService : IBaseService
    {
        void AddTag(TagEntity tag);

        void EditTag(TagEntity editedTag);

        void DeleteTag(Expression<Func<TagEntity, bool>> predicate);

        void DeleteTag(int tagId);

        TagEntity GetTag(int tagId);

        TagEntity GetTag(Expression<Func<TagEntity, bool>> predicate);

        IEnumerable<TagEntity> GetTags(Expression<Func<TagEntity, bool>> predicate = null);
    }
}