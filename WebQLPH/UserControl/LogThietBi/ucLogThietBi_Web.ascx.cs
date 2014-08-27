﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.LogThietBi
{
    public partial class ucLogThietBi_Web : System.Web.UI.UserControl
    {
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;
        List<QuanLyTaiSan.Entities.LogThietBi> listLogThietBi = new List<QuanLyTaiSan.Entities.LogThietBi>();
        public int idLog = -1;
        QuanLyTaiSan.Entities.LogThietBi objLogThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            if (Request.QueryString["id"] != null)
            {
                int id = -1;
                try
                {
                    id = Int32.Parse(Request.QueryString["id"].ToString());
                }
                catch
                {
                    Response.Redirect("~/");
                }
                objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
                if (objThietBi != null)
                {
                    Panel_Chinh.Visible = true;
                    Label_LogThietBi.Text = string.Format("Log của {0}", objThietBi.ten);
                    listLogThietBi = objThietBi.logthietbis.ToList();
                    var bind = listLogThietBi.Select(a => new
                    {
                        id = a.id,
                        tinhtrang = a.tinhtrang.value,
                        soluong = a.soluong,
                        phong = a.phong.ten,
                        ngay = a.date_create,
                        url = QuanLyTaiSan.Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "idLog", a.id.ToString())
                    }).OrderBy(item => item.ngay).ToList();
                    CollectionPagerDanhSachLogThietBi.DataSource = bind;
                    CollectionPagerDanhSachLogThietBi.BindToControl = RepeaterDanhSachLogThietBi;
                    RepeaterDanhSachLogThietBi.DataSource = CollectionPagerDanhSachLogThietBi.DataSourcePaged;
                    RepeaterDanhSachLogThietBi.DataBind();
                    if (listLogThietBi.Count == 0)
                    {
                        Label_DanhSachLogThietBi.Text = string.Format("Thiết bị {0} không có log", objThietBi.ten);
                    }
                    else
                    {
                        if (Request.QueryString["idLog"] != null)
                        {
                            idLog = -1;
                            try
                            {
                                idLog = Int32.Parse(Request.QueryString["idLog"].ToString());
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
                        objLogThietBi = listLogThietBi.Where(item => item.id == idLog).FirstOrDefault();
                        if (objLogThietBi != null)
                        {
                            Label_ThongTinLog.Text = string.Format("Thông tin log ngày {0}", ((DateTime)objLogThietBi.date_create).ToString("d/M/yyyy"));
                            QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objLogThietBi.hinhanhs.ToList(), ASPxImageSlider_Log);
                            TextBox_TenThietBi.Text = objThietBi.ten;
                            TextBox_TinhTrang.Text = objLogThietBi.tinhtrang.value;
                            TextBox_SoLuong.Text = objLogThietBi.soluong.ToString();
                            TextBox_Phong.Text = objLogThietBi.phong.ten;
                            TextBox_Ngay.Text = objLogThietBi.date_create.ToString();
                            TextBox_QuanTriVien.Text = objLogThietBi.quantrivien.hoten;
                            TextBox_GhiChu.Text = objLogThietBi.mota;
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
                        Label_ThongBaoLoi.Text = "Không có thiết bị này";
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