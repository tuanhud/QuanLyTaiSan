using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace WebQLPH
{
    public partial class NhanVien : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                //Dang test
                //Panel_Web.Visible = true;
                //Panel_Mobile.Visible = true;
                Panel_Mobile.Visible = true;
                ucNhanVien_Mobile.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                ucNhanVien_Mobile.LoadData();
            }
        }
    }
}