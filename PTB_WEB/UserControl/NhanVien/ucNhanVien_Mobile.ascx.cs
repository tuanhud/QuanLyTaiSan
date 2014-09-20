using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTB.Entities;
using PTB.Libraries;

namespace PTB_WEB.UserControl.NhanVien
{
    public partial class ucNhanVien_Mobile : System.Web.UI.UserControl
    {
        List<NhanVienPT> listNhanVienPT = null;
        NhanVienPT objNhanVienPT = new NhanVienPT();

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
                if (Request.QueryString["id"] != null)
                {
                    Guid id = Guid.Empty;
                    try
                    {
                        id = GUID.From(Request.QueryString["id"]);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }

                    objNhanVienPT = NhanVienPT.getById(id);
                    if (objNhanVienPT != null)
                    {
                        PanelThongTinNhanVienPhuTrach.Visible = true;
                        Label_MaNhanVien.Text = objNhanVienPT.subId;
                        _ucNhanVien_BreadCrumb.Label_TenNhanVien.Text = Label_HoTen.Text = objNhanVienPT.hoten;
                        Label_SoDienThoai.Text = objNhanVienPT.sodienthoai;
                        Libraries.ImageHelper.LoadImageWeb(objNhanVienPT.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);

                        List<PTB.Entities.Phong> ListPhong = objNhanVienPT.phongs.ToList();

                        var list = ListPhong.Select(a => new
                        {
                            id = a.id,
                            ten = string.Format("{0}{1}", a.ten, !Object.Equals(getVitri(a), "") ? " " + getVitri(a) : ""),
                            url = string.Format("http://{0}/Phong.aspx?Search={1}", HttpContext.Current.Request.Url.Authority, a.id.ToString())
                        }).ToList();

                        _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = list;
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
                    PanelDanhSachNhanVienPhuTrach.Visible = true;
                    BindData();
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có nhân viên";
            }
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

        //protected void Button_Back_Click(object sender, EventArgs e)
        //{
        //    if (Request.QueryString[_ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.QueryStringKey] != null)
        //    {
        //        int Page = 1;
        //        try
        //        {
        //            Page = Convert.ToInt32(Request.QueryString[_ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.QueryStringKey].ToString());
        //        }
        //        catch
        //        {
        //            Response.Redirect(Request.Url.AbsolutePath);
        //        }
        //        Response.Redirect(string.Format(Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.AbsolutePath) + Request.Url.AbsolutePath.Length) + "?{0}={1}", _ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.QueryStringKey, Page.ToString()));
        //    }
        //    else
        //        Response.Redirect(Request.Url.AbsolutePath);
        //}

        public string getVitri(PTB.Entities.Phong _objPhong)
        {
            return Libraries.StringHelper.StringViTriPhong(_objPhong);
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