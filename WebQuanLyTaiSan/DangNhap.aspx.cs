using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQuanLyTaiSan
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["op"] == "logout")
            {
                Session["Username"] = "";
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            if (Username == "") lblThongBao.Text = "Tài khoản không được trống";
            else if (Password == "") lblThongBao.Text = "Mật khẩu không được trống";
            else if (Username == "admin" && Password == "admin")
            {
                lblThongBao.Text = "Đăng nhập thành công";
                Session["Username"] = "admin";
                Response.Redirect("Default.aspx");
            }
            else lblThongBao.Text = "Tài khoản hoặc mật khẩu không chính xác";
        }
    }
}