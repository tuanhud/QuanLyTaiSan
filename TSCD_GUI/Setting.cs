using DevExpress.LookAndFeel;
using TSCD.Entities;
using SHARED.Libraries;
using TSCD_GUI.HeThong;
using TSCD_GUI.Settings;
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
using TSCD_GUI.MyForm;
using TSCD;

namespace TSCD_GUI
{
    public partial class Setting : frmCustomXtraForm
    {

        /// <summary>
        /// Sẽ tự động mở Login lên sau khi Close()
        /// </summary>
        //private bool _passed = false;

        public Setting()
        {
            InitializeComponent();
            //Check kết nối tới CSDL nếu OK thì gọi login ngay lập tức
            /*_passed = Global.working_database.isReady() > 0;
            if (_passed)
            {
                this.show_frm_login();
            }
            else
            {
                //register event
                ucCauHinh1.viewCauHinhLocal1._btnSaveLocal.Click += new EventHandler(this.checkPoint);
                //load uc data
                ucCauHinh1.reLoad();
            }*/
            //register event
            ucCauHinh1.viewCauHinhLocal1._btnSaveLocal.Click += new EventHandler(this.checkPoint);
            //load uc data
            ucCauHinh1.reLoad();
        }

        private void checkPoint(object sender, EventArgs e)
        {
            Boolean _passed = ucCauHinh1._passed;
            /*//Kiem tra ket noi toi CSDL working de show form login len
            if (_passed)
            {
                this.show_frm_login();
            }*/
            if (_passed)
            {
                Login _Login = new Login();
                this.Hide();
                _Login.ShowDialog();
                this.Close();
            }
        }

        /*/// <summary>
        /// Quyết định hành động kế tiếp khi hoàn tất form setting
        /// </summary>
        #region show from login in new thread
        private void ThreadProc()
        {
            //DevExpress.UserSkins.BonusSkins.Register();
            //Application.EnableVisualStyles();
            //DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.Run(new Login());
        }
        private void show_frm_login()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(ThreadProc));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                Application.Exit();
            }
            catch (Exception) { }
        }
        #endregion

        private void Setting_Shown(object sender, EventArgs e)
        {
            if (_passed)
            {
                try
                {
                    this.Close();
                }
                catch (Exception) { }
            }
        }*/
    }
}
