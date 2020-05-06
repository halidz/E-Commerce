using System;

namespace Commerce.Core
{
    public static class DateTimeExtensions
    {
        public static long ToDateTime(this DateTime source)
        {
            return Convert.ToInt64(source.ToString("yyyyMMddHHmmss")); 
        }

        public static long ToDate(this DateTime source)
        {
            return Convert.ToInt64(source.ToString("yyyyMMdd")); 
        }

        public static long ToPeriod(this DateTime source)
        {
            return Convert.ToInt64(source.ToString("yyyyMM"));
        }
        public static long ToTime(this DateTime source)
        {
            return Convert.ToInt64(source.ToString("HHmmss"));
        }
    }
}
