using System;
using System.Linq;

namespace MyBlog.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool HasRtlCharacter(this String text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            var chars = text.ToCharArray();
            return chars.Any(c => c >= 0x600 && c <= 0x6ff);
        }

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
    }
}