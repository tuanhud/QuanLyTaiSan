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
        NhanVienPT _NhanVienPT = new NhanVienPT();

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
                        Response.Redirect("~/NhanVien.aspx");
                        return;
                    }

                    _NhanVienPT = NhanVienPT.getById(id);
                    if (_NhanVienPT != null)
                    {
                        PanelThongTinNhanVienPhuTrach.Visible = true;
                        Label_ThongTin.Text = String.Format("Thông tin {0}", _NhanVienPT.hoten);
                        TextBox_MaNhanVien.Text = _NhanVienPT.subId;
                        TextBox_HoTen.Text = _NhanVienPT.hoten;
                        TextBox_SoDienThoai.Text = _NhanVienPT.sodienthoai;
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
                        CollectionPagerDanhSachPhong.DataSource = _NhanVienPT.phongs.ToList();
                        CollectionPagerDanhSachPhong.BindToControl = RepeaterDanhSachPhong;
                        RepeaterDanhSachPhong.DataSource = CollectionPagerDanhSachPhong.DataSourcePaged;
                        RepeaterDanhSachPhong.DataBind();
                    }
                    else
                    {
                        PanelThongBao.Visible = true;
                        LabelThongBao.Text = "Không có nhân viên này";
                    }
                }
                else
                {
                    listNhanVienPT = NhanVienPT.getQuery().OrderBy(c => c.hoten).ToList();
                    PanelDanhSachNhanVienPhuTrach.Visible = true;
                    CollectionPagerQuanLyNhanVien.DataSource = listNhanVienPT;
                    CollectionPagerQuanLyNhanVien.BindToControl = RepeaterQuanLyNhanVien;
                    RepeaterQuanLyNhanVien.DataSource = CollectionPagerQuanLyNhanVien.DataSourcePaged;
                    RepeaterQuanLyNhanVien.DataBind();
                }
            }
        }
    }
}