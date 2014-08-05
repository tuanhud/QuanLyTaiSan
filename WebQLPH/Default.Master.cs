using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Username"]) != String.Empty)
            {
                PanelAdmin.Visible = true;
                UserName.InnerText = Session["Username"].ToString();
            }
        }
        protected override void OnInit(EventArgs e)
        {
            Global.working_database.use_internal_config = true;
        }
    }
}