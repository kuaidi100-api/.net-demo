using System;

namespace Utils
{
    public static class DateUtils
    {
        public static string GetTimestamp()
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);//ToUniversalTime()转换为标准时区的时间,去掉的话直接就用北京时间
            return ts.TotalMilliseconds.ToString();
        }
    }
}