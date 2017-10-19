using MyBlog.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyBlog.Data.Mapping
{
    internal class PostMap : EntityTypeConfiguration<PostEntity>
    {
        public PostMap()
        {
            ToTable("Post");
            Property(cm => cm.IsEnabled).IsRequired().HasColumnOrder(1);
            Property(cm => cm.Title).IsUnicode(true).HasMaxLength(400).IsRequired().HasColumnOrder(2);
            Property(cm => cm.Slug).IsUnicode(true).HasMaxLength(500).IsRequired().HasColumnOrder(3);
            Property(cm => cm.CreateDate).IsRequired().HasColumnOrder(4);
            Property(cm => cm.UpdateDte).IsOptional().HasColumnOrder(5);
            Property(cm => cm.Slug).IsUnicode(true).HasMaxLength(int.MaxValue).IsRequired();

            HasMany(p => p.Tags).WithMany(p => p.Posts).Map(m => m.MapLeftKey("PostId").MapRightKey("TagId").ToTable("PostTag"));
        }
    }
}

internal class PostMap : EntityTypeConfiguration<PostEntity>
{
    public PostMap()
    {
        ToTable("Post");
        Property(cm => cm.IsEnabled).IsRequired().HasColumnOrder(1);
        Property(cm => cm.Title).IsUnicode(true).HasMaxLength(400).IsRequired().HasColumnOrder(2);
        Property(cm => cm.Slug).IsUnicode(true).HasMaxLength(500).IsRequired().HasColumnOrder(3);
        Property(cm => cm.CreateDate).IsRequired().HasColumnOrder(4);
        Property(cm => cm.UpdateDte).IsOptional().HasColumnOrder(5);
        Property(cm => cm.Slug).IsUnicode(true).HasMaxLength(int.MaxValue).IsRequired();

        HasMany(p => p.Tags).WithMany(p => p.Posts).Map(m => m.MapLeftKey("PostId").MapRightKey("TagId").ToTable("PostTag"));
    }
}