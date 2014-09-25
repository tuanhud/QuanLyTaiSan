using DevExpress.Web.ASPxTreeList;
using PTB.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTB.Libraries;

namespace PTB_WEB.UserControl.ThietBi
{
    public partial class ucThietBi_Mobile : System.Web.UI.UserControl
    {
        Guid idThietBi = Guid.Empty;
        string key = "";
        string p1 = "Thiết bị quản lý theo số lượng";
        string p2 = "Thiết bị quản lý theo cá thể";
        string c1 = "Thiết bị đang được sử dụng";
        string c2 = "Thiết bị chưa được sử dụng";

        List<PTB.Entities.ThietBi> listThietBi = new List<PTB.Entities.ThietBi>();
        PTB.Entities.ThietBi objThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ucTreeViTri.Label_TenViTri.Text = "Thiết bị";
            }
        }

        public void LoadData()
        {
            listThietBi = PTB.Entities.ThietBi.getAll();
            if (listThietBi.Count > 0)
            {
                CreateNode();
                SearchFunction();
                if (Request.QueryString["key"] != null)
                {
                    try
                    {
                        key = Request.QueryString["key"].ToString();
                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            LoadFocusedNodeData();
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                    node.Focus();
                    Label_TextDanhSachThietBi.Text = "Chưa chọn loại thiết bị";
                }

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
                        return;
                    }
                    objThietBi = PTB.Entities.ThietBi.getById(idThietBi);
                    if (objThietBi != null)
                    {
                        Panel_ThongTinObj.Visible = true;
                        Panel_TreeList.Visible = false;
                        Label_ThongTinThietBi.Text = "Thông tin " + objThietBi.ten;
                        Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);
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
                    Panel_TreeList.Visible = true;
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có thiết bị";
            }
        }

        private Boolean FindNodeTreeList(string key)
        {
            DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
            {
                node.Focus();
                return true;
            }
            return false;
        }

        public void CreateNode()
        {
            List<Libraries.DrawTreeHelper.TreeThietBi> ListTreeThietBi = new List<Libraries.DrawTreeHelper.TreeThietBi>();
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("1", p1, null));
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("2", p2, null));
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("3", c1, "2"));
            ListTreeThietBi.Add(new Libraries.DrawTreeHelper.TreeThietBi("4", c2, "2"));
            _ucTreeViTri.CreateTreeList();
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
            List<PTB.Entities.ThietBi> list = null;
            switch (loai)
            {
                case 1:
                    list = PTB.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 2:
                    list = PTB.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == false).ToList();
                    break;
                case 3:
                    list = PTB.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    list = PTB.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
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

        protected void ASPxTreeList_ThietBi_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
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
                PTB.Entities.ThietBi ThietBiSearch = listThietBi.Where(item => Object.Equals(item.id, SearchID)).FirstOrDefault();
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
            List<PTB.Entities.ThietBi> list = null;
            switch (key)
            {
                case 1:
                    list = PTB.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 3:
                    list = PTB.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    list = PTB.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
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