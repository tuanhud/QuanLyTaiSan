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
        ucNhanVien_Web _ucNhanVien_Web = null;
        ucNhanVien_Mobile _ucNhanVien_Mobile = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                if (_ucNhanVien_Web == null)
                    _ucNhanVien_Web = new ucNhanVien_Web();
                
                Panel_Main.Controls.Add(_ucNhanVien_Web);
            }
            else
            {
                if (_ucNhanVien_Mobile == null)
                    _ucNhanVien_Mobile = new ucNhanVien_Mobile();
                Panel_Main.Controls.Add(_ucNhanVien_Mobile);
            }
        }
    }
}