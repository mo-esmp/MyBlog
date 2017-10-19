using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Infrastructure.Data.Maps;

namespace MyBlog.Infrastructure.Data.EfMaps
{
    internal class PostEfMap : IEntityMap
    {
        public PostEfMap(ModelBuilder builder)
        {
            builder.Entity<PostEntity>(e =>
            {
                e.Property(p => p.IsActive).IsRequired();
                e.Property(p => p.Title).HasColumnType("nvarchar(256)").IsRequired();
                e.Property(p => p.Slug).HasColumnType("nvarchar(70)").IsRequired();
                e.Property(p => p.CreateDate).IsRequired();
                e.Property(p => p.UpdateDte).IsRequired(false);
                e.Property(p => p.ContentSummary).HasColumnType("nvarchar(512)").IsRequired();
                e.Property(p => p.Content).HasColumnType("nvarchar(max)").IsRequired();
            });
        }
    }
}