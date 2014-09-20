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

namespace PTB_GUI.MyForm
{
    public partial class frmDoiTenHinh : DevExpress.XtraEditors.XtraForm
    {
        public String name = "";

        public frmDoiTenHinh()
        {
            InitializeComponent();
        }

        public frmDoiTenHinh(String _name)
        {
            InitializeComponent();
            txtName.Text = System.IO.Path.GetFileNameWithoutExtension(_name);
            lblext.Text = System.IO.Path.GetExtension(_name);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (PTB.Entities.HinhAnh.getQuery().Where(h => h.path == (txtName.Text + lblext.Text + ".JPEG")).Count() == 0)
            {
                name = txtName.Text + lblext.Text;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Tên file đã tồn tại!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}