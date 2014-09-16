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
using DevExpress.XtraEditors;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using SHARED.Libraries;
using QuanLyTaiSan;

namespace QuanLyTaiSanGUI.Settings
{
    public partial class ucCauHinh : UserControl,_ourUcInterface
    {
        private bool can_init_server = false;
        private bool can_config_server = false;
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
            checkEdit_debugToFile.Checked = SHARED.Libraries.Debug.MODE == 1;
            checkEdit_autoSync.Checked = Global.local_setting.sync_auto;
            textEdit_sync_second.Text = Global.local_setting.sync_time_second.ToString();
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
                //SMTP
                txtSmtpHost.Text = Global.remote_setting.smtp_config.SMTP_HOST;
                txtSmtpPassword.Text = Global.remote_setting.smtp_config.SMTP_PASSWORD;
                txtSmtpPort.Text = Global.remote_setting.smtp_config.SMTP_PORT.ToString();
                txtSmtpUsername.Text = Global.remote_setting.smtp_config.SMTP_USERNAME;
                cbSmtpUseSSL.Checked = Global.remote_setting.smtp_config.SMTP_USESSL;
            }
            //disable some function base on current context and user
            can_config_server = Permission.canDo(Permission._SERVER_CONFIG);
            can_init_server = Global.current_quantrivien_login == null || can_config_server;

