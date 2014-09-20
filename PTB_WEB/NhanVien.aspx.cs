using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTB.Libraries;
using PTB_WEB.UserControl.NhanVien;
using System.Text;

namespace PTB_WEB
{
    public partial class NhanVien : System.Web.UI.Page
    {
        Boolean isMobile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "NHANVIEN";

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
}