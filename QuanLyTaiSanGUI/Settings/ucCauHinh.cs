using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using SHARED.Libraries;
using PTB;
using PTB.Entities;
using DevExpress.XtraEditors;

namespace PTB_GUI.Settings
{
    public partial class ucCauHinh : UserControl
    {
        //Ket qua tra ve cho frm Setting neu can thiet
        public bool _passed = false;

        private bool can_init_server = false;
        private bool can_config_server = false;
        public ucCauHinh()
        {
            InitializeComponent();
            //register event handler
            #region Local
            viewCauHinhLocal._btnSaveLocal.Click += new EventHandler(this.btnSaveLocal_Click);
            //Client
            viewCauHinhLocal._btnClientCleanUp.Click += new EventHandler(this.btnClientCleanUp_Click);
            viewCauHinhLocal._btnClientRemoveScope.Click += new EventHandler(this.btnClientRemoveScope_Click);
            viewCauHinhLocal._btnClientValidate.Click += new EventHandler(this.btnClientValidate_Click
                );
            viewCauHinhLocal._btnClientDropDB.Click += new EventHandler(this.btnClientDropDB_Click);
            //Server
            viewCauHinhLocal._btnServerCleanUp.Click += new EventHandler(this.btnServerCleanUp_Click);
            viewCauHinhLocal._btnServerRemoveScope.Click += new EventHandler(this.btnServerRemoveScope_Click);
            viewCauHinhLocal._btnServerValidate.Click += new EventHandler(this.btnServerValidate_Click);
            //Sync
            viewCauHinhLocal._btnStartSync.Click += new EventHandler(this.btnStartSync_Click);
            //Developer
            viewCauHinhLocal._btnImageCacheClear.Click += new EventHandler(this.btnImageCacheClear);
            #endregion

            #region Remote
            viewCauHinhRemote1.btnRemoteSettingSave.Click += new EventHandler(this.btnRemoteSettingSave_Click);
            viewCauHinhRemote1.btnSmtpSendTest.Click += new EventHandler(this.btnSmtpSendTest_Click);
            #endregion

        }

