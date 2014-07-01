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

            /*
             * REMOTE SETTING
             */
            //Phai co ket noi toi Database moi lay duoc remote 
            if (Global.working_database.isReady())
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
        /// <returns></returns>
        public int save()
        {
            //test ftp;
            return FTPHelper.checkconnect(txtAddressFTP.Text, txtUsernameFTP.Text, txtPasswordFTP.Text);
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

            //UPDATE
            Global.local_setting.Save();

            /*
             * REMOTE SETTING
             */
            //Cần phải có kết nối tới Database mới lưu được
            if (Global.working_database.isReady())
            {
                //FTP
                Global.remote_setting.ftp_host.HOST_NAME = txtAddressFTP.Text;
                Global.remote_setting.ftp_host.PRE_PATH = txtPrepathFTP.Text;
                Global.remote_setting.ftp_host.USER_NAME = txtUsernameFTP.Text;
                Global.remote_setting.ftp_host.PASS_WORD = txtPasswordFTP.Text;
                Global.remote_setting.ftp_host.PORT = txtPortFTP.Text;
                //HTTP
                Global.remote_setting.http_host.HOST_NAME = txtAddressHTTP.Text;
                Global.remote_setting.http_host.PORT = txtPortHTTP.Text;
                Global.remote_setting.http_host.PRE_PATH = txtPrepathHTTP.Text;

                Global.remote_setting.ftp_host.save();
                Global.remote_setting.http_host.save();

            }
            else
            {
                return -1;
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
    }
}
