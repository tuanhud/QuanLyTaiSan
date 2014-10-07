using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHARED.Views
{
    public partial class viewSuaThongTinCaNhan : UserControl
    {
        public viewSuaThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void textEdit_email_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void memoEdit_mota_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_hoten_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkEdit_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_showpass.Checked)
            {
                textEdit_newpass.Properties.PasswordChar =
                textEdit_newpass_confirm.Properties.PasswordChar =
                textEdit_oldpass.Properties.PasswordChar =
                '\0';
            }
            else
            {
                textEdit_newpass.Properties.PasswordChar =
                textEdit_newpass_confirm.Properties.PasswordChar =
                textEdit_oldpass.Properties.PasswordChar =
                '●';
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit_oldpass_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_newpass_confirm_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_newpass_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
