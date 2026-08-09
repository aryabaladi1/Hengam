using Hengam.Numbers;

namespace Hengam.Humanization
{
    public static class PersianTimeHumanizer
    {
        public static string Humanize(DateTime dateTime, DateTime? referenceTime = null)
        {
            var now = referenceTime ?? DateTime.Now;
            var difference = dateTime - now;
            var absoluteDifference = difference.Duration();

            if (absoluteDifference < TimeSpan.FromMinutes(1))
                return "همین الان";

            if (absoluteDifference < TimeSpan.FromHours(1))
            {
                var minutes = (int)absoluteDifference.TotalMinutes;
                return difference > TimeSpan.Zero
                    ? $"{PersianNumberFormatter.ToPersianDigits(minutes)} دقیقه دیگر"
                    : $"{PersianNumberFormatter.ToPersianDigits(minutes)} دقیقه پیش";
            }

            if (absoluteDifference < TimeSpan.FromDays(1))
            {
                var hours = (int)absoluteDifference.TotalHours;
                return difference > TimeSpan.Zero
                    ? $"{PersianNumberFormatter.ToPersianDigits(hours)} ساعت دیگر"
                    : $"{PersianNumberFormatter.ToPersianDigits(hours)} ساعت پیش";
            }

            if (absoluteDifference < TimeSpan.FromDays(7))
            {
                var days = (int)absoluteDifference.TotalDays;
                return difference > TimeSpan.Zero
                    ? $"{PersianNumberFormatter.ToPersianDigits(days)} روز دیگر"
                    : $"{PersianNumberFormatter.ToPersianDigits(days)} روز پیش";
            }

            if (absoluteDifference < TimeSpan.FromDays(30))
            {
                var weeks = (int)(absoluteDifference.TotalDays / 7);
                return difference > TimeSpan.Zero
                    ? $"{PersianNumberFormatter.ToPersianDigits(weeks)} هفته دیگر"
                    : $"{PersianNumberFormatter.ToPersianDigits(weeks)} هفته پیش";
            }

            if (absoluteDifference < TimeSpan.FromDays(365))
            {
                var months = (int)(absoluteDifference.TotalDays / 30);
                return difference > TimeSpan.Zero
                    ? $"{PersianNumberFormatter.ToPersianDigits(months)} ماه دیگر"
                    : $"{PersianNumberFormatter.ToPersianDigits(months)} ماه پیش";
            }

            var years = (int)(absoluteDifference.TotalDays / 365);
            return difference > TimeSpan.Zero
                ? $"{PersianNumberFormatter.ToPersianDigits(years)} سال دیگر"
                : $"{PersianNumberFormatter.ToPersianDigits(years)} سال پیش";
        }
    }
}
