using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;

            if (!IsPostBack)
            {
                try
                {
                    if (Convert.ToString(Session["Username"]).Equals(String.Empty))
                        PanelDangNhap.Visible = true;
                    else
                    {
                        if (LaQuanTriVien())
                        {
                            PanelQuanLyTaiKhoan.Visible = true;
                            _QuanLyTaiKhoan();
                        }
                        else
                            PanelKhongPhaiQuanTriVien.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        protected bool LaQuanTriVien()
        {
            return Convert.ToString(Session["KieuDangNhap"]).Equals("QuanTriVien");
        }

        protected void _QuanLyTaiKhoan()
        {
            List<GiangVien> ListGiangVien = GiangVien.getQuery().ToList();

            CollectionPagerQuanLyTaiKhoan.DataSource = ListGiangVien;
            CollectionPagerQuanLyTaiKhoan.BindToControl = RepeaterQuanLyTaiKhoan;
            RepeaterQuanLyTaiKhoan.DataSource = CollectionPagerQuanLyTaiKhoan.DataSourcePaged;
            RepeaterQuanLyTaiKhoan.DataBind();
        }

        protected string NgayTao()
        {
            DateTime dt = Convert.ToDateTime(Eval("date_create").ToString());
            return dt.ToString("HH\\hmm d/M/yyyy");
        }

        protected void ButtonLuu_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}