using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public static class Debug
    {
        public static void WriteLine(Object text=null)
        {
            switch (Global.debug.MODE)
            {
                case 2:

                    return;
                case 0:
                    System.Diagnostics.Debug.WriteLine(text);
                    return;
                case 1:
                    try
                    {
                        long v = new System.IO.FileInfo(Global.debug.FILENAME).Length;//bytes
                        if (v > 1048576)//1MB MAXIMUM
                        {
                            Global.debug.remove_file();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                    using (StreamWriter sw = File.AppendText(Global.debug.FILENAME))
                    {
                        sw.WriteLine(text == null ? "" : text.ToString());
                    }
                    return;
                default:
                    return;
            }
        }
    }
}
