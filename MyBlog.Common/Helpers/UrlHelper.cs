using System.Text;
using System.Text.RegularExpressions;

namespace MyBlog.Common.Helpers
{
    public class UrlHelper
    {
        public static string GenerateSlug(string value)
        {
            var slug = RemoveAccent(value).ToLower();
            slug = Regex.Replace(slug, @"،", " ").Trim();
            slug = Regex.Replace(slug, @"[^a-z0-9-\u0600-\u06FF]", "-");
            slug = Regex.Replace(slug, @"\s+", "-").Trim();
            slug = Regex.Replace(slug, @"-+", "-");

            slug = slug.Substring(0, slug.Length <= 50 ? slug.Length : 50).Trim();

            return slug;
        }

        private static string RemoveAccent(string text)
        {
            var bytes = Encoding.GetEncoding("UTF-8").GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}