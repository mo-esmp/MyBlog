using System;
using System.Globalization;

namespace MyBlog.Common.Extensions
{
    /// <summary>
    /// DateTime extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts and formats only date without time in the Jalali (Shamsi) calendar.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="date">The date to convert to jalali.</param>
        /// <param name="leftToRight">if set to <c>true</c> represents date in inverse format.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>System.String.</returns>
        public static string ToJalaliDateString(this DateTime dateTime, DateTime date, bool leftToRight = false, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? CultureInfo.InvariantCulture;
            var pc = new PersianCalendar();
            var convertedDate = string.Format(leftToRight ? "{2}/{1}/{0}" : "{0}/{1}/{2}", pc.GetYear(date),
                pc.GetMonth(date) < 10
                    ? "0" + pc.GetMonth(date)
                    : pc.GetMonth(date).ToString(cultureInfo),
                pc.GetDayOfMonth(date) < 10
                    ? "0" + pc.GetDayOfMonth(date)
                    : pc.GetDayOfMonth(date).ToString(cultureInfo));
            return convertedDate;
        }

        /// <summary>
        /// Converts and formats only date without time in the Jalali (Shamsi) calendar.
        /// </summary>
        /// <param name="dateTime">The current date to convert to jalali.</param>
        /// <param name="leftToRight">if set to <c>true</c> represents date in inverse format.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>System.String.</returns>
        public static string ToJalaliDateString(this DateTime dateTime, bool leftToRight = false, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? CultureInfo.InvariantCulture;
            var pc = new PersianCalendar();
            var convertedDate = string.Format(leftToRight ? "{2}/{1}/{0}" : "{0}/{1}/{2}", pc.GetYear(dateTime),
                pc.GetMonth(dateTime) < 10
                    ? "0" + pc.GetMonth(dateTime)
                    : pc.GetMonth(dateTime).ToString(cultureInfo),
                pc.GetDayOfMonth(dateTime) < 10
                    ? "0" + pc.GetDayOfMonth(dateTime)
                    : pc.GetDayOfMonth(dateTime).ToString(cultureInfo));
            return convertedDate;
        }

        /// <summary>
        /// Converts and formats date in the Jalali (Shamsi) calendar.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="date">The date to convert to jalali.</param>
        /// <param name="leftToRight">if set to <c>true</c> represents date in inverse format.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>System.String.</returns>
        public static string ToJalaliDateTimeString(this DateTime dateTime, DateTime date, bool leftToRight = false, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? CultureInfo.InvariantCulture;
            var pc = new PersianCalendar();
            var convertedDate = string.Format(leftToRight ? "{2}/{1}/{0} {3}:{4}:{5}" : "{3}:{4}:{5} {0}/{1}/{2}",
                pc.GetYear(date),
                pc.GetMonth(date) < 10
                    ? "0" + pc.GetMonth(date)
                    : pc.GetMonth(date).ToString(cultureInfo),
                pc.GetDayOfMonth(date) < 10
                    ? "0" + pc.GetDayOfMonth(date)
                    : pc.GetDayOfMonth(date).ToString(cultureInfo),
                pc.GetHour(date) < 10
                    ? "0" + pc.GetHour(date)
                    : pc.GetHour(date).ToString(cultureInfo),
                pc.GetMinute(date) < 10
                    ? "0" + pc.GetMinute(date)
                    : pc.GetMinute(date).ToString(cultureInfo),
                pc.GetSecond(date) < 10
                    ? "0" + pc.GetSecond(date)
                    : pc.GetSecond(date).ToString(cultureInfo));
            return convertedDate;
        }

