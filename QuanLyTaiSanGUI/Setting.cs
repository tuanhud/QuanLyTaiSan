using QuanLyTaiSanGUI.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI
{
    public partial class Setting : Form
    {
        ucCauHinh _ucCauHinh = null;
        public Setting()
        {
            InitializeComponent();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            if (_ucCauHinh == null)
            {
                _ucCauHinh = new ucCauHinh();
                _ucCauHinh.load_data();
            }
            panelControlHienThiCauHinh.Controls.Clear();
            _ucCauHinh.Dock = DockStyle.Fill;
            panelControlHienThiCauHinh.Controls.Add(_ucCauHinh);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_ucCauHinh != null)
            {
                int re = _ucCauHinh.save();
                if (re > 0)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể tạo kết nối tới Database!");
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
