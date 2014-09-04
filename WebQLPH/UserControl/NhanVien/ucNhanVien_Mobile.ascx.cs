using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.NhanVien
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
            if (!IsPostBack)
            {
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
                        Panel_Chinh.Visible = true;
                        PanelThongTinNhanVienPhuTrach.Visible = true;
                        Label_ThongTin.Text = String.Format("Thông tin {0}", objNhanVienPT.hoten);
                        Label_MaNhanVien.Text = objNhanVienPT.subId;
                        _ucNhanVien_BreadCrumb.Label_TenNhanVien.Text = Label_HoTen.Text = objNhanVienPT.hoten;
                        Label_SoDienThoai.Text = objNhanVienPT.sodienthoai;
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objNhanVienPT.hinhanhs.ToList(), ASPxImageSlider_NhanVienPT);
                        CollectionPagerDanhSachPhong.DataSource = objNhanVienPT.phongs.ToList();
                        CollectionPagerDanhSachPhong.BindToControl = RepeaterDanhSachPhong;
                        RepeaterDanhSachPhong.DataSource = CollectionPagerDanhSachPhong.DataSourcePaged;
                        RepeaterDanhSachPhong.DataBind();
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    listNhanVienPT = NhanVienPT.getQuery().OrderBy(c => c.hoten).ToList();
                    if (listNhanVienPT != null && listNhanVienPT.Count > 0)
                    {
                        Panel_Chinh.Visible = true;
                        PanelDanhSachNhanVienPhuTrach.Visible = true;
                        BindData();
                    }
                    else
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = "Chưa có nhân viên";
                        return;
                    }
                }
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
                    url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", a.id.ToString(), new List<string>(new string[] { CollectionPagerDanhSachPhong.QueryStringKey })).ToString()
                }).ToList();
                CollectionPagerQuanLyNhanVien.DataSource = list;
                CollectionPagerQuanLyNhanVien.BindToControl = RepeaterQuanLyNhanVien;
                RepeaterQuanLyNhanVien.DataSource = CollectionPagerQuanLyNhanVien.DataSourcePaged;
                RepeaterQuanLyNhanVien.DataBind();
            }
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}