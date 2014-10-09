using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSCD;
using TSCD.Entities;
using TSCD_GUI.HeThong;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Global.current_quantrivien_login = QuanTriVien.getQuery().FirstOrDefault();
            //Application.Run(new RibbonFormMain());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();

            //PRECONFIG
            SHARED.Libraries.Debug.MODE = TSCD.Global.local_setting.debug_mode;
            if (Global.working_database.isReady() > 0)
            {
                Application.Run(new Login());
            }
            else
            {
                Application.Run(new Setting());
            }

            //Application.Run(new Form1());
            //Application.Run(new frmHinhAnh());
            //Application.Run(new frmThuVienHinhAnh());
            //Application.Run(new Test());
            //Application.Run(new Setting());
            //Application.Run(new frmSuaPermission(new List<Permission>()));
            //Application.Run(new frmMain());
            //Application.Run(new SplashScreen1());
        }
    }
}
