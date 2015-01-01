using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MyBlog.Domain;

namespace MyBlog.Service.Contracts
{
    public interface IContactMessageService : IBaseService
    {
        void AddMessage(ContactMessageEntity message);

        void EditMessage(ContactMessageEntity message);

        void EditMessage(IEnumerable<int> idList, bool isNew);

        void DeleteMessage(Expression<Func<ContactMessageEntity, bool>> predicate);

        void DeleteMessages(IEnumerable<int> idList);

        void DeleteMessage(int messageId);

        ContactMessageEntity GetMessage(int messageId);

        ContactMessageEntity GetMessage(Expression<Func<ContactMessageEntity, bool>> predicate);

        IEnumerable<ContactMessageEntity> GetMessages(Expression<Func<ContactMessageEntity, bool>> predicate = null);
    }
}