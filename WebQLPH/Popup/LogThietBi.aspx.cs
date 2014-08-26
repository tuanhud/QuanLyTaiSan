using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.PhongThietBi
{
    public partial class LogThietBi : System.Web.UI.Page
    {
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;
        List<QuanLyTaiSan.Entities.LogThietBi> listLogThietBi = new List<QuanLyTaiSan.Entities.LogThietBi>();
        public int idLog = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = -1;
                try
                {
                    id = Int32.Parse(Request.QueryString["idObj"].ToString());
                }
                catch
                {
                    Response.Redirect("https://www.google.com");
                }
                objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
                if (objThietBi != null)
                {
                    Panel_Chinh.Visible = true;
                    listLogThietBi = objThietBi.logthietbis.ToList();
                    var bind = listLogThietBi.Select(a => new
                    {
                        id = a.id,
                        ten = a.thietbi.ten,
                        tinhtrang = a.tinhtrang.value,
                        soluong= a.soluong,
                        ghichu = a.mota,
                        quantrivien = a.quantrivien.hoten,
                        phong = a.phong.ten,
                        ngay = a.date_create,
                        url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", a.id.ToString())
                    }).ToList();
                    CollectionPagerDanhSachLogThietBi.DataSource = bind;
                    CollectionPagerDanhSachLogThietBi.BindToControl = RepeaterDanhSachLogThietBi;
                    RepeaterDanhSachLogThietBi.DataSource = CollectionPagerDanhSachLogThietBi.DataSourcePaged;
                    RepeaterDanhSachLogThietBi.DataBind();
                    if (listLogThietBi.Count == 0)
                    {
                        Label_DanhSachLogThietBi.Text = "Thiết bị này không có log";
                    }
                    else
                    {
                        if (Request.QueryString["idLog"] != null)
                        {
                            idLog = -1;
                            try
                            {
                                idLog = Int32.Parse(Request.QueryString["idObj"].ToString());
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
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(listLogThietBi.ElementAt(idLog).hinhanhs.ToList(), ASPxImageSlider_Log);
                    }
                }
                else
                {
                    if (Request.UrlReferrer.ToString() == "")
                    {
                        Response.Redirect("https://www.google.com");
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
                if (Request.UrlReferrer.ToString() == "")
                {
                    Response.Redirect("https://www.google.com");
                }
                else
                { 
                    //
                }
            }
        }
    }
}