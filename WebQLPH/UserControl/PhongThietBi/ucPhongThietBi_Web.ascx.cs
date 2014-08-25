using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.PhongThietBi
{
    public partial class ucPhongThietBi_Web : System.Web.UI.UserControl
    {
        public int idPhong = -1;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<ChiTietTBHienThi> listThietBiCuaPhong = new List<ChiTietTBHienThi>();
        QuanLyTaiSan.Entities.Phong objPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAllHavePhong();
            ASPxTreeList_ViTri.DataSource = listViTriHienThi;
            ASPxTreeList_ViTri.DataBind();
            Panel_Chinh.Visible = true;
        }

        protected void ASPxTreeList_ViTri_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                e.Cell.Font.Bold = true;
        }

        protected void ASPxTreeList_ViTri_FocusedNodeChanged(object sender, EventArgs e)
        {
            LoadFocusedNodeData();
        }

        private void LoadFocusedNodeData()
        {
            if (listViTriHienThi.Count > 0)
            {
                if (ASPxTreeList_ViTri.FocusedNode != null && ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")) > 0)
                {
                    if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(QuanLyTaiSan.Entities.Phong).Name))
                    {
                        LoadDataObj(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")));
                    }
                }
            }
        }

        private void LoadDataObj(int id)
        {
            objPhong = QuanLyTaiSan.Entities.Phong.getById(id);
            listThietBiCuaPhong = ChiTietTBHienThi.getAllByPhongId(id);
            CollectionPagerDanhSachThietBi.DataSource = listThietBiCuaPhong;
            CollectionPagerDanhSachThietBi.BindToControl = RepeaterDanhSachThietBi;
            
            RepeaterDanhSachThietBi.DataSource = CollectionPagerDanhSachThietBi.DataSourcePaged;
            RepeaterDanhSachThietBi.DataBind();
            ASPxGridView_DanhSachThietBi.DataSource = listThietBiCuaPhong;
            ASPxGridView_DanhSachThietBi.DataBind();
            if (listThietBiCuaPhong != null)
            {
                if (listThietBiCuaPhong.Count > 0)
                    Label_DanhSachThietBi.Text = string.Format("Danh sách thiết bị của {0}", objPhong != null ? objPhong.ten : "[Phòng]");
                else
                    Label_DanhSachThietBi.Text = string.Format("{0} chưa có thiết bị", objPhong != null ? objPhong.ten : "[Phòng]");
            }
            else
                Label_DanhSachThietBi.Text = string.Format("{0} này chưa có thiết bị", objPhong != null ? objPhong.ten : "[Phòng]");
        }
    }
}