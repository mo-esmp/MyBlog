using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;

namespace MyBlog.Infrastructure.Data.Maps
{
    internal class TagEfMap : IEntityMap
    {
        public TagEfMap(ModelBuilder builder)
        {
            builder.Entity<TagEntity>(e =>
            {
                e.Property(t => t.Name).HasColumnType("nvarchar(50)").IsRequired();
                e.Property(t => t.Name).HasColumnType("nvarchar(70)").IsRequired();
            });
        }
    }
}