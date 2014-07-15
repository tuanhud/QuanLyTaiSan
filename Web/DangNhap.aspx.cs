using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["Username"]) != String.Empty)
                {
                    Response.Redirect("Default.aspx");
                }

                if (Page.Request["op"] == "logout")
                {
                    Session["Username"] = "";
                    Response.Redirect("DangNhap.aspx");
                }

                if (Convert.ToString(Session["Username_Remember"]) != String.Empty)
                {
                    txtUsername.Text = Session["Username_Remember"].ToString();
                    txtPassword.Text = Session["Password_Remember"].ToString();
                    cbRemember.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string Username = txtUsername.Text;
                string Password = txtPassword.Text;

                if (Username == "")
                {
                    lblThongBao.Text = "Tài khoản không được trống";
                    return;
                }
                if (Password == "")
                {
                    lblThongBao.Text = "Mật khẩu không được trống";
                    return;
                }

                QuanLyTaiSan.Entities.QuanTriVien obj = new QuanLyTaiSan.Entities.QuanTriVien();
                obj.username = Username;
                obj.hashPassword(Password);
                Boolean re = obj.checkLoginByUserName();
                if (re)
                {
                    if (cbRemember.Checked == true)
                    {
                        Session["Username_Remember"] = Username;
                        Session["Password_Remember"] = Password;
                    }
                    else
                    {
                        Session["Username_Remember"] = String.Empty;
                        Session["Password_Remember"] = String.Empty;
                        cbRemember.Checked = false;
                    }

                    lblThongBao.Text = "Đăng nhập thành công";
                    Session["Username"] = "admin";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblThongBao.Text = "Tài khoản hoặc mật khẩu không chính xác";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}