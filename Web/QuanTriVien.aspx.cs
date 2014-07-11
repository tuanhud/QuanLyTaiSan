using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

namespace Web
{
    public partial class QuanTriVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<QuanTriVienFilter> ListQuanTriVienFilter = QuanTriVienFilter.getAll();
            //List<HinhAnh> ListHinhAnh = ListQuanTriVien[0].hinhanhs.ToList();
            //string text = ListQuanTriVien[0].hinhanhs.ToList()[0].path.ToString();
            Grid.DataSource = ListQuanTriVienFilter;
            Grid.DataBind();
            Grid.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
            Grid.Styles.Header.Font.Bold = true;
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (OurClass.MobileDetect.fBrowserIsMobile())
            {
                Grid.Theme = "iOS";
            }
            else
            {
                //Grid.Theme = "Aqua";
            }
        }
    }
}