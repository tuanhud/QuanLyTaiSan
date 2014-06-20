using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class FileHelper
    {
        public static Boolean isExist(String abs_path)
        {
            return File.Exists(abs_path);
        }
        /// <summary>
        /// vd: C:\Users\quocdunginfo\Documents\GitHub\QuanLyTaiSan\QuanLyTaiSan\bin\Debug
        /// </summary>
        /// <returns></returns>
        public static String localPath()
        {
            return new Uri(System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
        }

        public static void createFolderIfNotExist(String folder_path)
        {
            Directory.CreateDirectory(folder_path);
        }
    }
}
