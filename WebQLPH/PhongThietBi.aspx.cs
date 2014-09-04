using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace WebQLPH
{
    public partial class PhongThietBi : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Default SetClassActive = this.Master as Default;
            SetClassActive.page = "PHONGTHIETBI";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                _ucPhongThietBi_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                _ucPhongThietBi_Mobile.LoadData();
            }
        }
    }
}