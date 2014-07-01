using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Libraries;

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
            UserLookAndFeel.Default.SetSkinStyle(SkinHelper.iMaginary());
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.XtraSplashScreen.SplashScreenManager.RegisterUserSkins(typeof(DevExpress.UserSkins.BonusSkins).Assembly); // dx


            //Application.Run(new Form1());
            //Application.Run(new frmHinhAnh());
            //Application.Run(new frmThuVienHinhAnh());
            //Application.Run(new frmMain());
            Application.Run(new Setting(false));
            //Application.Run(new QuanLyTaiSanGUI.MyForm.frmNewThietBi());
            //Application.Run(new Setting());
            //Application.Run(new SplashScreen1());
        }
    }
}
