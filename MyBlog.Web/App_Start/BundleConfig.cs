using System.Web.Optimization;

namespace MyBlog.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/metrojs").Include(
                "~/Areas/MemberArea/Scripts/jquery.widget.min.js",
                "~/Areas/MemberArea/Scripts/metro.min.js",
                "~/Areas/MemberArea/Scripts/metro/metro-global.js",
                "~/Areas/MemberArea/Scripts/metro/metro-core.js",
                "~/Areas/MemberArea/Scripts/metro/metro-locale.js",
                "~/Areas/MemberArea/Scripts/metro/metro-touch-handler.js",
                "~/Areas/MemberArea/Scripts/metro/metro-dropdown.js",
                "~/Areas/MemberArea/Scripts/metro/metro-input-control.js",
                "~/Areas/MemberArea/Scripts/metro/metro-initiator.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/content/admincss").Include(
                      "~/content/admin/metro-bootstrap.css",
                      "~/content/admin/metro-bootstrap-responsive.css",
                      "~/content/admin/iconfont.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}