﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.Entities;

namespace TSCD_WEB.UserControl.DangNhap
{
    public partial class ucDangNhap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                string HashPassword = HiddenFieldMatKhau.Value;

                if (Username == "")
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Tài khoản không được trống";
                    return;
                }
                if (HashPassword == "")
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "Mật khẩu không được trống";
                    return;
                }

                Boolean KiemTraDangNhap = QuanTriVien.checkLoginByUserName(Username, HashPassword);

                if (KiemTraDangNhap)
                {
                    if (CheckBoxNhoDangNhap.Checked == true)
                    {
                        Response.Cookies["Username_Remember"].Value = Username;
                        Response.Cookies["HashPassword_Remember"].Value = HashPassword;
                        Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["HashPassword_Remember"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["HashPassword_Remember"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["Username"] = Username;
                    QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Username);
                    TSCD.Global.current_quantrivien_login = _QuanTriVien;
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