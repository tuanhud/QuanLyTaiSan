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
using PTB;
using PTB.Entities;
using PTB_GUI.MyForm;
using SHARED.Libraries;

namespace PTB_GUI.HeThong
{
    public partial class SuaThongTinCaNhan : frmCustomXtraForm
    {
        public SuaThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Global.current_quantrivien_login == null)
            {
                this.Close();
            }
            //cap nhat mat khau
            if (!textEdit_oldpass.Text.Equals("") || !textEdit_newpass.Text.Equals("") || !textEdit_newpass_confirm.Text.Equals(""))
            {
                if (QuanTriVien.checkLoginById(Global.current_quantrivien_login.id, QuanTriVien.hashPassword(textEdit_oldpass.Text)))
                {
                    if (textEdit_newpass.Text.Equals("") || textEdit_newpass_confirm.Text.Equals(""))
                    {
                        XtraMessageBox.Show("Mật khẩu không được để trống!");
                        return;
                    }
                    else
                    {
                        if (textEdit_newpass.Text.Equals(textEdit_newpass_confirm.Text))
                        {
                            Global.current_quantrivien_login.setPassword(textEdit_newpass.Text);
                        }
                        else
                        {
                            XtraMessageBox.Show("Mật khẩu không khớp!");
                            return;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Sai mật khẩu cũ!");
                    return;
                }
            }
            //cap nhat thuoc tinh don le
            Global.current_quantrivien_login.mota = memoEdit_mota.Text;
            Global.current_quantrivien_login.hoten = textEdit_hoten.Text;
            Global.current_quantrivien_login.email = textEdit_email.Text;
            if (Global.current_quantrivien_login.update() > 0 && DBInstance.commit() > 0)
            {
                this.Close();
                return;
            }
            XtraMessageBox.Show("KHÔNG thành công!");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
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

        private void SuaThongTinCaNhan_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += " [" + Global.current_quantrivien_login.niceName() + "]";

                textEdit_email.Text = Global.current_quantrivien_login.email;
                textEdit_hoten.Text = Global.current_quantrivien_login.hoten;
                memoEdit_mota.Text = Global.current_quantrivien_login.mota;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
                XtraMessageBox.Show("Thông tin người dùng không hợp lệ, vui lòng khởi động lại phần mềm");
                this.Close();
            }
        }
    }
}