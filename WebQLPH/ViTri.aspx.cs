using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class ViTri : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                Panel_Web.Visible = true;
                _ucViTri_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                //_ucViTri_Mobile.LoadData();
            }
        }
    }
}