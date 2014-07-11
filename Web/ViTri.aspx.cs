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
    public partial class ViTri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Phong> ListPhongs = Phong.getAll();
            Grid.DataSource = ListPhongs;
            Grid.DataBind();
            Grid.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
            Grid.Styles.Header.Font.Bold = true;
            Grid.ExpandRow(1);
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