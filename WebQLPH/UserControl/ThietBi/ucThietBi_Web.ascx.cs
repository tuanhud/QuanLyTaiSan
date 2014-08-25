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
            listThietBi = QuanLyTaiSan.Entities.ThietBi.getAll();
            if (listThietBi.Count > 0)
            {
                Panel_Chinh.Visible = true;
                CreateNode();
                if (Request.QueryString["id"] != null)
                {
                    idThietBi = -1;
                    try
                    {
                        idThietBi = Int32.Parse(Request.QueryString["id"].ToString());
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                        return;
                    }
                    objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(idThietBi);
                    if (objThietBi != null)
                    {
                        Panel_ThietBi.Visible = true;
                        Label_ThietBi.Visible = false;
                        PanelThongBao_ThietBi.Visible = false;
                        Label_ThongTinThietBi.Text = "Thông tin " + objThietBi.ten;
                        LoadImage(objThietBi.hinhanhs.ToList(), ASPxImageSlider_ThietBi);
                        TextBox_MaThietBi.Text = objThietBi.subId;
                        TextBox_TenThietBi.Text = objThietBi.ten;
                        TextBox_LoaiThietBi.Text = objThietBi.loaithietbi != null ? objThietBi.loaithietbi.ten : "";
                        TextBox_NgayMua.Text = objThietBi.ngaymua != null ? objThietBi.ngaymua.ToString() : "";
                        TextBox_MoTaThietBi.Text = objThietBi.mota;
                    }
                    else
                    {
                        //ClearData();
                        PanelThongBao_ThietBi.Visible = true;
                        LabelThongBao_ThietBi.Text = "Không có thiết bị này";
                    }
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có thiết bị";
            }
        }

        private void ClearData()
        {
            Panel_ThietBi.Visible = false;
            PanelThongBao_ThietBi.Visible = false;
            Label_ThongTinThietBi.Text = "Thông tin thiết bị";
            LoadImage(null, ASPxImageSlider_ThietBi);
            TextBox_MaThietBi.Text = "";
            TextBox_TenThietBi.Text = "";
            TextBox_LoaiThietBi.Text = "";
            TextBox_MoTaThietBi.Text = "";
        }

        public void CreateNode()
        {
            TreeListNode parent1 = ASPxTreeList_ThietBi.AppendNode(0);
            parent1.SetValue("ten", p1);
            TreeListNode parent2 = ASPxTreeList_ThietBi.AppendNode(1);
            parent2.SetValue("ten", p2);
            ASPxTreeList_ThietBi.AppendNode(2, parent2).SetValue("ten", c1);
            ASPxTreeList_ThietBi.AppendNode(3, parent2).SetValue("ten", c2);
            LoadFocusedNodeData();
        }

        protected void ASPxTreeList_ThietBi_FocusedNodeChanged(object sender, EventArgs e)
        {
            LoadFocusedNodeData();
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
            List<QuanLyTaiSan.Entities.ThietBi> list = null;
            switch (loai)
            {
                case 1:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 2:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == false).ToList();
                    break;
                case 3:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                loaithietbi = item.loaithietbi != null ? item.loaithietbi.ten : "",
                url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            CollectionPagerDanhSachThietBi.DataSource = bind;
            CollectionPagerDanhSachThietBi.BindToControl = RepeaterThietBi;
            RepeaterThietBi.DataSource = CollectionPagerDanhSachThietBi.DataSourcePaged;
            RepeaterThietBi.DataBind();
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

        protected void ASPxTreeList_ThietBi_CustomDataCallback1(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ThietBi.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
        }
    }
}