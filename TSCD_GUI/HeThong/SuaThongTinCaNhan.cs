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
using TSCD;
using TSCD.Entities;
using SHARED.Libraries;

namespace TSCD_GUI.HeThong
{
    public partial class SuaThongTinCaNhan : XtraForm
    {
        public SuaThongTinCaNhan()
        {
            InitializeComponent();
            //register event
            viewSuaThongTinCaNhan1.btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Global.current_quantrivien_login == null)
            {
                this.Close();
            }
            //cap nhat mat khau
            if (!viewSuaThongTinCaNhan1.textEdit_oldpass.Text.Equals("") || !viewSuaThongTinCaNhan1.textEdit_newpass.Text.Equals("") || !viewSuaThongTinCaNhan1.textEdit_newpass_confirm.Text.Equals(""))
            {
                if (QuanTriVien.checkLoginById(Global.current_quantrivien_login.id, QuanTriVien.hashPassword(viewSuaThongTinCaNhan1.textEdit_oldpass.Text)))
                {
                    if (viewSuaThongTinCaNhan1.textEdit_newpass.Text.Equals("") || viewSuaThongTinCaNhan1.textEdit_newpass_confirm.Text.Equals(""))
                    {
                        XtraMessageBox.Show("Mật khẩu không được để trống!");
                        return;
                    }
                    else
                    {
                        if (viewSuaThongTinCaNhan1.textEdit_newpass.Text.Equals(viewSuaThongTinCaNhan1.textEdit_newpass_confirm.Text))
                        {
                            Global.current_quantrivien_login.setPassword(viewSuaThongTinCaNhan1.textEdit_newpass.Text);
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
            Global.current_quantrivien_login.mota = viewSuaThongTinCaNhan1.memoEdit_mota.Text;
            Global.current_quantrivien_login.hoten = viewSuaThongTinCaNhan1.textEdit_hoten.Text;
            Global.current_quantrivien_login.email = viewSuaThongTinCaNhan1.textEdit_email.Text;
            if (Global.current_quantrivien_login.update() > 0 && DBInstance.commit() > 0)
            {
                this.Close();
                return;
            }
            XtraMessageBox.Show("KHÔNG thành công!");

        }
        private void SuaThongTinCaNhan_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += " [" + Global.current_quantrivien_login.niceName() + "]";

                viewSuaThongTinCaNhan1.textEdit_email.Text = Global.current_quantrivien_login.email;
                viewSuaThongTinCaNhan1.textEdit_hoten.Text = Global.current_quantrivien_login.hoten;
                viewSuaThongTinCaNhan1.memoEdit_mota.Text = Global.current_quantrivien_login.mota;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                XtraMessageBox.Show("Thông tin người dùng không hợp lệ, vui lòng khởi động lại phần mềm");
                this.Close();
            }
        }
    }
}