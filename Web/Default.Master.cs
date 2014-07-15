using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Very Important
            Global.working_database.use_internal_config = true;
            //Global.debug.MODE = 0;

            if (Convert.ToString(Page.Session["Username"]) != "admin")
            {
                Response.Redirect("DangNhap.aspx");
            }
        }
    }
}