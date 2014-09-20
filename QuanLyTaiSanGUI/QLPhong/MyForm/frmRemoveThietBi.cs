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

namespace PTB_GUI.QLPhong.MyForm
{
    public partial class frmRemoveThietBi : PTB_GUI.MyForm.frmCustomXtraForm
    {
        public String mota = "";
        public frmRemoveThietBi()
        {
            InitializeComponent();
        }

        public frmRemoveThietBi(String str)
        {
            InitializeComponent();
            labelControl2.Text = str;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mota = txtMota.Text;
        }
    }
}