using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        /// <returns>Bitmap or NULL</returns>
        public static Bitmap getImage(String host_name, String user_name, String pass_word, String abs_path)
        {
            try
            {
                var filePath = host_name + abs_path;
                var request = WebRequest.Create(filePath);
                request.Credentials = new NetworkCredential(user_name, pass_word);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (Image img = Image.FromStream(stream))
                {
                    return new Bitmap(img);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Upload hình Bitmap thành file JPEG trên host,
        /// Giữ nguyên kích thước và chất lượng ảnh
        /// Chưa thể tự tạo được thư mục nếu chưa có
        /// </summary>
        /// <param name="image"></param>
        /// <param name="remote_path">dạng full, vd: ftp://host.com/folder/file.JPEG</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int uploadImage(Bitmap image, String remote_path, String username, String password)
        {
            try
            {
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(
                    new Uri(remote_path)
                    );
                ftp.Credentials = new NetworkCredential(username, password);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                byte[] bytes = ImageHelper.ImageToByte(image);
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(bytes, 0, bytes.Length);
                ftpstream.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
