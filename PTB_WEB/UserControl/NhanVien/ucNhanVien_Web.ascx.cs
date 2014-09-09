using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.NhanVien
{
    public partial class ucNhanVien_Web : System.Web.UI.UserControl
    {
        List<NhanVienPT> listNhanVienPT = null;
        NhanVienPT objNhanVienPT = null;
        public Guid idNhanVien = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.QueryStringKey = "PageRoom";
            listNhanVienPT = NhanVienPT.getQuery().OrderBy(c => c.hoten).ToList();
            if (listNhanVienPT.Count > 0)
            {
                SearchFunction();
                Panel_Chinh.Visible = true;
                BindData();

                if (Request.QueryString["id"] != null)
                {
                    idNhanVien = Guid.Empty;
                    try
                    {
                        idNhanVien = GUID.From(Request.QueryString["id"]);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }

                    objNhanVienPT = NhanVienPT.getById(idNhanVien);
                    if (objNhanVienPT != null)
                    {
                        Panel_NhanVienPT.Visible = true;
                        Label_NhanVienPT.Visible = false;
                        Label_NhanVienPT.Text = "";
                        Label_ThongTin.Text = String.Format("Thông tin {0}", objNhanVienPT.hoten);
                        Libraries.ImageHelper.LoadImageWeb(objNhanVienPT.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                        Label_MaNhanVien.Text = objNhanVienPT.subId;
                        _ucNhanVien_BreadCrumb.Label_TenNhanVien.Text = Label_HoTen.Text = objNhanVienPT.hoten;
                        Label_SoDienThoai.Text = objNhanVienPT.sodienthoai;
                        _ucASPxImageSlider_Web.urlHinhAnh = string.Format("http://{0}/HinhAnh.aspx?id={1}&type=NHANVIEN", HttpContext.Current.Request.Url.Authority, objNhanVienPT.id);

                        _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = objNhanVienPT.phongs.ToList();
                        _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
                        RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
                        RepeaterDanhSachPhong.DataBind();
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    DeleteForm();
                    Panel_NhanVienPT.Visible = false;
                    Label_NhanVienPT.Visible = true;
                    Label_NhanVienPT.Text = "Chưa chọn nhân viên";
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có nhân viên";
            }
        }

        private void DeleteForm()
        {
            Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Web.ASPxImageSlider_Object);
            Label_MaNhanVien.Text = "";
            Label_HoTen.Text = "";
            Label_SoDienThoai.Text = "";
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = null;
            RepeaterDanhSachPhong.DataSource = null;
        }

        private void BindData()
        {
            if (listNhanVienPT != null && listNhanVienPT.Count > 0)
            {
                var list = listNhanVienPT.Select(a => new
                {
                    id = a.id,
                    subid = a.subId,
                    hoten = a.hoten,
                    sodienthoai = a.sodienthoai,
                    url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", a.id.ToString(), new List<string>(new string[] { _ucCollectionPager_DanhSachPhong.CollectionPager_Object.QueryStringKey })).ToString()
                }).ToList();
                _ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.DataSource = list;
                _ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.BindToControl = RepeaterDanhSachNhanVien;
                RepeaterDanhSachNhanVien.DataSource = _ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.DataSourcePaged;
                RepeaterDanhSachNhanVien.DataBind();
            }
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
                int index = listNhanVienPT.IndexOf(listNhanVienPT.Where(item => Object.Equals(item.id, SearchID)).FirstOrDefault());
                if (index != -1)
                {
                    int Page = index / _ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.PageSize + 1;
                    Response.Redirect(string.Format("{0}?id={1}&Page={2}", Request.Url.AbsolutePath, SearchID.ToString(), Page.ToString()));
                }
                else
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
            }
            else
            {
                return;
            }
        }
    }
}