using MyBlog.Domain;
using System.Collections.Generic;
using MyBlog.Service.Model;

namespace MyBlog.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<PostSummaryModel> Posts { get; set; }

        public IEnumerable<TagEntity> Tags { get; set; }
    }
}