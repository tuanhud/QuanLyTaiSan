using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucFTPSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public ucFTPSetting()
        {
            InitializeComponent();
        }

        private void ucFTPSetting_Load(object sender, EventArgs e)
        {
            //Load FTP
            textEdit_ftpHost.Text = Global.remote_setting.ftp_host.HOST_NAME;
            textEdit_ftpPass.Text = Global.remote_setting.ftp_host.PASS_WORD;
            textEdit_ftpUserName.Text = Global.remote_setting.ftp_host.USER_NAME;
            textEdit_ftpPrePath.Text = Global.remote_setting.ftp_host.PRE_PATH;
            //Load HTTP
            textEdit_httpHost.Text = Global.remote_setting.http_host.HOST_NAME;
            textEdit_httpPrePath.Text = Global.remote_setting.http_host.PRE_PATH;
        }
    }
}
