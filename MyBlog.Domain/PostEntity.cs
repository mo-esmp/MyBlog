using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBlog.Domain
{
    public class PostEntity : BaseEntity
    {
        [Display(Name = "Enabled", ResourceType = typeof(NameAndMessage))]
        public bool IsEnabled { get; set; }

        [DataType(DataType.Url)]
        [ScaffoldColumn(false)]
        public string Slug { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Title", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        [MaxLength(400, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Content", ResourceType = typeof(NameAndMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(NameAndMessage))]
        public string Content { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Time)]
        [Display(Name = "CreateDate", ResourceType = typeof(NameAndMessage))]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Time)]
        [Display(Name = "UpdateDate", ResourceType = typeof(NameAndMessage))]
        public DateTime? UpdateDte { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }
    }
}