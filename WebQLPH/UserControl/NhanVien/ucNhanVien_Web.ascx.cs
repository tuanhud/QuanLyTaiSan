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
        NhanVienPT _NhanVienPT = null;
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
                        return;
                    }

                    _NhanVienPT = NhanVienPT.getById(idNhanVien);
                    if (_NhanVienPT != null)
                    {
                        Label_ThongTin.Text = String.Format("Thông tin {0}", _NhanVienPT.hoten);
                        PanelThongBao.Visible = false;
                        ImageSliderNhanVienPhuTrach.Items.Clear();
                        if (_NhanVienPT.hinhanhs != null && _NhanVienPT.hinhanhs.Count > 0)
                        {
                            foreach (HinhAnh hinhanh in _NhanVienPT.hinhanhs)
                            {
                                DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                                item.ImageUrl = hinhanh.getImageURL();
                                if (hinhanh.mota != null && hinhanh.mota.Length > 0)
                                    item.Text = hinhanh.mota;
                                else
                                    item.Text = hinhanh.FILE_NAME;
                                ImageSliderNhanVienPhuTrach.Items.Add(item);
                            }
                        }
                        else
                        {
                            DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                            item.ImageUrl = "~/Images/NoImage.jpg";
                            item.Text = "Không có ảnh";
                            ImageSliderNhanVienPhuTrach.Items.Add(item);
                        }
                        TextBox_MaNhanVien.Text = _NhanVienPT.subId;
                        TextBox_HoTen.Text = _NhanVienPT.hoten;
                        TextBox_SoDienThoai.Text = _NhanVienPT.sodienthoai;

                        CollectionPagerDanhSachPhong.DataSource = _NhanVienPT.phongs.ToList();
                        CollectionPagerDanhSachPhong.BindToControl = RepeaterDanhSachPhong;
                        RepeaterDanhSachPhong.DataSource = CollectionPagerDanhSachPhong.DataSourcePaged;
                        RepeaterDanhSachPhong.DataBind();
                    }
                    else
                    {
                        PanelThongBao.Visible = true;
                        LabelThongBao.Text = "Không có nhân viên này";
                        DeleteForm();
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
            ImageSliderNhanVienPhuTrach.Items.Clear();
            DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
            item.ImageUrl = "~/Images/NoImage.jpg";
            item.Text = "Không có ảnh";
            ImageSliderNhanVienPhuTrach.Items.Add(item);
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
                    url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", a.id.ToString(), new List<string>(new string[] { CollectionPagerQuanLyNhanVien.QueryStringKey })).ToString()
                }).ToList();
                CollectionPagerQuanLyNhanVien.DataSource = list;
                CollectionPagerQuanLyNhanVien.BindToControl = RepeaterQuanLyNhanVien;
                RepeaterQuanLyNhanVien.DataSource = CollectionPagerQuanLyNhanVien.DataSourcePaged;
                RepeaterQuanLyNhanVien.DataBind();
            }
        }
    }
}