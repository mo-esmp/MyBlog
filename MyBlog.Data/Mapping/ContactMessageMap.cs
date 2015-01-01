using MyBlog.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyBlog.Data.Mapping
{
    internal class ContactMessageMap : EntityTypeConfiguration<ContactMessageEntity>
    {
        public ContactMessageMap()
        {
            ToTable("ContactMessage");
            Property(cm => cm.IsNew).IsRequired().HasColumnOrder(1);
            Property(cm => cm.CreateDate).IsRequired().HasColumnOrder(2);
            Property(cm => cm.Name).IsUnicode(true).HasMaxLength(100).IsRequired().HasColumnOrder(3);
            Property(cm => cm.Email).IsUnicode(false).HasMaxLength(100).IsRequired().HasColumnOrder(4);
            Property(cm => cm.Message).IsUnicode(true).HasMaxLength(2000).IsRequired().HasColumnOrder(6);
        }
    }
}