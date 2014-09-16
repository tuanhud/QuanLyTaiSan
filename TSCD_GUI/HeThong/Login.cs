﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using System.Threading;
using DevExpress.LookAndFeel;
using SHARED.Libraries;
using TSCD_GUI.MyForm;
using TSCD;

namespace TSCD_GUI.HeThong
{
    public partial class Login : frmCustomXtraForm
    {
        public Login()
        {
            InitializeComponent();
            //register event
            viewLogin1.btnOK.Click += new EventHandler(this.btnOK_Click);
            viewLogin1.btnThoat.Click += new EventHandler(this.btnThoat_Click);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //preset value
            viewLogin1.groupBox_Title.Text = "Quản lý tài sản cố định";
            viewLogin1.cbRemember.Checked = Global.local_setting.login_remember;
            if (Global.local_setting.login_remember)
            {
                viewLogin1.txtUsername.Text = Global.local_setting.login_username;
                viewLogin1.txtPassword.Text = Global.local_setting.login_password;
            }
            //Trước khi login phải sync CSDL
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang đồng bộ CSDL...");
            Global.client_database.start_sync();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Boolean re = true;// QuanTriVien.checkLoginByUserName(viewLogin1.txtUsername.Text, viewLogin1.txtPassword.Text);
            if (re)
            {
                //set global var
                Global.current_quantrivien_login = QuanTriVien.getByUserName(viewLogin1.txtUsername.Text);

                viewLogin1.txtMessage.Text = "Đăng nhập thành công!";
                this.show_frm_main();
            }
            else
            {
                viewLogin1.txtMessage.Text = "Sai tài khoản hoặc mật khẩu!";
            }
        }

        #region SHOW FRM MAIN IN NEW THREAD
        private void ThreadProc()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            UserLookAndFeel.Default.SetSkinStyle(Global.local_setting.ApplicationSkinName);
            DevExpress.XtraSplashScreen.SplashScreenManager.RegisterUserSkins(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
            DevExpress.Skins.SkinManager.EnableFormSkins();

            Application.Run(new RibbonFormMain());
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
            Global.local_setting.login_remember = viewLogin1.cbRemember.Checked;
            if (Global.local_setting.login_remember)
            {
                Global.local_setting.login_username = viewLogin1.txtUsername.Text;
                Global.local_setting.login_password = viewLogin1.txtPassword.Text;
            }
            else
            {
                Global.local_setting.login_username = "";
                Global.local_setting.login_password = "";
            }
            Global.local_setting.Save();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
        }
    }
}