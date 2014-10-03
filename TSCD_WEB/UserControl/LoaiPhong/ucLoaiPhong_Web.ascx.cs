﻿using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB.UserControl.LoaiPhong
{
    public partial class ucLoaiPhong_Web : System.Web.UI.UserControl
    {
        public Guid idPhong = Guid.Empty;
        List<TSCD.Entities.LoaiPhong> listLoaiPhong = new List<TSCD.Entities.LoaiPhong>();
        List<TSCD.Entities.Phong> listPhong = new List<TSCD.Entities.Phong>();
        public TSCD.Entities.Phong objPhong = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DevExpress.Web.ASPxTreeList.TreeListTextColumn _TreeListTextColumn = new DevExpress.Web.ASPxTreeList.TreeListTextColumn();
                _ucTreeViTri.Label_TenViTri.Text = "Loại phòng";
            }
        }
        public void LoadData()
        {
            listPhong = TSCD.Entities.Phong.getAll();
            if (listPhong.Count > 0)
            {
                infotr.Visible = true;
                listLoaiPhong = TSCD.Entities.LoaiPhong.getAll();
                if (listLoaiPhong.Count > 0)
                {
                    _ucTreeViTri.CreateTreeList();
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listLoaiPhong;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                    SearchFunction();
                    if (Convert.ToString(Page.Session["ShowInfo"]) == "1")
                    {
                        PanelChangePage.Visible = false;
                        Session["ShowInfo"] = null;
                    }
                    else
                    {
                        _ucCollectionPager_DanhSachPhong.ShowPanelPage(PanelChangePage);
                    }
                    if (Request.QueryString["key"] != null)
                    {
                        infotd.Visible = true;
                        string key = "";
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
                            ThongTinPhong.Visible = true;
                            thongtin.Visible = true;
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
                                Label_ThongTinPhong.Text = "Thông tin phòng " + objPhong.ten;
                                Label_MaPhong.Text = objPhong.subId;
                                ucLoaiPhong_BreadCrumb.Label_TenPhong.Text = Label_TenPhong.Text = objPhong.ten;
                                Label_LoaiPhong.Text = objPhong.loaiphong.ten;
                                Label_ViTriPhong.Text = ViTriCuaPhong(objPhong);
                                Label_MoTaPhong.Text = StringHelper.ConvertRNToBR(objPhong.mota);
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
                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                        node.Focus();
                        ChuaChonViTri.Visible = true;
                        ucWarning_ChuaChonViTri.LabelInfo.Text = "Chưa chọn vị trí";
                        ClearData();
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

        private void LoadFocusedNodeData()
        {
            if (listLoaiPhong.Count > 0)
            {
                if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    Guid _id = GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id"));
                    TSCD.Entities.LoaiPhong objLoaiPhong = new TSCD.Entities.LoaiPhong();
                    objLoaiPhong = TSCD.Entities.LoaiPhong.getById(_id);
                    ucLoaiPhong_BreadCrumb.Label_TenLoaiPhong.Text = objLoaiPhong.ten;
                    LoadDanhSachPhong(listPhong.Where(phong => phong.loaiphong.id != null).ToList().Where(phong => phong.loaiphong.id == _id).ToList());
                    ClearData();
                }
                else
                    Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadDanhSachPhong(List<TSCD.Entities.Phong> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                loai = item.loaiphong.ten,
                vitri = ViTriCuaPhong(item),
                url = StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
            if (RepeaterDanhSachPhong.Items.Count == 0)
            {
                KhongCoDuLieu.Visible = true;
                ucDanger_KhongCoDuLieu.LabelInfo.Text = "Vị trí này chưa có phòng";
            }
        }

        private void ClearData()
        {
            Label_ThongTinPhong.Text = "Thông tin phòng";
            Label_MaPhong.Text = "";
            Label_TenPhong.Text = "";
            Label_ViTriPhong.Text = "";
            Label_MoTaPhong.Text = "";
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
                    DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), nodeGuid.ToString())).FirstOrDefault();
                    if (node != null)
                    {
                        int Page = SearchPage(nodeGuid, PhongSearch.id, type);
                        if (Page != -1)
                        {
                            Session["ShowInfo"] = "1";
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