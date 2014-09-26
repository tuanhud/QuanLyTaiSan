using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class Phong : System.Web.UI.Page
    {
        Boolean isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Site SetClassActive = this.Master as Site;
            SetClassActive.page = "PHONG";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                ucPhong_Web.Visible = true;
                ucPhong_Web.LoadData();
            }
            else
            {
                ucPhong_Mobile.Visible = true;
                ucPhong_Mobile.LoadData();
            }
        }
    }
}