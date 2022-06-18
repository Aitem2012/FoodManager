namespace FoodManager.Common.Extensions
{
    public static class Extension
    {
        public static bool StringNotNullOrEmpty(this string str)
        {
            return str.Length > 0;
        }
        public static string ConvertToPhoneNumber(this string str)
        {
            return $"+234{str.Substring(1)}";
        }

        public static bool IsNullOrEmpty<T>(this T obj)
        {
            return obj == null;
        }
        /// <summary>
        /// Generates a Slug text from a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Slugify(this string str)
        {
            return str.ToLower().Replace(" ", "-").Replace(".", "").Replace("/", "-").Replace("\\", "-").Replace("@", "-").Replace("!", "").Replace(",", "").Replace("~", "").Replace("`", "").Replace("'", "").Replace("\"", "").Replace("#", "").Replace("&", "") + Guid.NewGuid().ToString().Substring(0, 12);
        }

        /// <summary>
        /// Generate References, appends random text to a specified text
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GenerateRef(this string str)
        {
            return $"{str}{Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 10)}";
        }

        /// <summary>
        /// Generates ReferralCode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GenerateReferralCode(this string str)
        {
            return $"{str}{Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 7)}";
        }

        /// <summary>
        /// Converts a Boolean Value to Yes or No string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        /// <summary>
        /// Converts a Boolean Value to True or False string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTrueFalse(this bool value)
        {
            return value ? "True" : "False";
        }
    }
}
