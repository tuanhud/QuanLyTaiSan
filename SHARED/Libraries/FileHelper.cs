
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.Libraries
{
    public class FileHelper
    {
        /// <summary>
        /// Kiem tra file co ton tai
        /// </summary>
        /// <param name="local_abs_path"></param>
        /// <returns></returns>
        public static Boolean isExist(String local_abs_path)
        {
            return File.Exists(local_abs_path);
        }
        /// <summary>
        /// Lấy tên file, bao gồm extension
        /// </summary>
        /// <param name="local_abs_path"></param>
        /// <returns></returns>
        public static String getFileName(String local_abs_path)
        {
            try
            {
                return Path.GetFileName(local_abs_path);
            }catch(Exception e)
            {
                Debug.WriteLine(e);
                return "";
            }
        }
        /// <summary>
        /// vd: C:\Users\quocdunginfo\Documents\GitHub\QuanLyTaiSan\QuanLyTaiSan\bin\Debug,
        /// Lay duong dan den file EXE dang thuc thi
        /// </summary>
        /// <returns></returns>
        public static String localPath()
        {
            return new Uri(System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
        }
        /// <summary>
        /// Tao folder neu chua co
        /// </summary>
        /// <param name="folder_path"></param>
        public static void createFolderIfNotExist(String folder_path)
        {
            Directory.CreateDirectory(folder_path);
        }
        /// <summary>
        /// Xoa file
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public static int delete(string file_path)
        {
            try
            {
                // Try to delete the file.
                File.Delete(file_path);
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                // We could not delete the file.
                return -1;
            }
        }
        /// <summary>
        /// Xóa mọi thứ trong thư mục này, nhưng không xóa thư mục này
        /// </summary>
        /// <param name="folder_path"></param>
        /// <returns></returns>
        public static int clearFolder(string folder_path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(folder_path);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(di.FullName);
                    di.Delete();
                }
                return 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        public static long getFileSizeKilobyte(string LOCAL_FILE_PATH)
        {
            try
            {
                return (new FileInfo(LOCAL_FILE_PATH)).Length / 1024;
            }catch(Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }
    }
}
