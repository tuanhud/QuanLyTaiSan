using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHARED.Libraries
{
    public static class DateTimeHelper
    {
        public static long toMilisec(DateTime? value)
        {
            try
            {
                if (value == null)
                {
                    return 0;
                }
                return ((DateTime)value).Ticks;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }
        public static long toMilisec(DateTime value)
        {
            try
            {
                return value.Ticks;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }
    }
}
