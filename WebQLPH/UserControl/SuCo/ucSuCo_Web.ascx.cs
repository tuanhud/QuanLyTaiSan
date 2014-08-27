using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl.SuCo
{
    public partial class ucSuCo_Web : System.Web.UI.UserControl
    {
        public int idSuCo = -1;
        List<SuCoPhong> listSuCoPhong = new List<SuCoPhong>();
        SuCoPhong objSuCoPhong = new SuCoPhong();

        public int idPhong = -1;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        QuanLyTaiSan.Entities.Phong objPhong = null;

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
                ASPxTreeList_ViTri.ExpandToLevel(1);

                if (Request.QueryString["key"] != null)
                {
                    try
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
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(idPhong);
                            if (objPhong != null)
                            {
                                LoadDataObjPhong();
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
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                        return;
                    }
                }
                else
                {
                    LoadFocusedNodeData();
                }

                if (Request.QueryString["id"] != null)
                {
                    idSuCo = -1;
                    try
                    {
                        idSuCo = Int32.Parse(Request.QueryString["id"].ToString());
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                        return;
                    }
                    objSuCoPhong = QuanLyTaiSan.Entities.SuCoPhong.getById(idSuCo);
                    if (objSuCoPhong != null)
                    {
                        Panel_SuCo.Visible = true;
                        Label_SuCo.Visible = false;
                        PanelThongBao_SuCo.Visible = false;
                        Label_ThongTinSuCo.Text = "Thông tin " + objSuCoPhong.ten;
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objSuCoPhong.hinhanhs.ToList(), ASPxImageSlider_SuCo);
                        Session["TenSuCo"] = Label_TenSuCo.Text = objSuCoPhong.ten;
                        Label_TinhTrang.Text = objSuCoPhong.tinhtrang.value;
                        Label_NgayTao.Text = ((DateTime)objSuCoPhong.date_create).ToString();
                        Label_MoTa.Text = QuanLyTaiSan.Libraries.StringHelper.ConvertRNToBR(objSuCoPhong.mota);
                    }
                    else
                    {
                        ClearData();
                        PanelThongBao_SuCo.Visible = true;
                        LabelThongBao_SuCo.Text = "Không có sự cố này";
                    }
                }
                else
                {
                    Label_ThongBao.Text = "Chưa chọn sự cố";
                }

            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có vị trí";
            }
        }

        private void ClearData()
        {
            Label_ThongTinSuCo.Text = "";
            
            Label_TenSuCo.Text = "";
            Label_TinhTrang.Text = "";
            Label_NgayTao.Text = "";
            Label_MoTa.Text = "";
        }

        private void LoadFocusedNodeData()
        {
            
        }

        private bool FindNodeTreeList(string key)
        {
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
            {
                idPhong = Convert.ToInt32(node.GetValue("id").ToString());
                node.Focus();
                return true;
            }
            return false;
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

        protected void ASPxTreeList_ViTri_FocusedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void ASPxTreeList_ViTri_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                e.Cell.Font.Bold = true;
        }
        private void LoadDataObjPhong()
        {
            if (objPhong != null)
            {
                Session["TenPhong"] = objPhong.ten;
                listSuCoPhong = objPhong.sucophongs.OrderByDescending(c => c.ngay).ToList();
                var bind = listSuCoPhong.Select(item => new
                {
                    id = item.id,
                    ten = item.ten,
                    tinhtrang = item.tinhtrang.mota,
                    mota = item.mota,
                    ngay = item.ngay,
                    url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
                }).ToList();
                CollectionPagerDanhSachSuCo.DataSource = bind;
                CollectionPagerDanhSachSuCo.BindToControl = RepeaterSuCo;
                RepeaterSuCo.DataSource = CollectionPagerDanhSachSuCo.DataSourcePaged;
                RepeaterSuCo.DataBind();

                if (listSuCoPhong != null)
                {
                    if (listSuCoPhong.Count > 0)
                        Label_SuCo.Text = string.Format("Danh sách sự cố của {0}", objPhong.ten);
                    else
                        Label_SuCo.Text = string.Format("{0} chưa có sự cố", objPhong.ten);
                }
                else
                    Label_SuCo.Text = string.Format("{0} chưa có sự cố", objPhong.ten);
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }
    }
}