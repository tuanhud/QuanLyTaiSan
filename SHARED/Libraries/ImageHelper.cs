
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.Libraries
{
    public static class ImageHelper
    {
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
        public static Bitmap ScaleBySize(Bitmap input, int max_size)
        {
            try
            {
                Bitmap imgPhoto = new Bitmap(input);
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
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }
        public static Bitmap fromFile(String abs_path)
        {
            return new Bitmap(abs_path);
        }
    }
}
