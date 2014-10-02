using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHARED.Libraries
{
    public static class GUID
    {
        /// <summary>
        /// Chuyển 1 chuỗi sang GUID,
        /// nếu lỗi thì return Guid.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid From(String value)
        {
            try
            {
                if(!String.IsNullOrEmpty(value))
                    return Guid.Parse(value);
                else
                    return Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public static Guid From(Object value)
        {
            try
            {
                if (value != null)
                    return Guid.Parse(value.ToString());
                else
                    return Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
