using MediatR;
using MyBlog.Core.Entities;
using System;

namespace MyBlog.Core.Queries
{
    public class PostGetQuery : IRequest<PostEntity>
    {
        public int PostId { get; set; }
    }

    public class PostGetActiveQuery : IRequest<PostEntity>
    {
        public PostGetActiveQuery(DateTime postDate, string postSlug)
        {
            PostDate = postDate;
            PostSlug = postSlug;
        }

        public DateTime PostDate { get; }

        public string PostSlug { get; }
    }
}