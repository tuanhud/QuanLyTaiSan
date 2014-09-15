using QuanLyTaiSan;
using QuanLyTaiSan.Entities;
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

        public static string _IDSUCO = "";
        public static string _KEYSUCO = "";
        public static string _TENPHONG = "";
        public static string _TENSUCO = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                {
                    PanelDangNhap.Visible = false;
                    PanelAdmin.Visible = true;
                    UserName.InnerText = Session["HoTen"].ToString();
                    HiddenFieldUserName.Value = Session["UserName"].ToString();
                }
                
                if (!string.IsNullOrWhiteSpace(Page.Request["op"]))
                {
                    if (Page.Request["op"].Equals("thoat"))
                    {
                        Session.Clear();
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
        protected override void OnInit(EventArgs e)
        {
            //Global.working_database.WEB_MODE = true;
            if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                QuanLyTaiSan.Global.current_quantrivien_login = QuanTriVien.getByUserName(Session["UserName"].ToString());
        }

        protected void ParentClassActive(string category)
        {
            String[] ThuocQuanLyPhong = { "VITRI", "PHONG", "PHONGTHIETBI", "THIETBI", "LOAITHIETBI", "NHANVIEN", "SUCO", "LOGSUCOMOBILE" };
            String[] ThuocAdmin = { "THONGTINCANHAN", "QUANLYMUONPHONG","QUANLYTAIKHOAN","SETTING" };
            String[] ThuocKhac = { "MUONPHONG", "QUANLYHINHANH" };
            string parent = "";

            foreach(String temp in ThuocQuanLyPhong){
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