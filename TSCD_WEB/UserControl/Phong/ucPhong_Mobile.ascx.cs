using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_WEB.UserControl.Phong
{
    public partial class ucPhong_Mobile : System.Web.UI.UserControl
    {
        public Guid idPhong = Guid.Empty;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<TSCD.Entities.Phong> listPhong = new List<TSCD.Entities.Phong>();
        TSCD.Entities.Phong objPhong = null;
        string key = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucTreeViTri.Label_TenViTri.Text = "Vị trí";
            }
        }

        public void LoadData()
        {
            listPhong = TSCD.Entities.Phong.getAll();
            if (listPhong.Count > 0)
            {
                TreeViTri.Visible = true;
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count > 0)
                {
                    ucTreeViTri.CreateTreeList();
                    ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                    SearchFunction();
                    if (Request.QueryString["key"] != null)
                    {
                        DanhSach.Visible = true;
                        TreeViTri.Visible = false;
                        key = "";
                        try
                        {
                            key = Request.QueryString["key"].ToString();
                        }
                        catch
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            string strViTri = "";
                            DevExpress.Web.ASPxTreeList.TreeListNode Pnode = node.ParentNode;
                            while (!Object.Equals(Pnode.Key, ""))
                            {
                                strViTri = " - " + Pnode.GetValue("ten").ToString() + strViTri;
                                Pnode = Pnode.ParentNode;
                            }
                            if (!Object.Equals(strViTri, ""))
                            {
                                strViTri = string.Format("({0})", strViTri.Substring(3));
                                ucPhong_BreadCrumb.Label_TenViTri.Text = node.GetValue("ten").ToString() + " " + strViTri;
                            }
                            else
                                ucPhong_BreadCrumb.Label_TenViTri.Text = node.GetValue("ten").ToString();
                            if (Request.QueryString["id"] != null)
                            {
                                ThongTin.Visible = true;
                                idPhong = Guid.Empty;
                                try
                                {
                                    idPhong = GUID.From(Request.QueryString["id"]);
                                }
                                catch
                                {
                                    Response.Redirect(Request.Url.AbsolutePath);
                                }
                                objPhong = TSCD.Entities.Phong.getById(idPhong);
                                if (objPhong != null)
                                {
                                    ucPhong_BreadCrumb.Label_TenPhong.Text = objPhong.ten;
                                    Label_MaPhong.Text = objPhong.subId;
                                    Label_TenPhong.Text = objPhong.ten;
                                    Label_LoaiPhong.Text = objPhong.loaiphong.ten;
                                    Label_ViTriPhong.Text = ViTriCuaPhong(objPhong);
                                    Label_MoTaPhong.Text = StringHelper.ConvertRNToBR(objPhong.mota);
                                }
                                else
                                {
                                    Response.Redirect(Request.Url.AbsolutePath);
                                }
                            }
                            LoadDanhSachPhong(GUID.From(node.GetValue("id")), node.GetValue("loai").ToString());
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    else
                    {
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                        node.Focus();
                    }
                }
                else
                {
                    KhongCoDuLieu.Visible = true;
                    ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có phòng";
                }
            }
            else
            {
                KhongCoDuLieu.Visible = true;
                ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có phòng";
            }
        }

        protected string ViTriCuaPhong(TSCD.Entities.Phong objPhong)
        {
            string _strtemp = "", _strCoSo, _strDay, _strTang;
            _strCoSo = objPhong.vitri.coso != null ? objPhong.vitri.coso.ten : "";
            _strDay = objPhong.vitri.day != null ? objPhong.vitri.day.ten : "";
            _strTang = objPhong.vitri.tang != null ? objPhong.vitri.tang.ten : "";

            if (!_strCoSo.Equals(""))
            {
                _strtemp += _strCoSo;
                if (!_strDay.Equals(""))
                {
                    _strtemp += " - " + _strDay;
                    if (!_strTang.Equals(""))
                    {
                        _strtemp += " - " + _strTang;
                    }
                }
            }
            return _strtemp == "" ? "[Không rõ]" : _strtemp;
        }

        private void LoadDanhSachPhong(Guid id, string type)
        {
            if (type.Equals(typeof(CoSo).Name))
            {
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.coso_id != null).ToList().Where(phong => phong.vitri.coso_id == id).ToList());
            }
            else if (type.Equals(typeof(Dayy).Name))
            {
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.day_id != null).ToList().Where(phong => phong.vitri.day_id == id).ToList());
            }
            else if (type.Equals(typeof(Tang).Name))
            {
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.tang_id != null).ToList().Where(phong => phong.vitri.tang_id == id).ToList());
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadDanhSachPhong(List<TSCD.Entities.Phong> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                ten = item.ten,
                loai=item.loaiphong.ten,
                url = StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
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
                TSCD.Entities.Phong PhongSearch = listPhong.Where(item => Object.Equals(item.id, SearchID)).FirstOrDefault();
                if (PhongSearch != null)
                {
                    Guid nodeGuid = Guid.Empty;
                    int type = 0;
                    if (PhongSearch.vitri != null)
                    {
                        if (PhongSearch.vitri.tang != null)
                        {
                            nodeGuid = PhongSearch.vitri.tang.id;
                            type = 3;
                        }
                        else if (PhongSearch.vitri.day != null)
                        {
                            nodeGuid = PhongSearch.vitri.day.id;
                            type = 2;
                        }
                        else if (PhongSearch.vitri.coso != null)
                        {
                            nodeGuid = PhongSearch.vitri.coso.id;
                            type = 1;
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    else
                        Response.Redirect(Request.Url.AbsolutePath);
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), nodeGuid.ToString())).FirstOrDefault();
                    if (node != null)
                    {
                        int Page = SearchPage(nodeGuid, PhongSearch.id, type);
                        if (Page != -1)
                        {
                            Response.Redirect(string.Format("{0}?key={1}&id={2}&Page={3}", Request.Url.AbsolutePath, node.Key.ToString(), PhongSearch.id.ToString(), Page.ToString()));
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
                    Response.Redirect(Request.Url.AbsolutePath);
            }
            else
            {
                return;
            }
        }

        private int SearchPage(Guid GuidViTri, Guid GuidPhong, int type)
        {
            int Page = -1;
            List<TSCD.Entities.Phong> listTemp = new List<TSCD.Entities.Phong>();
            switch (type)
            {
                case 1:
                    listTemp = listPhong.Where(phong => phong.vitri.coso_id != null).ToList().Where(phong => phong.vitri.coso_id == GuidViTri).ToList();
                    break;
                case 2:
                    listTemp = listPhong.Where(phong => phong.vitri.day_id != null).ToList().Where(phong => phong.vitri.day_id == GuidViTri).ToList();
                    break;
                case 3:
                    listTemp = listPhong.Where(phong => phong.vitri.tang_id != null).ToList().Where(phong => phong.vitri.tang_id == GuidViTri).ToList();
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    break;
            }
            int index = listTemp.IndexOf(listTemp.Where(item => Object.Equals(item.id, GuidPhong)).FirstOrDefault());
            if (index != -1)
            {
                Page = index / _ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize + 1;
            }
            return Page;
        }
    }
}