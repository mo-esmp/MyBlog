using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Common.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var enumType = value.GetType();
            var enumName = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumName)[0];

            var attributes = member.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var outString = attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : value.ToString();

            return outString;
        }

        public static string GetDisplayName(this Enum value)
        {
            var enumType = value.GetType();
            var enumName = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumName)[0];

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