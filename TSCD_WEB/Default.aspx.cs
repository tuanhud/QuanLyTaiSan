using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class Default : System.Web.UI.Page
    {
        public Boolean isMobile = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
        }
    }
}