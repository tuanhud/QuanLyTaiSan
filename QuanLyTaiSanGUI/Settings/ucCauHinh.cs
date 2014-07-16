using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace QuanLyTaiSanGUI.Settings
{
    public partial class ucCauHinh : UserControl
    {
        public ucCauHinh()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            /*
             * LOCAL SETTING
             */
            //CACHE SERVER
            textEdit_CacheHost.Text = Global.local_setting.db_cache_host;
            textEdit_CacheAccount.Text = Global.local_setting.db_cache_username;
            textEdit_CachePass.Text = Global.local_setting.db_cache_password;
            textEdit_CachePort.Text = Global.local_setting.db_cache_port;
            checkEdit_CacheWA.Checked = Global.local_setting.db_cache_WA;
            textEdit_CacheDBName.Text = Global.local_setting.db_cache_dbname;
            //MAIN SERVER
            txtAddressDatabase.Text = Global.local_setting.db_server_host;
            txtUsernameDatabase.Text = Global.local_setting.db_server_username;
            txtPasswordDatabase.Text = Global.local_setting.db_server_password;
            txtPortDatabase.Text = Global.local_setting.db_server_port;
            checkEdit_ServerWA.Checked = Global.local_setting.db_server_WA;
            textEdit_ServerDBName.Text = Global.local_setting.db_server_dbname;
            //IS USING DBCACHE
            checkEdit_useDBCache.Checked = Global.local_setting.use_db_cache;
            //Debug to file
            checkEdit_debugToFile.Checked = Global.debug.MODE == 1;

            /*
             * REMOTE SETTING
             */
            //Phai co ket noi toi Database moi lay duoc remote 
            if (Global.working_database.isReady()>0)
            {
                //FTP
                txtAddressFTP.Text = Global.remote_setting.ftp_host.HOST_NAME;
                txtPrepathFTP.Text = Global.remote_setting.ftp_host.PRE_PATH;
                txtUsernameFTP.Text = Global.remote_setting.ftp_host.USER_NAME;
                txtPasswordFTP.Text = Global.remote_setting.ftp_host.PASS_WORD;
                txtPortFTP.Text = Global.remote_setting.ftp_host.PORT;
                //HTTP
                txtAddressHTTP.Text = Global.remote_setting.http_host.HOST_NAME;
                txtPrepathHTTP.Text = Global.remote_setting.http_host.PRE_PATH;
            }
        }
        /// <summary>
        /// Lưu lại cài đặt
        /// 
        /// </summary>
        /// <returns>-5: FTP Fail, -2: SERVER DB FAIL, -3: CLIENT DB FAIL </returns>
        public int save()
        {
            /*
             * LOCAL SETTING
             */
            if(checkEdit_useDBCache.Checked)
            {
                //CACHE SERVER
                Global.local_setting.db_cache_host = textEdit_CacheHost.Text;
                Global.local_setting.db_cache_username = textEdit_CacheAccount.Text;
                Global.local_setting.db_cache_password = textEdit_CachePass.Text;
                Global.local_setting.db_cache_port = textEdit_CachePort.Text;
                Global.local_setting.db_cache_dbname = textEdit_CacheDBName.Text;
                Global.local_setting.db_cache_WA = checkEdit_CacheWA.Checked;
            }
            //MAIN SERVER
            Global.local_setting.db_server_host = txtAddressDatabase.Text;
            Global.local_setting.db_server_username = txtUsernameDatabase.Text;
            Global.local_setting.db_server_password = txtPasswordDatabase.Text;
            Global.local_setting.db_server_port = txtPortDatabase.Text;
            Global.local_setting.db_server_dbname = textEdit_ServerDBName.Text;
            Global.local_setting.db_server_WA = checkEdit_ServerWA.Checked;
            //IS USING DBCACHE
            Global.local_setting.use_db_cache = checkEdit_useDBCache.Checked;
            //debug mode
            Global.debug.MODE = checkEdit_debugToFile.Checked ? 1 : 2;
            //UPDATE
            Global.local_setting.Save();


            //CHECK DB CONFIG
            if (Global.local_setting.use_db_cache)
            {
                if (Global.server_database.isReady()<0)
                {
                    //SERVER FAIL
                    return -2;
                }
                if (Global.client_database.isReady()<0)
                {
                    //CLIENT FAIL
                    return -3;
                }
            }
            else
            {
                if (Global.working_database.isReady()<0)
                {
                    //SERVER FAIL
                    return -2;
                }
            }


            return 1;
            
        }
        private void checkEdit_useDBCache_CheckedChanged(object sender, EventArgs e)
        {
            panelControl_Cache.Enabled = checkEdit_useDBCache.Checked;
        }

        private void checkEdit_ServerWA_CheckedChanged(object sender, EventArgs e)
        {
            txtUsernameDatabase.Enabled = !checkEdit_ServerWA.Checked;
            txtPasswordDatabase.Enabled = !checkEdit_ServerWA.Checked;
        }

        private void checkEdit_CacheWA_CheckedChanged(object sender, EventArgs e)
        {
            textEdit_CacheAccount.Enabled = !checkEdit_CacheWA.Checked;
            textEdit_CachePass.Enabled = !checkEdit_CacheWA.Checked;
        }

        private void checkEdit_ServerWA_CheckedChanged_1(object sender, EventArgs e)
        {
            txtUsernameDatabase.Enabled = !checkEdit_ServerWA.Checked;
            txtPasswordDatabase.Enabled = !checkEdit_ServerWA.Checked;
        }

        private void simpleButton_validateServer_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            Global.server_database.prepare_db_structure();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton_validateClient_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            Global.client_database.prepare_db_structure();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang đồng bộ...");
            Global.client_database.start_sync();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton_cleanUpServerScope_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Client Up Scrope Server...");
            Global.server_database.clean_up_scope();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton_cleanUpClientScope_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Client Up Scrope Client...");
            Global.client_database.clean_up_scope();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnFTPSave_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang cập nhật...");
            /*
             * REMOTE SETTING
             */
            //FTP
            Global.remote_setting.ftp_host.HOST_NAME = txtAddressFTP.Text;
            Global.remote_setting.ftp_host.PRE_PATH = txtPrepathFTP.Text;
            Global.remote_setting.ftp_host.USER_NAME = txtUsernameFTP.Text;
            Global.remote_setting.ftp_host.PASS_WORD = txtPasswordFTP.Text;
            Global.remote_setting.ftp_host.PORT = txtPortFTP.Text;

            //if (FTPHelper.checkconnect(Global.remote_setting.ftp_host.HOST_NAME,
            //    Global.remote_setting.ftp_host.USER_NAME,
            //    Global.remote_setting.ftp_host.PASS_WORD
            //    ) > 0
            //)
            //{
            Global.remote_setting.ftp_host.save();
            //}
            //else
            //{
            //    //FTP FAIL
            //    return -5;
            //}

            //HTTP
            Global.remote_setting.http_host.HOST_NAME = txtAddressHTTP.Text;
            Global.remote_setting.http_host.PORT = txtPortHTTP.Text;
            Global.remote_setting.http_host.PRE_PATH = txtPrepathHTTP.Text;

            Global.remote_setting.http_host.save();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void ucCauHinh_Load(object sender, EventArgs e)
        {
            txtAddressDatabase.Focus();
        }

        private void btnDebugClear_Click(object sender, EventArgs e)
        {
            Global.debug.remove_file();
        }

        private void btnRemoveServerScope_Click(object sender, EventArgs e)
        {
            Global.server_database.drop_scope();
        }

        private void btnRemoveClientScope_Click(object sender, EventArgs e)
        {
            Global.client_database.drop_scope();
        }
    }
}
