using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Infrastructure.Data.Maps;
using System;
using System.Linq;

namespace MyBlog.Infrastructure.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContactMessageEntity> Messages { get; set; }

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<PostTagEntity> PostTags { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=local;Database=MyBlog;Integrated Security=True;MultipleActiveResultSets=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterMaps(builder);

            base.OnModelCreating(builder);
        }

        private static void RegisterMaps(ModelBuilder builder)
        {
            var maps = typeof(DataContext).Assembly
                .GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace) && type.IsClass && typeof(IEntityMap).IsAssignableFrom(type)).ToList();

            foreach (var type in maps)
                Activator.CreateInstance(type, builder);
        }
    }
}