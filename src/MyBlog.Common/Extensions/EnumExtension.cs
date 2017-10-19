using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Common.Extensions
{
    /// <summary>
    /// Class EnumExtension.
    /// </summary>
    public static class EnumExtension
    {
        private static readonly Dictionary<Enum, string> Cache = new Dictionary<Enum, string>();

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetDisplayName(this Enum value)
        {
            if (Cache.ContainsKey(value))
                return Cache[value];

            var enumType = value.GetType();
            var enumName = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumName)[0];

            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attributes[0]).Name;

            if (((DisplayAttribute)attributes[0]).ResourceType != null)
                outString = ((DisplayAttribute)attributes[0]).GetName();
            Cache.Add(value, outString);

            return outString;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription(this Enum value)
        {
            if (Cache.ContainsKey(value))
                return Cache[value];

            var enumType = value.GetType();
            var enumName = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumName)[0];

            var attributes = member.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var outString = ((DescriptionAttribute)attributes[0]).Description;
            Cache.Add(value, outString);

            return outString;
        }
    }
}