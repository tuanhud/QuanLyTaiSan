using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using DevExpress.Web.ASPxEditors;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.PhongThietBi
{
    public partial class ucPhongThietBi_Web : System.Web.UI.UserControl
    {
        public Guid idThietBi = Guid.Empty;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<ChiTietTBHienThi> listThietBiCuaPhong = new List<ChiTietTBHienThi>();
        QuanLyTaiSan.Entities.Phong objPhong = null;
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            _ucTreeViTri.ASPxTreeList_ViTri.CustomDataCallback += new DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventHandler(this.ASPxTreeList_ViTri_CustomDataCallback);
            _ucTreeViTri.ASPxTreeList_ViTri.HtmlDataCellPrepared += new DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventHandler(this.ASPxTreeList_ViTri_HtmlDataCellPrepared);
            if (!IsPostBack)
            {
                _ucTreeViTri.Label_TenViTri.Text = "Phòng";
                _ucCollectionPager_DanhSachThietBi.ShowPanelPage(PanelChangePage);
            }
        }

        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAllHavePhong();
            if (listViTriHienThi.Count > 0)
            {
                if (listViTriHienThi.Where(item => Object.Equals(item.loai, typeof(QuanLyTaiSan.Entities.Phong).Name)).FirstOrDefault() != null)
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
                            _ucTreeViTri.FocusAndExpandToNode(node);
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(GUID.From(node.GetValue("id")));
                            if (objPhong != null)
                            {
                                string strViTri = "";
                                DevExpress.Web.ASPxTreeList.TreeListNode Pnode = node.ParentNode;
                                while (!Object.Equals(Pnode.Key, ""))
                                {
                                    strViTri = " - " + Pnode.GetValue("ten").ToString() + strViTri;
                                    Pnode = Pnode.ParentNode;
                                }
                                strViTri = string.Format("({0})", strViTri.Substring(3));
                                ucPhongThietBi_BreadCrumb.Label_TenPhong.Text = objPhong.ten + " " + strViTri;
                                LoadDataObjPhong();
                                if (Request.QueryString["id"] != null)
                                {
                                    idThietBi = Guid.Empty;
                                    try
                                    {
                                        idThietBi = GUID.From(Request.QueryString["id"]);
                                    }
                                    catch
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                    objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(idThietBi);
                                    if (objThietBi != null)
                                    {
                                        Label_ThongTinThietBi.Text = string.Format("Thông tin {0}", objThietBi.ten);
                                        Panel_ThietBi.Visible = true;
                                        Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                                        _ucASPxImageSlider_Web.urlHinhAnh = string.Format("http://{0}/HinhAnh.aspx?id={1}&type=THIETBI", HttpContext.Current.Request.Url.Authority, objThietBi.id);
                                        Label_MaThietBi.Text = objThietBi.subId;
                                        ucPhongThietBi_BreadCrumb.Label_TenThietBi.Text = Label_TenThietBi.Text = objThietBi.ten;
                                        if (objThietBi.loaithietbi != null)
                                        {
                                            Label_LoaiThietBi.Text = objThietBi.loaithietbi.ten;
                                            if (objThietBi.loaithietbi.loaichung)
                                            {
                                                Panel_NgayMua.Visible = false;
                                                Label_NgayMua.Text = "";
                                                Label_KieuQuanLy.Text = "Theo số lượng";
                                            }
                                            else
                                            {
                                                Panel_NgayMua.Visible = true;
                                                Label_NgayMua.Text = objThietBi.ngaymua.ToString();
                                                Label_KieuQuanLy.Text = "Theo cá thể";
                                            }
                                        }
                                        else
                                        {
                                            Label_LoaiThietBi.Text = "[Loại thiết bị]";
                                            Panel_NgayMua.Visible = false;
                                            Label_NgayMua.Text = "";
                                            Label_KieuQuanLy.Text = "Chưa rõ";
                                        }
                                        Label_Phong.Text = objPhong.ten;
                                        Label_NgayLap.Text = objThietBi.ctthietbis != null ? objThietBi.ctthietbis.Where(item => item.phong_id == objPhong.id).FirstOrDefault().ngay.ToString() : "";
                                        Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objThietBi.mota);
                                        Button_XemLog.OnClientClick = string.Format("OnMoreInfoClick('{0}'); return false;", Libraries.StringHelper.AddParameter(new Uri("http://" + Request.Url.Authority + "/" + ResolveClientUrl("~/LogThietBi.aspx")), new List<string>(new string[] { "id", "idp" }), new List<string>(new string[] { idThietBi.ToString(), objPhong.id.ToString() })));
                                        Label_ThietBi.Visible = false;
                                        Label_ThietBi.Text = "";
                                    }
                                    else
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                }
                                else
                                {
                                    ClearData();
                                }
                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                    }
                    else
                    {
                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                        node.Focus();
                        Label_DanhSachThietBi.Text = "Chưa chọn phòng";
                        ClearData();
                    }
                }
                else
                {
                    ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                    ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có phòng";
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có vị trí";
            }
        }

        private void LoadDataObjPhong()
        {
            if (objPhong != null)
            {
                listThietBiCuaPhong = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
                var bind = listThietBiCuaPhong.Select(a => new
                {
                    id = a.idTB,
                    ten = a.ten,
                    tinhtrang = a.tinhtrang,
                    soluong = a.soluong,
                    url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", a.idTB.ToString()),
                    urlLog = Libraries.StringHelper.AddParameter(new Uri("http://" + Request.Url.Authority + "/" + ResolveClientUrl("~/LogThietBi.aspx")), new List<string>(new string[] { "id", "idp" }), new List<string>(new string[] { a.idTB.ToString(), objPhong.id.ToString() }))
                }).OrderBy(item => item.tinhtrang).ToList();
                _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.DataSource = bind;
                _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.BindToControl = RepeaterDanhSachThietBi;
                RepeaterDanhSachThietBi.DataSource = _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.DataSourcePaged;
                RepeaterDanhSachThietBi.DataBind();

                if (listThietBiCuaPhong != null)
                {
                    if (listThietBiCuaPhong.Count > 0)
                        Label_DanhSachThietBi.Text = string.Format("Danh sách thiết bị của {0}", objPhong.ten);
                    else
                        Label_DanhSachThietBi.Text = string.Format("{0} chưa có thiết bị", objPhong.ten);
                }
                else
                    Label_DanhSachThietBi.Text = string.Format("{0} chưa có thiết bị", objPhong.ten);
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void ClearData()
        {
            Label_ThongTinThietBi.Text = "Thông tin thiết bị";
            Panel_ThietBi.Visible = false;
            Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Web.ASPxImageSlider_Object);
            Label_MaThietBi.Text = "";
            Label_TenThietBi.Text = "";
            Label_LoaiThietBi.Text = "";
            Label_LoaiThietBi.Text = "Chưa rõ";
            Label_Phong.Text = "";
            Panel_NgayMua.Visible = false;
            Label_NgayMua.Text = "";
            Label_NgayLap.Text = "";
            Label_MoTa.Text = "";
            Label_ThietBi.Visible = true;
            Label_ThietBi.Text = "Chưa chọn thiết bị";
        }

        private void ASPxTreeList_ViTri_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
            {
                if (Object.Equals(node.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                    e.Result = Request.Url.AbsolutePath + "?key=" + key;
                else
                    e.Result = "";
            }
            else
                e.Result = Request.Url.AbsolutePath;
        }

        private void ASPxTreeList_ViTri_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                e.Cell.Font.Bold = true;
        }
    }
}