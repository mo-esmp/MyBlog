using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyBlog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState()
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["OsSpecificCss"] != null)
                return;

            HttpContext.Current.Session["OsSpecificCss"] =
                HttpContext.Current.Request.UserAgent.IndexOf("Windows NT 6.3", StringComparison.InvariantCultureIgnoreCase) > -1 ||
                HttpContext.Current.Request.UserAgent.IndexOf("Windows NT 10.0; Win64", StringComparison.InvariantCultureIgnoreCase) > -1
                ? HttpContext.Current.Session["OsSpecificCss"] = ""
                : HttpContext.Current.Session["OsSpecificCss"] = "~/content/font-fix.css";
        }
    }
}