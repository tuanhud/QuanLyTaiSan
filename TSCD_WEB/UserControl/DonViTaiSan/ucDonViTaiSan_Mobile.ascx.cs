using DevExpress.Web.ASPxTreeList;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_WEB.UserControl.DonViTaiSan
{
    public partial class ucDonViTaiSan_Mobile : System.Web.UI.UserControl
    {
        public Guid idTaiSan = Guid.Empty;
        List<TSCD.Entities.DonVi> listDonVi = new List<TSCD.Entities.DonVi>();
        List<TSCD.Entities.CTTaiSan> listCTTaiSan = new List<TSCD.Entities.CTTaiSan>();
        public TSCD.DataFilter.TaiSanHienThi objCTTaiSan = null;
        string key = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucTreeViTri.Label_TenViTri.Text = "Chọn đơn vị cần xem";
            }
        }

        public void LoadData()
        {
            if (Convert.ToString(Session["Username"]).Equals(String.Empty))
            {
                DangNhap.Visible = true;
            }
            else
            {
                DangNhap.Visible = false;
                listDonVi = Permission.getAll<TSCD.Entities.DonVi>(Permission._VIEW).OrderBy(c => c.ten).ToList();
                if (listDonVi.Count > 0)
                {
                    TreeViTri.Visible = true;
                    if (listDonVi.Count > 0)
                    {
                        ucTreeViTri.CreateTreeList();
                        ucTreeViTri.ASPxTreeList_ViTri.DataSource = listDonVi;
                        ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                        SearchFunction();
                        if (Request.QueryString["key"] != null)
                        {
                            DanhSach.Visible = true;
                            TreeViTri.Visible = false;
                            key = "";
                            try
                            {
                                key = Request.QueryString["key"].ToString();
                            }
                            catch
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                            DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                            if (node != null)
                            {
                                Guid idDonVi;
                                ucDonViTaiSan_BreadCrumb.Label_Ten.Text = node.GetValue("ten").ToString();
                                if (Request.QueryString["id"] != null)
                                {
                                    ThongTin.Visible = true;
                                    idTaiSan = Guid.Empty;
                                    try
                                    {
                                        idTaiSan = GUID.From(Request.QueryString["id"]);
                                    }
                                    catch
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                    TaiSanHienThi obj = TaiSanHienThi.Convert(TSCD.Entities.CTTaiSan.getQuery().Where(c => c.id == idTaiSan)).FirstOrDefault();
                                    if (obj != null)
                                    {
                                        ucDonViTaiSan_BreadCrumb.Label_Ten.Text = obj.ten;
                                        Label_NgaySuDung.Text = ((DateTime)obj.ngay).ToString("d/M/yyyy");
                                        Label_SoHieu.Text = obj.sohieu_ct;
                                        Label_NgayThang.Text = ((DateTime)obj.ngay_ct).ToString("d/M/yyyy");
                                        Label_TenTaiSan.Text = obj.ten;
                                        Label_DonViTinh.Text = obj.donvitinh;
                                        Label_SoLuong.Text = obj.soluong.ToString();
                                        Label_DonGia.Text = obj.dongia.ToString("#,# VNĐ");
                                        Label_ThanhTien.Text = obj.thanhtien.ToString("#,# VNĐ");
                                        Label_NuocSanXuat.Text = obj.nuocsx;
                                        Label_NguonGoc.Text = obj.nguongoc;
                                        Label_TinhTrang.Text = obj.tinhtrang;
                                        Label_Phong.Text = obj.phong;
                                        Label_ViTri.Text = obj.vitri;
                                        Label_DonViQuanLy.Text = obj.dvquanly;
                                        Label_DonViSuDung.Text = obj.dvsudung;
                                        Label_GhiChu.Text = StringHelper.ConvertRNToBR(obj.ghichu);
                                    }
                                    else
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                }
                                Guid _iddonvi = GUID.From(node.GetValue("id"));
                                TSCD.Entities.DonVi objDonVi = TSCD.Entities.DonVi.getById(_iddonvi);
                                ucDonViTaiSan_BreadCrumb.Label_Ten.Text = objDonVi.ten;
                                List<TaiSanHienThi> listCTTaiSan = TaiSanHienThi.Convert(objDonVi.getAllCTTaiSanRecursive());
                                LoadDanhSachTaiSan(listCTTaiSan);
                            }
                            else
                                Response.Redirect(Request.Url.AbsolutePath);
                        }
                        else
                        {
                            DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                            node.Focus();
                        }
                    }
                    else
                    {
                        KhongCoDuLieu.Visible = true;
                        ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có tài sản";
                    }
                }
                else
                {
                    KhongCoDuLieu.Visible = true;
                    ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có tài sản";
                }
            }
        }

        private void LoadDanhSachTaiSan(List<TSCD.DataFilter.TaiSanHienThi> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                ten = item.ten,
                loai = item.loaits,
                url = StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachTaiSan.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachTaiSan.CollectionPager_Object.BindToControl = RepeaterDanhSachTaiSan;
            RepeaterDanhSachTaiSan.DataSource = _ucCollectionPager_DanhSachTaiSan.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachTaiSan.DataBind();
        }

        private void SearchFunction()
        {
            if (Request.QueryString["Search"] != null)
            {
                Guid SearchID = Guid.Empty;
                try
                {
                    SearchID = GUID.From(Request.QueryString["Search"]);
                }
                catch
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
                TSCD.Entities.CTTaiSan CTTaiSanSearch = TSCD.Entities.CTTaiSan.getById(SearchID);
                if (CTTaiSanSearch != null)
                {
                    Guid nodeGuid = GUID.From(CTTaiSanSearch.donviquanly_id);
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), nodeGuid.ToString())).FirstOrDefault();
                    if (node != null)
                    {
                        int Page = SearchPage(nodeGuid, SearchID);
                        if (Page != -1)
                        {
                            Response.Redirect(string.Format("{0}?key={1}&id={2}&Page={3}", Request.Url.AbsolutePath, node.Key.ToString(), SearchID.ToString(), Page.ToString()));
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
                    Response.Redirect(Request.Url.AbsolutePath);
            }
            else
            {
                return;
            }
        }

        private int SearchPage(Guid GuidDonVi, Guid GuidCTTaiSan)
        {
            int Page = -1;
            TSCD.Entities.DonVi objDonVi = TSCD.Entities.DonVi.getById(GuidDonVi);
            List<TaiSanHienThi> listCTTaiSan = TaiSanHienThi.Convert(objDonVi.getAllCTTaiSanRecursive());
            int index = listCTTaiSan.IndexOf(listCTTaiSan.Where(item => Object.Equals(item.id, GuidCTTaiSan)).FirstOrDefault());
            if (index != -1)
            {
                Page = index / _ucCollectionPager_DanhSachTaiSan.CollectionPager_Object.PageSize + 1;
            }
            return Page;
        }
    }
}