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

namespace QuanLyTaiSanGUI
{
    public partial class Setting : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Sẽ tự động mở Login lên sau khi Close()
        /// </summary>
        private Boolean cau_hinh_ban_dau = true;

        private ucCauHinh _ucCauHinh = null;
        private ucThongTinPhanMem _ucThongTinPhanMem = null;
        private ucGiaoDienvaNgonNgu _ucGiaoDienvaNgonNgu = null;
        public Setting()
        {
            InitializeComponent();
            frmMain.CaiDatGiaoDien();
        }
        public Setting(Boolean cauHinhBanDau=true)
        {
            InitializeComponent();
            this.cau_hinh_ban_dau = cauHinhBanDau;
            frmMain.CaiDatGiaoDien();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            if (_ucCauHinh == null)
            {
                _ucCauHinh = new ucCauHinh();
                _ucCauHinh.load_data();
            }
            panelControlHienThiCauHinh.Controls.Clear();
            _ucCauHinh.Dock = DockStyle.Fill;
            panelControlHienThiCauHinh.Controls.Add(_ucCauHinh);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int re = 1;
            if (_ucCauHinh != null)
            {
                //call ucSave
                re = _ucCauHinh.save();
                
                if (re > 0)
                {
                    this.custom_close();
                    return;
                }
                else if (re == -5)
                {
                    MessageBox.Show("FTP Setting Fail!");
                    return;
                }
                else if (re==-2)
                {
                    MessageBox.Show("Server DB Fail!");
                    return;
                }
                else if (re == -3)
                {
                    MessageBox.Show("Client DB Fail!");
                    return;
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            btnCauHinh.PerformClick();

            //Check kết nối tới CSDL nếu OK thì gọi Close
            if (cau_hinh_ban_dau)
            {
                if (Global.working_database.isReady()>0)
                {
                    this.custom_close();
                }
                else
                {
                    btnGiaoDienvaNgonNgu.Enabled = false;
                    btnCapNhatPhanMem.Enabled = false;
                }
            }
            else
            {

            }
        }
        /// <summary>
        /// Quyết định hành động kế tiếp khi hoàn tất form setting
        /// </summary>
        private void custom_close()
        {
            if (cau_hinh_ban_dau)
            {
                this.show_frm_login();
            }
            else
            {
                this.Close();
            }
        }
        #region show from login in new thread
        private void ThreadProc()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            //UserLookAndFeel.Default.SetSkinStyle(SkinHelper.Default());
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

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {
            _ucThongTinPhanMem = new ucThongTinPhanMem();
            panelControlHienThiCauHinh.Controls.Clear();
            _ucThongTinPhanMem.Dock = DockStyle.Fill;
            panelControlHienThiCauHinh.Controls.Add(_ucThongTinPhanMem);
        }

        private void btnGiaoDienvaNgonNgu_Click(object sender, EventArgs e)
        {
            _ucGiaoDienvaNgonNgu = new ucGiaoDienvaNgonNgu();
            panelControlHienThiCauHinh.Controls.Clear();
            _ucGiaoDienvaNgonNgu.Dock = DockStyle.Fill;
            panelControlHienThiCauHinh.Controls.Add(_ucGiaoDienvaNgonNgu);
        }
    }
}
