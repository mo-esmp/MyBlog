using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Infrastructure.Data.Maps;

namespace MyBlog.Infrastructure.Data.EfMaps
{
    internal class CommentEfMap : IEntityMap
    {
        public CommentEfMap(ModelBuilder builder)
        {
            builder.Entity<CommentEntity>(e =>
            {
                e.Property(m => m.Message).HasColumnType("nvarchar(max)").IsRequired();
                e.Property(m => m.Name).HasColumnType("nvarchar(256)").IsRequired(false);
                e.Property(m => m.Email).HasColumnType("nvarchar(256)").IsRequired(false);
                e.Property(c => c.WebSite).HasColumnType("nvarchar(256)").IsRequired(false);
            });
        }
    }
}