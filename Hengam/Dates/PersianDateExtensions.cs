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

        public static string ToPersianDayOfWeekString(this DateTime dateTime)
        {
            return PersianDayNames[(int)dateTime.DayOfWeek];
        }
    }
}
