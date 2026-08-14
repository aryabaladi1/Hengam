namespace Hengam.Numbers
{
    public static class PersianNumberFormatter
    {
        /// <summary>
        /// Converts the digits of an integer from Western Arabic numerals to Persian numerals.
        /// </summary>
        /// <param name="number">The integer whose digits should be converted.</param>
        /// <returns>A string containing the number represented using Persian digits.</returns>
        public static string ToPersianDigits(int number)
        {
            return number
                .ToString()
                .Replace('0', '۰')
                .Replace('1', '۱')
                .Replace('2', '۲')
                .Replace('3', '۳')
                .Replace('4', '۴')
                .Replace('5', '۵')
                .Replace('6', '۶')
                .Replace('7', '۷')
                .Replace('8', '۸')
                .Replace('9', '۹');
        }

        /// <summary>
        /// Converts Western Arabic numerals in a string to Persian numerals.
        /// </summary>
        /// <param name="text">The text whose digits should be converted.</param>
        /// <returns>A string with all Western Arabic numerals replaced by Persian numerals.</returns>
        public static string ToPersianDigits(string text)
        {
            return text
                .Replace('0', '۰')
                .Replace('1', '۱')
                .Replace('2', '۲')
                .Replace('3', '۳')
                .Replace('4', '۴')
                .Replace('5', '۵')
                .Replace('6', '۶')
                .Replace('7', '۷')
                .Replace('8', '۸')
                .Replace('9', '۹');
        }
    }
}
