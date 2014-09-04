﻿using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl.SuCo
{
    public partial class ucSuCo_BreadCrumb : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                    Session["IDSUCO"] = Request.QueryString["id"];
                if (Request.QueryString["key"] != null)
                    Session["KEYSUCO"] = Request.QueryString["key"];
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}