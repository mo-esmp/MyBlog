using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;

namespace MyBlog.Infrastructure.Data.Maps
{
    internal class TagEfMap : IEntityMap
    {
        public TagEfMap(ModelBuilder builder)
        {
            builder.Entity<TagEntity>(c =>
            {
                c.Property(a => a.Name).HasColumnType("nvarchar(50)").IsRequired();
                c.Property(a => a.Name).HasColumnType("nvarchar(60)").IsRequired();

                //c.HasOne(a => a.Province)
                //    .WithMany(a => a.Cities).HasForeignKey(a => a.ProvinceId);
            });
        }
    }
}