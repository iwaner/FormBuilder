using System;

namespace FormBuilder.Utility
{
    public static class StringExtension
    {
        public static int ToInt(this string convertString)
        {
            int result;
            if (int.TryParse(convertString, out result)) return result;
            return result;
        }

        public static Int64 ToInt64(this string convertString)
        {
            Int64 result;
            if (Int64.TryParse(convertString, out result)) return result;
            return result;
        }

        public static DateTime ToDateTime(this string convertString)
        {
            DateTime result;
            DateTime.TryParse(convertString, out result);
            return DateTime.Parse(result.ToString("yyyy-MM-dd"));
        }
    }
}
