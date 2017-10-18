using MyBlog.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Areas.Admin.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "TagName", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Name { get; set; }

        public string Slug { get; set; }
    }
}