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

namespace QuanLyTaiSanGUI
{
    public partial class frmPasswordXML : DevExpress.XtraEditors.XtraForm
    {
        public frmPasswordXML()
        {
            InitializeComponent();
        }

        private void simpleButton_Ok_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            if (textEdit_Password.Text.Length == 0)
            {
                dxErrorProvider1.SetError(textEdit_Password, "Chưa điền password!");
                this.DialogResult = DialogResult.None;
                textEdit_Password.Focus();
                return;
            }
            if (textEdit_Password.Text.Length < 6)
            {
                dxErrorProvider1.SetError(textEdit_Password, "Password từ 6 kí tự trở lên!");
                this.DialogResult = DialogResult.None;
                textEdit_Password.Focus();
                return;
            }
        }

        private void textEdit_Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton_Ok.PerformClick();
            }
        }
    }
}