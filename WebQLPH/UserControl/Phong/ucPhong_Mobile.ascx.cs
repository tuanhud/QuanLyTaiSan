using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.Phong
{
    public partial class ucPhong_Mobile : System.Web.UI.UserControl
    {
        public int idPhong = -1;
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<QuanLyTaiSan.Entities.Phong> listPhong = new List<QuanLyTaiSan.Entities.Phong>();
        QuanLyTaiSan.Entities.Phong objPhong = null;
        string key = "";

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
                    ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    ASPxTreeList_ViTri.DataBind();
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
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            if (Request.QueryString["id"] != null)
                            {
                                idPhong = -1;
                                try
                                {
                                    idPhong = Int32.Parse(Request.QueryString["id"].ToString());
                                }
                                catch
                                {
                                    Response.Redirect(Request.Url.AbsolutePath);
                                }
                                objPhong = QuanLyTaiSan.Entities.Phong.getById(idPhong);
                                if (objPhong != null)
                                {
                                    Panel_ThongTinPhong.Visible = true;
                                    Label_ThongTinPhong.Text = "Thông tin " + objPhong.ten;
                                    QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objPhong.hinhanhs.ToList(), ASPxImageSlider_Phong);
                                    TextBox_MaPhong.Text = objPhong.subId;
                                    TextBox_TenPhong.Text = objPhong.ten;
                                    string strCoSo, strDay, strTang;
                                    strCoSo = objPhong.vitri.coso != null ? objPhong.vitri.coso.ten : "";
                                    strDay = objPhong.vitri.day != null ? objPhong.vitri.day.ten : "";
                                    strTang = objPhong.vitri.tang != null ? objPhong.vitri.tang.ten : "";
                                    if (!strCoSo.Equals(""))
                                    {
                                        TextBox_ViTriPhong.Text += strCoSo;
                                        if (!strDay.Equals(""))
                                        {
                                            TextBox_ViTriPhong.Text += " - " + strDay;
                                            if (!strTang.Equals(""))
                                            {
                                                TextBox_ViTriPhong.Text += " - " + strTang;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TextBox_ViTriPhong.Text = "";
                                    }
                                    TextBox_MoTaPhong.Text = objPhong.mota;
                                    TextBox_NhanVienPhuTrach.Text = objPhong.nhanvienpt != null ? objPhong.nhanvienpt.hoten : "";

                                    if (objPhong.nhanvienpt != null)
                                    {
                                        Panel_NhanVien.Visible = true;
                                        Label_NhanVien.Visible = false;
                                        Label_NhanVien.Text = "";
                                        Label_ThongTinNhanVien.Text = "Thông tin " + objPhong.nhanvienpt.hoten;
                                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objPhong.nhanvienpt.hinhanhs.ToList(), ASPxImageSlider_NhanVien);
                                        TextBox_MaNhanVien.Text = objPhong.nhanvienpt.subId;
                                        TextBox_TenNhanVien.Text = objPhong.nhanvienpt.hoten;
                                        TextBox_SoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                                    }
                                    else
                                    {
                                        Panel_NhanVien.Visible = false;
                                        Label_NhanVien.Visible = true;
                                        Label_NhanVien.Text = "Phòng này chưa có nhân viên phụ trách";
                                        Label_ThongTinNhanVien.Text = "Thông tin nhân viên";
                                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(null, ASPxImageSlider_NhanVien);
                                        TextBox_MaNhanVien.Text = "";
                                        TextBox_TenNhanVien.Text = "";
                                        TextBox_SoDienThoai.Text = "";
                                    }
                                }
                                else
                                {
                                    Response.Redirect(Request.Url.AbsolutePath);
                                }
                            }
                            else
                            {
                                LoadDanhSachPhong(Convert.ToInt32(node.GetValue("id").ToString()), node.GetValue("loai").ToString());
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

        private void LoadDanhSachPhong(int id, string type)
        {
            if (type.Equals(typeof(CoSo).Name))
            {
                CoSo objCoso = CoSo.getById(id);
                if (objCoso != null)
                    Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0})", objCoso.ten);
                else
                    Response.Redirect(Request.Url.AbsolutePath);
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.coso_id != null).ToList().Where(phong => phong.vitri.coso_id == id).ToList());
                
            }
            else if (type.Equals(typeof(Dayy).Name))
            {
                Dayy objDay = Dayy.getById(id);
                if (objDay != null)
                    Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0} - {1})", objDay.coso != null ? objDay.coso.ten : "[Cơ sở]", objDay.ten);
                else
                    Response.Redirect(Request.Url.AbsolutePath);
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.day_id != null).ToList().Where(phong => phong.vitri.day_id == id).ToList());
            }
            else if (type.Equals(typeof(Tang).Name))
            {
                Tang objTang = Tang.getById(id);
                if (objTang != null)
                {
                    if (objTang.day != null)
                    {
                        Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0} - {1} - {2})", objTang.day.coso != null ? objTang.day.coso.ten : "[Null]", objTang.day.ten, objTang.ten);
                    }
                    else
                    {
                        Label_DanhSachPhong.Text = string.Format("Danh sách phòng ([Cơ sở] - [Dãy] - {2})", objTang.ten);
                    }
                }
                else
                    Response.Redirect(Request.Url.AbsolutePath);
                LoadDanhSachPhong(listPhong.Where(phong => phong.vitri.tang_id != null).ToList().Where(phong => phong.vitri.tang_id == id).ToList());
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadDanhSachPhong(List<QuanLyTaiSan.Entities.Phong> list)
        {
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                nhanvienpt = item.nhanvienpt != null ? item.nhanvienpt.hoten : "",
                url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            CollectionPagerDanhSachPhong.DataSource = bind;
            CollectionPagerDanhSachPhong.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = CollectionPagerDanhSachPhong.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
        }

        protected void ButtonBack_ThongTinPhong_Click(object sender, EventArgs e)
        {
            if (!key.Equals(""))
            {
                string url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "key", key, new List<string>(new string[] { "id" })).ToString();
                Response.Redirect(url);
            }
            else
                Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void ButtonBack_DanhSachPhong_Click(object sender, EventArgs e)
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