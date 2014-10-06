using DevExpress.LookAndFeel;
using PTB.Entities;
using PTB_GUI.HeThong;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB_GUI
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
                SHARED.Libraries.Debug.MODE = PTB.Global.local_setting.debug_mode;
                if (PTB.Global.working_database.isReady() > 0)
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
                //Application.Run(new frmSuaPermission(QuanTriVien.getByUserName("admin").group.permissions.ToList()));
                //Application.Run(new frmMain());
                //Application.Run(new SplashScreen1());
           }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal ERROR 'Application.Run(new Setting());'\r\n"+ex.ToString());
            }
        }
    }
}
