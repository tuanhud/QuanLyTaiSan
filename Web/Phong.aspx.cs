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
    public partial class Phongs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Phong> ListPhongs = Phong.getAll();
            Grid.DataSource = ListPhongs;
            Grid.DataBind();
            Grid.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
            Grid.Styles.Header.Font.Bold = true;
        }
    }
}