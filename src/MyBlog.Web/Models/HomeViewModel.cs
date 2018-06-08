using MyBlog.Core.Entities;
using System.Collections.Generic;

namespace MyBlog.Web.Models
{
    public class HomeViewModel
    {
        public PagedPostViewModel PagedPosts { get; set; }

        public IEnumerable<TagEntity> Tags { get; set; }
    }
}