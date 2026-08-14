using Hengam.Numbers;
using System.Globalization;

namespace Hengam.Dates
{
    public static class PersianDateExtensions
    {
        private static readonly string[] PersianMonthNames =
        {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"
        };

        private static readonly string[] PersianDayNames =
        {
            "یکشنبه",
            "دوشنبه",
            "سه‌شنبه",
            "چهارشنبه",
            "پنجشنبه",
            "جمعه",
            "شنبه"
        };

        /// <summary>
        /// Converts a Gregorian date to a Persian (Jalali) date in a human-readable format,
        /// such as "۲۲ مرداد ۱۴۰۵".
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time to convert.</param>
        /// <returns>A formatted Persian date containing the day, month name, and year.</returns>
        public static string ToPersianDateString(this DateTime dateTime)
        {
            var persianCalendar = new System.Globalization.PersianCalendar();

            var year = persianCalendar.GetYear(dateTime);
            var month = persianCalendar.GetMonth(dateTime);
            var day = persianCalendar.GetDayOfMonth(dateTime);

            return $"{PersianNumberFormatter.ToPersianDigits(day)} " +
                   $"{PersianMonthNames[month - 1]} " +
                   $"{PersianNumberFormatter.ToPersianDigits(year)}";
        }

        /// <summary>
        /// Converts a Gregorian date to a Persian (Jalali) date in a numeric format,
        /// such as "۱۴۰۵/۰۵/۲۲".
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time to convert.</param>
        /// <returns>A formatted Persian date using the year/month/day format.</returns>
        public static string ToPersianShortDateString(this DateTime dateTime)
        {
            var calendar = new PersianCalendar();

            var year = calendar.GetYear(dateTime);
            var month = calendar.GetMonth(dateTime);
            var day = calendar.GetDayOfMonth(dateTime);

            return $"{PersianNumberFormatter.ToPersianDigits(year)}/" +
                   $"{PersianNumberFormatter.ToPersianDigits(month).PadLeft(2, '۰')}/" +
                   $"{PersianNumberFormatter.ToPersianDigits(day).PadLeft(2, '۰')}";
        }

        /// <summary>
        /// Gets the Persian name of the day of the week for the specified date.
        /// </summary>
        /// <param name="dateTime">The date and time whose day of the week should be retrieved.</param>
        /// <returns>The Persian name of the corresponding day of the week.</returns>
        public static string ToPersianDayOfWeekString(this DateTime dateTime)
        {
            return PersianDayNames[(int)dateTime.DayOfWeek];
        }
    }
}
