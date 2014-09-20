using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTB.DataFilter;
using PTB.Entities;
using PTB.Libraries;

namespace PTB_WEB.UserControl.Phong
{
    public partial class ucPhong_Mobile : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<PTB.Entities.Phong> listPhong = new List<PTB.Entities.Phong>();
        PTB.Entities.Phong objPhong = null;
        string key = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ucTreeViTri.Label_TenViTri.Text = "Chọn vị trí cần xem";
            }
            _ucTreeViTri.NotFocusOnCreated();
        }

        public void LoadData()
        {
            listPhong = PTB.Entities.Phong.getAll();
            if (listPhong.Count > 0)
            {
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count > 0)
                {
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                    SearchFunction();
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
                                Guid idPhong = Guid.Empty;
                                try
                                {
                                    idPhong = GUID.From(Request.QueryString["id"]);
                                }
                                catch
                                {
                                    Response.Redirect(Request.Url.AbsolutePath);
                                }
                                objPhong = PTB.Entities.Phong.getById(idPhong);
                                if (objPhong != null)
                                {
                                    ucPhong_BreadCrumb.Label_TenPhong.Text = objPhong.ten;
                                    Panel_ThongTinPhong.Visible = true;
                                    Libraries.ImageHelper.LoadImageWeb(objPhong.hinhanhs.ToList(), _ucASPxImageSlider_Mobile_Phong.ASPxImageSlider_Object);
                                    Label_MaPhong.Text = objPhong.subId;
                                    Label_TenPhong.Text = objPhong.ten;
                                    string strCoSo, strDay, strTang;
                                    strCoSo = objPhong.vitri.coso != null ? objPhong.vitri.coso.ten : "";
                                    strDay = objPhong.vitri.day != null ? objPhong.vitri.day.ten : "";
                                    strTang = objPhong.vitri.tang != null ? objPhong.vitri.tang.ten : "";
                                    if (!strCoSo.Equals(""))
                                    {
                                        Label_ViTriPhong.Text += strCoSo;
                                        if (!strDay.Equals(""))
                                        {
                                            Label_ViTriPhong.Text += " - " + strDay;
                                            if (!strTang.Equals(""))
                                            {
                                                Label_ViTriPhong.Text += " - " + strTang;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Label_ViTriPhong.Text = "[Không rõ]";
                                    }
                                    Label_MoTaPhong.Text = Libraries.StringHelper.ConvertRNToBR(objPhong.mota);
                                    Label_NhanVienPhuTrach.Text = objPhong.nhanvienpt != null ? objPhong.nhanvienpt.hoten : "";

                                    if (objPhong.nhanvienpt != null)
                                    {
                                        Panel_NhanVienPT.Visible = true;
                                        Label_NhanVienPT.Visible = false;
                                        Label_NhanVienPT.Text = "";
                                        Libraries.ImageHelper.LoadImageWeb(objPhong.nhanvienpt.hinhanhs.ToList(), _ucASPxImageSlider_Mobile_NhanVienPT.ASPxImageSlider_Object);
                                        Label_MaNhanVien.Text = objPhong.nhanvienpt.subId;
                                        Label_HoTen.Text = objPhong.nhanvienpt.hoten;
                                        Label_SoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                                    }
                                    else
                                    {
                                        Panel_NhanVienPT.Visible = false;
                                        Label_NhanVienPT.Visible = true;
                                        Label_NhanVienPT.Text = "Phòng này chưa có nhân viên phụ trách";
                                        Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Mobile_NhanVienPT.ASPxImageSlider_Object);
                                        Label_MaNhanVien.Text = "";
                                        Label_HoTen.Text = "";
                                        Label_SoDienThoai.Text = "";
                                    }
                                }
                                else
                                {
                                    Response.Redirect(Request.Url.AbsolutePath);
                                }
                            }
                            else
                            {
                                LoadDanhSachPhong(GUID.From(node.GetValue("id")), node.GetValue("loai").ToString());
                                Panel_DanhSachPhong.Visible = true;
                            }
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    else
                    {
                        Panel_TreeListViTri.Visible = true;
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
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có phòng";
            }
        }

        private void LoadDanhSachPhong(Guid id, string type)
        {
            if (type.Equals(typeof(CoSo).Name))
            {
                //CoSo objCoso = CoSo.getById(id);
                //if (objCoso != null)
                //    Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0})", objCoso.ten);
                //else
                //    Response.Redirect(Request.Url.AbsolutePath);
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.coso_id != null).ToList().Where(phong => phong.vitri.coso_id == id).ToList());
            }
            else if (type.Equals(typeof(Dayy).Name))
            {
                //Dayy objDay = Dayy.getById(id);
                //if (objDay != null)
                //    Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0} - {1})", objDay.coso != null ? objDay.coso.ten : "[Cơ sở]", objDay.ten);
                //else
                //    Response.Redirect(Request.Url.AbsolutePath);
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.day_id != null).ToList().Where(phong => phong.vitri.day_id == id).ToList());
            }
            else if (type.Equals(typeof(Tang).Name))
            {
                //Tang objTang = Tang.getById(id);
                //if (objTang != null)
                //{
                //    if (objTang.day != null)
                //    {
                //        Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0} - {1} - {2})", objTang.day.coso != null ? objTang.day.coso.ten : "[Cơ sở]", objTang.day.ten, objTang.ten);
                //    }
                //    else
                //    {
                //        Label_DanhSachPhong.Text = string.Format("Danh sách phòng ([Cơ sở] - [Dãy] - {0})", objTang.ten);
                //    }
                //}
                //else
                //    Response.Redirect(Request.Url.AbsolutePath);
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.tang_id != null).ToList().Where(phong => phong.vitri.tang_id == id).ToList());
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadDanhSachPhong(List<PTB.Entities.Phong> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                nhanvienpt = item.nhanvienpt != null ? item.nhanvienpt.hoten : "",
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
        }

        //protected void ButtonBack_ThongTinPhong_Click(object sender, EventArgs e)
        //{
        //    if (!key.Equals(""))
        //        Response.Redirect(Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "key", key, new List<string>(new string[] { "id" })).ToString());
        //    else
        //        Response.Redirect(Request.Url.AbsolutePath);
        //}

        //protected void ButtonBack_DanhSachPhong_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(Request.Url.AbsolutePath);
        //}

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
                PTB.Entities.Phong PhongSearch = listPhong.Where(item => Object.Equals(item.id, SearchID)).FirstOrDefault();
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
            List<PTB.Entities.Phong> listTemp = new List<PTB.Entities.Phong>();
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