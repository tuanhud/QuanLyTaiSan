using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

namespace WebQLPH
{
    public partial class NhanVien : System.Web.UI.Page
    {
        Boolean isMobile = false;
        List<NhanVienPTFilter> listNhanVienPTFilter = NhanVienPTFilter.getAll();
        NhanVienPTFilter _NhanVienPTFilter = new NhanVienPTFilter();

        protected void Page_Load(object sender, EventArgs e)
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
                    Response.Redirect("~/NhanVien.aspx");
                }
                _NhanVienPTFilter = listNhanVienPTFilter.Where(nv => nv.id == id).FirstOrDefault();
                if (_NhanVienPTFilter != null)
                {
                    PanelThongTinNhanVienPhuTrach.Visible = true;
                    TextBox_MaNhanVien.Text = _NhanVienPTFilter.subId;
                    TextBox_HoTen.Text = _NhanVienPTFilter.hoten;
                    TextBox_SoDienThoai.Text = _NhanVienPTFilter.sodienthoai;
                }
                else
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = String.Format("Không có nhân viên phụ trách có id = {0}", id);
                }
            }
            else
            {
                PanelDanhSachNhanVienPhuTrach.Visible = true;
                GridViewNhanVienPhuTrach.DataSource = listNhanVienPTFilter;
                GridViewNhanVienPhuTrach.DataBind();
                GridViewNhanVienPhuTrach.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
                GridViewNhanVienPhuTrach.Styles.Header.Font.Bold = true;
            }
        }
    }
}