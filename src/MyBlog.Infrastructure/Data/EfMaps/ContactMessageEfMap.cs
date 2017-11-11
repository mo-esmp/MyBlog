using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Infrastructure.Data.Maps;

namespace MyBlog.Infrastructure.Data.EfMaps
{
    internal class ContactMessageEfMap : IEntityMap
    {
        public ContactMessageEfMap(ModelBuilder builder)
        {
            builder.Entity<ContactMessageEntity>(e =>
            {
                e.Property(cm => cm.IsNew).IsRequired();
                e.Property(cm => cm.CreateDate).IsRequired();
                e.Property(cm => cm.Name).IsUnicode().HasMaxLength(100).IsRequired();
                e.Property(cm => cm.Email).IsUnicode(false).HasMaxLength(100).IsRequired();
                e.Property(cm => cm.Message).IsUnicode().HasMaxLength(2000).IsRequired();
            });
        }
    }
}