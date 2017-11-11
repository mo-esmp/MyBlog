using System.Collections.Generic;

namespace MyBlog.Web.Areas.Admin.ViewModels
{
    public class PostEditViewModel
    {
        public PostViewModel Post { get; set; }

        public IEnumerable<KeyValuePair<int, string>> Tags { get; set; }
    }
}