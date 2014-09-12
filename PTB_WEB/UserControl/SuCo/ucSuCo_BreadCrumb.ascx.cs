using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB.UserControl.SuCo
{
    public partial class ucSuCo_BreadCrumb : System.Web.UI.UserControl
    {
        public bool isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = SHARED.Libraries.MobileDetect.fBrowserIsMobile();
            try
            {
                if (Request.QueryString["id"] != null)
                    Session["IDSUCO"] = Request.QueryString["id"];
                if (Request.QueryString["key"] != null)
                    Session["KEYSUCO"] = Request.QueryString["key"];
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}