using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSCD;
using TSCD.Entities;

namespace TSCD_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Global.current_quantrivien_login = QuanTriVien.getQuery().FirstOrDefault();
            Application.Run(new RibbonFormMain());
        }
    }
}
