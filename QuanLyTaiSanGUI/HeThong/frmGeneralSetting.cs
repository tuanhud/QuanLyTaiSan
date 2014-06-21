using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class frmGeneralSetting : DevExpress.XtraEditors.XtraForm
    {
        private ucFTPSetting ucFTPSetting_ = null;
        private ucHTTPSetting ucHTTPSetting_ = null;
        public frmGeneralSetting()
        {
            InitializeComponent();
            tao_left_panel();
            initUc();
            switchUc("FTP Host");
        }
        private void initUc()
        {
            ucFTPSetting_ = new ucFTPSetting();
            ucHTTPSetting_ = new ucHTTPSetting();
        }
        private void tao_left_panel()
        {
            imageListBoxControl_left.DataSource = new String[] {"FTP Host","HTTP Host" };
        }

        private void imageListBoxControl_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageListBoxControl_left.SelectedValue.Equals("FTP Host"))
            {
                switchUc("FTP Host");
            }
            else if (imageListBoxControl_left.SelectedValue.Equals("HTTP Host"))
            {
                switchUc("HTTP Host");
            }
        }
        private void switchUc(String type="")
        {
            if (ucFTPSetting_ == null || ucHTTPSetting_ == null)
            {
                return;
            }
            xtraScrollableControl_view.Controls.Clear();
            if (type.Equals("FTP Host"))
            {
                ucFTPSetting_.Dock = DockStyle.Fill;
                xtraScrollableControl_view.Controls.Add(ucFTPSetting_);
            }
            else if (type.Equals("HTTP Host"))
            {
                ucFTPSetting_.Dock = DockStyle.Fill;
                xtraScrollableControl_view.Controls.Add(ucHTTPSetting_);
            }
        }

        private void simpleButton_save_Click(object sender, EventArgs e)
        {
            Boolean re = true;
            re=re&& ucFTPSetting_.save()>0;

            if (re)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}