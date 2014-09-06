using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.LogThietBi
{
    public partial class ucLogThietBi_Mobile : System.Web.UI.UserControl
    {
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;
        List<QuanLyTaiSan.Entities.LogThietBi> listLogThietBi = new List<QuanLyTaiSan.Entities.LogThietBi>();
        QuanLyTaiSan.Entities.LogThietBi objLogThietBi = null;

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
                objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
                if (objThietBi != null)
                {
                    listLogThietBi = objThietBi.logthietbis.ToList();
                    RepeaterDanhSachLogThietBi.DataBind();
                    if (listLogThietBi.Count == 0)
                    {
                        Panel_ThongBaoLoi.Visible = true;
                        Label_ThongBaoLoi.Text = string.Format("Thiết bị {0} không có log", objThietBi.ten);
                    }
                    else
                    {
                        if (Request.QueryString["idLog"] != null)
                        {
                            Guid idLog = Guid.Empty;
                            try
                            {
                                idLog = GUID.From(Request.QueryString["idLog"]);
                            }
                            catch
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                            objLogThietBi = listLogThietBi.Where(item => item.id == idLog).FirstOrDefault();
                            if (objLogThietBi != null)
                            {
                                Panel_ThongTinLog.Visible = true;
                                Label_ThongTinLog.Text = string.Format("Thông tin log ngày {0}", ((DateTime)objLogThietBi.date_create).ToString("d/M/yyyy"));
                                Libraries.ImageHelper.LoadImageWeb(objLogThietBi.hinhanhs.ToList(), _ucASPxImageSlider_Mobile.ASPxImageSlider_Object);
                                Label_TenThietBi.Text = objThietBi.ten;
                                Label_TinhTrang.Text = objLogThietBi.tinhtrang != null ? objLogThietBi.tinhtrang.value : "[Tình trạng]";
                                Label_SoLuong.Text = objLogThietBi.soluong.ToString();
                                Label_Phong.Text = objLogThietBi.phong != null ? objLogThietBi.phong.ten : "[Phòng]";
                                Label_Ngay.Text = objLogThietBi.date_create.ToString();
                                Label_QuanTriVien.Text = objLogThietBi.quantrivien != null ? objLogThietBi.quantrivien.hoten : "[Quản trị viên]";
                                Label_GhiChu.Text = Libraries.StringHelper.ConvertRNToBR(objLogThietBi.mota);
                            }
                            else
                            {
                                Response.Redirect("~/");
                            }
                        }
                        else
                        {
                            Panel_DanhSachLog.Visible = true;
                            Label_LogThietBi.Text = string.Format("Log của {0}", objThietBi.ten);
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
                        Label_ThongBaoLoi.Text = "Không có thiết bị này";
                    }
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Libraries.StringHelper.RemoveParameter(new Uri(Request.Url.AbsoluteUri), new List<string>(new string[] { "idLog" })).ToString());
        }
    }
}