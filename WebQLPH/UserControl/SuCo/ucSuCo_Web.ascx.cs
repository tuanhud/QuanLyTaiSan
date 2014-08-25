using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl.SuCo
{
    public partial class ucSuCo_Web : System.Web.UI.UserControl
    {
        public int idSuCo = -1;
        List<SuCoPhong> listSuCoPhong = new List<SuCoPhong>();
        SuCoPhong objSuCoPhong = new SuCoPhong();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            List<ViTriHienThi> listViTriHienThi = ViTriHienThi.getAll();
            ASPxTreeList_SuCo.DataSource = listViTriHienThi;
            ASPxTreeList_SuCo.DataBind();
            ASPxTreeList_SuCo.ExpandToLevel(1);
            Panel_Chinh.Visible = true;
        }

        protected void ASPxTreeList_SuCo_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {

        }

        protected void ASPxTreeList_SuCo_FocusedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}