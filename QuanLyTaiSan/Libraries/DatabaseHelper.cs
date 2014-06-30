using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class DatabaseHelper
    {
        /// <summary>
        /// Kiểm tra kết nối tới Database thông qua Connection String đưa vào
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static Boolean isReady(String connectionString="")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}