        private void btnImageCacheClear(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                FileHelper.clearFolder(HinhAnh.CACHE_PATH);
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }
        /// <summary>
        /// Tải các casu hình lên
        /// </summary>
        private void load_data()
        {
            /*
             * LOCAL SETTING
             */
            //CACHE SERVER
            viewCauHinhLocal._txtClientHost.Text = Global.local_setting.db_cache_host;
            viewCauHinhLocal._txtClientUsername.Text = Global.local_setting.db_cache_username;
            viewCauHinhLocal._txtClientPassword.Text = Global.local_setting.db_cache_password;
            viewCauHinhLocal._txtClientPort.Text = Global.local_setting.db_cache_port;
            viewCauHinhLocal._cbClientWA.Checked = Global.local_setting.db_cache_WA;
            viewCauHinhLocal._txtClientDBName.Text = Global.local_setting.db_cache_dbname;
            //MAIN SERVER
            viewCauHinhLocal._txtServerHost.Text = Global.local_setting.db_server_host;
            viewCauHinhLocal._txtServerUsername.Text = Global.local_setting.db_server_username;
            viewCauHinhLocal._txtServerPassword.Text = Global.local_setting.db_server_password;
            viewCauHinhLocal._txtServerPort.Text = Global.local_setting.db_server_port;
            viewCauHinhLocal._cbServerWA.Checked = Global.local_setting.db_server_WA;
            viewCauHinhLocal._txtServerDBName.Text = Global.local_setting.db_server_dbname;
            //IS USING DBCACHE
            viewCauHinhLocal._cbUseDBCache.Checked = Global.local_setting.use_db_cache;
            //Debug to file
            viewCauHinhLocal._cbDebugToFile.Checked = SHARED.Libraries.Debug.MODE == 1;
            viewCauHinhLocal._cbAutoSync.Checked = Global.local_setting.sync_auto;
            viewCauHinhLocal._txtSyncSecond.Text = Global.local_setting.sync_time_second.ToString();
            /*
             * REMOTE SETTING
             */
            //Phai co ket noi toi Database moi lay duoc remote 
            if (Global.working_database.isReady()>0)
            {
                //FTP
                viewCauHinhRemote1.txtAddressFTP.Text = Global.remote_setting.ftp_host.HOST_NAME;
                viewCauHinhRemote1.txtPrepathFTP.Text = Global.remote_setting.ftp_host.PRE_PATH;
                viewCauHinhRemote1.txtUsernameFTP.Text = Global.remote_setting.ftp_host.USER_NAME;
                viewCauHinhRemote1.txtPasswordFTP.Text = Global.remote_setting.ftp_host.PASS_WORD;
                viewCauHinhRemote1.txtPortFTP.Text = Global.remote_setting.ftp_host.PORT;
                //HTTP
                viewCauHinhRemote1.txtAddressHTTP.Text = Global.remote_setting.http_host.HOST_NAME;
                viewCauHinhRemote1.txtPrepathHTTP.Text = Global.remote_setting.http_host.PRE_PATH;
                //SMTP
                viewCauHinhRemote1.txtSmtpHost.Text = Global.remote_setting.smtp_config.SMTP_HOST;
                viewCauHinhRemote1.txtSmtpPassword.Text = Global.remote_setting.smtp_config.SMTP_PASSWORD;
                viewCauHinhRemote1.txtSmtpPort.Text = Global.remote_setting.smtp_config.SMTP_PORT.ToString();
                viewCauHinhRemote1.txtSmtpUsername.Text = Global.remote_setting.smtp_config.SMTP_USERNAME;
                viewCauHinhRemote1.cbSmtpUseSSL.Checked = Global.remote_setting.smtp_config.SMTP_USESSL;
            }
            //disable some function base on current context and user
            can_config_server = Permission.canDo(Permission._SERVER_CONFIG);
            can_init_server = Global.current_quantrivien_login == null || can_config_server;

            //simpleButton_validateServer.Enabled = can_init_server;
            viewCauHinhLocal._btnServerCleanUp.Enabled = viewCauHinhLocal._btnServerCleanUp.Enabled = can_config_server;
            viewCauHinhRemote1.btnRemoteSettingSave.Enabled = can_config_server;
        }
        /// <summary>
        /// Lưu local setting
        /// </summary>
        /// <returns></returns>
        private void save()
        {
            /*
             * LOCAL SETTING
             */
            if(viewCauHinhLocal._cbUseDBCache.Checked)
            {
                //CACHE DB
                Global.local_setting.db_cache_host = viewCauHinhLocal._txtClientHost.Text;
                Global.local_setting.db_cache_username = viewCauHinhLocal._txtClientUsername.Text;
                Global.local_setting.db_cache_password = viewCauHinhLocal._txtClientPassword.Text;
                Global.local_setting.db_cache_port = viewCauHinhLocal._txtClientPort.Text;
                Global.local_setting.db_cache_dbname = viewCauHinhLocal._txtClientDBName.Text;
                Global.local_setting.db_cache_WA = viewCauHinhLocal._cbClientWA.Checked;
            }
            //MAIN SERVER
            Global.local_setting.db_server_host = viewCauHinhLocal._txtServerHost.Text;
            Global.local_setting.db_server_username = viewCauHinhLocal._txtServerUsername.Text;
            Global.local_setting.db_server_password = viewCauHinhLocal._txtServerPassword.Text;
            Global.local_setting.db_server_port = viewCauHinhLocal._txtServerPort.Text;
            Global.local_setting.db_server_dbname = viewCauHinhLocal._txtServerDBName.Text;
            Global.local_setting.db_server_WA = viewCauHinhLocal._cbServerWA.Checked;

            //IS USING DBCACHE
            Global.local_setting.use_db_cache = viewCauHinhLocal._cbUseDBCache.Checked;
            //debug mode
            Global.local_setting.debug_mode = SHARED.Libraries.Debug.MODE = viewCauHinhLocal._cbDebugToFile.Checked ? 1 : 0;

            Global.local_setting.sync_auto = viewCauHinhLocal._cbAutoSync.Checked;
            int sync_time = StringHelper.toInt(viewCauHinhLocal._txtSyncSecond.Text);
            Global.local_setting.sync_time_second = sync_time <=0?20:sync_time;
            //UPDATE LOCAL SETTING
            Global.local_setting.Save();
        }

        private void btnServerValidate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            save();
            Global.server_database.prepare_db_structure();
            load_DB_State();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnClientValidate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            save();
            Global.client_database.prepare_db_structure();
            load_DB_State();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang đồng bộ...");
            save();
            Global.client_database.start_sync();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnServerCleanUp_Click(object sender, EventArgs e)
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

