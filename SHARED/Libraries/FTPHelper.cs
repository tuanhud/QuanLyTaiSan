
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHARED.Libraries
{
    public class FTPHelper
    {
        public static IEnumerable<string> GetFilesInDirectory(string url, string username, string password)
        {
            // Get the object used to communicate with the server.
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(username, password);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line) == false)
                        {
                            yield return line.Split(new[] { ' ', '\t' }).Last();
                        }
                    }
                }
            }
        }
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
            catch (Exception)
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
                Debug.WriteLine(ex.ToString());
                return -1;
            }
        }
        /// <summary>
        /// Xoa hinh tren FTP host
        /// </summary>
        /// <param name="remote_path">dạng full, vd: ftp://host.com/folder/file.JPEG</param>
        /// <param name="user_name"></param>
        /// <param name="pass_word"></param>
        /// <returns></returns>
        public static int deleteFile(String remote_path, String user_name, String pass_word)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(remote_path));

                //If you need to use network credentials
                request.Credentials = new NetworkCredential(user_name, pass_word);
                //additionally, if you want to use the current user's network credentials, just use:
                //System.Net.CredentialCache.DefaultNetworkCredentials

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Kiểm tra kết nối FTP
        /// </summary>
        /// <param name="host_name">dạng ftp url, vd: ftp://host.com</param>
        /// <param name="user_name"></param>
        /// <param name="pass_word"></param>
        /// <param name="timeout">giây</param>
        /// <returns></returns>

        public static int checkconnect(String host_name, String user_name, String pass_word, int timeout=-1)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host_name);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user_name, pass_word);
                if (timeout > 0)
                {
                    request.Timeout = timeout * 1000;
                }
                request.GetResponse();
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            
        }

        #region Image Utilities

        /// <summary>
        /// Loads an image from a URL into a Bitmap object.
        /// Currently as written if there is an error during downloading of the image, no exception is thrown.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Bitmap LoadPicture(string url)
        {
            System.Net.HttpWebRequest wreq;
            System.Net.HttpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;

            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;

                wresp = (System.Net.HttpWebResponse)wreq.GetResponse();

                if ((mystream = wresp.GetResponseStream()) != null)
                    bmp = new Bitmap(mystream);
            }
            catch
            {
                // Do nothing... 
            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }

            return (bmp);
        }

        /// <summary>
        /// Takes in an image, scales it maintaining the proper aspect ratio of the image such it fits in the PictureBox's canvas size and loads the image into picture box.
        /// Has an optional param to center the image in the picture box if it's smaller then canvas size.
        /// </summary>
        /// <param name="image">The Image you want to load, see LoadPicture</param>
        /// <param name="canvas">The canvas you want the picture to load into</param>
        /// <param name="centerImage"></param>
        /// <returns></returns>

        public static Image ResizeImage(Image image, PictureBox canvas, bool centerImage)
        {
            if (image == null || canvas == null)
            {
                return null;
            }

            int canvasWidth = canvas.Size.Width;
            int canvasHeight = canvas.Size.Height;
            int originalWidth = image.Size.Width;
            int originalHeight = image.Size.Height;

            System.Drawing.Image thumbnail =
                new Bitmap(canvasWidth, canvasHeight); // changed parm names
            System.Drawing.Graphics graphic =
                         System.Drawing.Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            /* ------------------ new code --------------- */

            // Figure out the ratio
            double ratioX = (double)canvasWidth / (double)originalWidth;
            double ratioY = (double)canvasHeight / (double)originalHeight;
            double ratio = ratioX < ratioY ? ratioX : ratioY; // use whichever multiplier is smaller

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            // Now calculate the X,Y position of the upper-left corner 
            // (one of these will always be zero)
            int posX = Convert.ToInt32((canvasWidth - (image.Width * ratio)) / 2);
            int posY = Convert.ToInt32((canvasHeight - (image.Height * ratio)) / 2);

            if (!centerImage)
            {
                posX = 0;
                posY = 0;
            }
            graphic.Clear(Color.White); // white padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            /* ------------- end new code ---------------- */

            System.Drawing.Imaging.ImageCodecInfo[] info =
                             ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,
                             100L);

            Stream s = new System.IO.MemoryStream();
            thumbnail.Save(s, info[1],
                              encoderParameters);

            return Image.FromStream(s);
        }

        #endregion

        public static int FTPUpload(String username, String password, String filePath, String fileName, String FTPAddress)
        {
            try
            {
                FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(FTPAddress + fileName);
                requestFTPUploader.Credentials = new NetworkCredential(username, password);
                requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileInfo = new FileInfo(filePath);
                FileStream fileStream = fileInfo.OpenRead();

                int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];

                Stream uploadStream = requestFTPUploader.GetRequestStream();
                int contentLength = fileStream.Read(buffer, 0, bufferLength);

                while (contentLength != 0)
                {
                    uploadStream.Write(buffer, 0, contentLength);
                    contentLength = fileStream.Read(buffer, 0, bufferLength);
                }

                uploadStream.Close();
                fileStream.Close();

                requestFTPUploader = null;
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
