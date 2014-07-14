using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public static class Debug
    {
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
        private static int mode = -1;
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
                mode = Global.local_setting.debug_mode;
                return mode;
            }
            set
            {
                mode = value;
            }
        }
        public static void WriteLine(Object text=null)
        {
            switch (MODE)
            {
                case 2:

                    return;
                case 0:
                    System.Diagnostics.Debug.WriteLine(text);
                    return;
                case 1:
                    // This text is always added, making the file longer over time 
                    // if it is not deleted. 
                    using (StreamWriter sw = File.AppendText(FILENAME))
                    {
                        sw.WriteLine(text==null?"":text.ToString());
                    }
                    return;

                default:
                    return;
            }
        }
    }
}
