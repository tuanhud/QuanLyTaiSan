using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                {
                    if (Request.UrlReferrer.Equals(null))
                        Response.Redirect(Request.UrlReferrer.ToString());
                    else
                        Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}