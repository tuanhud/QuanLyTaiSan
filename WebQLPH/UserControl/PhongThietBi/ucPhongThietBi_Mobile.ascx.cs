using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.PhongThietBi
{
    public partial class ucPhongThietBi_Mobile : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<ChiTietTBHienThi> listThietBiCuaPhong = new List<ChiTietTBHienThi>();
        QuanLyTaiSan.Entities.Phong objPhong = null;
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;
        string key = "";

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
                    ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ASPxTreeList_ViTri.DataBind();
                    if (Request.QueryString["key"] != null)
                    {
                        key = "";
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
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(GUID.From(node.GetValue("id")));
                            if (objPhong != null)
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
                                    objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
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
                                    }
                                    else
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                }
                                else
                                {
                                    LoadDataObjPhong();
                                    Panel_DanhSachThietBi.Visible = true;
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
                        Panel_TreeListViTri.Visible = true;
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

        protected void ASPxTreeList_ViTri_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                e.Cell.Font.Bold = true;
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

        private void LoadDataObjPhong()
        {
            if (objPhong != null)
            {
                if (objPhong.vitri != null)
                {
                    if (objPhong.vitri.coso != null)
                    {
                        Label_DanhSachThietBiTitle.Text = string.Format("Danh sách thiết bị phòng {0} ({1}", objPhong.ten, objPhong.vitri.coso.ten);
                        if (objPhong.vitri.day != null)
                        {
                            Label_DanhSachThietBiTitle.Text += string.Format(" - {0}", objPhong.vitri.day.ten);
                            if (objPhong.vitri.tang != null)
                            {
                                Label_DanhSachThietBiTitle.Text += string.Format(" - {0})", objPhong.vitri.tang.ten);
                            }
                            else
                            {
                                Label_DanhSachThietBiTitle.Text += ")";
                            }
                        }
                        else
                        {
                            Label_DanhSachThietBiTitle.Text += ")";
                        }
                    }
                    else
                    {
                        Label_DanhSachThietBiTitle.Text = string.Format("Danh sách thiết bị phòng {0}", objPhong.ten);
                    }
                }
                else
                {
                    Label_DanhSachThietBiTitle.Text = string.Format("Danh sách thiết bị phòng {0}", objPhong.ten);
                }
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

        protected void ButtonBack_DanhSachThietBi_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void ButtonBack_ThietBi_Click(object sender, EventArgs e)
        {
            if (!key.Equals(""))
                Response.Redirect(QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "key", key, new List<string>(new string[] { "id" })).ToString());
            else
                Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}