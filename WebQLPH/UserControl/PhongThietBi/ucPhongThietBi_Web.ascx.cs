using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using DevExpress.Web.ASPxEditors;

namespace WebQLPH.UserControl.PhongThietBi
{
    public partial class ucPhongThietBi_Web : System.Web.UI.UserControl
    {
        public int idThietBi = -1;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<ChiTietTBHienThi> listThietBiCuaPhong = new List<ChiTietTBHienThi>();
        QuanLyTaiSan.Entities.Phong objPhong = null;
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAllHavePhong();
            if (listViTriHienThi.Count > 0)
            {
                if (listViTriHienThi.Where(item => Object.Equals(item.loai, typeof(QuanLyTaiSan.Entities.Phong).Name)).FirstOrDefault() != null)
                {
                    Panel_Chinh.Visible = true;
                    ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ASPxTreeList_ViTri.DataBind();
                    if (Request.QueryString["key"] != null)
                    {
                        string key = "";
                        try
                        {
                            key = Request.QueryString["key"].ToString();
                        }
                        catch
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(Convert.ToInt32(node.GetValue("id").ToString()));
                            if (objPhong != null)
                            {
                                LoadDataObjPhong();
                                if (Request.QueryString["id"] != null)
                                {
                                    idThietBi = -1;
                                    try
                                    {
                                        idThietBi = Convert.ToInt32(Request.QueryString["id"].ToString());
                                    }
                                    catch
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                    objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(idThietBi);
                                    if (objThietBi != null)
                                    {
                                        Label_ThongTinThietBi.Text = string.Format("Thông tin {0}", objThietBi.ten);
                                        Panel_ThietBi.Visible = true;
                                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs.ToList(), ASPxImageSlider_ThietBi);
                                        TextBox_MaThietBi.Text = objThietBi.subId;
                                        TextBox_Ten.Text = objThietBi.ten;
                                        if (objThietBi.loaithietbi != null)
                                        {
                                            TextBox_LoaiThietBi.Text = objThietBi.loaithietbi.ten;
                                            if (objThietBi.loaithietbi.loaichung)
                                            {
                                                Panel_NgayMua.Visible = false;
                                                TextBox_NgayMua.Text = "";
                                                TextBox_KieuQuanLy.Text = "Theo số lượng";
                                            }
                                            else
                                            {
                                                Panel_NgayMua.Visible = true;
                                                TextBox_NgayMua.Text = objThietBi.ngaymua.ToString();
                                                TextBox_KieuQuanLy.Text = "Theo cá thể";
                                            }
                                        }
                                        else
                                        {
                                            TextBox_LoaiThietBi.Text = "[Loại thiết bị]";
                                            Panel_NgayMua.Visible = false;
                                            TextBox_NgayMua.Text = "";
                                            TextBox_KieuQuanLy.Text = "Chưa rõ";
                                        }
                                        TextBox_Phong.Text = objPhong.ten;
                                        TextBox_NgayLap.Text = objThietBi.ctthietbis != null ? objThietBi.ctthietbis.Where(item => item.phong_id == objPhong.id).FirstOrDefault().ngay.ToString() : "";
                                        TextBox_MoTa.Text = objThietBi.mota;
                                        Label_ThietBi.Visible = false;
                                        Label_ThietBi.Text = "";
                                    }
                                    else
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                }
                                else
                                {
                                    ClearData();
                                }
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
                    {
                        if (Object.Equals(ASPxTreeList_ViTri.FocusedNode.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                        {
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id").ToString()));
                            if (objPhong != null)
                            {
                                LoadDataObjPhong();
                                ClearData();
                            }
                            else
                            {
                                Response.Redirect("~/");
                            }
                        }
                        else
                        {
                            Label_DanhSachThietBi.Text = "Chưa chọn phòng";
                            ClearData();
                        }
                    }
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có phòng";
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có vị trí";
            }
        }

        private void LoadDataObjPhong()
        {
            if (objPhong != null)
            {
                listThietBiCuaPhong = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
                var bind = listThietBiCuaPhong.Select(a => new
                {
                    id = a.idTB,
                    ten = a.ten,
                    tinhtrang = a.tinhtrang,
                    soluong = a.soluong,
                    url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", a.idTB.ToString()),
                    urlLog = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri("http://" + Request.Url.Authority + "/" + ResolveClientUrl("~/LogThietBi.aspx")), "id", a.idTB.ToString())
                }).OrderBy(item => item.tinhtrang).ToList();
                CollectionPagerDanhSachThietBi.DataSource = bind;
                CollectionPagerDanhSachThietBi.BindToControl = RepeaterDanhSachThietBi;
                RepeaterDanhSachThietBi.DataSource = CollectionPagerDanhSachThietBi.DataSourcePaged;
                RepeaterDanhSachThietBi.DataBind();

                if (listThietBiCuaPhong != null)
                {
                    if (listThietBiCuaPhong.Count > 0)
                        Label_DanhSachThietBi.Text = string.Format("Danh sách thiết bị của {0}", objPhong.ten);
                    else
                        Label_DanhSachThietBi.Text = string.Format("{0} chưa có thiết bị", objPhong.ten);
                }
                else
                    Label_DanhSachThietBi.Text = string.Format("{0} chưa có thiết bị", objPhong.ten);
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        protected void ASPxTreeList_ViTri_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
            {
                if (Object.Equals(node.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                    e.Result = Request.Url.AbsolutePath + "?key=" + key;
                else
                    e.Result = "";
            }
            else
                e.Result = Request.Url.AbsolutePath;
        }

        protected void ASPxTreeList_ViTri_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                e.Cell.Font.Bold = true;
        }

        private void ClearData()
        {
            Label_ThongTinThietBi.Text = "Thông tin thiết bị";
            Panel_ThietBi.Visible = false;
            QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(null, ASPxImageSlider_ThietBi);
            TextBox_MaThietBi.Text = "";
            TextBox_Ten.Text = "";
            TextBox_LoaiThietBi.Text = "";
            TextBox_KieuQuanLy.Text = "Chưa rõ";
            TextBox_Phong.Text = "";
            Panel_NgayMua.Visible = false;
            TextBox_NgayMua.Text = "";
            TextBox_NgayLap.Text = "";
            TextBox_MoTa.Text = "";
            Label_ThietBi.Visible = true;
            Label_ThietBi.Text = "Chưa chọn thiết bị";
        }
    }
}