using MyBlog.Data.Contracts;
using MyBlog.Domain;
using MyBlog.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyBlog.Service.Implementation
{
    public class ContactMessageService : BaseService<ContactMessageEntity>, IContactMessageService
    {
        public ContactMessageService(IQueryableContext queryableContext)
            : base(queryableContext)
        {
        }

        public void AddMessage(ContactMessageEntity message)
        {
            message.IsNew = true;
            message.CreateDate = DateTime.Now;
            AddItem(message);
        }

        public void EditMessage(ContactMessageEntity message)
        {
            EditItem(message);
        }

        public void EditMessage(IEnumerable<int> idList, bool isNew)
        {
            foreach (var message in idList.Select(messageId => FindItem(messageId)))
            {
                if (message == null)
                    return;

                message.IsNew = isNew;
                EditItem(message);
            }
        }

        public void DeleteMessage(Expression<Func<ContactMessageEntity, bool>> predicate)
        {
            DeleteItem(predicate);
        }

        public void DeleteMessage(int messageId)
        {
            var message = FindItem(messageId);
            if (message == null)
                return;

            DeleteItem(message);
        }

        public void DeleteMessages(IEnumerable<int> idList)
        {
            foreach (var message in idList.Select(messageId => FindItem(messageId)))
            {
                if (message == null)
                    return;

                DeleteItem(message);
            }
        }

        public ContactMessageEntity GetMessage(int messageId)
        {
            var message = FindItem(messageId);
            if (message == null || !message.IsNew)
                return message;

            message.IsNew = false;
            EditMessageAsync(message);
            return message;
        }

        public ContactMessageEntity GetMessage(Expression<Func<ContactMessageEntity, bool>> predicate)
        {
            var message = GetItem(predicate);
            if (message != null && message.IsNew)
                EditMessageAsync(message);

            return message;
        }

        public IEnumerable<ContactMessageEntity> GetMessages(Expression<Func<ContactMessageEntity, bool>> predicate = null)
        {
            var messages = GetItems(predicate).OrderByDescending(m => m.CreateDate);
            return messages;
        }

        private async void EditMessageAsync(ContactMessageEntity message)
        {
            EditItem(message);
            CommitAsync();
        }
    }
}