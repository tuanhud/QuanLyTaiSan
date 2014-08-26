using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

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
                    int id = -1;
                    try
                    {
                        id = Int32.Parse(Request.QueryString["id"].ToString());
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                        return;
                    }

                    objNhanVienPT = NhanVienPT.getById(id);
                    if (objNhanVienPT != null)
                    {
                        PanelThongTinNhanVienPhuTrach.Visible = true;
                        Label_ThongTin.Text = String.Format("Thông tin {0}", objNhanVienPT.hoten);
                        TextBox_MaNhanVien.Text = objNhanVienPT.subId;
                        TextBox_HoTen.Text = objNhanVienPT.hoten;
                        TextBox_SoDienThoai.Text = objNhanVienPT.sodienthoai;
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