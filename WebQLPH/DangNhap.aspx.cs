using System;
using SHARED.Libraries;
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
            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "DANGNHAP";

                try
                {
                    if (!Convert.ToString(Session["UserName"]).Equals(string.Empty))
                    {
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
}