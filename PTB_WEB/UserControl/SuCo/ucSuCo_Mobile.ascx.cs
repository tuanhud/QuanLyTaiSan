using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

namespace PTB_WEB.UserControl.SuCo
{
    public partial class ucSuCo_Mobile : System.Web.UI.UserControl
    {
        public Guid idSuCo = Guid.Empty;
        List<SuCoPhong> listSuCoPhong = new List<SuCoPhong>();
        SuCoPhong objSuCoPhong = new SuCoPhong();
        string key = "";

        public Guid idPhong = Guid.Empty;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        QuanLyTaiSan.Entities.Phong objPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ucTreeViTri.Label_TenViTri.Text = "Chọn phòng";
            }
            _ucTreeViTri.NotFocusOnCreated();
            _ucTreeViTri.ASPxTreeList_ViTri.CustomDataCallback += new DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventHandler(this.ASPxTreeList_ViTri_CustomDataCallback);
            _ucTreeViTri.ASPxTreeList_ViTri.HtmlDataCellPrepared += new DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventHandler(this.ASPxTreeList_ViTri_HtmlDataCellPrepared);
        }

        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAllHavePhong();
            if (listViTriHienThi.Count > 0)
            {
                if (listViTriHienThi.Where(item => Object.Equals(item.loai, typeof(QuanLyTaiSan.Entities.Phong).Name)).FirstOrDefault() != null)
                {
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
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
                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            objPhong = QuanLyTaiSan.Entities.Phong.getById(GUID.From(node.GetValue("id")));
                            if (objPhong != null)
                            {
                                if (Request.QueryString["id"] != null)
                                {
                                    idSuCo = Guid.Empty;
                                    try
                                    {
                                        idSuCo = GUID.From(Request.QueryString["id"]);
                                    }
                                    catch
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                    objSuCoPhong = QuanLyTaiSan.Entities.SuCoPhong.getById(idSuCo);
                                    if (objSuCoPhong != null)
                                    {
                                        Panel_SuCo.Visible = true;
                                        Label_ThongTinSuCo.Text = "Thông tin " + objSuCoPhong.ten;
                                        Libraries.ImageHelper.LoadImageWeb(objSuCoPhong.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);
                                        Session["TenSuCo"] = Label_TenSuCo.Text = objSuCoPhong.ten;
                                        Label_TinhTrang.Text = objSuCoPhong.tinhtrang != null ? objSuCoPhong.tinhtrang.value : "[Tình trạng]";
                                        Label_NgayTao.Text = ((DateTime)objSuCoPhong.date_create).ToString();
                                        Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objSuCoPhong.mota);
                                        Button_XemLog.OnClientClick = string.Format("location.href='{0}'; return false;", Libraries.StringHelper.AddParameter(new Uri("http://" + Request.Url.Authority + "/" + ResolveClientUrl("~/LogSuCo.aspx")), "id", idSuCo.ToString()));
                                    }
                                    else
                                    {
                                        Response.Redirect(Request.Url.AbsolutePath);
                                    }
                                }
                                else
                                {
                                    LoadDataObjPhong();
                                    Panel_DanhSachSuCo.Visible = true;
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
                        Panel_TreeViTri.Visible = true;
                    }
                }
                else
                {
                    ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                    ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có phòng";
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có vị trí";
            }
        }

        private void ASPxTreeList_ViTri_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlDataCellEventArgs e)
        {
            if (Object.Equals(e.GetValue("loai"), typeof(QuanLyTaiSan.Entities.Phong).Name))
                e.Cell.Font.Bold = true;
        }

        private void ASPxTreeList_ViTri_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
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
                string strViTri = Libraries.StringHelper.StringViTriPhong(objPhong);
                Session["TenPhong"] = !Object.Equals(strViTri, "") ? objPhong.ten + " " + strViTri : objPhong.ten;
                if (objPhong.vitri != null)
                {
                    if (objPhong.vitri.coso != null)
                    {
                        Label_DanhSachSuCoTitle.Text = string.Format("Danh sách sự cố phòng {0} ({1}", objPhong.ten, objPhong.vitri.coso.ten);
                        if (objPhong.vitri.day != null)
                        {
                            Label_DanhSachSuCoTitle.Text += string.Format(" - {0}", objPhong.vitri.day.ten);
                            if (objPhong.vitri.tang != null)
                            {
                                Label_DanhSachSuCoTitle.Text += string.Format(" - {0})", objPhong.vitri.tang.ten);
                            }
                            else
                            {
                                Label_DanhSachSuCoTitle.Text += ")";
                            }
                        }
                        else
                        {
                            Label_DanhSachSuCoTitle.Text += ")";
                        }
                    }
                    else
                    {
                        Label_DanhSachSuCoTitle.Text = string.Format("Danh sách sự cố phòng {0}", objPhong.ten);
                    }
                }
                else
                {
                    Label_DanhSachSuCoTitle.Text = string.Format("Danh sách sự cố phòng {0}", objPhong.ten);
                }
                listSuCoPhong = objPhong.sucophongs.OrderByDescending(c => c.ngay).ToList();
                var bind = listSuCoPhong.Select(item => new
                {
                    id = item.id,
                    ten = item.ten,
                    tinhtrang = item.tinhtrang.value,
                    mota = item.mota,
                    ngay = item.ngay,
                    url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString(),
                    urlLog = Libraries.StringHelper.AddParameter(new Uri("http://" + Request.Url.Authority + "/" + ResolveClientUrl("~/LogSuCo.aspx")), "id", item.id.ToString())
                }).ToList();
                _ucCollectionPager_DanhSachSuCo.CollectionPager_Object.DataSource = bind;
                _ucCollectionPager_DanhSachSuCo.CollectionPager_Object.BindToControl = RepeaterSuCo;
                RepeaterSuCo.DataSource = _ucCollectionPager_DanhSachSuCo.CollectionPager_Object.DataSourcePaged;
                RepeaterSuCo.DataBind();

                if (listSuCoPhong != null)
                {
                    if (listSuCoPhong.Count == 0)
                        Label_DanhSachSuCo.Text = string.Format("{0} chưa có sự cố", objPhong.ten);
                }
                else
                    Label_DanhSachSuCo.Text = string.Format("{0} chưa có sự cố", objPhong.ten);
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }
    }
}