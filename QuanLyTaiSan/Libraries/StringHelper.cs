using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class StringHelper
    {
        /// <summary>
        /// SHA1 thuần, trả về kiểu HOA </summary>
        public static String SHA1(String obj)
        {
            if (obj == null)
            {
                obj = "";
            }
            byte[] b1 = System.Text.Encoding.UTF8.GetBytes(obj);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(b1);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    var hex = b.ToString("x2");
                    sb.Append(hex);
                }

                return sb.ToString().ToUpper();
            }
        }
        /// <summary>
        /// SHA1 chuỗi với salt, trả về kiểu HOA </summary>
        public static String SHA1_Salt(String obj)
        {
            String salt1 = "34@3%%6CV*&_+";
            String salt2 = "hg13@';,Ghfya";
            obj = salt1 + obj + salt2;
            return StringHelper.SHA1(obj);
        }
        public static String generateConnectionString(String db_host, String db_name, String db_username, String db_password)
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = db_host;
            sqlBuilder.InitialCatalog = db_name;
            sqlBuilder.UserID = db_username;
            sqlBuilder.Password = db_password;
            sqlBuilder.IntegratedSecurity = false;

           return sqlBuilder.ToString();
        }
    }
}
