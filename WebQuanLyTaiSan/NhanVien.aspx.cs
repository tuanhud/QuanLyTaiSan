using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQuanLyTaiSan
{
    public partial class NhanVien : System.Web.UI.Page
    {
        List<NhanVienPT> ListNhanVienPT = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListNhanVienPT = NhanVienPT.getAll();
            RepeaterNhanVienPT.DataSource = ListNhanVienPT;
            RepeaterNhanVienPT.DataBind();
        }
    }
}