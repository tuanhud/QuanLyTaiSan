using QuanLyTaiSan;
using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class PopupMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            if (!Convert.ToString(Session["Username"]).Equals(String.Empty))
                Global.current_quantrivien_login = QuanTriVien.getByUserName(Session["UserName"].ToString());
        }
    }
}