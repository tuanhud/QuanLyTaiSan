using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class FTPHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host_name">ftp://example.com</param>
        /// <param name="user_name">root</param>
        /// <param name="pass_word">root</param>
        /// <param name="abs_path">/site1/path_to_img/img1.jpeg</param>
        /// <returns></returns>
        public static Bitmap getImage(String host_name, String user_name, String pass_word, String abs_path)
        {
            var filePath = host_name + abs_path;
            var request = WebRequest.Create(filePath);
            request.Credentials = new NetworkCredential(user_name, pass_word);
            using(var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (Image img = Image.FromStream(stream))
            {
                return new Bitmap(img);
            }
        }
    }
}
