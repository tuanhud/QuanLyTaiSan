using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl
{
    public partial class ucDangNhap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!Convert.ToString(Session["Username_Remember"]).Equals(String.Empty))
                    {
                        TextBoxTaiKhoan.Text = Session["Username_Remember"].ToString();
                        TextBoxMatKhau.Text = Session["Password_Remember"].ToString();
                        CheckBoxNhoDangNhap.Checked = true;
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

                Boolean KiemTraDangNhap = false;
                String KieuDangNhap = string.Empty;

                if (CheckBoxQuanTriVien.Checked == true)
                {
                    QuanTriVien _QuanTriVien = new QuanTriVien();
                    _QuanTriVien.username = Username;
                    _QuanTriVien.hashPassword(Password);
                    KiemTraDangNhap = _QuanTriVien.checkLoginByUserName();
                    KieuDangNhap = "QuanTriVien";
                }
                else
                {
                    GiangVien _GiangVien = new GiangVien();
                    _GiangVien.username = Username;
                    _GiangVien.hashPassword(Password);
                    KiemTraDangNhap = _GiangVien.checkLoginByUserName();
                    KieuDangNhap = "GiangVien";
                }

                if (KiemTraDangNhap)
                {
                    if (CheckBoxNhoDangNhap.Checked == true)
                    {
                        Session["Username_Remember"] = Username;
                        Session["Password_Remember"] = Password;
                    }
                    else
                    {
                        Session["Username_Remember"] = String.Empty;
                        Session["Password_Remember"] = String.Empty;
                        CheckBoxNhoDangNhap.Checked = false;
                    }
                    Session["Username"] = Username;
                    if (KieuDangNhap.Equals("GiangVien"))
                    {
                        GiangVien _GiangVien = GiangVien.getByUserName(Username);
                        Session["HoTen"] = _GiangVien.hoten;
                    }
                    else
                    {
                        QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Username);
                        Session["HoTen"] = _QuanTriVien.hoten;
                    }
                    Session["KieuDangNhap"] = KieuDangNhap;
                    if (Request.UrlReferrer.Equals(null))
                        Response.Redirect(Request.UrlReferrer.ToString());
                    else
                        Response.Redirect("Default.aspx");
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