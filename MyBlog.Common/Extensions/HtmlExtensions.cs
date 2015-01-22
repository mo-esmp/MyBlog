using System;
using System.ComponentModel.DataAnnotations;
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
    }
}