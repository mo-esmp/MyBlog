using MyBlog.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyBlog.Data.Mapping
{
    internal class CommentMap : EntityTypeConfiguration<CommentEntity>
    {
        public CommentMap()
        {
            ToTable("Comment");
            Property(c => c.PostId).IsRequired().HasColumnOrder(1);
            Property(c => c.ParentId).IsOptional().HasColumnOrder(2);
            Property(c => c.IsEnabled).IsRequired().HasColumnOrder(3);
            Property(c => c.CreateDate).IsRequired().HasColumnOrder(4);
            Property(c => c.Content).IsUnicode(true).HasMaxLength(2000).IsOptional().HasColumnOrder(5);

            HasMany(c => c.Children).WithOptional(c => c.Parent).HasForeignKey(c => c.ParentId);
        }
    }
}