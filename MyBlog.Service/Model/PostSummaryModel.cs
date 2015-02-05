using System;
using System.Collections.Generic;
using MyBlog.Domain;

namespace MyBlog.Service.Model
{
    public class PostSummaryModel
    {
        public int Id { get; set; }

        public int CommentCount { get; set; }

        public DateTime CreateDate { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public IEnumerable<TagEntity> Tags { get; set; }
    }
}