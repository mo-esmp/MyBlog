using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Infrastructure.Data.Maps;

namespace MyBlog.Infrastructure.Data.EfMaps
{
    internal class PostTagEfMap : IEntityMap
    {
        public PostTagEfMap(ModelBuilder builder)
        {
            builder.Entity<PostTagEntity>(e =>
            {
                e.HasKey(pt => new { pt.PostId, pt.TagId });

                e.HasOne(pt => pt.Post).WithMany(p => p.PostTags).HasForeignKey(pt => pt.PostId);

                e.HasOne(pt => pt.Tag).WithMany(p => p.PostTags).HasForeignKey(pt => pt.TagId);
            });
        }
    }
}