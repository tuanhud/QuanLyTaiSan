using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQuanLyTaiSan
{
    public partial class TaiSan : System.Web.UI.Page
    {
        List<CTThietBi> ListCTThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListCTThietBi = CTThietBi.getAll();

        }
    }
}