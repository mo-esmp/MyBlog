using Microsoft.AspNet.Identity.EntityFramework;

namespace MyBlog.Domain
{
    public class RoleEntity : IdentityRole
    {
        public RoleEntity()
        { }

        public RoleEntity(string name)
            : base(name)
        { }

        public string Description { get; set; }
    }
}