using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public String page = "Default";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            //SHARED.Global.WEB_MODE = true;
        }
    }
}