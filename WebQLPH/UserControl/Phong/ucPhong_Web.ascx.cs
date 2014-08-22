using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

namespace WebQLPH.UserControl.Phong
{
    public partial class ucPhong_Web : System.Web.UI.UserControl
    {
        public int idPhong = -1;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<QuanLyTaiSan.Entities.Phong> listPhong = new List<QuanLyTaiSan.Entities.Phong>();
        QuanLyTaiSan.Entities.Phong objPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listPhong = QuanLyTaiSan.Entities.Phong.getAll();
            if (listPhong.Count > 0)
            {
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count > 0)
                {
                    Panel_Chinh.Visible = true;
                    ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ASPxTreeList_ViTri.DataBind();
                    if (Request.QueryString["idObj"] != null && Request.QueryString["type"] != null)
                    {
                        int idObj = -1;
                        string type = "";
                        try
                        {
                            idObj = Int32.Parse(Request.QueryString["idObj"].ToString());
                            type = Request.QueryString["type"].ToString();
                        }
                        catch
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }

                        if (type.Equals(typeof(CoSo).Name))
                        {
                            if (FindNodeTreeList(idObj, type))
                                LoadDanhSachPhong(idObj, 1);
                            else
                                Response.Redirect(Request.Url.AbsolutePath);
                        }
                        else if (type.Equals(typeof(Dayy).Name))
                        {
                            if (FindNodeTreeList(idObj, type))
                                LoadDanhSachPhong(idObj, 2);
                            else
                                Response.Redirect(Request.Url.AbsolutePath);
                        }
                        else if (type.Equals(typeof(Tang).Name))
                        {
                            if (FindNodeTreeList(idObj, type))
                                LoadDanhSachPhong(idObj, 3);
                            else
                                Response.Redirect(Request.Url.AbsolutePath);
                        }
                        else
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                    }
                    else
                    {
                        LoadFocusedNodeData();
                    }
                    if (Request.QueryString["id"] != null)
                    {
                        idPhong = -1;
                        try
                        {
                            idPhong = Int32.Parse(Request.QueryString["id"].ToString());
                        }
                        catch
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                            return;
                        }
                        objPhong = QuanLyTaiSan.Entities.Phong.getById(idPhong);
                        if (objPhong != null)
                        {
                            Panel_Phong.Visible = true;
                            Label_Phong.Visible = false;
                            PanelThongBao_Phong.Visible = false;
                            Label_ThongTinPhong.Text = "Thông tin " + objPhong.ten;
                            LoadImage(objPhong.hinhanhs.ToList(), ASPxImageSlider_Phong);
                            TextBox_MaPhong.Text = objPhong.subId;
                            TextBox_TenPhong.Text = objPhong.ten;
                            string strCoSo, strDay, strTang;
                            strCoSo = objPhong.vitri.coso != null ? objPhong.vitri.coso.ten : "";
                            strDay = objPhong.vitri.day != null ? objPhong.vitri.day.ten : "";
                            strTang = objPhong.vitri.tang != null ? objPhong.vitri.tang.ten : "";
                            if (!strCoSo.Equals(""))
                            {
                                TextBox_ViTriPhong.Text += strCoSo;
                                if (!strDay.Equals(""))
                                {
                                    TextBox_ViTriPhong.Text += " - " + strDay;
                                    if (!strTang.Equals(""))
                                    {
                                        TextBox_ViTriPhong.Text += " - " + strTang;
                                    }
                                }
                            }
                            else
                            {
                                TextBox_ViTriPhong.Text = "";
                            }
                            TextBox_MoTaPhong.Text = objPhong.mota;
                            TextBox_NhanVienPhuTrach.Text = objPhong.nhanvienpt != null ? objPhong.nhanvienpt.hoten : "";

                            if (objPhong.nhanvienpt != null)
                            {
                                Panel_NhanVien.Visible = true;
                                Label_NhanVien.Visible = false;
                                Label_NhanVien.Text = "";
                                Label_ThongTinNhanVien.Text = "Thông tin " + objPhong.nhanvienpt.hoten;
                                LoadImage(objPhong.nhanvienpt.hinhanhs.ToList(), ASPxImageSlider_NhanVien);
                                TextBox_MaNhanVien.Text = objPhong.nhanvienpt.subId;
                                TextBox_TenNhanVien.Text = objPhong.nhanvienpt.hoten;
                                TextBox_SoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                            }
                            else
                            {
                                Panel_NhanVien.Visible = false;
                                Label_NhanVien.Visible = true;
                                Label_NhanVien.Text = "Phòng này chưa có nhân viên phụ trách";
                                Label_ThongTinNhanVien.Text = "Thông tin nhân viên";
                                LoadImage(null, ASPxImageSlider_NhanVien);
                                TextBox_MaNhanVien.Text = "";
                                TextBox_TenNhanVien.Text = "";
                                TextBox_SoDienThoai.Text = "";
                            }
                        }
                        else
                        {
                            ClearData();
                            PanelThongBao_Phong.Visible = true;
                            LabelThongBao_Phong.Text = "Không có phòng này";
                        }
                    }
                    else
                    {
                        ClearData();
                        Label_Phong.Visible = true;
                        Label_Phong.Text = "Chưa chọn phòng";
                    }
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có phòng";
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có phòng";
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listViTriHienThi.Count > 0)
            {
                if (ASPxTreeList_ViTri.FocusedNode != null && ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")) > 0)
                {
                    if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(CoSo).Name))
                    {
                        LoadDanhSachPhong(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 1);
                    }
                    else if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Dayy).Name))
                    {
                        LoadDanhSachPhong(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 2);
                    }
                    else if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Tang).Name))
                    {
                        LoadDanhSachPhong(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 3);
                    }
                    ClearData();
                }
            }
        }

        private void LoadDanhSachPhong(int id, int type)
        {
            switch (type)
            {
                case 1:
                    LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.coso_id != null).ToList().Where(phong => phong.vitri.coso_id == id).ToList());
                    break;
                case 2:
                    LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.day_id != null).ToList().Where(phong => phong.vitri.day_id == id).ToList());
                    break;
                case 3:
                    LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.tang_id != null).ToList().Where(phong => phong.vitri.tang_id == id).ToList());
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
        }

        private void LoadDanhSachPhong(List<QuanLyTaiSan.Entities.Phong> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                nhanvienpt = item.nhanvienpt != null ? item.nhanvienpt.hoten : "",
                url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            CollectionPagerDanhSachPhong.DataSource = bind;
            CollectionPagerDanhSachPhong.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = CollectionPagerDanhSachPhong.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
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

        private void ClearData()
        {
            Panel_Phong.Visible = false;
            PanelThongBao_Phong.Visible = false;
            Label_ThongTinPhong.Text = "Thông tin phòng";
            LoadImage(null, ASPxImageSlider_Phong);
            TextBox_MaPhong.Text = "";
            TextBox_TenPhong.Text = "";
            TextBox_ViTriPhong.Text = "";
            TextBox_MoTaPhong.Text = "";
            TextBox_NhanVienPhuTrach.Text = "";

            Panel_NhanVien.Visible = false;
            Label_NhanVien.Visible = true;
            Label_NhanVien.Text = "Không có dữ liệu";
            Label_ThongTinNhanVien.Text = "Thông tin nhân viên";
            LoadImage(null, ASPxImageSlider_NhanVien);
            TextBox_MaNhanVien.Text = "";
            TextBox_TenNhanVien.Text = "";
            TextBox_SoDienThoai.Text = "";
        }

        private Boolean FindNodeTreeList(int id, string type)
        {
            List<DevExpress.Web.ASPxTreeList.TreeListNode> listNode = ASPxTreeList_ViTri.FindNodesByFieldValue("loai", type);
            DevExpress.Web.ASPxTreeList.TreeListNode node = listNode.Where(item => ((ViTriHienThi)item.DataItem).id == id).FirstOrDefault();
            if (node != null)
            {
                node.Focus();                
                return true;
            }
            return false;
        }

        protected void ASPxTreeList_ViTri_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?idObj=" + node.GetValue("id").ToString() + "&type=" + node.GetValue("loai").ToString();
            else
                e.Result = Request.Url.AbsolutePath;
        }
    }
}