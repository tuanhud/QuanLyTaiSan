using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class HinhAnh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Guid id = GUID.From(Request.QueryString["id"]);
                switch (Request.QueryString["TYPE"])
                {
                    case "THIETBI":
                        QuanLyTaiSan.Entities.ThietBi objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs.ToList(), ASPxImageSlider);
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx");
                Console.Write(ex);
            }
        }
    }
}