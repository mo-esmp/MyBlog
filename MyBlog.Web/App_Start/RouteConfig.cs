using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PostDetail",
                url: "post/{id}/{slug}",
                defaults: new { controller = "Post", action = "PostDetail" },
                constraints: new { id = "\\d+" },
                namespaces: new[] { "MyBlog.Web.Controllers" }
            );

            routes.MapRoute(
                name: "PostsByTag",
                url: "tag/{slug}",
                defaults: new { controller = "Post", action = "PostsByTag" },
                namespaces: new[] { "MyBlog.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MyBlog.Web.Controllers" }
            );
        }
    }
}