using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.Phong
{
    public partial class ucPhong_Mobile : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        List<QuanLyTaiSan.Entities.Phong> listPhong = new List<QuanLyTaiSan.Entities.Phong>();
        QuanLyTaiSan.Entities.Phong objPhong = null;
        string key = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            _ucTreeViTri.NotFocusOnCreated();
        }

        public void LoadData()
        {
            listPhong = QuanLyTaiSan.Entities.Phong.getAll();
            if (listPhong.Count > 0)
            {
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count > 0)
                {
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
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
                                objPhong = QuanLyTaiSan.Entities.Phong.getById(idPhong);
                                if (objPhong != null)
                                {
                                    Panel_ThongTinPhong.Visible = true;
                                    Label_ThongTinPhong.Text = "Thông tin " + objPhong.ten;
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
                                        Label_ThongTinNhanVien.Text = "Thông tin " + objPhong.nhanvienpt.hoten;
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
                                        Label_ThongTinNhanVien.Text = "Thông tin nhân viên";
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

        private void LoadDanhSachPhong(Guid id, string type)
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
                        Label_DanhSachPhong.Text = string.Format("Danh sách phòng ({0} - {1} - {2})", objTang.day.coso != null ? objTang.day.coso.ten : "[Cơ sở]", objTang.day.ten, objTang.ten);
                    }
                    else
                    {
                        Label_DanhSachPhong.Text = string.Format("Danh sách phòng ([Cơ sở] - [Dãy] - {0})", objTang.ten);
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
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachPhong.CollectionPager_Object.BindToControl = RepeaterDanhSachPhong;
            RepeaterDanhSachPhong.DataSource = _ucCollectionPager_DanhSachPhong.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachPhong.DataBind();
        }

        protected void ButtonBack_ThongTinPhong_Click(object sender, EventArgs e)
        {
            if (!key.Equals(""))
                Response.Redirect(Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "key", key, new List<string>(new string[] { "id" })).ToString());
            else
                Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void ButtonBack_DanhSachPhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}