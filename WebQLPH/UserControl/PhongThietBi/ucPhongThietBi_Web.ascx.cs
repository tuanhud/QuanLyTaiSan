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
        public int idPhong = -1;
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
                    if (FindNodeTreeList(key))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            int idPhong = -1;
                            try
                            {
                                idPhong = Int32.Parse(Request.QueryString["id"].ToString());
                            }
                            catch
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(idPhong);
                            if (objPhong != null)
                            {
                                LoadDataObjPhong();
                                if (Request.QueryString["idTB"] != null)
                                {
                                    int idTB = -1;
                                    try
                                    {
                                        idTB = Int32.Parse(Request.QueryString["idTB"].ToString());
                                    }
                                    catch
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                    objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(idTB);
                                    if (objThietBi != null)
                                    {

                                    }
                                    else
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
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
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có phòng";
            }
        }

        private void LoadDataObjPhong()
        {
            if (objPhong != null)
            {
                listThietBiCuaPhong = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
                var bind = listThietBiCuaPhong.Select(a => new
                {
                    id = a.id,
                    ten = a.ten,
                    subId = a.subId,
                    tenloai = a.tenloai,
                    tinhtrang = a.tinhtrang,
                    soluong = a.soluong,
                    kieuQL = a.kieuQL,
                    url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idTB", a.id.ToString())
                }).ToList();
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
                    e.Result = Request.Url.AbsolutePath + "?key=" + key + "&id=" + node.GetValue("id").ToString();
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

        private Boolean FindNodeTreeList(string key)
        {
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
            {
                node.Focus();
                return true;
            }
            return false;
        }
    }
}