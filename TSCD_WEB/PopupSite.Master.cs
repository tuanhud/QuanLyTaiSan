using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.Entities;

namespace TSCD_WEB
{
    public partial class PopupSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                TSCD.Global.current_quantrivien_login = QuanTriVien.getByUserName(Session["UserName"].ToString());
        }
    }
}