using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSCD.Entities;
using DevExpress.XtraEditors;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using SHARED.Libraries;
using TSCD;
using TSCD_GUI;
using SHARED.Views;

namespace TSCD_GUI.Settings
{
    public partial class ucCauHinh : UserControl,_ourUcInterface
    {
        public bool _passed = false;
        private bool can_init_server = false;
        private bool can_config_server = false;
        public ucCauHinh()
        {
            InitializeComponent();
            //register event handler
            viewCauHinhLocal1._btnSaveLocal.Click += new EventHandler(this.btnSaveLocal_Click);
            //Client
            viewCauHinhLocal1._btnClientCleanUp.Click += new EventHandler(this.btnClientCleanUp_Click);
            viewCauHinhLocal1._btnClientRemoveScope.Click += new EventHandler(this.btnClientRemoveScope_Click);
            viewCauHinhLocal1._btnClientValidate.Click += new EventHandler(this.btnClientValidate_Click
                );
            viewCauHinhLocal1._btnClientDropDB.Click += new EventHandler(this.btnClientDropDB_Click);
            //Server
            viewCauHinhLocal1._btnServerCleanUp.Click += new EventHandler(this.btnServerCleanUp_Click);
            viewCauHinhLocal1._btnServerRemoveScope.Click += new EventHandler(this.btnServerRemoveScope_Click);
            viewCauHinhLocal1._btnServerValidate.Click += new EventHandler(this.btnServerValidate_Click);
            //Sync
            viewCauHinhLocal1._btnStartSync.Click += new EventHandler(this.btnStartSync_Click);

        }
        private void load_data()
        {
            /*
             * LOCAL SETTING
             */
            //CACHE SERVER
            viewCauHinhLocal1._txtClientHost.Text = Global.local_setting.db_cache_host;
            viewCauHinhLocal1._txtClientUsername.Text = Global.local_setting.db_cache_username;
            viewCauHinhLocal1._txtClientPassword.Text = Global.local_setting.db_cache_password;
            viewCauHinhLocal1._txtClientPort.Text = Global.local_setting.db_cache_port;
            viewCauHinhLocal1._cbClientWA.Checked = Global.local_setting.db_cache_WA;
            viewCauHinhLocal1._txtClientDBName.Text = Global.local_setting.db_cache_dbname;
            //MAIN SERVER
            viewCauHinhLocal1._txtServerHost.Text = Global.local_setting.db_server_host;
            viewCauHinhLocal1._txtServerUsername.Text = Global.local_setting.db_server_username;
            viewCauHinhLocal1._txtServerPassword.Text = Global.local_setting.db_server_password;
            viewCauHinhLocal1._txtServerPort.Text = Global.local_setting.db_server_port;
            viewCauHinhLocal1._cbServerWA.Checked = Global.local_setting.db_server_WA;
            viewCauHinhLocal1._txtServerDBName.Text = Global.local_setting.db_server_dbname;
            //IS USING DBCACHE
            viewCauHinhLocal1._cbUseDBCache.Checked = Global.local_setting.use_db_cache;
            //Debug to file
            viewCauHinhLocal1._cbDebugToFile.Checked = SHARED.Libraries.Debug.MODE == 1;
            viewCauHinhLocal1._cbAutoSync.Checked = Global.local_setting.sync_auto;
            viewCauHinhLocal1._txtSyncSecond.Text = Global.local_setting.sync_time_second.ToString();
            
            //disable some function base on current context and user
            can_config_server = Permission.canDo(Permission._SERVER_CONFIG);
            can_init_server = Global.current_quantrivien_login == null || can_config_server;

            //simpleButton_validateServer.Enabled = can_init_server;
            viewCauHinhLocal1._btnServerCleanUp.Enabled = viewCauHinhLocal1._btnServerCleanUp.Enabled = can_config_server;
            
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
            if (viewCauHinhLocal1._cbUseDBCache.Checked)
            {
                //CACHE DB
                Global.local_setting.db_cache_host = viewCauHinhLocal1._txtClientHost.Text;
                Global.local_setting.db_cache_username = viewCauHinhLocal1._txtClientUsername.Text;
                Global.local_setting.db_cache_password = viewCauHinhLocal1._txtClientPassword.Text;
                Global.local_setting.db_cache_port = viewCauHinhLocal1._txtClientPort.Text;
                Global.local_setting.db_cache_dbname = viewCauHinhLocal1._txtClientDBName.Text;
                Global.local_setting.db_cache_WA = viewCauHinhLocal1._cbClientWA.Checked;
            }
            //MAIN SERVER
            Global.local_setting.db_server_host = viewCauHinhLocal1._txtServerHost.Text;
            Global.local_setting.db_server_username = viewCauHinhLocal1._txtServerUsername.Text;
            Global.local_setting.db_server_password = viewCauHinhLocal1._txtServerPassword.Text;
            Global.local_setting.db_server_port = viewCauHinhLocal1._txtServerPort.Text;
            Global.local_setting.db_server_dbname = viewCauHinhLocal1._txtServerDBName.Text;
            Global.local_setting.db_server_WA = viewCauHinhLocal1._cbServerWA.Checked;

            //IS USING DBCACHE
            Global.local_setting.use_db_cache = viewCauHinhLocal1._cbUseDBCache.Checked;
            //debug mode
            Global.local_setting.debug_mode = SHARED.Libraries.Debug.MODE = viewCauHinhLocal1._cbDebugToFile.Checked ? 1 : 0;

            Global.local_setting.sync_auto = viewCauHinhLocal1._cbAutoSync.Checked;
            int sync_time = StringHelper.toInt(viewCauHinhLocal1._txtSyncSecond.Text);
            Global.local_setting.sync_time_second = sync_time <= 0 ? 20 : sync_time;
            //UPDATE LOCAL SETTING
            Global.local_setting.Save();
        }

