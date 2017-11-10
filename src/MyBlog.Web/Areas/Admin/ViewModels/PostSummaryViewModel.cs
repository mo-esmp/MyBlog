using MyBlog.Web.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Areas.Admin.ViewModels
{
    public class PostSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Enabled", ResourceType = typeof(NameAndMessage))]
        public bool IsActive { get; set; }

        [MaxLength(70, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Slug { get; set; }

        [Display(Name = "Title", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(400, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Title { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(NameAndMessage))]
        public DateTime CreateDate { get; set; }
    }
}