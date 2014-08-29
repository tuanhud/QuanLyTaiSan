using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.Libraries
{
    public static class DateTimeHelper
    {
        public static long toMilisec(DateTime? value)
        {
            if (value == null)
            {
                return 0;
            }
            return ((DateTime)value).Ticks;
        }
        public static long toMilisec(DateTime value)
        {
            return value.Ticks;
        }
    }
}
