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
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //QuanTriVien obj = new QuanTriVien();
            //obj.hoten = "Nguyen Dung";
            //obj.username = "admin2";
            //obj.hashPassword("admin2");
            //obj.group = new Group(obj.DB).getById(1);
            //obj.add();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            QuanTriVien obj = new QuanTriVien();
            obj.username = textEdit_username.Text;
            obj.hashPassword(textEdit_password.Text);
            
            Boolean re = obj.checkLoginByUserName();
            if (re)
            {
                labelControl_msg.Text = "Đăng nhập thành công!";
                //...
            }
            else
            {
                labelControl_msg.Text = "Sai tài khoản hoặc mật khẩu!";

            }
        }

        private void textEdit_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textEdit_password_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_password_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textEdit_username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_ok.PerformClick();
            }
        }

        private void textEdit_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_ok.PerformClick();
            }
        }
    }
}