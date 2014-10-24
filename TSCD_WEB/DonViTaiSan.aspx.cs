using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class DonViTaiSan : System.Web.UI.Page
    {
        Boolean isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Site SetClassActive = this.Master as Site;
            SetClassActive.page = "DONVITAISAN";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                DevExpress.Web.ASPxClasses.ASPxWebControl.RegisterBaseScript(this);
                ucDonViTaiSan_Web.Visible = true;
                ucDonViTaiSan_Web.LoadData();
            }
            else
            {
                ucDonViTaiSan_Mobile.Visible = true;
                ucDonViTaiSan_Mobile.LoadData();
            }
        }
    }
}