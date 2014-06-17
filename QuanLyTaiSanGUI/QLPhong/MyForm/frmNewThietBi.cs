using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.MyForm
{
    public partial class frmNewThietBi : Form
    {
        public frmNewThietBi()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = true;
        }
    }
}