        /// <summary>
        /// Converts and formats date in the Jalali (Shamsi) calendar.
        /// </summary>
        /// <param name="dateTime">The current date to convert to jalali.</param>
        /// <param name="leftToRight">if set to <c>true</c> represents date in inverse format.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>System.String.</returns>
        public static string ToJalaliDateTimeString(this DateTime dateTime, bool leftToRight = false, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? CultureInfo.InvariantCulture;
            var pc = new PersianCalendar();
            var convertedDate = string.Format(leftToRight ? "{2}/{1}/{0} {3}:{4}:{5}" : "{3}:{4}:{5} {0}/{1}/{2}",
                pc.GetYear(dateTime),
                pc.GetMonth(dateTime) < 10
                    ? "0" + pc.GetMonth(dateTime)
                    : pc.GetMonth(dateTime).ToString(cultureInfo),
                pc.GetDayOfMonth(dateTime) < 10
                    ? "0" + pc.GetDayOfMonth(dateTime)
                    : pc.GetDayOfMonth(dateTime).ToString(cultureInfo),
                pc.GetHour(dateTime) < 10
                    ? "0" + pc.GetHour(dateTime)
                    : pc.GetHour(dateTime).ToString(cultureInfo),
                pc.GetMinute(dateTime) < 10
                    ? "0" + pc.GetMinute(dateTime)
                    : pc.GetMinute(dateTime).ToString(cultureInfo),
                pc.GetSecond(dateTime) < 10
                    ? "0" + pc.GetSecond(dateTime)
                    : pc.GetSecond(dateTime).ToString(cultureInfo));
            return convertedDate;
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) year.
        /// </summary>
        /// <param name="dateTime">The current date.</param>
        /// <returns>System.Int32.</returns>
        public static int GetJalaliYear(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            var year = pc.GetYear(dateTime);
            return year;
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) year.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <param name="date">The date.</param>
        /// <returns>System.Int32.</returns>
        public static int GetJalaliYear(this DateTime dateTime, DateTime date)
        {
            var pc = new PersianCalendar();
            var year = pc.GetYear(date);
            return year;
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) month.
        /// </summary>
        /// <param name="dateTime">The current date.</param>
        /// <returns>System.Int32.</returns>
        public static int GetJalaliMonth(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            var month = pc.GetMonth(dateTime);
            return month;
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="date">The date.</param>
        /// <returns>System.Int32.</returns>
        public static int GetJalaliMonth(this DateTime dateTime, DateTime date)
        {
            var pc = new PersianCalendar();
            var month = pc.GetMonth(date);
            return month;
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) month name.
        /// </summary>
        /// <param name="dateTime">The current date.</param>
        /// <returns>System.String.</returns>
        public static string GetJalaliMonthName(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            var month = pc.GetMonth(dateTime);
            switch (month)
            {
                case 1:
                    return "فروردین";

                case 2:
                    return "اردیبهشت";

                case 3:
                    return "خرداد";

                case 4:
                    return "تیر";

                case 5:
                    return "مرداد";

                case 6:
                    return "شهریور";

                case 7:
                    return "مهر";

                case 8:
                    return "آبان";

                case 9:
                    return "آذر";

                case 10:
                    return "دی";

                case 11:
                    return "بهمن";

                case 12:
                    return "اسفند";

                default:
                    return "";
            }
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) month name.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string GetJalaliMonthName(this DateTime dateTime, DateTime date)
        {
            var pc = new PersianCalendar();
            var month = pc.GetMonth(date);
            switch (month)
            {
                case 1:
                    return "فروردین";

                case 2:
                    return "اردیبهشت";

                case 3:
                    return "خرداد";

                case 4:
                    return "تیر";

                case 5:
                    return "مرداد";

                case 6:
                    return "شهریور";

                case 7:
                    return "مهر";

                case 8:
                    return "آبان";

                case 9:
                    return "آذر";

                case 10:
                    return "دی";

                case 11:
                    return "بهمن";

                case 12:
                    return "اسفند";

                default:
                    return "";
            }
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) day.
        /// </summary>
        /// <param name="dateTime">The current date.</param>
        /// <returns>System.Int32.</returns>
        public static int GetJalaliDay(this DateTime dateTime)
        {
            var pc = new PersianCalendar();
            var month = pc.GetDayOfMonth(dateTime);
            return month;
        }

        /// <summary>
        /// Gets the Jalali (Shamsi) day.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="date">The date.</param>
        /// <returns>System.Int32.</returns>
        public static int GetJalaliDay(this DateTime dateTime, DateTime date)
        {
            var pc = new PersianCalendar();
            var month = pc.GetDayOfMonth(date);
            return month;
        }

        /// <summary>
        /// Times the ago.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.String.</returns>
        public static string TimeAgo(this DateTime dateTime)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            var delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * minute)
            {
                return ts.Seconds == 1 ? "لحظه ای قبل" : ts.Seconds + " ثانیه قبل";
            }
            if (delta < 2 * minute)
            {
                return "یک دقیقه قبل";
            }
            if (delta < 45 * minute)
            {
                return ts.Minutes + " دقیقه قبل";
            }
            if (delta < 90 * minute)
            {
                return "یک ساعت قبل";
            }
            if (delta < 24 * hour)
            {
                return ts.Hours + " ساعت قبل";
            }
            if (delta < 48 * hour)
            {
                return "دیروز";
            }
            if (delta < 30 * day)
            {
                return ts.Days + " روز قبل";
            }
            if (delta < 12 * month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "یک ماه قبل" : months + " ماه قبل";
            }
            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "یک سال قبل" : years + " سال قبل";
        }

        /// <summary>
        /// Times the ago.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string TimeAgo(this DateTime dateTime, DateTime date)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            var ts = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
            var delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * minute)
                return ts.Seconds == 1 ? "لحظه ای قبل" : ts.Seconds + " ثانیه قبل";

            if (delta < 2 * minute)
                return "یک دقیقه قبل";

            if (delta < 45 * minute)
                return ts.Minutes + " دقیقه قبل";

            if (delta < 90 * minute)
                return "یک ساعت قبل";

            if (delta < 24 * hour)
                return ts.Hours + " ساعت قبل";

            if (delta < 48 * hour)
                return "دیروز";

            if (delta < 30 * day)
                return ts.Days + " روز قبل";

            if (delta < 12 * month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "یک ماه قبل" : months + " ماه قبل";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "یک سال قبل" : years + " سال قبل";
        }
    }
}