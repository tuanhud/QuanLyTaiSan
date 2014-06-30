using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        public static String generateConnectionString(String db_host, String db_name, Boolean useWA=true, String db_username="", String db_password="", String port="")
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = db_host;

            if (!port.Equals(""))
            {
                sqlBuilder.DataSource += "," + port;
            }
            if (!db_name.Equals(""))
            {
                sqlBuilder.InitialCatalog = db_name;
            }
            if (!useWA)
            {
                sqlBuilder.UserID = db_username;
                sqlBuilder.Password = db_password;
                sqlBuilder.IntegratedSecurity = false;
            }
            else
            {
                sqlBuilder.IntegratedSecurity = true;
            }

            Debug.WriteLine("StringHelper: "+sqlBuilder.ToString());
            return sqlBuilder.ToString();
        }
        /// <summary>
        /// Chuyển chuổi có dấu thành không dấu </summary>
        public static string CoDauThanhKhongDau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /// <summary>
        /// Lọc ký tự đặc biệt. Chỉ còn Chữ, Số _ - </summary>
        public static string LocKyTuDacBiet(string s)
        {
            s = s.Replace(" ","_");
            return Regex.Replace(s, "[^.a-zA-Z0-9_-]", "");
        }

        public static string RandomName(int length)
        {
            string Name = "";
            Random Random = new Random();
            int Num;
            while (Name.Length < length)
            {
                Num = Random.Next(1, 3);
                if (Num == 1)
                {
                    Num = Random.Next(65, 91);
                    Name = Name + Convert.ToChar(Num);
                }
                else
                {
                    Num = Random.Next(0, 10);
                    Name = Name + Num.ToString();
                }
            }
            return Name;
        }

        public Boolean IsNumber(String str)
        {
            int num;
            if (int.TryParse(str, out num))
                return true;
            return false;
        }
    }
}
