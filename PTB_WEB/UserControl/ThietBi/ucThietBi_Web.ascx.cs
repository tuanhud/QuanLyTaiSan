using DevExpress.Web.ASPxTreeList;
using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.ThietBi
{
    public partial class ucThietBi_Web : System.Web.UI.UserControl
    {
        public Guid idThietBi = Guid.Empty;
        string key = "";
        string p1 = "Quản lý theo số lượng";
        string p2 = "Quản lý theo cá thể";
        string c1 = "Đang được sử dụng";
        string c2 = "Chưa được sử dụng";

        List<QuanLyTaiSan.Entities.ThietBi> listThietBi = new List<QuanLyTaiSan.Entities.ThietBi>();
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ucTreeViTri.Label_TenViTri.Text = "Thiết bị";
                _ucCollectionPager_DanhSachThietBi.ShowPanelPage(PanelChangePage);
            }
        }

        public void LoadData()
        {
            listThietBi = QuanLyTaiSan.Entities.ThietBi.getAll();
            if (listThietBi.Count > 0)
            {
                CreateNode();
                SearchFunction();
                if (Convert.ToString(Page.Session["ShowInfo"]) == "1")
                {
                    PanelChangePage.Visible = false;
                    Session["ShowInfo"] = null;
                }
                Panel_Chinh.Visible = true;
                if (Request.QueryString["key"] != null)
                {
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
                        _ucTreeViTri.FocusAndExpandToNode(node);
                        LoadFocusedNodeData();
                    }
                    else
                        Response.Redirect(Request.Url.AbsolutePath);
                    if (Request.QueryString["id"] != null)
                    {
                        idThietBi = Guid.Empty;
                        try
                        {
                            idThietBi = GUID.From(Request.QueryString["id"]);
                        }
                        catch
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                        objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(idThietBi);
                        if (objThietBi != null)
                        {
                            Panel_ThietBi.Visible = true;
                            Label_ThietBi.Visible = false;
                            Label_ThietBi.Text = "";
                            Label_ThongTinThietBi.Text = "Thông tin " + objThietBi.ten;
                            Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                            _ucASPxImageSlider_Web.urlHinhAnh = string.Format("http://{0}/HinhAnh.aspx?id={1}&type=THIETBI", HttpContext.Current.Request.Url.Authority, objThietBi.id);
                            Label_MaThietBi.Text = objThietBi.subId;
                            Session["TenThietBi"] = Label_TenThietBi.Text = objThietBi.ten;
                            Label_LoaiThietBi.Text = objThietBi.loaithietbi != null ? objThietBi.loaithietbi.ten : "";
                            Label_NgayMua.Text = objThietBi.ngaymua != null ? objThietBi.ngaymua.ToString() : "";
                            Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objThietBi.mota);
                        }
                        else
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                    }
                    else
                    {
                        Label_ThietBi.Visible = true;
                        Label_ThietBi.Text = "Chưa chọn thiết bị";
                    }
                }
                else
                {
                    DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                    node.Focus();
                    Label_TextDanhSachThietBi.Text = "Chưa chọn loại thiết bị";
                    Label_ThietBi.Visible = true;
                    Label_ThietBi.Text = "Chưa chọn thiết bị";
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có thiết bị";
            }
        }

        public void CreateNode()
        {
            List<Libraries.DrawTreeHelper.TreeThietBi> ListTreeThietBi = new List<Libraries.DrawTreeHelper.TreeThietBi>();
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("1", p1, null));
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("2", p2, null));
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("3", c1, "2"));
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("4", c2, "2"));
            _ucTreeViTri.ASPxTreeList_ViTri.DataSource = ListTreeThietBi;
            _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
        }

        private void LoadFocusedNodeData()
        {
            if (listThietBi.Count > 0)
            {
                if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && _ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id") != null)
                {
                    try
                    {
                        LoadDanhSachThietBi(Convert.ToInt32(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id").ToString()));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void LoadDanhSachThietBi(int loai)
        {
            List<QuanLyTaiSan.Entities.ThietBi> list = null;
            switch (loai)
            {
                case 1:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 2:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == false).ToList();
                    break;
                case 3:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                loaithietbi = item.loaithietbi != null ? item.loaithietbi.ten : "",
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.BindToControl = RepeaterThietBi;
            RepeaterThietBi.DataSource = _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.DataSourcePaged;
            RepeaterThietBi.DataBind();
            if (RepeaterThietBi.Items.Count == 0)
                Label_TextDanhSachThietBi.Text = "Chưa có thiết bị";
        }

        private void SearchFunction()
        {
            if (Request.QueryString["Search"] != null)
            {
                Guid SearchID = Guid.Empty;
                try
                {
                    SearchID = GUID.From(Request.QueryString["Search"]);
                }
                catch
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
                QuanLyTaiSan.Entities.ThietBi ThietBiSearch = listThietBi.Where(item => Object.Equals(item.id, SearchID)).FirstOrDefault();
                if (ThietBiSearch != null)
                {
                    if (ThietBiSearch.loaithietbi != null)
                    {
                        int key = 0;
                        if (ThietBiSearch.loaithietbi.loaichung)
                            key = 1;
                        else
                        {
                            if (ThietBiSearch.ctthietbis != null)
                            {
                                if (ThietBiSearch.ctthietbis.Count > 0)
                                {
                                    key = 3;
                                }
                                else
                                {
                                    key = 4;
                                }
                            }
                        }
                        int Page = SearchPage(ThietBiSearch.id, key);
                        if (Page != -1)
                        {
                            Session["ShowInfo"] = "1";
                            Response.Redirect(string.Format("{0}?key={1}&id={2}&Page={3}", Request.Url.AbsolutePath, key.ToString(), ThietBiSearch.id.ToString(), Page.ToString()));
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
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
                return;
            }
        }

        private int SearchPage(Guid GuidThietBiSearch, int key)
        {
            int Page = -1;
            List<QuanLyTaiSan.Entities.ThietBi> list = null;
            switch (key)
            {
                case 1:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 3:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
                    break;
                default:
                    return -1;
            }
            int index = list.IndexOf(list.Where(item => Object.Equals(item.id, GuidThietBiSearch)).FirstOrDefault());
            if (index != -1)
            {
                Page = index / _ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize + 1;
            }
            return Page;
        }
    }
}