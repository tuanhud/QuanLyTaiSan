using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.Entities;

namespace TSCD_WEB
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public String page = "Default";
        public String HoTen_Changed { get { return UserName.InnerText; } set { UserName.InnerText = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                {
                    ulDangNhap.Visible = false;
                    ulAdmin.Visible = true;
                    UserName.InnerText = Session["HoTen"].ToString();
                    HiddenFieldUserName.Value = Session["UserName"].ToString();
                }

                if (!string.IsNullOrWhiteSpace(Page.Request["op"]))
                {
                    if (Page.Request["op"].Equals("thoat"))
                    {
                        Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["HashPassword_Remember"].Expires = DateTime.Now.AddDays(-1);
                        Session.Abandon();
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                TSCD.Global.current_quantrivien_login = QuanTriVien.getByUserName(Session["UserName"].ToString());
        }

        protected void ParentClassActive(string category)
        {
            String[] ThuocQuanLyPhong = { "VITRI", "PHONG", "LOAIPHONG", "DONVI", "LOAITAISAN", "TAISAN", "DONVITAISAN" };
            String[] ThuocAdmin = { "THONGTINCANHAN" };
            string parent = "";

            foreach (String temp in ThuocQuanLyPhong)
            {
                if (temp.Equals(page))
                {
                    parent = "QuanLyPhong";
                    break;
                }
            }

            foreach (String temp in ThuocAdmin)
            {
                if (temp.Equals(page))
                {
                    parent = "Admin";
                    break;
                }
            }

            if (parent.Equals(category))
                Response.Write("active");
        }
    }
}