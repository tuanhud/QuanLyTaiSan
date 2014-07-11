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
    public partial class ThietBis : System.Web.UI.Page
    {
        List<ThietBiHienThi> ListThietBiHienThi = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Openlbl(true);
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

        protected void lblLoaiChung_Click(object sender, EventArgs e)
        {
            Openlbl(true);
        }

        protected void lblLoaiRieng_Click(object sender, EventArgs e)
        {
            Openlbl(false);
        }

        public void Openlbl(bool LoaiChung)
        {
            if (LoaiChung)
            {
                lblLoaiChung.Enabled = false;
                lblLoaiRieng.Enabled = true;
                ListThietBiHienThi = ThietBiHienThi.getAllByTypeLoai(true);
                lblInfo.Text = "Thiết bị quản lý theo số lượng";
                Grid.Columns[3].Visible = false;
                Grid.DataSource = ListThietBiHienThi;
                Grid.DataBind();
            }
            else
            {
                lblLoaiChung.Enabled = true;
                lblLoaiRieng.Enabled = false;
                ListThietBiHienThi = ThietBiHienThi.getAllByTypeLoai(false);
                lblInfo.Text = "Thiết bị quản lý riêng lẻ";
                Grid.Columns[3].Visible = true;
                Grid.DataSource = ListThietBiHienThi;
                Grid.DataBind();
            }
        }
    }
}