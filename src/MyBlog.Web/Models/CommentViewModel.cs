using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MyBlog.Web.Resources;

namespace MyBlog.Web.Models
{
    public class CommentViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(256, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(256, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Email { get; set; }

        [Display(Name = "WebSite", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(256, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        [Url(ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string WebSite { get; set; }

        [Display(Name = "Message", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(256, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Message { get; set; }
    }
}