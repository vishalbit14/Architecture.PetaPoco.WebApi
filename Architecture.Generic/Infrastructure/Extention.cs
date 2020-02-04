using System;
using System.Collections.Generic;
using System.Globalization;

namespace Architecture.Generic.Infrastructure
{
    public static class Extentions
    {
        public static DateTime ToDateTime(this string text)
        {
            DateTime date = new DateTime(1974, 1, 1);
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Contains("-"))
                    date = DateTime.ParseExact(text, Constants.DateFormatDashed, CultureInfo.CreateSpecificCulture(Constants.Culture_EN));
                else
                    date = DateTime.ParseExact(text, Constants.DateFormatSlash, CultureInfo.CreateSpecificCulture(Constants.Culture_EN));
            }
            return date;
        }

        public static string ToLowerCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";
            return text.ToLower();
        }

        public static string ToUpperCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";
            return text.ToUpper();
        }

        public static List<string> ToStringList(this string data, string separator = ",")
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    var items = data.Split(new string[] { separator }, StringSplitOptions.None);
                    foreach (var item in items)
                    {
                        if (!string.IsNullOrEmpty(item))
                            list.Add(item);
                    }
                }
                catch { }
            }
            return list;
        }

        public static List<Int64> ToIntList(this string data, string separator = ",")
        {
            var list = new List<Int64>();
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    var numbers = data.Split(new string[] { separator }, StringSplitOptions.None);
                    foreach (var number in numbers)
                    {
                        if (!string.IsNullOrEmpty(number))
                            list.Add(Convert.ToInt64(number));
                    }
                }
                catch { }
            }
            return list;
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }
    }
}
