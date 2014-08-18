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
        public int id { get; set; }
        public Boolean check { get; set; }
        //public List<NhanVienPT> listNhanVienPT_Temp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadData()
        {
            if (!IsPostBack)
            {
                listNhanVienPT = NhanVienPT.getQuery().OrderBy(c => c.hoten).ToList();
                Panel_Chinh.Visible = true;
                if (listNhanVienPT != null && listNhanVienPT.Count > 0)
                {
                    CollectionPagerQuanLyNhanVien.DataSource = listNhanVienPT;
                    CollectionPagerQuanLyNhanVien.BindToControl = RepeaterQuanLyNhanVien;
                    RepeaterQuanLyNhanVien.DataSource = CollectionPagerQuanLyNhanVien.DataSourcePaged;
                    RepeaterQuanLyNhanVien.DataBind();
                    //listNhanVienPT_Temp = (List<NhanVienPT>)((object)CollectionPagerQuanLyNhanVien.DataSourcePaged);
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có nhân viên";
                    return;
                }

                if (Request.QueryString["id"] != null)
                {
                    id = -1;
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
                        check = true;
                        for (int i = 0; i < RepeaterQuanLyNhanVien.Items.Count; i++)
                        { 
                            
                        }
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
                        check = false;
                        PanelThongBao.Visible = true;
                        LabelThongBao.Text = "Không có nhân viên này";
                        DeleteForm();
                    }
                }
                else
                {
                    DeleteForm();
                }
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
    }
}