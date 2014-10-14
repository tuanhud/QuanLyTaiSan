using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using SHARED.Libraries;
using System.Threading.Tasks;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmFileChungTu : DevExpress.XtraEditors.XtraForm
    {
        bool save = false;

        public frmFileChungTu()
        {
            InitializeComponent();
        }

        public frmFileChungTu(ChungTu _obj, bool _save = false)
        {
            InitializeComponent();
            this.ct2 = _obj;
            this.save = _save;
            this.ct.attachments = new List<Attachment>(_obj.attachments);
            loadData();
        }

        public ChungTu ct = new ChungTu();
        private ChungTu ct2 = null;
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            //Chọn files
            OpenFileDialog x = new OpenFileDialog();
            x.Multiselect = true;
            x.ShowDialog();
            string[] file_names = x.FileNames;
            if (file_names.Count() > 0)
            {
                //Tạo chứng từ mới
                //ct = new ChungTu();
                //ct.ngay = ServerTimeHelper.getNow();
                //ct.sohieu = "mã chứng từ";
                //Gán attchment
                foreach (string file_name in file_names)
                {
                    Attachment tmp = new Attachment();
                    tmp.LOCAL_FILE_PATH = file_name;
                    ct.attachments.Add(tmp);
                }
                //register event
                ct.onUploadProgress += new SHARED.Libraries.FTPHelper.UploadProgress(this.onChungTu_Uploading);
                // do in background
                var taskA = new Task(() => ct.upload());
                taskA.Start();
                taskA.ContinueWith(new Action<Task>(this.onUploadFinish));

                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Uploading...");

            }
        }
        private delegate void SetLabelProgress(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label_uploading.InvokeRequired)
            {
                SetLabelProgress d = new SetLabelProgress(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label_uploading.Text = text;
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Uploading..." + text);
            }
        }

        private void onUploadFinish(Task obj)
        {
            //ct.update();
            //DBInstance.commit();
            MessageBox.Show("Upload thành công!");
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            loadData();
        }
        private delegate void _loadData();
        private void loadData()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label_uploading.InvokeRequired)
            {
                _loadData d = new _loadData(loadData);
                this.Invoke(d);
            }
            else
            {
                gridControlAttachment.DataSource = null;
                gridControlAttachment.DataSource = ct.attachments;
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Uploading..." + text);
            }
            
        }

        private void onChungTu_Uploading(long current, long total)
        {
            System.Diagnostics.Debug.WriteLine(current + "/" + total);
            this.SetText(current + "/" + total);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewAttachment.GetFocusedRow() != null)
            {
                Attachment obj = gridViewAttachment.GetFocusedRow() as Attachment;
                ct.attachments.Remove(obj);
                //ct.update();
                loadData();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (save)
            {
                ct2.attachments = ct.attachments;
                ct2.update();
                DBInstance.commit();
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (gridViewAttachment.GetFocusedRow() != null)
            {
                Attachment obj = gridViewAttachment.GetFocusedRow() as Attachment;
            }
        }
    }
}