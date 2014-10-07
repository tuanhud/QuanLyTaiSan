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
    }
}