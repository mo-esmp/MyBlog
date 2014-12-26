using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MyBlog.Common.Extensions
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
        /// Truncate plain text string without cutting words appending
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="input">The input string for truncating</param>
        /// <param name="maxLength">The length of truncated string</param>
        public static string TurncateString(this HtmlHelper helper, string input, int maxLength)
        {
            if (input == null)
                throw new ArgumentNullException();

            input = input.Trim();

            if (string.IsNullOrEmpty(input))
                return input;

            var tags = new Regex("<(.|\n)+?>");
            if (tags.IsMatch(input))
                input = tags.Replace(input, "");

            var response = input;
            if (input.Length <= maxLength)
                return response;

            do
            {
                var c = input.Substring(maxLength, 1);
                if (c == " ")
                {
                    response = input.Substring(0, maxLength);
                    break;
                }
                maxLength--;
            } while (maxLength > 0);

            return response + " ...";
        }

        /// <summary>
        /// Truncates a string containing HTML to a number of text characters, keeping whole words.
        /// The result contains HTML and any tags left open are closed.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="html"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string TruncateHtml(this HtmlHelper helper, string html, int maxLength)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            // find the spot to truncate
            // count the text characters and ignore tags
            var textCount = 0;
            var charCount = 0;
            var ignore = false;
            foreach (char c in html)
            {
                charCount++;
                if (c == '<')
                    ignore = true;
                else if (!ignore)
                    textCount++;

                if (c == '>')
                    ignore = false;

                // stop once we hit the limit
                if (textCount >= maxLength)
                    break;
            }

            // Truncate the html and keep whole words only
            var trunc = new StringBuilder(helper.TruncateWords(html, charCount));

            // keep track of open tags and close any tags left open
            var tags = new Stack<string>();
            var matches = Regex.Matches(trunc.ToString(),
                @"<((?<tag>[^\s/>]+)|/(?<closeTag>[^\s>]+)).*?(?<selfClose>/)?\s*>",
                RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    var tag = match.Groups["tag"].Value;
                    var closeTag = match.Groups["closeTag"].Value;

                    // push to stack if open tag and ignore it if it is self-closing, i.e. <br />
                    if (!string.IsNullOrEmpty(tag) && string.IsNullOrEmpty(match.Groups["selfClose"].Value))
                        tags.Push(tag);

                    // pop from stack if close tag
                    else if (!string.IsNullOrEmpty(closeTag))
                    {
                        // pop the tag to close it.. find the matching opening tag
                        // ignore any unclosed tags
                        while (tags.Pop() != closeTag && tags.Count > 0)
                        { }
                    }
                }
            }

            if (html.Length > charCount)

                // add the trailing text
                trunc.Append(" ...");

            // pop the rest off the stack to close remainder of tags
            while (tags.Count > 0)
            {
                trunc.Append("</");
                trunc.Append(tags.Pop());
                trunc.Append('>');
            }

            return trunc.ToString();
        }

        /// <summary>
        /// Truncates text and discards any partial words left at the end
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="text"></param>
        /// <param name="maxCharacters"></param>
        /// <returns></returns>
        public static string TruncateWords(this HtmlHelper helper, string text, int maxCharacters)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;

            // Truncate the text, then remove the partial word at the end
            return Regex.Replace(helper.TruncateHtml(text, maxCharacters),
                @"\s+[^\s]+$", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled) + " ...";
        }
    }
}