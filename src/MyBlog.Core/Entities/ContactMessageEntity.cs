using System;

namespace MyBlog.Core.Entities
{
    public class ContactMessageEntity : BaseEntity
    {
        public bool IsNew { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}