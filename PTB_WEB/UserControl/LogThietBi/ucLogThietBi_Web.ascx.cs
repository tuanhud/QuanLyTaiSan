using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.LogThietBi
{
    public partial class ucLogThietBi_Web : System.Web.UI.UserControl
    {
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;
        List<QuanLyTaiSan.Entities.LogThietBi> listLogThietBi = new List<QuanLyTaiSan.Entities.LogThietBi>();
        public Guid idLog = Guid.Empty;
        QuanLyTaiSan.Entities.LogThietBi objLogThietBi = null;
        QuanLyTaiSan.Entities.Phong objPhong = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadData()
        {
            HyperLinkXemLogTheoPhong.NavigateUrl = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "type", "phong").ToString(); ;
            HyperLinkXemLogTheoThietBi.NavigateUrl = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "type", "thietbi").ToString();

            if (Request.QueryString["id"] != null && Request.QueryString["idp"] != null)
            {
                Guid id = Guid.Empty;
                Guid idp = Guid.Empty;
                try
                {
                    id = GUID.From(Request.QueryString["id"]);
                    idp = GUID.From(Request.QueryString["idp"]);
                }
                catch
                {
                    Response.Redirect("~/");
                }
                objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
                objPhong = QuanLyTaiSan.Entities.Phong.getById(idp);
                if (objThietBi != null)
                {
                    try
                    {
                        if (Request.QueryString["type"] == "thietbi")
                        {
                            XemLogTheoThietBi();
                        }
                        else
                        {
                            XemLogTheoPhong();
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("~/");
                    }

                    if (listLogThietBi.Count == 0)
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = string.Format("Thiết bị {0} không có log", objThietBi.ten);
                    }
                    else
                    {
                        Panel_Chinh.Visible = true;
                        if (Request.QueryString["idLog"] != null)
                        {
                            idLog = Guid.Empty;
                            try
                            {
                                idLog = GUID.From(Request.QueryString["idLog"]);
                            }
                            catch
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else
                        {
                            idLog = listLogThietBi.ElementAt(0).id;
                        }
                        objLogThietBi = listLogThietBi.Where(item => item.id == idLog).FirstOrDefault();
                        if (objLogThietBi == null)
                        {
                            idLog = listLogThietBi.ElementAt(0).id;
                            objLogThietBi = listLogThietBi.Where(item => item.id == idLog).FirstOrDefault();
                        }

                        Label_ThongTinLog.Text = string.Format("Thông tin log ngày {0}", ((DateTime)objLogThietBi.date_create).ToString("d/M/yyyy"));
                        Libraries.ImageHelper.LoadImageWeb(objLogThietBi.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                        Label_TenThietBi.Text = objThietBi.ten;
                        Label_TinhTrang.Text = objLogThietBi.tinhtrang != null ? objLogThietBi.tinhtrang.value : "[Tình trạng]";
                        Label_SoLuong.Text = objLogThietBi.soluong.ToString();
                        Label_Phong.Text = objLogThietBi.phong != null ? objLogThietBi.phong.ten : "[Phòng]";
                        Label_Ngay.Text = objLogThietBi.date_create.ToString();
                        Label_QuanTriVien.Text = objLogThietBi.quantrivien != null ? objLogThietBi.quantrivien.hoten : "[Quản trị viên]";
                        Label_GhiChu.Text = Libraries.StringHelper.ConvertRNToBR(objLogThietBi.mota);
                    }
                }
                else
                {
                    if (Request.UrlReferrer == null)
                    {
                        Response.Redirect("~/");
                    }
                    else
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = "Không có thiết bị này";
                    }
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        public void XemLogTheoThietBi()
        {
            HyperLinkXemLogTheoThietBi.Visible = false;
            HyperLinkXemLogTheoPhong.Visible = true;

            Label_LogThietBi.Text = string.Format("Log của <b>{0}</b>", objThietBi.ten);
            HyperLinkXemLogTheoPhong.Text = string.Format("Log TB phòng <b>{0}</b>", objPhong.ten);
            listLogThietBi = objThietBi.logthietbis.ToList();
            var bind = listLogThietBi.Select(a => new
            {
                id = a.id,
                tinhtrang = a.tinhtrang.value,
                soluong = a.soluong,
                phong = a.phong.ten,
                ngay = a.date_create,
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", a.id.ToString())
            }).OrderBy(item => item.ngay).ToList();
            _ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.BindToControl = RepeaterDanhSachLogThietBi;
            RepeaterDanhSachLogThietBi.DataSource = _ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachLogThietBi.DataBind();
        }

        public void XemLogTheoPhong()
        {
            HyperLinkXemLogTheoThietBi.Visible = true;
            HyperLinkXemLogTheoPhong.Visible = false;

            Label_LogThietBi.Text = string.Format("Log thiết bị phòng <b>{0}</b>", objPhong.ten);
            listLogThietBi = objThietBi.logthietbis.Where(c => c.phong == objPhong).ToList();
            var bind = listLogThietBi.Select(a => new
            {
                id = a.id,
                tinhtrang = a.tinhtrang.value,
                soluong = a.soluong,
                phong = a.phong.ten,
                ngay = a.date_create,
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", a.id.ToString())
            }).OrderBy(item => item.ngay).ToList();
            _ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.DataSource = bind;
            _ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.BindToControl = RepeaterDanhSachLogThietBi;
            RepeaterDanhSachLogThietBi.DataSource = _ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.DataSourcePaged;
            RepeaterDanhSachLogThietBi.DataBind();
        }
    }
}