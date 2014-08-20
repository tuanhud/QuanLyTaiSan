using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

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
            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                int id = -1;
                string type = "";
                try
                {
                    id = Int32.Parse(Request.QueryString["id"].ToString());
                    type = Request.QueryString["type"].ToString();
                }
                catch
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
                }
                if (type.Equals(typeof(CoSo).Name))
                {
                    objCoSo = CoSo.getById(id);
                    if (objCoSo != null)
                    {
                        Panel_Chinh.Visible = true;
                        Panel_ThongTinObj.Visible = true;
                        Label_ThongTin.Text = "Thông tin " + objCoSo.ten;
                        LoadImage(objCoSo.hinhanhs.ToList());
                        TextBox_Ten.Text = objCoSo.ten;
                        TextBox_Thuoc.Text = "[Đại học Sài Gòn]";
                        Panel_DiaChi.Visible = true;
                        TextBox_DiaChi.Text = objCoSo.diachi;
                        TextBox_Mota.Text = objCoSo.mota;
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
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = "Không có cơ sở này";
                    }
                }
                else if(type.Equals(typeof(Dayy).Name))
                {
                    objDay = Dayy.getById(id);
                    if (objDay != null)
                    {
                        Panel_Chinh.Visible = true;
                        Panel_ThongTinObj.Visible = true;
                        Label_ThongTin.Text = "Thông tin " + objDay.ten;
                        LoadImage(objDay.hinhanhs.ToList());
                        TextBox_Ten.Text = objDay.ten;
                        TextBox_Thuoc.Text = objDay.coso.ten;
                        Panel_DiaChi.Visible = false;
                        TextBox_DiaChi.Text = "";
                        TextBox_Mota.Text = objDay.mota;
                        Button_Map.Visible = false;
                    }
                    else
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = "Không có dãy này";
                    }
                }
                else if (type.Equals(typeof(Tang).Name))
                {
                    objTang = Tang.getById(id);
                    if (objTang != null)
                    {
                        Panel_Chinh.Visible = true;
                        Panel_ThongTinObj.Visible = true;
                        Label_ThongTin.Text = "Thông tin " + objTang.ten;
                        LoadImage(objTang.hinhanhs.ToList());
                        TextBox_Ten.Text = objTang.ten;
                        TextBox_Thuoc.Text = objTang.day.coso.ten + " - " + objTang.day.ten;
                        Panel_DiaChi.Visible = false;
                        TextBox_DiaChi.Text = "";
                        TextBox_Mota.Text = objTang.mota;
                        Button_Map.Visible = false;
                    }
                    else
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = "Không có tầng này";
                    }
                }
                else
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
            }
            else
            {
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count > 0)
                {
                    Panel_Chinh.Visible = true;
                    Panel_TreeViTri.Visible = true;
                    ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ASPxTreeList_ViTri.DataBind();
                    ASPxTreeList_ViTri.ExpandToLevel(1);
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có vị trí";
                }
            }
        }

        private void LoadImage(List<HinhAnh> listHinhAnh)
        {
            ASPxImageSlider_Object.Items.Clear();
            if (listHinhAnh != null)
            {
                if (listHinhAnh.Count > 0)
                {
                    foreach (HinhAnh hinhanh in listHinhAnh)
                    {
                        DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                        item.ImageUrl = hinhanh.getImageURL();
                        if (hinhanh.mota != null)
                        {
                            if (hinhanh.mota.Length > 0)
                                item.Text = hinhanh.mota;
                        }
                        else
                            item.Text = hinhanh.FILE_NAME;
                        ASPxImageSlider_Object.Items.Add(item);
                    }
                }
                else
                {
                    DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                    item.ImageUrl = "~/Images/NoImage.jpg";
                    item.Text = "Không có ảnh";
                    ASPxImageSlider_Object.Items.Add(item);
                }
            }
            else
            {
                DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                item.ImageUrl = "~/Images/NoImage.jpg";
                item.Text = "Không có ảnh";
                ASPxImageSlider_Object.Items.Add(item);
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
    }
}