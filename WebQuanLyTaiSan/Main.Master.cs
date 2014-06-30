using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQuanLyTaiSan
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Page.Session["Username"]) != "admin")
            {
                //Response.Redirect("DangNhap.aspx");
            }
        }
    }
}