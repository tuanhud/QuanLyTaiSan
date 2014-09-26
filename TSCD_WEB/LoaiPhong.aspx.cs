using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class LoaiPhong : System.Web.UI.Page
    {
        Boolean isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Site SetClassActive = this.Master as Site;
            SetClassActive.page = "LOAIPHONG";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                ucLoaiPhong_Web.Visible = true;
                ucLoaiPhong_Web.LoadData();
            }
            else
            {
                ucLoaiPhong_Mobile.Visible = true;
                ucLoaiPhong_Mobile.LoadData();
            }
        }
    }
}