using DevExpress.Web.ASPxTreeList;
using QuanLyTaiSan.DataFilter;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System.Net;
using System.Text;
using DevExpress.Web.ASPxEditors;

namespace PTB_WEB.UserControl.ViTri
{
    public partial class ucViTri_Web : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        public CoSo objCoSo = null;
        Dayy objDay = null;
        Tang objTang = null;
        public string strSrc = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ucTreeViTri.Label_TenViTri.Text = "Vị Trí";
            }
        }

        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAll();
            if (listViTriHienThi.Count > 0)
            {
                _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                SearchFunction();
                Panel_Chinh.Visible = true;
                ClearData();
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
                    DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                    if (node != null)
                    {
                        _ucTreeViTri.FocusAndExpandToNode(node);
                        LoadFocusedNodeData();
                        Panel_ThongTinViTri.Visible = true;
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                    node.Focus();
                    Label_ChuaChon.Visible = true;
                    Label_ChuaChon.Text = "Chưa chọn vị trí";
                }
            }
            else
            {
                ucThongBaoLoi.Panel_ThongBaoLoi.Visible = true;
                ucThongBaoLoi.Label_ThongBaoLoi.Text = "Chưa có vị trí";
            }
        }

        private void ClearData()
        {
            Label_ThongTin.Text = "Thông tin";
            Libraries.ImageHelper.LoadImageWeb(null, _ucASPxImageSlider_Web.ASPxImageSlider_Object);
            Label_Ten.Text = "";
            Label_Thuoc.Text = "";
            Label_DiaChi.Text = "";
            Label_MoTa.Text = "";
            Panel_DiaChi.Visible = false;
        }
        private void LoadDataObj(Guid id, int type)
        {
            switch (type)
            {
                case 1:
                    objCoSo = CoSo.getById(id);
                    if (objCoSo != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objCoSo.ten);
                        Libraries.ImageHelper.LoadImageWeb(objCoSo.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                        _ucASPxImageSlider_Web.urlHinhAnh = string.Format("http://{0}/HinhAnh.aspx?id={1}&type=COSO", HttpContext.Current.Request.Url.Authority, objCoSo.id);
                        ucViTri_BreadCrumb.Label_TenViTri.Text = Label_Ten.Text = objCoSo.ten;
                        Label_Thuoc.Text = "[Đại học Sài Gòn]";
                        Panel_DiaChi.Visible = true;
                        Label_DiaChi.Text = objCoSo.diachi;
                        Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objCoSo.mota);
                        if (objCoSo.diachi != null)
                        {
                            if (objCoSo.diachi.Length > 0)
                            {
                                strSrc = @"https://www.google.com/maps/embed/v1/place?key=AIzaSyB2ryXlc0dNmczXS7O6E5htyRpkR4zvmVo&q=" + objCoSo.diachi;
                                popup.HeaderText = string.Format("Bản đồ {0}", objCoSo.ten);
                                LinkButtonBanDo.Text = popup.HeaderText;
                                LinkButtonBanDo.OnClientClick = string.Format("_ShowMaps('{0}'); return false;", strSrc);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    break;
                case 2:
                    objDay = Dayy.getById(id);
                    if (objDay != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objDay.ten);
                        Libraries.ImageHelper.LoadImageWeb(objDay.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                        _ucASPxImageSlider_Web.urlHinhAnh = string.Format("http://{0}/HinhAnh.aspx?id={1}&type=DAY", HttpContext.Current.Request.Url.Authority, objDay.id);
                        Label_Ten.Text = objDay.ten;
                        Label_Thuoc.Text = objDay.coso != null ? objDay.coso.ten : "[Cơ sở]";
                        ucViTri_BreadCrumb.Label_TenViTri.Text = string.Format("{0} ({1})", Label_Ten.Text, Label_Thuoc.Text);
                        Panel_DiaChi.Visible = false;
                        Label_DiaChi.Text = "";
                        Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objDay.mota);
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    break;
                case 3:
                    objTang = Tang.getById(id);
                    if (objTang != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objTang.ten);
                        Libraries.ImageHelper.LoadImageWeb(objTang.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                        _ucASPxImageSlider_Web.urlHinhAnh = string.Format("http://{0}/HinhAnh.aspx?id={1}&type=TANG", HttpContext.Current.Request.Url.Authority, objTang.id);
                        Label_Ten.Text = objTang.ten;
                        if (objTang.day != null)
                        {
                            if (objTang.day.coso != null)
                            {
                                Label_Thuoc.Text = objTang.day.coso.ten + " - " + objTang.day.ten;
                            }
                            else
                            {
                                Label_Thuoc.Text = "[Cơ sở] - " + objTang.day.ten;
                            }
                        }
                        else
                        {
                            Label_Thuoc.Text = "[Cơ sở] - [Dãy]";
                        }
                        ucViTri_BreadCrumb.Label_TenViTri.Text = string.Format("{0} ({1})", Label_Ten.Text, Label_Thuoc.Text);
                        Panel_DiaChi.Visible = false;
                        Label_DiaChi.Text = "";
                        Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objTang.mota);
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listViTriHienThi.Count > 0)
            {
                if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && _ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(CoSo).Name))
                    {
                        LoadDataObj(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 1);
                    }
                    else if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Dayy).Name))
                    {
                        LoadDataObj(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 2);
                    }
                    else if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Tang).Name))
                    {
                        LoadDataObj(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 3);
                    }
                }
            }
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
                DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), SearchID.ToString())).FirstOrDefault();
                if (node != null)
                {
                    Response.Redirect(string.Format("{0}?key={1}", Request.Url.AbsolutePath, node.Key.ToString()));
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

        protected void lnkButton_Init(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;

            btn.CssFilePath = string.Empty;
            btn.CssPostfix = string.Empty;
            btn.SpriteCssFilePath = string.Empty;
        }
    }
}