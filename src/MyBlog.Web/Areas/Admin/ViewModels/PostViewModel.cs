using MyBlog.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Areas.Admin.ViewModels
{
    public class PostViewModel
    {
        [Display(Name = "Enabled", ResourceType = typeof(NameAndMessage))]
        public bool IsActive { get; set; }

        [MaxLength(70, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Slug { get; set; }

        [Display(Name = "Title", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(400, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Title { get; set; }

        [Display(Name = "Content", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Content { get; set; }

        [Display(Name = "Tag", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Tags { get; set; }
    }
}