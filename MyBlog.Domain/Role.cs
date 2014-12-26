using Microsoft.AspNet.Identity.EntityFramework;

namespace MyBlog.Domain
{
    public class Role : IdentityRole
    {
        public Role()
        { }

        public Role(string name)
            : base(name)
        { }

        public string Description { get; set; }
    }
}