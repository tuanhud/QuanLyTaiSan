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
using System.Threading;
using DevExpress.LookAndFeel;
using QuanLyTaiSan.Libraries;

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
            checkEdit_remember.Checked = Global.local_setting.login_remember;
            if (Global.local_setting.login_remember)
            {
                textEdit_username.Text = Global.local_setting.login_username;
                textEdit_password.Text = Global.local_setting.login_password;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            QuanTriVien obj = new QuanTriVien();
            obj.username = textEdit_username.Text;
            obj.hashPassword(textEdit_password.Text);
            
            Boolean re = obj.checkLoginByUserName();
            if (re)
            {
                //set global var
                Global.current_login = obj;

                labelControl_msg.Text = "Đăng nhập thành công!";
                this.show_frm_main();
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

        #region SHOW FRM MAIN IN NEW THREAD
        private void ThreadProc()
        {
            Application.EnableVisualStyles();
            UserLookAndFeel.Default.SetSkinStyle(SkinHelper.Office_2010_Blue());
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.SetCompatibleTextRenderingDefault(false);
            

            Application.Run(new frmMain());
        }
        private void show_frm_main()
        {
            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            Application.Exit();
        }
        #endregion

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.local_setting.login_remember = checkEdit_remember.Checked;
            if (Global.local_setting.login_remember)
            {
                Global.local_setting.login_username = textEdit_username.Text;
                Global.local_setting.login_password = textEdit_password.Text;
            }
            Global.local_setting.Save();
        }

        private void checkEdit_remember_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}