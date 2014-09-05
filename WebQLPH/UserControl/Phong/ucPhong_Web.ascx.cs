using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.Phong
{
    public partial class ucPhong_Web : System.Web.UI.UserControl
    {
        public Guid idPhong = Guid.Empty;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<QuanLyTaiSan.Entities.Phong> listPhong = new List<QuanLyTaiSan.Entities.Phong>();
        QuanLyTaiSan.Entities.Phong objPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DevExpress.Web.ASPxTreeList.TreeListTextColumn _TreeListTextColumn = new DevExpress.Web.ASPxTreeList.TreeListTextColumn();
                _TreeListTextColumn.VisibleIndex = 1;
                _TreeListTextColumn.Name = "colmota";
                _TreeListTextColumn.FieldName = "mota";
                _TreeListTextColumn.Caption = "Mô tả";
                _ucTreeViTri.ASPxTreeList_ViTri.Columns.Add(_TreeListTextColumn);
            }
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
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                    if (Request.QueryString["key"] != null)
                    {
                        string key = "";
                        try
                        {
                            key = Request.QueryString["key"].ToString();
                        }
                        catch
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }

                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            LoadFocusedNodeData();
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                        if (Request.QueryString["id"] != null)
                        {
                            idPhong = Guid.Empty;
                            try
                            {
                                idPhong = GUID.From(Request.QueryString["id"]);
                            }
                            catch
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }

                            objPhong = QuanLyTaiSan.Entities.Phong.getById(idPhong);
                            if (objPhong != null)
                            {
                                Panel_Phong.Visible = true;
                                Label_Phong.Visible = false;
                                Label_ThongTinPhong.Text = "Thông tin " + objPhong.ten;
                                Libraries.ImageHelper.LoadImageWeb(objPhong.hinhanhs.ToList(), _ucASPxImageSlider_Web_Phong.ASPxImageSlider_Object);
                                Label_MaPhong.Text = objPhong.subId;
                                Label_TenPhong.Text = objPhong.ten;
                                string strCoSo, strDay, strTang;
                                strCoSo = objPhong.vitri.coso != null ? objPhong.vitri.coso.ten : "";
                                strDay = objPhong.vitri.day != null ? objPhong.vitri.day.ten : "";
                                strTang = objPhong.vitri.tang != null ? objPhong.vitri.tang.ten : "";
                                if (!strCoSo.Equals(""))
                                {
                                    Label_ViTriPhong.Text += strCoSo;
                                    if (!strDay.Equals(""))
                                    {
                                        Label_ViTriPhong.Text += " - " + strDay;
                                        if (!strTang.Equals(""))
                                        {
                                            Label_ViTriPhong.Text += " - " + strTang;
                                        }
                                    }
                                }
                                else
                                {
                                    Label_ViTriPhong.Text = "[Không rõ]";
                                }
                                Label_MoTaPhong.Text = Libraries.StringHelper.ConvertRNToBR(objPhong.mota);
                                Label_NhanVienPhuTrach.Text = objPhong.nhanvienpt != null ? objPhong.nhanvienpt.hoten : "";

                                if (objPhong.nhanvienpt != null)
                                {
                                    Panel_NhanVienPT.Visible = true;
                                    Label_NhanVienPT.Visible = false;
                                    Label_NhanVienPT.Text = "";
                                    Label_ThongTinNhanVien.Text = "Thông tin " + objPhong.nhanvienpt.hoten;
                                    Libraries.ImageHelper.LoadImageWeb(objPhong.nhanvienpt.hinhanhs.ToList(), _ucASPxImageSlider_Web_NhanVienPT.ASPxImageSlider_Object);
                                    Label_MaNhanVien.Text = objPhong.nhanvienpt.subId;
                                    Label_HoTen.Text = objPhong.nhanvienpt.hoten;
                                    Label_SoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                                }
                                else
                                {
                                    Panel_NhanVienPT.Visible = false;
                                    Label_NhanVienPT.Visible = true;
                                    Label_NhanVienPT.Text = "Phòng này chưa có nhân viên phụ trách";
                                    Label_ThongTinNhanVien.Text = "Thông tin nhân viên";
                                    Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Web_NhanVienPT.ASPxImageSlider_Object);
                                    Label_MaNhanVien.Text = "";
                                    Label_HoTen.Text = "";
                                    Label_SoDienThoai.Text = "";
                                }
                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
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
                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                        node.Focus();
                        Label_TextDanhSachPhong.Text = "Chưa chọn vị trí";
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
                if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && _ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(CoSo).Name))
                    {
                        LoadDanhSachPhong(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 1);
                    }
                    else if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Dayy).Name))
                    {
                        LoadDanhSachPhong(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 2);
                    }
                    else if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Tang).Name))
                    {
                        LoadDanhSachPhong(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 3);
                    }
                    ClearData();
                }
                else
                    Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadDanhSachPhong(Guid id, int type)
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
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
            if (RepeaterDanhSachPhong.Items.Count == 0)
                Label_TextDanhSachPhong.Text = "Vị trí này chưa có phòng";
        }

        private void ClearData()
        {
            Panel_Phong.Visible = false;
            Label_ThongTinPhong.Text = "Thông tin phòng";
            Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Web_Phong.ASPxImageSlider_Object);
            Label_MaPhong.Text = "";
            Label_TenPhong.Text = "";
            Label_ViTriPhong.Text = "";
            Label_MoTaPhong.Text = "";
            Label_NhanVienPhuTrach.Text = "";

            Panel_NhanVienPT.Visible = false;
            Label_NhanVienPT.Visible = true;
            Label_NhanVienPT.Text = "Không có dữ liệu";
            Label_ThongTinNhanVien.Text = "Thông tin nhân viên";
            Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Web_NhanVienPT.ASPxImageSlider_Object);
            Label_MaNhanVien.Text = "";
            Label_HoTen.Text = "";
            Label_SoDienThoai.Text = "";
        }
    }
}