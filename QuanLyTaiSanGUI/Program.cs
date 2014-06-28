using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI
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

            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.XtraSplashScreen.SplashScreenManager.RegisterUserSkins(typeof(DevExpress.UserSkins.BonusSkins).Assembly); // dx


            //Application.Run(new Form1());
            //Application.Run(new frmHinhAnh());
            //Application.Run(new frmThuVienHinhAnh());
            Application.Run(new frmMain());
            //Application.Run(new SplashScreen1());
        }
    }
}
