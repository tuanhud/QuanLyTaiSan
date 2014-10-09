using PTB;
using PTB.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class Default : System.Web.UI.MasterPage
    {
        public String page = "Default";
        public String HoTen_Changed { get { return UserName.InnerText; } set { UserName.InnerText = value; } }

        public static string _IDSUCO = "";
        public static string _KEYSUCO = "";
        public static string _TENPHONG = "";
        public static string _TENSUCO = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraDangNhap();

                if (!string.IsNullOrWhiteSpace(Page.Request["op"]))
                {
                    if (Page.Request["op"].Equals("thoat"))
                    {
                        Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["HashPassword_Remember"].Expires = DateTime.Now.AddDays(-1);
                        Session.Abandon();
                        Response.Redirect("Default.aspx");
                    }
                }

                if (page.Equals("LOGSUCOMOBILE"))
                    Session["page"] = "LOGSUCOMOBILE";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public void KiemTraDangNhap()
        {
            try
            {
                if (Object.Equals(Session["UserName"], null))
                {
                    if (!Object.Equals(Request.Cookies["Username_Remember"], null) && !Object.Equals(Request.Cookies["HashPassword_Remember"], null))
                    {
                        string Username = Request.Cookies["Username_Remember"].Value;
                        string HashPassword = Request.Cookies["HashPassword_Remember"].Value;

                        if (QuanTriVien.checkLoginByUserName(Username, HashPassword))
                        {
                            PTB.Global.current_quantrivien_login = QuanTriVien.getByUserName(UserName.ToString());
                            QuanTriVien _QuanTriVien = QuanTriVien.getByUserName(Username);
                            Session["HoTen"] = _QuanTriVien.hoten;
                            Session["UserName"] = Username;
                            PanelDangNhap.Visible = false;
                            PanelAdmin.Visible = true;
                            UserName.InnerText = Session["HoTen"].ToString();
                            HiddenFieldUserName.Value = Session["UserName"].ToString();
                        }
                        else
                        {
                            Response.Cookies["Username_Remember"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["HashPassword_Remember"].Expires = DateTime.Now.AddDays(-1);
                            Session.Abandon();
                        }
                        Response.Redirect(Request.RawUrl);
                    }
                }
                else
                {
                    PanelDangNhap.Visible = false;
                    PanelAdmin.Visible = true;
                    UserName.InnerText = Session["HoTen"].ToString();
                    HiddenFieldUserName.Value = Session["UserName"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                PTB.Global.current_quantrivien_login = QuanTriVien.getByUserName(Session["UserName"].ToString());
        }

        protected void ParentClassActive(string category)
        {
            String[] ThuocQuanLyPhong = { "VITRI", "PHONG", "PHONGTHIETBI", "THIETBI", "LOAITHIETBI", "NHANVIEN", "SUCO", "LOGSUCOMOBILE" };
            String[] ThuocAdmin = { "THONGTINCANHAN", "QUANLYMUONPHONG", "QUANLYTAIKHOAN", "SETTING" };
            String[] ThuocKhac = { "MUONPHONG", "QUANLYHINHANH" };
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

            foreach (String temp in ThuocKhac)
            {
                if (temp.Equals(page))
                {
                    parent = "Khac";
                    break;
                }
            }

            if (parent.Equals(category))
                Response.Write("active");
        }
    }
}