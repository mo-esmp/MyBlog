using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Domain
{
    public class ContactMessageEntity : BaseEntity
    {
        public bool IsNew { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(NameAndMessage))]
        [StringLength(100, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Name { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(NameAndMessage))]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Email", ResourceType = typeof(NameAndMessage))]
        [StringLength(100, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message", ResourceType = typeof(NameAndMessage))]
        [StringLength(2000, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Message { get; set; }
    }
}