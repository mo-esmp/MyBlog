using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Domain
{
    public class TagEntity : BaseEntity
    {
        [DataType(DataType.Text)]
        [Display(Name = "TagName", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Name { get; set; }

        [MaxLength(70, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Slug { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }
    }
}