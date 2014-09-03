using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.PhongThietBi
{
    public partial class LogSuCo : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                _ucLogSuCo_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                _ucLogSuCo_Mobile.LoadData();
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
                SetClassActive.page = "LOGSUCOMOBILE";
            }
        }
    }
}