        private void btnClientCleanUp_Click(object sender, EventArgs e)
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
            Global.remote_setting.ftp_host.HOST_NAME = viewCauHinhRemote1.txtAddressFTP.Text;
            Global.remote_setting.ftp_host.PRE_PATH = viewCauHinhRemote1.txtPrepathFTP.Text;
            Global.remote_setting.ftp_host.USER_NAME = viewCauHinhRemote1.txtUsernameFTP.Text;
            Global.remote_setting.ftp_host.PASS_WORD = viewCauHinhRemote1.txtPasswordFTP.Text;
            Global.remote_setting.ftp_host.PORT = viewCauHinhRemote1.txtPortFTP.Text;

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
                Global.remote_setting.http_host.HOST_NAME = viewCauHinhRemote1.txtAddressHTTP.Text;
                Global.remote_setting.http_host.PORT = viewCauHinhRemote1.txtPortHTTP.Text;
                Global.remote_setting.http_host.PRE_PATH = viewCauHinhRemote1.txtPrepathHTTP.Text;

            Global.remote_setting.http_host.save();
            //SMTP MAIL
            Global.remote_setting.smtp_config.SMTP_HOST = viewCauHinhRemote1.txtSmtpHost.Text;
            Global.remote_setting.smtp_config.SMTP_PASSWORD = viewCauHinhRemote1.txtSmtpPassword.Text;
            Global.remote_setting.smtp_config.SMTP_PORT = StringHelper.toInt(viewCauHinhRemote1.txtSmtpPort.Text);
            Global.remote_setting.smtp_config.SMTP_USERNAME = viewCauHinhRemote1.txtSmtpUsername.Text;
            Global.remote_setting.smtp_config.SMTP_USESSL = viewCauHinhRemote1.cbSmtpUseSSL.Checked;

            Global.remote_setting.smtp_config.save();

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void ucCauHinh_Load(object sender, EventArgs e)
        {
            //Không nên đặt các hàm load dữ liệu tự động trong UC
        }
        /// <summary>
        /// Hiển thị các bút ứng với State hiện tại của cấu hình
        /// </summary>
        /// <returns>-5: FTP Fail, -2: SERVER DB FAIL, -3: CLIENT DB FAIL </returns>
        private int load_DB_State()
        {
            //Load DB State Indicator
            if (Global.working_database.use_db_cache)
            {
                int server_ready = Global.server_database.isReady();
                int client_ready = Global.client_database.isReady();

                viewCauHinhLocal._btnServerRemoveScope.Enabled = Global.server_database.isHasScope() > 0 && can_config_server;
                viewCauHinhLocal._btnServerCleanUp.Enabled = can_config_server;
                viewCauHinhLocal._btnServerValidate.Enabled = !(server_ready > 0) && can_init_server;

                viewCauHinhLocal._btnClientRemoveScope.Enabled = Global.client_database.isHasScope() > 0;
                viewCauHinhLocal._btnClientValidate.Enabled = !(client_ready > 0);
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
                viewCauHinhLocal._btnServerRemoveScope.Enabled = Global.server_database.isHasScope() > 0 && can_config_server;
                viewCauHinhLocal._btnServerCleanUp.Enabled = can_config_server;
                viewCauHinhLocal._btnServerValidate .Enabled = !(server_ready > 0) && can_init_server;
                if (server_ready < 0)
                {
                    return -2;
                }
            }
            return 1;
        }

        private void btnServerRemoveScope_Click(object sender, EventArgs e)
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

        private void btnClientRemoveScope_Click(object sender, EventArgs e)
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

