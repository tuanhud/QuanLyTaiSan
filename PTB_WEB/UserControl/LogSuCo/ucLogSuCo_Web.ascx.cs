using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.LogSuCo
{
    public partial class ucLogSuCo_Web : System.Web.UI.UserControl
    {
        QuanLyTaiSan.Entities.SuCoPhong objSuCoPhong = null;
        List<QuanLyTaiSan.Entities.LogSuCoPhong> listLogSuCoPhong = new List<QuanLyTaiSan.Entities.LogSuCoPhong>();
        public Guid idLog = Guid.Empty;
        QuanLyTaiSan.Entities.LogSuCoPhong objLogSuCoPhong = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            if (Request.QueryString["id"] != null)
            {
                Guid id = Guid.Empty;
                try
                {
                    id = GUID.From(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("~/");
                }
                objSuCoPhong = QuanLyTaiSan.Entities.SuCoPhong.getById(id);
                if (objSuCoPhong != null)
                {
                    Label_LogSuCo.Text = string.Format("Log của {0}", objSuCoPhong.ten);
                    listLogSuCoPhong = objSuCoPhong.logsucophongs.ToList();
                    var bind = listLogSuCoPhong.Select(a => new
                    {
                        id = a.id,
                        tinhtrang = a.tinhtrang.value,
                        phong = a.sucophong.phong.ten,
                        ghichu = a.mota,
                        quantrivien = a.quantrivien.hoten,
                        ngay = a.date_create,
                        url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", a.id.ToString())
                    }).OrderBy(item => item.ngay).ToList();
                    _ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.DataSource = bind;
                    _ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.BindToControl = RepeaterDanhSachLogSuCo;
                    RepeaterDanhSachLogSuCo.DataSource = _ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.DataSourcePaged;
                    RepeaterDanhSachLogSuCo.DataBind();
                    if (listLogSuCoPhong.Count == 0)
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        ucThongBaoLoi.Label_ThongBaoLoi.Text = string.Format("Thiết bị {0} không có log", objSuCoPhong.ten);
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
                            idLog = bind.ElementAt(0).id;
                        }
                        objLogSuCoPhong = listLogSuCoPhong.Where(item => item.id == idLog).FirstOrDefault();
                        if (objLogSuCoPhong != null)
                        {
                            Label_ThongTinLog.Text = string.Format("Thông tin log ngày {0}", ((DateTime)objLogSuCoPhong.date_create).ToString("d/M/yyyy"));
                            Libraries.ImageHelper.LoadImageWeb(objLogSuCoPhong.hinhanhs.ToList(), _ucASPxImageSlider_Web.ASPxImageSlider_Object);
                            Label_TenSuCo.Text = objLogSuCoPhong.sucophong.ten;
                            Label_TinhTrang.Text = objLogSuCoPhong.tinhtrang != null ? objLogSuCoPhong.tinhtrang.value : "[Tình trạng]";
                            Label_Phong.Text = objLogSuCoPhong.sucophong.phong != null ? objLogSuCoPhong.sucophong.phong.ten : "[Phòng]";
                            Label_Ngay.Text = objLogSuCoPhong.date_create.ToString();
                            Label_QuanTriVien.Text = objLogSuCoPhong.quantrivien != null ? objLogSuCoPhong.quantrivien.hoten : "[Quản trị viên]";
                            Label_GhiChu.Text = Libraries.StringHelper.ConvertRNToBR(objLogSuCoPhong.mota);
                        }
                        else
                        {
                            Response.Redirect("~/");
                        }
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
                        ucThongBaoLoi.Label_ThongBaoLoi.Text = "Không có thiết bị này";
                    }
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}