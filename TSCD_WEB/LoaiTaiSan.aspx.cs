using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class LoaiTaiSan : System.Web.UI.Page
    {
        Boolean isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Site SetClassActive = this.Master as Site;
            SetClassActive.page = "LOAITAISAN";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                ucLoaiTaiSan_Web.Visible = true;
                ucLoaiTaiSan_Web.LoadData();
            }
            else
            {
                ucLoaiTaiSan_Mobile.Visible = true;
                ucLoaiTaiSan_Mobile.LoadData();
            }
        }
    }
}