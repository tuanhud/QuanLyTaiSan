using QuanLyTaiSan.Libraries;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class LienHe : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Default SetClassActive = this.Master as Default;
            SetClassActive.page = "LIENHE";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                ucLienHe_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                ucLienHe_Mobile.LoadData();
            }
        }
    }
}