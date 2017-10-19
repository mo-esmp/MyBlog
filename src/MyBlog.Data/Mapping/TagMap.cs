using MyBlog.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyBlog.Data.Mapping
{
    internal class TagMap : EntityTypeConfiguration<TagEntity>
    {
        public TagMap()
        {
            ToTable("Tag");
            Property(c => c.Name).IsUnicode(true).HasMaxLength(50).IsRequired().HasColumnOrder(1);
            Property(c => c.Slug).IsUnicode(true).HasMaxLength(70).IsRequired().HasColumnOrder(2);
        }
    }
}