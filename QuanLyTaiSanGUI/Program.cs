using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Libraries;
using DevExpress.Skins.Info;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.XtraSplashScreen;

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
            BonusSkins.Register();
            Application.EnableVisualStyles();
            UserLookAndFeel.Default.SetSkinStyle(SkinHelper.Default());
            SkinManager.EnableFormSkins();
            
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreenManager.RegisterUserSkins(typeof(BonusSkins).Assembly);
            SkinManager.Default.RegisterSkin(new SkinBlobXmlCreator(UserLookAndFeel.Default.SkinName, "SkinData.", typeof(BonusSkins).Assembly, null));

            //Application.Run(new Form1());
            //Application.Run(new frmHinhAnh());
            //Application.Run(new frmThuVienHinhAnh());
            Application.Run(new frmMain());
            //Application.Run(new Test());
            //Application.Run(new QuanLyTaiSanGUI.MyForm.frmNewThietBi());
            //Application.Run(new Setting());
            //Application.Run(new SplashScreen1());
        }
    }
}
