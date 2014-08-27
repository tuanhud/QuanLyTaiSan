using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.Libraries
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
                return Guid.Parse(value);
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
                return Guid.Parse(value.ToString());
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
