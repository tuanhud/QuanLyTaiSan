using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public static class ImageHelper
    {
        /// <summary>
        /// Hỗ trợ cache
        /// </summary>
        public static class CACHE
        {
            private static Dictionary<String, Bitmap> collection = new Dictionary<string, Bitmap>();
            private static HashSet<String> fail_url = new HashSet<string>();

            public static Bitmap get(String url)
            {
                if (url == null)
                {
                    return null;
                }
                //Nếu nằm trong fail list thì return ảnh mặc định
                if (fail_url.Contains(url))
                {
                    return HinhAnh.DEFAULT_IMAGE;
                }
                //tìm kiếm trong cache list
                if (collection.ContainsKey(url))
                {
                    return collection[url];
                }
                return null;
            }
            /// <summary>
            /// Đánh dấu url fail, lần get kế tiếp từ CACHE sẽ trả về hình mặc định
            /// </summary>
            /// <param name="url"></param>
            public static void mark_url_fail(String url)
            {
                fail_url.Add(url);
            }
            /// <summary>
            /// Đăng ký ảnh vào cache list, OVERRIDE MODE ON
            /// </summary>
            /// <param name="url"></param>
            /// <param name="image"></param>
            public static void register(String url, Bitmap image)
            {
                if (collection.ContainsKey(url))
                {
                    collection.Remove(url);
                }
                collection.Add(url, image);
            }
        }
        /// <summary>
        /// Convert to JPEG
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToByte(Bitmap image)
        {
            byte[] byteArray = new byte[0];
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Close();
            return stream.ToArray();
        }
        /// <summary>
        /// Thu nhỏ 1 hình
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="max_size">pixel, ex: 400 có nghĩa là chiều dài và chiều rộng của hình bị scale luôn nhỏ hơn 400</param>
        /// <returns></returns>
        public static Bitmap ScaleBySize(Bitmap imgPhoto, int max_size)
        {
            int logoSize = max_size;

            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            //landscape
            if (sourceWidth >= sourceHeight)
            {
                destWidth = logoSize;
                destHeight = (float)(sourceHeight * destWidth / sourceWidth);
            }
            else
            {
                destHeight = logoSize;
                destWidth = (float)(sourceWidth * destHeight / sourceHeight);
            }

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }
        public static Bitmap fromFile(String abs_path)
        {
            return new Bitmap(abs_path);
        }
    }
}
