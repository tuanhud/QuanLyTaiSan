
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
        /// <param name="abs_path"></param>
        /// <returns></returns>
        public static Boolean isExist(String abs_path)
        {
            return File.Exists(abs_path);
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
        /// <param name="FILENAME"></param>
        /// <returns></returns>
        public static int delete(string FILENAME)
        {
            try
            {
                // Try to delete the file.
                File.Delete(FILENAME);
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                // We could not delete the file.
                return -1;
            }
        }
    }
}
