using System.Text;
using System.Text.RegularExpressions;

namespace MyBlog.Common.Helpers
{
    public class UriHelper
    {
        public static string GenerateSlug(string value)
        {
            if (value.Length > 50)
            {
                var i = 49;
                while (value[i] != ' ')
                {
                    i++;
                }

                value = value.Substring(0, i);
            }

            //First to lower case
            value = value.ToLowerInvariant();

            //Remove all accents
            var bytes = Encoding.GetEncoding("UTf-8").GetBytes(value);
            value = Encoding.UTF8.GetString(bytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\u0600-\u06FFuFB8A\u067E\u0686\u06AF\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurrences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }
    }
}