using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MyBlog.Core.Entities;
using System.Linq;

namespace MyBlog.Infrastructure.Data
{
    public static class DataContextSeed
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this DataContext context)
        {
            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new TagEntity { Name = "ASP.NET", Slug = "asp-net" },
                    new TagEntity { Name = "ASP.NET Core", Slug = "asp-net-core" },
                    new TagEntity { Name = "C#", Slug = "c-sharp" }
                );

                context.SaveChanges();
            }
        }
    }
}