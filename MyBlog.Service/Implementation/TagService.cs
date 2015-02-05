using MyBlog.Common.Helpers;
using MyBlog.Data;
using MyBlog.Data.Contracts;
using MyBlog.Domain;
using MyBlog.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlog.Service.Implementation
{
    public class TagService : BaseService<TagEntity>, ITagService
    {
        private readonly DataContext _context;

        public TagService(IQueryableContext queryableContext)
            : base(queryableContext)
        {
            _context = queryableContext.EfContext;
        }

        public void AddTag(TagEntity tag)
        {
            tag.Slug = UrlHelper.GenerateSlug(tag.Name);
            if (GetTag(t => t.Slug == tag.Slug) != null)
                return;

            AddItem(tag);
        }

        public void EditTag(TagEntity editedTag)
        {
            editedTag.Slug = UrlHelper.GenerateSlug(editedTag.Name);
            EditItem(editedTag);
        }

        public void DeleteTag(Expression<Func<TagEntity, bool>> predicate)
        {
            DeleteItem(predicate);
        }

        public void DeleteTag(int tagId)
        {
            var tag = FindItem(tagId);
            DeleteItem(tag);
        }

        public TagEntity GetTag(int tagId)
        {
            var tag = FindItem(tagId);
            return tag;
        }

        public TagEntity GetTag(Expression<Func<TagEntity, bool>> predicate)
        {
            var tag = GetItem(predicate);
            return tag;
        }

        public IEnumerable<TagEntity> GetTags(Expression<Func<TagEntity, bool>> predicate = null)
        {
            var tags = GetItems(predicate);
            return tags;
        }

        public async Task<IEnumerable<TagEntity>> GetTagsAsync(Expression<Func<TagEntity, bool>> predicate = null)
        {
            var tags = await GetItems(predicate).ToListAsync();
            return tags;
        }

        public IEnumerable<TagEntity> GetTags(IEnumerable<int> idList)
        {
            var tags = from tag in _context.Tags
                       where idList.Contains(tag.Id)
                       select tag;

            return tags;
        }
    }
}