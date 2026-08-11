using Hengam.Numbers;

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
    }
}
