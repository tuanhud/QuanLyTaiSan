using DevExpress.LookAndFeel;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.HeThong;
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
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkins();

                //PRECONFIG
                SHARED.Libraries.Debug.MODE = QuanLyTaiSan.Global.local_setting.debug_mode;

                //Application.Run(new Form1());
                //Application.Run(new frmHinhAnh());
                //Application.Run(new frmThuVienHinhAnh());
                //Application.Run(new Test());
                Application.Run(new Setting());
                //Application.Run(new frmSuaPermission(QuanTriVien.getByUserName("admin").group.permissions.ToList()));
                //Application.Run(new frmMain());
                //Application.Run(new SplashScreen1());
           }
            catch (Exception)
            {
                MessageBox.Show("Fatal ERROR 'Application.Run(new Setting());'");
            }
        }
    }
}