        private void btnServerValidate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            save();
            Global.server_database.prepare_db_structure();
            load_DB_State();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnClientValidate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tạo dữ liệu...");
            save();
            Global.client_database.prepare_db_structure();
            load_DB_State();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang đồng bộ...");
            save();
            Global.client_database.start_sync();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnServerCleanUp_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
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
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.client_database.clean_up_scope();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }


        private void ucCauHinh_Load(object sender, EventArgs e)
        {
            //txtAddressDatabase.Focus();
            //load_DB_State();
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

                viewCauHinhLocal1._btnServerRemoveScope.Enabled = Global.server_database.isHasScope() > 0 && can_config_server;
                viewCauHinhLocal1._btnServerCleanUp.Enabled = can_config_server;
                viewCauHinhLocal1._btnServerValidate.Enabled = !(server_ready > 0) && can_init_server;

                viewCauHinhLocal1._btnClientRemoveScope.Enabled = Global.client_database.isHasScope() > 0;
                viewCauHinhLocal1._btnClientValidate.Enabled = !(client_ready > 0);
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
                viewCauHinhLocal1._btnServerRemoveScope.Enabled = Global.server_database.isHasScope() > 0 && can_config_server;
                viewCauHinhLocal1._btnServerCleanUp.Enabled = can_config_server;
                viewCauHinhLocal1._btnServerValidate.Enabled = !(server_ready > 0) && can_init_server;
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
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
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
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
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
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                re = load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                if (re > 0)
                {
                    XtraMessageBox.Show("Lưu cài đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //viewCauHinhLocal1 Controls
            foreach (XmlNode nodechild in node)
            {
                _CheckEdit = this.viewCauHinhLocal1.Controls.Find(nodechild.Name, true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
                if (_CheckEdit != null)
                    _CheckEdit.Checked = Int32.Parse(nodechild.InnerText) > 0 ? true : false;
                _TextEdit = this.viewCauHinhLocal1.Controls.Find(nodechild.Name, true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
                if (_TextEdit != null)
                    _TextEdit.Text = nodechild.InnerText;
            }
        }

        private String LayThongTinCauHinhHienTai()
        {
            String str = "";
            var XML = new XElement("Controls",
                new XElement(viewCauHinhLocal1._cbUseDBCache.Name, (viewCauHinhLocal1._cbUseDBCache.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal1._txtServerHost.Name, viewCauHinhLocal1._txtServerHost.Text),
                new XElement(viewCauHinhLocal1._txtServerPort.Name, viewCauHinhLocal1._txtServerPort.Text),
                new XElement(viewCauHinhLocal1._cbServerWA.Name, (viewCauHinhLocal1._cbServerWA.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal1._txtServerUsername.Name, viewCauHinhLocal1._txtServerUsername.Text),
                new XElement(viewCauHinhLocal1._txtServerPassword.Name, viewCauHinhLocal1._txtServerPassword.Text),
                new XElement(viewCauHinhLocal1._txtServerDBName.Name, viewCauHinhLocal1._txtServerDBName.Text),

                new XElement(viewCauHinhLocal1._txtClientHost.Name, viewCauHinhLocal1._txtClientHost.Text),
                new XElement(viewCauHinhLocal1._txtClientPort.Name, viewCauHinhLocal1._txtClientPort.Text),
                new XElement(viewCauHinhLocal1._cbClientWA.Name, (viewCauHinhLocal1._cbClientWA.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal1._txtClientUsername.Name, viewCauHinhLocal1._txtClientUsername.Text),
                new XElement(viewCauHinhLocal1._txtClientPassword.Name, viewCauHinhLocal1._txtClientPassword.Text),
                new XElement(viewCauHinhLocal1._txtClientDBName.Name, viewCauHinhLocal1._txtClientDBName.Text),
                new XElement(viewCauHinhLocal1._cbDebugToFile.Name, (viewCauHinhLocal1._cbDebugToFile.Checked ? 1 : 0).ToString()),
                new XElement(viewCauHinhLocal1._txtSyncSecond.Name, viewCauHinhLocal1._txtSyncSecond.Text),
                new XElement(viewCauHinhLocal1._cbAutoSync.Name, (viewCauHinhLocal1._cbAutoSync.Checked ? 1 : 0).ToString())
                );
                
            str = XML.ToString();
            return str;
        }

        public void reLoad()
        {
            load_data();
            load_DB_State();
        }

        private void btnClientDropDB_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Xác nhận?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                save();
                Global.client_database.dropDB();
                load_DB_State();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }
    }
}