            //simpleButton_validateServer.Enabled = can_init_server;
            btnRemoveServerScope.Enabled = simpleButton_cleanUpServerScope.Enabled = can_config_server;
            btnRemoteSettingSave.Enabled = can_config_server;
        }
        /// <summary>
        /// Lưu local setting
        /// </summary>
        /// <returns></returns>
        public void save()
        {
            /*
             * LOCAL SETTING
             */
            if(checkEdit_useDBCache.Checked)
            {
                //CACHE DB
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
            Global.local_setting.debug_mode = SHARED.Libraries.Debug.MODE = checkEdit_debugToFile.Checked ? 1 : 0;

            Global.local_setting.sync_auto = checkEdit_autoSync.Checked;
            int sync_time = StringHelper.toInt(textEdit_sync_second.Text);
            Global.local_setting.sync_time_second = sync_time <=0?20:sync_time;
            //UPDATE LOCAL SETTING
            Global.local_setting.Save();
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
            save();
            Global.server_database.prepare_db_structure();
            load_DB_State();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton_validateClient_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            save();
            Global.client_database.prepare_db_structure();
            load_DB_State();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang đồng bộ...");
            save();
            Global.client_database.start_sync();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void simpleButton_cleanUpServerScope_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.server_database.clean_up_scope();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void simpleButton_cleanUpClientScope_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.client_database.clean_up_scope();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void btnRemoteSettingSave_Click(object sender, EventArgs e)
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
            //    Global.remote_setting.ftp_host.PASS_WORD,
            //    10
            //    ) > 0
            //)
            //{
                Global.remote_setting.ftp_host.save();
            //}
            //else
            //{
            //    MessageBox.Show("FTP Fail");
            //    return;
            //}

            //HTTP
            Global.remote_setting.http_host.HOST_NAME = txtAddressHTTP.Text;
            Global.remote_setting.http_host.PORT = txtPortHTTP.Text;
            Global.remote_setting.http_host.PRE_PATH = txtPrepathHTTP.Text;

            Global.remote_setting.http_host.save();
            //SMTP MAIL
            Global.remote_setting.smtp_config.SMTP_HOST = txtSmtpHost.Text;
            Global.remote_setting.smtp_config.SMTP_PASSWORD = txtSmtpPassword.Text;
            Global.remote_setting.smtp_config.SMTP_PORT = StringHelper.toInt(txtSmtpPort.Text);
            Global.remote_setting.smtp_config.SMTP_USERNAME = txtSmtpUsername.Text;
            Global.remote_setting.smtp_config.SMTP_USESSL = cbSmtpUseSSL.Checked;

            Global.remote_setting.smtp_config.save();

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void ucCauHinh_Load(object sender, EventArgs e)
        {
            //txtAddressDatabase.Focus();
            load_DB_State();
        }
        /// <summary>
        /// Lưu lại cài đặt
        /// 
        /// </summary>
        /// <returns>-5: FTP Fail, -2: SERVER DB FAIL, -3: CLIENT DB FAIL </returns>
        private int load_DB_State()
        {
            //Load DB State Indicator
            if (Global.working_database.use_db_cache)
            {
                int server_ready = Global.server_database.isReady();
                int client_ready = Global.client_database.isReady();

                btnRemoveServerScope.Enabled = Global.server_database.isHasScope() > 0 && can_config_server;
                simpleButton_cleanUpServerScope.Enabled = can_config_server;
                simpleButton_validateServer.Enabled = !(server_ready > 0) && can_init_server;

                btnRemoveClientScope.Enabled = Global.client_database.isHasScope() > 0;
                simpleButton_validateClient.Enabled = !(client_ready > 0);
                if (client_ready < 0)
                {
                    return -3;
                }
                if (server_ready < 0)
                {
                    return -2;
                }
            }
            else
            {
                int server_ready = Global.server_database.isReady();
                btnRemoveServerScope.Enabled = Global.server_database.isHasScope() > 0 && can_config_server;
                simpleButton_cleanUpServerScope.Enabled = can_config_server;
                simpleButton_validateServer.Enabled = !(server_ready > 0) && can_init_server;
                if (server_ready < 0)
                {
                    return -2;
                }
            }
            return 1;
        }
        private void btnDebugClear_Click(object sender, EventArgs e)
        {
            SHARED.Libraries.Debug.remove_file();
        }

        private void btnRemoveServerScope_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.server_database.drop_scope();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void btnRemoveClientScope_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.client_database.drop_scope();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void simpleButton_Luu_Click(object sender, EventArgs e)
        {
            int re = 1;
            //if (_ucCauHinh != null)
            {
                //call ucSave
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                re = load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                if (re > 0)
                {
                    XtraMessageBox.Show("Lưu cài đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.ParentForm.Name.Equals("Setting"))
                    {
                        Setting _Setting = new Setting();
                        _Setting.KiemtraKetnoiDatabase();
                    }
                    return;
                }
                else if (re == -5)
                {
                    XtraMessageBox.Show("Lỗi cài đặt FTP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (re == -2)
                {
                    XtraMessageBox.Show("Lỗi cài đặt Database Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (re == -3)
                {
                    XtraMessageBox.Show("Lỗi cài đặt Database Client!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private string passwordMaHoa = "ajdshja^%jasdaASHGHJ";

        private void simpleButton_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.Title = "Chọn file XML cấu hình";
            _OpenFileDialog.Filter = "XML File|*.xml";
            _OpenFileDialog.Multiselect = false;
            DialogResult _DialogResult = _OpenFileDialog.ShowDialog();
            if (_DialogResult == DialogResult.OK)
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    xml.Load(_OpenFileDialog.FileName);
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi khi đọc file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = xml.SelectNodes("/CauHinh");
                if (result.Count > 0)
                {
                    string strXML = result[0].InnerText;
                    string strXMLCauHinh = StringHelper.Decrypt(strXML, passwordMaHoa);
                    if (strXMLCauHinh != string.Empty)
                    {
                        SetThongTinCauHinh(strXMLCauHinh);
                        XtraMessageBox.Show("Import file XML thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi giải mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("File XML không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void simpleButton_Export_Click(object sender, EventArgs e)
        {
            string strXML = "";
            strXML = StringHelper.Encrypt(LayThongTinCauHinhHienTai(), passwordMaHoa);
            SaveFileDialog _SaveFileDialog = new SaveFileDialog();
            _SaveFileDialog.Filter = "XML File|*.xml";
            _SaveFileDialog.Title = "Lưu file XML";
            _SaveFileDialog.ShowDialog();

            if (_SaveFileDialog.FileName != "")
            {
                var xFile = new XElement("CauHinh", strXML);
                xFile.Save(_SaveFileDialog.FileName);
                XtraMessageBox.Show("Export file XML thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetThongTinCauHinh(String strXMLCauHinh)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strXMLCauHinh);

            XmlNode node = xml.DocumentElement.SelectSingleNode("/Controls");
            DevExpress.XtraEditors.CheckEdit _CheckEdit = null;
            DevExpress.XtraEditors.TextEdit _TextEdit = null;
            foreach (XmlNode nodechild in node)
            {
                _CheckEdit = this.Controls.Find(nodechild.Name, true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
                if (_CheckEdit != null)
                    _CheckEdit.Checked = Int32.Parse(nodechild.InnerText) > 0 ? true : false;
                _TextEdit = this.Controls.Find(nodechild.Name, true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
                if (_TextEdit != null)
                    _TextEdit.Text = nodechild.InnerText;
            }
        }

        private String LayThongTinCauHinhHienTai()
        {
            String str = "";
            var XML = new XElement("Controls",
                new XElement(checkEdit_useDBCache.Name, (checkEdit_useDBCache.Checked ? 1 : 0).ToString()),
                new XElement(txtAddressDatabase.Name, txtAddressDatabase.Text),
                new XElement(txtPortDatabase.Name, txtPortDatabase.Text),
                new XElement(checkEdit_ServerWA.Name, (checkEdit_ServerWA.Checked ? 1 : 0).ToString()),
                new XElement(txtUsernameDatabase.Name, txtUsernameDatabase.Text),
                new XElement(txtPasswordDatabase.Name, txtPasswordDatabase.Text),
                new XElement(textEdit_ServerDBName.Name, textEdit_ServerDBName.Text),

                new XElement(textEdit_CacheHost.Name, textEdit_CacheHost.Text),
                new XElement(textEdit_CachePort.Name, textEdit_CachePort.Text),
                new XElement(checkEdit_CacheWA.Name, (checkEdit_CacheWA.Checked ? 1 : 0).ToString()),
                new XElement(textEdit_CacheAccount.Name, textEdit_CacheAccount.Text),
                new XElement(textEdit_CachePass.Name, textEdit_CachePass.Text),
                new XElement(textEdit_CacheDBName.Name, textEdit_CacheDBName.Text),
                new XElement(checkEdit_debugToFile.Name, (checkEdit_debugToFile.Checked ? 1 : 0).ToString()),

                new XElement(txtAddressFTP.Name, txtAddressFTP.Text),
                new XElement(txtPortFTP.Name, txtPortFTP.Text),
                new XElement(txtPrepathFTP.Name, txtPrepathFTP.Text),
                new XElement(txtUsernameFTP.Name, txtUsernameFTP.Text),
                new XElement(txtPasswordFTP.Name, txtPasswordFTP.Text),
                new XElement(txtAddressHTTP.Name, txtAddressHTTP.Text),
                new XElement(txtPortHTTP.Name, txtPortHTTP.Text),
                new XElement(txtPrepathHTTP.Name, txtPrepathHTTP.Text),
                new XElement(txtSmtpHost.Name, txtSmtpHost.Text),
                new XElement(txtSmtpPort.Name, txtSmtpPort.Text),
                new XElement(cbSmtpUseSSL.Name, (cbSmtpUseSSL.Checked ? 1 : 0).ToString()),
                new XElement(txtSmtpUsername.Name, txtSmtpUsername.Text),
                new XElement(txtSmtpPassword.Name, txtSmtpPassword.Text));

            str = XML.ToString();
            return str;
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }
        private void saveLocalSetting()
        {

        }

        private void btnSmtpSendTest_Click(object sender, EventArgs e)
        {
            if (SHARED.Libraries.EmailHelper.sendMail(
                txtSmtpTestEmail.Text,
                "Test email",
                ServerTimeHelper.getNow().ToString(),
                txtSmtpHost.Text,
                StringHelper.toInt(txtSmtpPort.Text),
                cbSmtpUseSSL.Checked,
                txtSmtpUsername.Text,
                txtSmtpPassword.Text                
                ) > 0)
            {
                MessageBox.Show("Email được gửi thành công, vui lòng kiểm tra hộp thư đến!");
            }
            else
            {
                MessageBox.Show("Gửi email bị lỗi!");
            }
        }

        private void btn_dropClientDB_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.client_database.dropDB();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void checkEdit_autoSync_CheckedChanged(object sender, EventArgs e)
        {
            textEdit_sync_second.Enabled = (sender as CheckEdit).Checked;
        }
    }
}
