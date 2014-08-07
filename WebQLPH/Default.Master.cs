using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                {
                    PanelDangNhap.Visible = false;
                    PanelAdmin.Visible = true;
                    UserName.InnerText = Session["HoTen"].ToString();
                }
                
                if (!string.IsNullOrWhiteSpace(Page.Request["op"]))
                {
                    Session.Clear();
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        protected override void OnInit(EventArgs e)
        {
            Global.working_database.use_internal_config = true;
        }

        protected bool LaQuanTriVien()
        {
            return Convert.ToString(Session["KieuDangNhap"]).Equals("QuanTriVien");
        }
    }
}