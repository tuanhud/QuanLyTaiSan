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
    public partial class frmNewPhong : Form
    {
        public frmNewPhong()
        {
            InitializeComponent();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmNewCoSo frm = new frmNewCoSo();
            frm.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmNewDay frm = new frmNewDay();
            frm.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmNewTang frm = new frmNewTang();
            frm.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
