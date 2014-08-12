using QuanLyTaiSan.Entities;
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
        private static HashSet<String> fail_url = new HashSet<string>();
        /// <summary>
        /// Có hỗ trợ cache url hình bị lỗi
        /// </summary>
        /// <param name="url">Đường dẫn URL của hình</param>
        /// <param name="force">Bỏ qua cached fail url (luôn lấy về từ Internet)</param>
        /// <returns>null (Mạng lỗi, URL not found, image corrupted or unsupported)</returns>
        public static Bitmap getImage(String url, Boolean force=false)
        {
            //check in fail list
            if (!force && fail_url.Contains(url))
            {
                return null;
            }

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
                Debug.WriteLine(ex.ToString());
                fail_url.Add(url);
                return null;
            }
        }
    }
}
