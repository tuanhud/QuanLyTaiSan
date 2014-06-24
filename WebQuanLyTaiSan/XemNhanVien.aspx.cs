using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQuanLyTaiSan
{
    public partial class XemNhanVien : System.Web.UI.Page
    {
        List<NhanVienPT> listNhanVienPT = new List<NhanVienPT>();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        protected void Page_Load(object sender, EventArgs e)
        {
            NhanVienPT _NhanVienPT = new NhanVienPT();
            HinhAnh _HinhAnh = new HinhAnh();
            listNhanVienPT = _NhanVienPT.getAll();
            ASPxGridView.DataSource = listNhanVienPT;
            ASPxGridView.DataBind();
        }
    }
}