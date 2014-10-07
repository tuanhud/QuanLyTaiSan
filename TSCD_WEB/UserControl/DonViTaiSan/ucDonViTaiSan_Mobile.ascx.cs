using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.DataFilter;

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
                ucTreeViTri.Label_TenViTri.Text = "Chọn đơn vị cần xem";
                listDonVi = TSCD.Entities.DonVi.getAll();
                if (listDonVi.Count > 0)
                {
                    TreeViTri.Visible = true;
                    if (listDonVi.Count > 0)
                    {
                        ucTreeViTri.CreateTreeList();
                        ucTreeViTri.ASPxTreeList_ViTri.DataSource = listDonVi;
                        ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                        //SearchFunction();
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
                                        Label_NgaySuDung.Text = obj.ngay.ToString();
                                        Label_SoHieu.Text = obj.sohieu_ct;
                                        Label_NgayThang.Text = obj.ngay_ct.ToString();
                                        Label_TenTaiSan.Text = obj.ten;
                                        Label_DonViTinh.Text = obj.donvitinh;
                                        Label_SoLuong.Text = obj.soluong.ToString();
                                        Label_DonGia.Text = obj.dongia.ToString();
                                        Label_ThanhTien.Text = obj.thanhtien.ToString();
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
                                Guid _id = GUID.From(node.GetValue("id"));
                                LoadDanhSachPhong(listPhong.Where(phong => phong.loaiphong.id != null).ToList().Where(phong => phong.loaiphong.id == _id).ToList());
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
                        ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có phòng";
                    }
                }
                else
                {
                    KhongCoDuLieu.Visible = true;
                    ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có phòng";
                }
            }
        }

        protected string ViTriCuaPhong(TSCD.Entities.Phong objPhong)
        {
            string _strtemp = "", _strCoSo, _strDay, _strTang;
            _strCoSo = objPhong.vitri.coso != null ? objPhong.vitri.coso.ten : "";
            _strDay = objPhong.vitri.day != null ? objPhong.vitri.day.ten : "";
            _strTang = objPhong.vitri.tang != null ? objPhong.vitri.tang.ten : "";

            if (!_strCoSo.Equals(""))
            {
                _strtemp += _strCoSo;
                if (!_strDay.Equals(""))
                {
                    _strtemp += " - " + _strDay;
                    if (!_strTang.Equals(""))
                    {
                        _strtemp += " - " + _strTang;
                    }
                }
            }
            return _strtemp == "" ? "[Không rõ]" : _strtemp;
        }

        private void LoadDanhSachPhong(List<TSCD.Entities.Phong> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                ten = item.ten,
                loai = item.loaiphong.ten,
                url = StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
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
                TSCD.Entities.Phong PhongSearch = listPhong.Where(item => Object.Equals(item.id, SearchID)).FirstOrDefault();
                if (PhongSearch != null)
                {
                    Guid nodeGuid = Guid.Empty;
                    int type = 0;
                    if (PhongSearch.vitri != null)
                    {
                        if (PhongSearch.vitri.tang != null)
                        {
                            nodeGuid = PhongSearch.vitri.tang.id;
                            type = 3;
                        }
                        else if (PhongSearch.vitri.day != null)
                        {
                            nodeGuid = PhongSearch.vitri.day.id;
                            type = 2;
                        }
                        else if (PhongSearch.vitri.coso != null)
                        {
                            nodeGuid = PhongSearch.vitri.coso.id;
                            type = 1;
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    else
                        Response.Redirect(Request.Url.AbsolutePath);
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), nodeGuid.ToString())).FirstOrDefault();
                    if (node != null)
                    {
                        int Page = SearchPage(nodeGuid, PhongSearch.id, type);
                        if (Page != -1)
                        {
                            Response.Redirect(string.Format("{0}?key={1}&id={2}&Page={3}", Request.Url.AbsolutePath, node.Key.ToString(), PhongSearch.id.ToString(), Page.ToString()));
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

        private int SearchPage(Guid GuidViTri, Guid GuidPhong, int type)
        {
            int Page = -1;
            List<TSCD.Entities.Phong> listTemp = new List<TSCD.Entities.Phong>();
            switch (type)
            {
                case 1:
                    listTemp = listPhong.Where(phong => phong.vitri.coso_id != null).ToList().Where(phong => phong.vitri.coso_id == GuidViTri).ToList();
                    break;
                case 2:
                    listTemp = listPhong.Where(phong => phong.vitri.day_id != null).ToList().Where(phong => phong.vitri.day_id == GuidViTri).ToList();
                    break;
                case 3:
                    listTemp = listPhong.Where(phong => phong.vitri.tang_id != null).ToList().Where(phong => phong.vitri.tang_id == GuidViTri).ToList();
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    break;
            }
            int index = listTemp.IndexOf(listTemp.Where(item => Object.Equals(item.id, GuidPhong)).FirstOrDefault());
            if (index != -1)
            {
                Page = index / _ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize + 1;
            }
            return Page;
        }
    }
}