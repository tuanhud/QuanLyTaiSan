using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SHARED.Libraries;
using TSCD.Entities;

namespace TSCD_GUI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        private ChungTu ct= null;
        private void button1_Click(object sender, EventArgs e)
        {
            //Chọn files
            OpenFileDialog x = new OpenFileDialog();
            x.Multiselect = true;
            x.ShowDialog();
            string[] file_names = x.FileNames;
            //Tạo chứng từ mới
            ct = new ChungTu();
            ct.ngay = ServerTimeHelper.getNow();
            ct.sohieu = "mã chứng từ";
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
            }
        }

        private void onUploadFinish(Task obj)
        {
            ct.add();
            DBInstance.commit();
            MessageBox.Show("Upload and add to DB finished!");
        }

        private void onChungTu_Uploading(long current, long total)
        {
            System.Diagnostics.Debug.WriteLine(current + "/" + total);
            this.SetText(current + "/" + total);
        }
    }
}
