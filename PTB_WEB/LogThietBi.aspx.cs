using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.PhongThietBi
{
    public partial class LogThietBi : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Default SetClassActive = this.Master as Default;
            //SetClassActive.page = "LOGTHIETBI";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                _ucLogThietBi_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                _ucLogThietBi_Mobile.LoadData();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
                MasterPageFile = "~/PopupMasterPage.master";
            else
            {
                MasterPageFile = "~/Default.master";
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "LOGTHIETBIMOBILE";
            }
        }
    }
}