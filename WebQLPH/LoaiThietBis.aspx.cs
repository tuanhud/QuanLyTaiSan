using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLPH.UserControl.LoaiThietBis;

namespace WebQLPH
{
    public partial class LoaiThietBis : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Default SetClassActive = this.Master as Default;
            SetClassActive.page = "LOAITHIETBI";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                ucLoaiThietBi_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                ucLoaiThietBi_Mobile.LoadData();
            }
        }
    }
}