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
    public class HTTPHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Đường dẫn URL của hình</param>
        /// <returns>null (Mạng lỗi, URL not found, image corrupted or unsupported)</returns>
        public static Bitmap getImage(String url)
        {
            try
            {

                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

                using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream stream = httpWebReponse.GetResponseStream())
                    {
                        Image tmp = Image.FromStream(stream);
                        return new Bitmap(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
