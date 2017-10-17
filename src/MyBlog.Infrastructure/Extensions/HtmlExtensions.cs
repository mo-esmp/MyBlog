using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Infrastructure.Extensions
{
    public static class HtmlExtensions
    {
        public static string DisplayFor(this HtmlHelper helper, Enum value)
        {
            var enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumValue)[0];

            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attributes[0]).Name;

            if (((DisplayAttribute)attributes[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attributes[0]).GetName();
            }

            return outString;
        }

        /// <summary>
        /// Generates the seo optimized page title fro web.
        /// </summary>
        /// <param name="crumbs">The crumbs.</param>
        /// <returns>System.String.</returns>
        public static string GeneratePageTitle(this HtmlHelper helper, params string[] crumbs)
        {
            const string separatorTitle = " - ";
            const int maxLengthTitle = 60;
            var title = "";

            for (var i = 0; i < crumbs.Length; i++)
            {
                title += String.Format
                    (
                        "{0}{1}",
                        crumbs[i],
                        (i < crumbs.Length - 1) ? separatorTitle : String.Empty
                    );
            }

            title = title.Substring(0, title.Length <= maxLengthTitle ? title.Length : maxLengthTitle).Trim();

            return title;
        }

        public enum CacheControlType
        {
            [Description("public")]
            Public,

            [Description("private")]
            Private,

            [Description("no-cache")]
            NoCache,

            [Description("no-store")]
            NoStore
        }

        public static MvcHtmlString GenerateMetaTag(this HtmlHelper helper, string keyword, string description, bool allowIndexPage, bool allowFollowLinks, string author = "", string lastModified = "", string expires = "never", string language = "fa", CacheControlType cacheControlType = CacheControlType.Private)
        {
            //const int maxLengthTitle = 60;
            const int maxLengthDescription = 170;
            //const string favIconPath = "~/cdn/ui/favicon.ico";
            //title = title.Substring(0, title.Length <= maxLengthTitle ? title.Length : maxLengthTitle).Trim();
            description = description.Substring(0, description.Length <= maxLengthDescription ? description.Length : maxLengthDescription).Trim();

            var meta = "";
            //meta += String.Format("<title>{0}</title>\n", title);
            //meta += String.Format("<meta http-equiv=\"content-language\" content=\"{0}\"/>\n", language);
            //meta += String.Format("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"/>\n");
            //meta += String.Format("<meta charset=\"utf-8\"/>\n");
            meta += String.Format("<meta name=\"keyword\" content=\"{0}\"/>\n", keyword);
            meta += String.Format("<meta name=\"description\" content=\"{0}\"/>\n", description);
            meta += String.Format("<meta http-equiv=\"Cache-control\" content=\"{0}\"/>\n", cacheControlType.GetDescription());
            meta += String.Format("<meta name=\"robots\" content=\"{0}, {1}\" />\n", allowIndexPage ? "index" : "noindex", allowFollowLinks ? "follow" : "nofollow");
            meta += String.Format("<meta name=\"expires\" content=\"{0}\"/>\n", expires);

            if (!String.IsNullOrEmpty(lastModified))
                meta += String.Format("<meta name=\"last-modified\" content=\"{0}\"/>\n", lastModified);

            if (!String.IsNullOrEmpty(author))
                meta += String.Format("<meta name=\"author\" content=\"{0}\"/>\n", author);

            //------------------------------------Google & Bing Doesn't Use Meta Keywords ...
            //meta += string.Format("<meta name=\"keywords\" content=\"{0}\"/>\n", keywords);

            return new MvcHtmlString(meta);
        }
    }
}