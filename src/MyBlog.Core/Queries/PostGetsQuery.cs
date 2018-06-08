using MediatR;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;

namespace MyBlog.Core.Queries
{
    public class PostGetsQuery : IRequest<IEnumerable<PostEntity>>
    {
    }

    public class PostGetsPagedQuery : IRequest<Tuple<IEnumerable<PostEntity>, int>>
    {
        public PostGetsPagedQuery(int page, string tagSlug = null)
        {
            Page = page;
            TagSlug = tagSlug;
        }

        public int Page { get; }

        public string TagSlug { get; }
    }
}