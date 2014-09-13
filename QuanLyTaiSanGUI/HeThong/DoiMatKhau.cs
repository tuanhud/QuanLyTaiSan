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
using QuanLyTaiSan;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class DoiMatKhau : frmCustomXtraForm
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Global.current_quantrivien_login == null)
            {
                return;
            }
            if (QuanTriVien.checkLoginById(Global.current_quantrivien_login.id, textEdit_oldpass.Text) && textEdit_newpass.Text.Equals(textEdit_newpass_confirm.Text))
            {
                Global.current_quantrivien_login.hashPassword(textEdit_newpass.Text);
                if (Global.current_quantrivien_login.update() > 0 && DBInstance.commit() > 0)
                {
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("KHÔNG thành công!");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
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
    }
}