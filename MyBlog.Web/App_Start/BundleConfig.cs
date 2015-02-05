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

            bundles.Add(new ScriptBundle("~/bundles/typehead").Include(
                      "~/Scripts/bootstrap-tokenfield.js",
                      "~/Scripts/bootstrap.typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/tagsinput").Include(
                      "~/Scripts/bootstrap-tagsinput.js",
                      "~/Scripts/bootstrap.typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                      "~/Areas/Admin/Scripts/jquery.slimscroll.js",
                      "~/Areas/Admin/Scripts/icheck.js",
                      "~/Areas/Admin/Scripts/helper.js",
                      "~/Areas/Admin/Scripts/startup.js"));

            bundles.Add(new ScriptBundle("~/bundles/syntaxhighlighter").Include(
                      "~/Scripts/syntaxhighlighter/shCore.js",
                      "~/Scripts/syntaxhighlighter/shBrushCSharp.js",
                      "~/Scripts/syntaxhighlighter/shBrushCss.js",
                      "~/Scripts/syntaxhighlighter/shBrushJScript.js",
                      "~/Scripts/syntaxhighlighter/shBrushSql.js",
                      "~/Scripts/syntaxhighlighter/shBrushXml.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Content/bootstrap-rtl.css",
                      "~/Content/Site.css",
                      "~/Content/font.css"));

            bundles.Add(new StyleBundle("~/content/admincss").Include(
                      "~/content/admin/bootstrap.css",
                      "~/content/admin/font-awesome.css",
                      "~/content/admin/adminlte.css"));

            bundles.Add(new StyleBundle("~/content/syntaxhighlighter").Include(
                      "~/content/syntaxhighlighter/shCore.css",
                      "~/content/syntaxhighlighter/shThemedefault.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}