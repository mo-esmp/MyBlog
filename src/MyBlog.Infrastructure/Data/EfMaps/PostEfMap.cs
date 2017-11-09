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
                e.Property(p => p.Slug).HasColumnType("nvarchar(100)").IsRequired();
                e.Property(p => p.CreateDate).HasColumnType("datetime").IsRequired();
                e.Property(p => p.UpdateDte).HasColumnType("datetime").IsRequired(false);
                e.Property(p => p.ContentSummary).HasColumnType("nvarchar(max)").IsRequired();
                e.Property(p => p.Content).HasColumnType("nvarchar(max)").IsRequired();
            });
        }
    }
}