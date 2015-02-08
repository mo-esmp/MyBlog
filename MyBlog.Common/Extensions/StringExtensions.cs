using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyBlog.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether string has has RTL character.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if [has RTL character] [the specified text]; otherwise, <c>false</c>.</returns>
        public static bool HasRtlCharacter(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            var chars = text.ToCharArray();
            return chars.Any(c => c >= 0x600 && c <= 0x6ff);
        }

        /// <summary>
        /// Convert to the persian digits.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string ToPersianDigits(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var splitted = text.ToCharArray();
            var convertedText = string.Empty;
            for (var i = 0; i < splitted.Length; i++)
            {
                switch (splitted[i])
                {
                    case '1':
                        convertedText += "١";
                        break;

                    case '2':
                        convertedText += "٢";
                        break;

                    case '3':
                        convertedText += "٣";
                        break;

                    case '4':
                        convertedText += "٤";
                        break;

                    case '5':
                        convertedText += "٥";
                        break;

                    case '6':
                        convertedText += "٦";
                        break;

                    case '7':
                        convertedText += "٧";
                        break;

                    case '8':
                        convertedText += "٨";
                        break;

                    case '9':
                        convertedText += "٩";
                        break;

                    case '0':
                        convertedText += "٠";
                        break;

                    case '.':
                        if (i == 0)
                        {
                            if (char.IsDigit(splitted[i + 1]))
                                convertedText += "/";
                        }
                        else
                        {
                            if (char.IsDigit(splitted[i - 1]))
                                convertedText += "/";
                        }
                        break;

                    default:
                        convertedText += splitted[i];
                        break;
                }
            }

            return convertedText;
        }

        /// <summary>
        /// Truncates a string containing HTML to a number of text characters, keeping whole words.
        /// The result contains HTML and any tags left open are closed.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="maxCharacters"></param>
        /// <param name="trailingText"></param>
        /// <returns></returns>
        public static string TruncateHtml(this string html, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            // find the spot to truncate
            // count the text characters and ignore tags
            var textCount = 0;
            var charCount = 0;
            var ignore = false;
            foreach (var c in html)
            {
                charCount++;
                if (c == '<')
                    ignore = true;
                else if (!ignore)
                    textCount++;

                if (c == '>')
                    ignore = false;

                // stop once we hit the limit
                if (textCount >= maxCharacters)
                    break;
            }

            // Truncate the html and keep whole words only
            var truncate = new StringBuilder(html.TruncateWords(charCount));

            // keep track of open tags and close any tags left open
            var tags = new Stack<string>();
            var matches = Regex.Matches(truncate.ToString(),
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
                        {
                        }
                    }
                }
            }

            if (html.Length > charCount)
                // add the trailing text
                truncate.Append(trailingText);

            // pop the rest off the stack to close remainder of tags
            while (tags.Count > 0)
            {
                truncate.Append("</");
                truncate.Append(tags.Pop());
                truncate.Append('>');
            }

            return truncate.ToString();
        }

        /// <summary>
        /// Truncates a string containing HTML to a number of text characters, keeping whole words.
        /// The result contains HTML and any tags left open are closed.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="maxCharacters"></param>
        /// <returns></returns>
        public static string TruncateHtml(this string html, int maxCharacters)
        {
            return html.TruncateHtml(maxCharacters, null);
        }

        /// <summary>
        /// Strips all HTML tags from a string
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string StripHtml(this string html)
        {
            return string.IsNullOrEmpty(html) ? html : Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }

        /// <summary>
        /// Truncates text to a number of characters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxCharacters"></param>
        /// <returns></returns>
        public static string Truncate(this string text, int maxCharacters)
        {
            return text.Truncate(maxCharacters, null);
        }

        /// <summary>
        /// Truncates text to a number of characters and adds trailing text, i.e. ellipses, to the end
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxCharacters"></param>
        /// <param name="trailingText"></param>
        /// <returns></returns>
        public static string Truncate(this string text, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;

            return text.Substring(0, maxCharacters) + trailingText;
        }

        /// <summary>
        /// Truncates text and discards any partial words left at the end
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxCharacters"></param>
        /// <returns></returns>
        public static string TruncateWords(this string text, int maxCharacters)
        {
            return text.TruncateWords(maxCharacters, null);
        }

        /// <summary>
        /// Truncates text and discards any partial words left at the end
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxCharacters"></param>
        /// <param name="trailingText"></param>
        /// <returns></returns>
        public static string TruncateWords(this string text, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;

            // truncate the text, then remove the partial word at the end
            return Regex.Replace(text.Truncate(maxCharacters),
                @"\s+[^\s]+$", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled) + trailingText;
        }
    }
}