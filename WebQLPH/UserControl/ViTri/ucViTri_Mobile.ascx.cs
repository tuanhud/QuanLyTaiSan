using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.ViTri
{
    public partial class ucViTri_Mobile : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        CoSo objCoSo = null;
        Dayy objDay = null;
        Tang objTang = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAll();
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
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
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
                                QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objCoSo.hinhanhs.ToList(), ASPxImageSlider_Object);
                                TextBox_Ten.Text = objCoSo.ten;
                                TextBox_Thuoc.Text = "[Đại học Sài Gòn]";
                                Panel_DiaChi.Visible = true;
                                TextBox_DiaChi.Text = objCoSo.diachi;
                                TextBox_MoTa.Text = objCoSo.mota;
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
                                QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objDay.hinhanhs.ToList(), ASPxImageSlider_Object);
                                TextBox_Ten.Text = objDay.ten;
                                TextBox_Thuoc.Text = objDay.coso.ten;
                                Panel_DiaChi.Visible = false;
                                TextBox_DiaChi.Text = "";
                                TextBox_MoTa.Text = objDay.mota;
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
                                QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objTang.hinhanhs.ToList(), ASPxImageSlider_Object);
                                TextBox_Ten.Text = objTang.ten;
                                TextBox_Thuoc.Text = objTang.day.coso.ten + " - " + objTang.day.ten;
                                Panel_DiaChi.Visible = false;
                                TextBox_DiaChi.Text = "";
                                TextBox_MoTa.Text = objTang.mota;
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

        protected void ASPxTreeList_ViTri_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
        }
    }
}