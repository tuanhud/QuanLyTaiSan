using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB.UserControl.LoaiTaiSan
{
    public partial class ucLoaiTaiSan_BreadCrumb : System.Web.UI.UserControl
    {
        public bool isMobile = false;
        public string key = string.Empty;
        public string id = string.Empty;
        public string page = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = SHARED.Libraries.MobileDetect.fBrowserIsMobile();
            key = Request.QueryString["key"] != null ? Request.QueryString["key"] : "";

            if (isMobile)
                _MOBILE.Visible = true;
            else
                _WEB.Visible = true;

            if (!key.Equals(string.Empty))
                _KEY.Visible = true;
        }
    }
}