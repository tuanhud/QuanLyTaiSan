using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB.UserControl.Phong
{
    public partial class ucPhong_BreadCrumb : System.Web.UI.UserControl
    {
        public bool isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = SHARED.Libraries.MobileDetect.fBrowserIsMobile();
        }
    }
}