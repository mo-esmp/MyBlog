using MyBlog.Core.Entities;
using System.Collections.Generic;

namespace MyBlog.Web.Models
{
    public class HomeViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPage => TotalPosts % 5 != 0 ? TotalPosts / 5 + 1 : TotalPosts / 5;

        public int TotalPosts { get; set; }

        public IEnumerable<PostEntity> Posts { get; set; }
    }
}