using Hengam.Numbers;
using System.Globalization;

namespace Hengam.Dates
{
    public static class PersianDateExtensions
    {
        private static readonly PersianCalendar PersianCalendar = new PersianCalendar();

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
            var year = PersianCalendar.GetYear(dateTime);
            var month = PersianCalendar.GetMonth(dateTime);
            var day = PersianCalendar.GetDayOfMonth(dateTime);

            return $"{PersianNumberFormatter.ToPersianDigits(day)} " +
                   $"{PersianMonthNames[month - 1]} " +
                   $"{PersianNumberFormatter.ToPersianDigits(year)}";
        }

        /// <summary>
        /// Converts a Gregorian date to a Persian (Jalali) date in numeric format,
        /// such as "۱۴۰۵/۰۵/۲۲".
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time to convert.</param>
        /// <returns>A formatted Persian date using the year/month/day format.</returns>
        public static string ToPersianShortDateString(this DateTime dateTime)
        {
            var year = PersianCalendar.GetYear(dateTime);
            var month = PersianCalendar.GetMonth(dateTime);
            var day = PersianCalendar.GetDayOfMonth(dateTime);

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

        /// <summary>
        /// Gets the Persian (Jalali) year of the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time.</param>
        /// <returns>The Persian year represented using Persian digits.</returns>
        public static string ToPersianYear(this DateTime dateTime)
        {
            var year = PersianCalendar.GetYear(dateTime);

            return PersianNumberFormatter.ToPersianDigits(year);
        }

        /// <summary>
        /// Gets the Persian month name of the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time.</param>
        /// <returns>The Persian name of the corresponding month.</returns>
        public static string ToPersianMonthString(this DateTime dateTime)
        {
            var month = PersianCalendar.GetMonth(dateTime);

            return PersianMonthNames[month - 1];
        }

        /// <summary>
        /// Gets the numeric Persian (Jalali) month of the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time.</param>
        /// <returns>The Persian month represented using Persian digits.</returns>
        public static string ToPersianMonth(this DateTime dateTime)
        {
            var month = PersianCalendar.GetMonth(dateTime);

            return PersianNumberFormatter.ToPersianDigits(month);
        }

        /// <summary>
        /// Gets the day of the Persian (Jalali) month for the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time.</param>
        /// <returns>The day of the Persian month represented using Persian digits.</returns>
        public static string ToPersianDay(this DateTime dateTime)
        {
            var day = PersianCalendar.GetDayOfMonth(dateTime);

            return PersianNumberFormatter.ToPersianDigits(day);
        }

        /// <summary>
        /// Converts a Gregorian date and time to a human-readable Persian date and time,
        /// such as "۲۲ مرداد ۱۴۰۵، ۱۴:۳۰".
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time to convert.</param>
        /// <returns>A formatted Persian date and time.</returns>
        public static string ToPersianDateTimeString(this DateTime dateTime)
        {
            var year = PersianCalendar.GetYear(dateTime);
            var month = PersianCalendar.GetMonth(dateTime);
            var day = PersianCalendar.GetDayOfMonth(dateTime);

            var hour = PersianNumberFormatter
                .ToPersianDigits(dateTime.Hour)
                .PadLeft(2, '۰');

            var minute = PersianNumberFormatter
                .ToPersianDigits(dateTime.Minute)
                .PadLeft(2, '۰');

            return $"{PersianNumberFormatter.ToPersianDigits(day)} " +
                   $"{PersianMonthNames[month - 1]} " +
                   $"{PersianNumberFormatter.ToPersianDigits(year)}، " +
                   $"{hour}:{minute}";
        }

        /// <summary>
        /// Converts a Gregorian date and time to a short Persian date and time format,
        /// such as "۱۴۰۵/۰۵/۲۲ ۱۴:۳۰".
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time to convert.</param>
        /// <returns>A formatted Persian date and time using numeric date components.</returns>
        public static string ToPersianDateTimeShortString(this DateTime dateTime)
        {
            var year = PersianCalendar.GetYear(dateTime);
            var month = PersianCalendar.GetMonth(dateTime);
            var day = PersianCalendar.GetDayOfMonth(dateTime);

            var date = $"{PersianNumberFormatter.ToPersianDigits(year)}/" +
                       $"{PersianNumberFormatter.ToPersianDigits(month).PadLeft(2, '۰')}/" +
                       $"{PersianNumberFormatter.ToPersianDigits(day).PadLeft(2, '۰')}";

            var hour = PersianNumberFormatter
                .ToPersianDigits(dateTime.Hour)
                .PadLeft(2, '۰');

            var minute = PersianNumberFormatter
                .ToPersianDigits(dateTime.Minute)
                .PadLeft(2, '۰');

            return $"{date} {hour}:{minute}";
        }

        /// <summary>
        /// Determines whether the Persian (Jalali) year containing the specified date is a leap year.
        /// </summary>
        /// <param name="dateTime">The Gregorian date and time used to determine the Persian year.</param>
        /// <returns><c>true</c> if the corresponding Persian year is a leap year; otherwise, <c>false</c>.</returns>
        public static bool IsPersianLeapYear(this DateTime dateTime)
        {
            var year = PersianCalendar.GetYear(dateTime);

            return PersianCalendar.IsLeapYear(year);
        }
    }
}