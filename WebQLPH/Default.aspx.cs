using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class Default1 : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                ucTrangChu_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                ucTrangChu_Mobile.LoadData();
            }
        }
    }
}