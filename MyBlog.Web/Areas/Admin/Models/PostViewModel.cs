using MyBlog.Domain;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Areas.Admin.Models
{
    public class PostViewModel
    {
        public PostEntity Post { get; set; }

        [Display(Name = "Tag", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Tags { get; set; }
    }
}