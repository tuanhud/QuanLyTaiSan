using DevExpress.Web.ASPxClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class t : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DevExpress.Web.ASPxClasses.ASPxWebControl.RegisterBaseScript(this);
        }
    }
}