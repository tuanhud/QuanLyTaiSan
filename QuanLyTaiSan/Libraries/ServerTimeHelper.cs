using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class ServerTimeHelper
    {
        /// <summary>
        /// Lấy ngày hiện tại từ SQL Server bằng hàm GETDATE(), nếu lỗi thì return DateTime.Now </summary>
        public static DateTime getNow()
        {
            try
            {
                //sql server time
                DateTime current = DBInstance.DB.Database.SqlQuery<DateTime>("select GETDATE()").FirstOrDefault();
                return current;
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
    }
}
