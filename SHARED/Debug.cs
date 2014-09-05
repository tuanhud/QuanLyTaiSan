using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHARED.Libraries
{
    public static class Debug
    {
        public static int remove_file()
        {
            return FileHelper.delete(FILENAME);
        }
        public static String FILENAME
        {
            get
            {
                return "debug.txt";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static int mode = 0;//-1;
        /// <summary>
        /// 0: Ghi ra Console,
        /// 1: Ghi ra File "debug.txt",
        /// 2: Silient
        /// </summary>
        public static int MODE
        {
            get
            {
                if (mode != -1)
                {
                    return mode;
                }
                if (Global.WEB_MODE)
                {
                    return mode = 0;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (Global.WEB_MODE)
                {
                    mode = 0;
                }
                else
                {
                    mode = value;
                }
            }
        }
        public static void WriteLine(Object text=null)
        {
            if (text == null)
            {
                return;
            }

            switch (Debug.MODE)
            {
                case 2:
                    return;
                case 0:
                    System.Diagnostics.Debug.WriteLine(text);
                    return;
                case 1:
                    if (Global.WEB_MODE)
                    {
                        System.Diagnostics.Debug.WriteLine(text);
                        return;
                    }

                    try
                    {
                        long v = new System.IO.FileInfo(Debug.FILENAME).Length;//bytes
                        if (v > 1048576)//1MB MAXIMUM
                        {
                            Debug.remove_file();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }

                    try
                    {
                        using (StreamWriter sw = File.AppendText(Debug.FILENAME))
                        {
                            sw.WriteLine(text == null ? "" : text.ToString());
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        return;
                    }
                default:
                    return;
            }
        }
    }
}
