using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.ViTri
{
    public partial class ucViTri_Mobile : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        CoSo objCoSo = null;
        Dayy objDay = null;
        Tang objTang = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            _ucTreeViTri.NotFocusOnCreated();
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
                        Guid id = GUID.From(node.GetValue("id"));
                        string type = node.GetValue("loai").ToString();
                        if (type.Equals(typeof(CoSo).Name))
                        {
                            objCoSo = CoSo.getById(id);
                            if (objCoSo != null)
                            {
                                Panel_ThongTinObj.Visible = true;
                                Label_ThongTin.Text = "Thông tin " + objCoSo.ten;
                                Libraries.ImageHelper.LoadImageWeb(objCoSo.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);
                                Label_Ten.Text = objCoSo.ten;
                                ucViTri_BreadCrumb.Label_TenViTri.Text = Label_Ten.Text = objCoSo.ten;
                                Label_Thuoc.Text = "[Đại học Sài Gòn]";
                                Panel_DiaChi.Visible = true;
                                Label_DiaChi.Text = objCoSo.diachi;
                                Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objCoSo.mota);
                                if (objCoSo.diachi != null)
                                {
                                    if (objCoSo.diachi.Length > 0)
                                    {
                                        Button_Map.Visible = true;
                                    }
                                    else
                                        Button_Map.Visible = false;
                                }
                                else
                                    Button_Map.Visible = false;
                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else if (type.Equals(typeof(Dayy).Name))
                        {
                            objDay = Dayy.getById(id);
                            if (objDay != null)
                            {
                                Panel_ThongTinObj.Visible = true;
                                Label_ThongTin.Text = "Thông tin " + objDay.ten;
                                Libraries.ImageHelper.LoadImageWeb(objDay.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);
                                Label_Ten.Text = objDay.ten;
                                Label_Thuoc.Text = objDay.coso != null ? objDay.coso.ten : "[Cơ sở]";
                                ucViTri_BreadCrumb.Label_TenViTri.Text = string.Format("{0} ({1})", Label_Ten.Text, Label_Thuoc.Text);
                                Panel_DiaChi.Visible = false;
                                Label_DiaChi.Text = "";
                                Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objDay.mota);
                                Button_Map.Visible = false;
                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else if (type.Equals(typeof(Tang).Name))
                        {
                            objTang = Tang.getById(id);
                            if (objTang != null)
                            {
                                Panel_ThongTinObj.Visible = true;
                                Label_ThongTin.Text = "Thông tin " + objTang.ten;
                                Libraries.ImageHelper.LoadImageWeb(objTang.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);
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
                                Button_Map.Visible = false;
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
                else
                {
                    Panel_TreeViTri.Visible = true;
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có vị trí";
            }
        }

        protected void Button_Map_Click(object sender, EventArgs e)
        {
            if (objCoSo != null)
            {
                if (objCoSo.diachi != null)
                {
                    if (objCoSo.diachi.Length > 0)
                    {
                        string strUrl = @"http://www.google.com/maps/search/" + objCoSo.diachi;
                        Response.Redirect(strUrl);
                    }
                }
            }
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
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
    }
}