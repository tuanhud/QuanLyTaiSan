using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;

namespace Web
{
    public partial class LoaiThietBis : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<LoaiThietBi> ListLoaiThietBi = LoaiThietBi.getAll();
            TreeListLoaiThietBi.DataSource = ListLoaiThietBi;
            TreeListLoaiThietBi.DataBind();
        }
    }
}