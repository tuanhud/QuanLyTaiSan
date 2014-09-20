using QuanLyTaiSan;
using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PTB_WEB.UserControl
{
    public partial class ucDangNhap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.Cookies["Username_Remember"] != null)
                    {
                        TextBoxTaiKhoan.Text = Request.Cookies["Username_Remember"].Value;
                        TextBoxMatKhau.Attributes.Add("value", Request.Cookies["Password_Remember"].Value);
                        CheckBoxNhoDangNhap.Checked = true;
                    }
                    else
                    {
                        CheckBoxNhoDangNhap.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        protected void ButtonDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        protected void DangNhap()
        {
            try
            {
                string Username = TextBoxTaiKhoan.Text;
                string Password = TextBoxMatKhau.Text;

                if (Username == "")
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Tài khoản không được trống";
                    return;
                }
                if (Password == "")
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Mật khẩu không được trống";
                    return;
                }

                Boolean KiemTraDangNhap = QuanTriVien.checkLoginByUserName(Username,Password);

                if (KiemTraDangNhap)
                {
                    if (CheckBoxNhoDangNhap.Checked == true)
                    {
                        Response.Cookies["Username_Remember"].Value = Username;
                        Response.Cookies["Password_Remember"].Value = Password;
                        Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password_Remember"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password_Remember"].Expires = DateTime.Now.AddDays(-1);
                        CheckBoxNhoDangNhap.Checked = false;
                    }
                    Session["Username"] = Username;
                    QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Username);
                    QuanLyTaiSan.Global.current_quantrivien_login = _QuanTriVien;
                    Session["HoTen"] = _QuanTriVien.hoten;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Tài khoản hoặc mật khẩu không chính xác";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                PanelThongBao.Visible = true;
                LabelThongBao.Text = "<strong>Có lỗi xảy ra !</strong> Vui lòng kiểm tra lại thông tin.";
            }
        }
    }
}
