using MyBlog.Core.Entities;
using System.Collections.Generic;

namespace MyBlog.Web.Models
{
    public class PagedPostViewModel
    {
        public int TotalPosts { get; set; }

        public IEnumerable<PostEntity> Posts { get; set; }
    }
}