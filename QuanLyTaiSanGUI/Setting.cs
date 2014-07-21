using DevExpress.LookAndFeel;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using QuanLyTaiSanGUI.HeThong;
using QuanLyTaiSanGUI.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI
{
    public partial class Setting : frmCustomXtraForm
    {
        /// <summary>
        /// Sẽ tự động mở Login lên sau khi Close()
        /// </summary>

        private ucCauHinh _ucCauHinh = null;
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            KiemtraKetnoiDatabase();
        }

        public void KiemtraKetnoiDatabase()
        {
            //Check kết nối tới CSDL nếu OK thì gọi Close
            if (Global.working_database.isReady() > 0)
            {
                this.show_frm_login();
            }
            else
            {
                HienThiCauHinh();
            }
        }

        public void HienThiCauHinh()
        {
            panelControlHienThiCauHinh.Controls.Clear();
            if (_ucCauHinh == null)
            {
                _ucCauHinh = new ucCauHinh();
                _ucCauHinh.load_data();
            }            
            _ucCauHinh.Dock = DockStyle.Fill;
            panelControlHienThiCauHinh.Controls.Add(_ucCauHinh);
        }

        /// <summary>
        /// Quyết định hành động kế tiếp khi hoàn tất form setting
        /// </summary>
        #region show from login in new thread
        private void ThreadProc()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.Run(new Login());
        }
        private void show_frm_login()
        {
            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Application.Exit();
        }
        #endregion
    }
}
