namespace FoodManager.Common.Extensions
{
    public static class Extension
    {
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
