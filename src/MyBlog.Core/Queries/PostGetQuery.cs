using MediatR;
using MyBlog.Core.Entities;
using System;

namespace MyBlog.Core.Queries
{
    public class PostGetQuery : IRequest<PostEntity>
    {
        public int PostId { get; set; }
    }

    public class PostGetActiveBySlugAndDateQuery : IRequest<PostEntity>
    {
        public PostGetActiveBySlugAndDateQuery(DateTime postDate, string postSlug)
        {
            PostDate = postDate;
            PostSlug = postSlug;
        }

        public DateTime PostDate { get; }

        public string PostSlug { get; }
    }

    public class PostGetDateQuery : IRequest<DateTime?>
    {
        public PostGetDateQuery(string postSlug)
        {
            PostSlug = postSlug;
        }

        public string PostSlug { get; }
    }
}