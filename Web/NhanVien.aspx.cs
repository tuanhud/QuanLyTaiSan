using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace Web
{
    public partial class NhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<NhanVienPT> ListNhanVienPT = NhanVienPT.getAll();
            //List<HinhAnh> ListHinhAnh = ListNhanVienPT[0].hinhanhs.ToList();
            //string text = ListNhanVienPT[0].hinhanhs.First().path.ToString();
            Grid.DataSource = ListNhanVienPT;
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