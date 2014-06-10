using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class ServerDateTime
    {
        /// <summary>
        /// Lấy ngày hiện tại từ SQL Server bằng hàm GETDATE() </summary>
        public static DateTime getNow()
        {
            MyDB db=new MyDB();
            try
            {
                //sql server time
                DateTime current = db.Database.SqlQuery<DateTime>("select GETDATE()").FirstOrDefault();
                db.Dispose();
                return current;
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
