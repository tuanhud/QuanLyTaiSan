using DevExpress.Web.ASPxTreeList;
using QuanLyTaiSan.DataFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.ViTri
{
    public partial class ucViTri_Web : System.Web.UI.UserControl
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
                ClearData();
                ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                ASPxTreeList_ViTri.DataBind();
                ASPxTreeList_ViTri.ExpandToLevel(1);
                LoadFocusedNodeData();
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có vị trí";
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

        private void ClearData()
        {
            Label_ThongTin.Text = "Thông tin";
            ASPxImageSlider_Object.Items.Clear();
            DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
            item.ImageUrl = "~/Images/NoImage.jpg";
            item.Text = "Không có ảnh";
            ASPxImageSlider_Object.Items.Add(item);
            TextBox_Ten.Text = "";
            TextBox_Thuoc.Text = "";
            TextBox_DiaChi.Text = "";
            TextBox_Mota.Text = "";
            Panel_DiaChi.Visible = false;
            Panel_GoogleMap.Visible = false;
        }

        private void SetError(string strError)
        {
            PanelThongBao.Visible = true;
            LabelThongBao.Text = strError;
        }

        private void LoadDataObj(int id, int type)
        {
            switch (type)
            { 
                case 1:
                    objCoSo = CoSo.getById(id);
                    if (objCoSo != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objCoSo.ten);
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
                                Panel_GoogleMap.Visible = true;
                                string strSrc = @"https://www.google.com/maps/embed/v1/place?key=AIzaSyB2ryXlc0dNmczXS7O6E5htyRpkR4zvmVo&q=" + objCoSo.diachi;
                                Label_Script.Text = string.Format("<script>document.getElementById(\"Iframe_GoogleMap\").src = \"{0}\";document.getElementById(\"Iframe_Popup\").src = \"{1}\";</script>", strSrc, strSrc);
                            }
                            else
                                Panel_GoogleMap.Visible = false;
                        }
                        else
                            Panel_GoogleMap.Visible = false;
                    }
                    else
                    {
                        ClearData();
                        SetError("Không có dữ liệu về cơ sở này");
                    }
                    break;
                case 2:
                    objDay = Dayy.getById(id);
                    if (objDay != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objDay.ten);
                        LoadImage(objDay.hinhanhs.ToList());
                        TextBox_Ten.Text = objDay.ten;
                        TextBox_Thuoc.Text = objDay.coso.ten;
                        Panel_DiaChi.Visible = false;
                        TextBox_DiaChi.Text = "";
                        TextBox_Mota.Text = objDay.mota;
                        Panel_GoogleMap.Visible = false;
                    }
                    else
                    {
                        ClearData();
                        SetError("Không có dữ liệu về dãy này");
                    }
                    break;
                case 3:
                    objTang = Tang.getById(id);
                    if (objTang != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objTang.ten);
                        LoadImage(objTang.hinhanhs.ToList());
                        TextBox_Ten.Text = objTang.ten;
                        TextBox_Thuoc.Text = objTang.day.coso.ten + " - " + objTang.day.ten;
                        Panel_DiaChi.Visible = false;
                        TextBox_DiaChi.Text = "";
                        TextBox_Mota.Text = objTang.mota;
                        Panel_GoogleMap.Visible = false;
                    }
                    else
                    {
                        ClearData();
                        SetError("Không có dữ liệu về tầng này");
                    }
                    break;
            }
        }

        protected void ASPxTreeList_ViTri_FocusedNodeChanged(object sender, EventArgs e)
        {
            LoadFocusedNodeData();
        }

        private void LoadFocusedNodeData()
        {
            if (listViTriHienThi.Count > 0)
            {
                if (ASPxTreeList_ViTri.FocusedNode != null && ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")) > 0)
                {
                    if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(CoSo).Name))
                    {
                        LoadDataObj(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 1);
                    }
                    else if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Dayy).Name))
                    {
                        LoadDataObj(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 2);
                    }
                    else if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Tang).Name))
                    {
                        LoadDataObj(Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 3);
                    }
                }
            }
        }
    }
}