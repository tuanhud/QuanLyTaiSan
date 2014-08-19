using QuanLyTaiSan.DataFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl.ViTri
{
    public partial class ucViTri_Web : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            Panel_Chinh.Visible = true;
            List<ViTriHienThi> ListViTriHienThi = ViTriHienThi.getAll();
            ASPxTreeList_ViTri.DataSource = ListViTriHienThi;
            ASPxTreeList_ViTri.DataBind();
            ASPxTreeList_ViTri.ExpandToLevel(1);
        }

        protected void ASPxTreeList_ViTri_FocusedNodeChanged(object sender, EventArgs e)
        {
            PanelThongBao.Visible = !PanelThongBao.Visible;
        }
    }
}