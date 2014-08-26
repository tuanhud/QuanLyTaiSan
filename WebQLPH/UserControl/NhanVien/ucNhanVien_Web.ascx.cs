using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.NhanVien
{
    public partial class ucNhanVien_Web : System.Web.UI.UserControl
    {
        List<NhanVienPT> listNhanVienPT = null;
        NhanVienPT objNhanVienPT = null;
        public int idNhanVien = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadData()
        {
            if (!IsPostBack)
            {
                listNhanVienPT = NhanVienPT.getQuery().OrderBy(c => c.hoten).ToList();
                if (listNhanVienPT == null || listNhanVienPT.Count == 0)
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có nhân viên";
                    return;
                }

                if (Request.QueryString["id"] != null)
                {
                    idNhanVien = -1;
                    try
                    {
                        idNhanVien = Int32.Parse(Request.QueryString["id"].ToString());
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }

                    objNhanVienPT = NhanVienPT.getById(idNhanVien);
                    if (objNhanVienPT != null)
                    {
                        Label_ThongTin.Text = String.Format("Thông tin {0}", objNhanVienPT.hoten);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objNhanVienPT.hinhanhs.ToList(), ASPxImageSlider_NhanVienPT);
                        TextBox_MaNhanVien.Text = objNhanVienPT.subId;
                        TextBox_HoTen.Text = objNhanVienPT.hoten;
                        TextBox_SoDienThoai.Text = objNhanVienPT.sodienthoai;

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
                    DeleteForm();
                }
                BindData();
                Panel_Chinh.Visible = true;
            }
        }

        private void DeleteForm()
        {
            QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(null, ASPxImageSlider_NhanVienPT);
            TextBox_MaNhanVien.Text = "";
            TextBox_HoTen.Text = "";
            TextBox_SoDienThoai.Text = "";
            CollectionPagerDanhSachPhong.DataSource = null;
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
                    url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", a.id.ToString(), new List<string>(new string[] { CollectionPagerDanhSachPhong.QueryStringKey })).ToString()
                }).ToList();
                CollectionPagerQuanLyNhanVien.DataSource = list;
                CollectionPagerQuanLyNhanVien.BindToControl = RepeaterQuanLyNhanVien;
                RepeaterQuanLyNhanVien.DataSource = CollectionPagerQuanLyNhanVien.DataSourcePaged;
                RepeaterQuanLyNhanVien.DataBind();
            }
        }
    }
}