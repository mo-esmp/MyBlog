using System;
using System.Collections.Generic;

namespace MyBlog.Service.Model
{
    public class PostSummaryModel
    {
        public int Id { get; set; }

        public int CommentCount { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}