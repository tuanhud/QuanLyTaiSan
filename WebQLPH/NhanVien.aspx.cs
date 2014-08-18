using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;
using WebQLPH.UserControl.NhanVien;

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
                Panel_Web.Visible = true;
                _ucNhanVien_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                _ucNhanVien_Mobile.LoadData();
            }
        }
    }
}