        private void btnSaveLocal_Click(object sender, EventArgs e)
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
                    //set result
                    _passed = true;
                    return;
                }
                //else if (re == -5)
                //{
                //    XtraMessageBox.Show("Lỗi cài đặt FTP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
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
            //viewCauHinhLocal Controls
            foreach (XmlNode nodechild in node)
            {
                _CheckEdit = this.viewCauHinhLocal.Controls.Find(nodechild.Name, true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
                if (_CheckEdit != null)
                    _CheckEdit.Checked = Int32.Parse(nodechild.InnerText) > 0 ? true : false;
                _TextEdit = this.viewCauHinhLocal.Controls.Find(nodechild.Name, true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
                if (_TextEdit != null)
                    _TextEdit.Text = nodechild.InnerText;
            }
            //this Controls
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
                new XElement(viewCauHinhLocal._cbUseDBCache.Name, (viewCauHinhLocal._cbUseDBCache.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal._txtServerHost.Name, viewCauHinhLocal._txtServerHost.Text),
                new XElement(viewCauHinhLocal._txtServerPort.Name, viewCauHinhLocal._txtServerPort.Text),
                new XElement(viewCauHinhLocal._cbServerWA.Name, (viewCauHinhLocal._cbServerWA.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal._txtServerUsername.Name, viewCauHinhLocal._txtServerUsername.Text),
                new XElement(viewCauHinhLocal._txtServerPassword.Name, viewCauHinhLocal._txtServerPassword.Text),
                new XElement(viewCauHinhLocal._txtServerDBName.Name, viewCauHinhLocal._txtServerDBName.Text),

                new XElement(viewCauHinhLocal._txtClientHost.Name, viewCauHinhLocal._txtClientHost.Text),
                new XElement(viewCauHinhLocal._txtClientPort.Name, viewCauHinhLocal._txtClientPort.Text),
                new XElement(viewCauHinhLocal._cbClientWA.Name, (viewCauHinhLocal._cbClientWA.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal._txtClientUsername.Name, viewCauHinhLocal._txtClientUsername.Text),
                new XElement(viewCauHinhLocal._txtClientPassword.Name, viewCauHinhLocal._txtClientPassword.Text),
                new XElement(viewCauHinhLocal._txtClientDBName.Name, viewCauHinhLocal._txtClientDBName.Text),
                new XElement(viewCauHinhLocal._cbDebugToFile.Name, (viewCauHinhLocal._cbDebugToFile.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal._txtSyncSecond.Name, viewCauHinhLocal._txtSyncSecond.Text),
                new XElement(viewCauHinhLocal._cbAutoSync.Name, (viewCauHinhLocal._cbAutoSync.Checked ? 1 : 0).ToString()),


                new XElement(viewCauHinhRemote1.txtAddressFTP.Name, viewCauHinhRemote1.txtAddressFTP.Text),
                new XElement(viewCauHinhRemote1.txtPortFTP.Name, viewCauHinhRemote1.txtPortFTP.Text),
                new XElement(viewCauHinhRemote1.txtPrepathFTP.Name, viewCauHinhRemote1.txtPrepathFTP.Text),
                new XElement(viewCauHinhRemote1.txtUsernameFTP.Name, viewCauHinhRemote1.txtUsernameFTP.Text),
                new XElement(viewCauHinhRemote1.txtPasswordFTP.Name, viewCauHinhRemote1.txtPasswordFTP.Text),
                new XElement(viewCauHinhRemote1.txtAddressHTTP.Name, viewCauHinhRemote1.txtAddressHTTP.Text),
                new XElement(viewCauHinhRemote1.txtPortHTTP.Name, viewCauHinhRemote1.txtPortHTTP.Text),
                new XElement(viewCauHinhRemote1.txtPrepathHTTP.Name, viewCauHinhRemote1.txtPrepathHTTP.Text),
                new XElement(viewCauHinhRemote1.txtSmtpHost.Name, viewCauHinhRemote1.txtSmtpHost.Text),
                new XElement(viewCauHinhRemote1.txtSmtpPort.Name, viewCauHinhRemote1.txtSmtpPort.Text),
                new XElement(viewCauHinhRemote1.cbSmtpUseSSL.Name, (viewCauHinhRemote1.cbSmtpUseSSL.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhRemote1.txtSmtpUsername.Name, viewCauHinhRemote1.txtSmtpUsername.Text),
                new XElement(viewCauHinhRemote1.txtSmtpPassword.Name, viewCauHinhRemote1.txtSmtpPassword.Text));

            str = XML.ToString();
            return str;
        }

        /// <summary>
        /// Làm mới lại dữ liệu
        /// </summary>
        public void reLoad()
        {
            load_data();
            load_DB_State();
        }

        private void btnSmtpSendTest_Click(object sender, EventArgs e)
        {
            if (SHARED.Libraries.EmailHelper.sendMail(
                viewCauHinhRemote1.txtSmtpTestEmail.Text,
                "Test email",
                ServerTimeHelper.getNow().ToString(),
                viewCauHinhRemote1.txtSmtpHost.Text,
                StringHelper.toInt(viewCauHinhRemote1.txtSmtpPort.Text),
                viewCauHinhRemote1.cbSmtpUseSSL.Checked,
                viewCauHinhRemote1.txtSmtpUsername.Text,
                viewCauHinhRemote1.txtSmtpPassword.Text                
                ) > 0)
            {
                MessageBox.Show("Email được gửi thành công, vui lòng kiểm tra hộp thư đến!");
            }
            else
            {
                MessageBox.Show("Gửi email bị lỗi!");
            }
        }

        private void btnClientDropDB_Click(object sender, EventArgs e)
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
    }
}
