using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

namespace WebQLPH.UserControl.Phong
{
    public partial class ucPhong_Web : System.Web.UI.UserControl
    {
        public int idPhong = -1;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<QuanLyTaiSan.Entities.Phong> listPhong = new List<QuanLyTaiSan.Entities.Phong>();
        CoSo objCoSo = null;
        Dayy objDay = null;
        Tang objTang = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listPhong = QuanLyTaiSan.Entities.Phong.getAll();
            if (listPhong.Count > 0)
            {
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count > 0)
                {
                    Panel_Chinh.Visible = true;
                    ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ASPxTreeList_ViTri.DataBind();
                    ASPxTreeList_ViTri.ExpandToLevel(1);
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có phòng";
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có phòng";
            }
        }

        protected void ASPxTreeList_ViTri_FocusedNodeChanged(object sender, EventArgs e)
        {
            if (listViTriHienThi.Count > 0)
            {
                if (ASPxTreeList_ViTri.FocusedNode != null && ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && Convert.ToInt32(ASPxTreeList_ViTri.FocusedNode.GetValue("id")) > 0)
                {
                    if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(CoSo).Name))
                    {
                        
                    }
                    else if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Dayy).Name))
                    {
                        
                    }
                    else if (ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Tang).Name))
                    {
                        
                    }
                }
            }
        }

        private void LoadDanhSachPhong(int id, int type)
        {
            switch (type)
            {
                case 1:
                    objCoSo = CoSo.getById(id);
                    if (objCoSo != null)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    break;
                case 2:
                    objDay = Dayy.getById(id);
                    if (objDay != null)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    break;
                case 3:
                    objTang = Tang.getById(id);
                    if (objTang != null)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    break;
                default:
                    Response.Redirect("~/ViTri.aspx");
                    return;
            }
        }
    }
}