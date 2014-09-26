using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class ViTri : System.Web.UI.Page
    {
        Boolean isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Site SetClassActive = this.Master as Site;
            SetClassActive.page = "VITRI";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                ucViTri_Web.Visible = true;
                ucViTri_Web.LoadData();
            }
            else
            {
                ucViTri_Mobile.Visible = true;
                ucViTri_Mobile.LoadData();
            }
        }
    }
}