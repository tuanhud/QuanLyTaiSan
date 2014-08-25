using DevExpress.Web.ASPxTreeList;
using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl.ThietBi
{
    public partial class ucThietBi_Web : System.Web.UI.UserControl
    {
        public int idThietBi = -1;
        public string p1 = "Thiết bị quản lý theo số lượng";
        public string p2 = "Thiết bị quản lý theo cá thể";
        public string c1 = "Thiết bị đang được sử dụng";
        public string c2 = "Thiết bị chưa được sử dụng";

        List<QuanLyTaiSan.Entities.ThietBi> listThietBi = new List<QuanLyTaiSan.Entities.ThietBi>();
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            CreateNode();
        }

        public void CreateNode()
        {
            TreeListNode parent1 = ASPxTreeList_ThietBi.AppendNode(0);
            parent1.SetValue("ten", p1);
            TreeListNode parent2 = ASPxTreeList_ThietBi.AppendNode(1);
            parent2.SetValue("ten", p2);
            ASPxTreeList_ThietBi.AppendNode(2, parent2).SetValue("ten", c1);
            ASPxTreeList_ThietBi.AppendNode(3, parent2).SetValue("ten", c2);
            Panel_Chinh.Visible = true;
        }

        protected void ASPxTreeList_ThietBi_FocusedNodeChanged(object sender, EventArgs e)
        {

        }

        private void LoadFocusedNodeData()
        {
            if (listThietBi.Count > 0)
            {
                if (ASPxTreeList_ThietBi.FocusedNode != null && ASPxTreeList_ThietBi.FocusedNode.GetValue("ten") != null)
                {
                    if (ASPxTreeList_ThietBi.FocusedNode.GetValue("ten").ToString().Equals(p1))
                    {
                        LoadDanhSachThietBi(1);
                    }
                    else if (ASPxTreeList_ThietBi.FocusedNode.GetValue("ten").ToString().Equals(p2))
                    {
                        LoadDanhSachThietBi(2);
                    }
                    else if (ASPxTreeList_ThietBi.FocusedNode.GetValue("ten").ToString().Equals(c1))
                    {
                        LoadDanhSachThietBi(3);
                    }
                    else if (ASPxTreeList_ThietBi.FocusedNode.GetValue("ten").ToString().Equals(c2))
                    {
                        LoadDanhSachThietBi(4);
                    }
                }
            }
        }

        private void LoadDanhSachThietBi(int loai)
        {
            switch (loai)
            {
                case 1:
                    listThietBi = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 2:
                    listThietBi = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == false).ToList();
                    break;
                case 3:
                    listThietBi = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    listThietBi = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
        }

        private void LoadImage(List<HinhAnh> listHinhAnh, DevExpress.Web.ASPxImageSlider.ASPxImageSlider _ASPxImageSlider)
        {
            _ASPxImageSlider.Items.Clear();
            if (listHinhAnh != null)
            {
                if (listHinhAnh.Count > 0)
                {
                    foreach (HinhAnh hinhanh in listHinhAnh)
                    {
                        DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                        item.ImageUrl = hinhanh.getImageURL();
                        if (hinhanh.mota != null)
                        {
                            if (hinhanh.mota.Length > 0)
                                item.Text = hinhanh.mota;
                        }
                        else
                            item.Text = hinhanh.FILE_NAME;
                        _ASPxImageSlider.Items.Add(item);
                    }
                }
                else
                {
                    DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                    item.ImageUrl = "~/Images/NoImage.jpg";
                    item.Text = "Không có ảnh";
                    _ASPxImageSlider.Items.Add(item);
                }
            }
            else
            {
                DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                item.ImageUrl = "~/Images/NoImage.jpg";
                item.Text = "Không có ảnh";
                _ASPxImageSlider.Items.Add(item);
            }
        }
    }
}