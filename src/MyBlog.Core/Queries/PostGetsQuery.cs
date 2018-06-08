using MediatR;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;

namespace MyBlog.Core.Queries
{
    public class PostGetsQuery : IRequest<IEnumerable<PostEntity>>
    {
    }

    public class PostPagedGetsQuery : IRequest<Tuple<IEnumerable<PostEntity>, int>>
    {
        public PostPagedGetsQuery(int page)
        {
            Page = page;
        }

        public int Page { get; }
    }
}