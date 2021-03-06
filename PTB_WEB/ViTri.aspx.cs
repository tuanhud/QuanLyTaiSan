﻿using PTB.Libraries;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class ViTri : System.Web.UI.Page
    {
        Boolean isMobile = false;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            DevExpress.Web.ASPxClasses.ASPxWebControl.GlobalTheme = "Moderno";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Default SetClassActive = this.Master as Default;
            SetClassActive.page = "VITRI";

            isMobile = MobileDetect.fBrowserIsMobile();
            if (!isMobile)
            {
                DevExpress.Web.ASPxClasses.ASPxWebControl.RegisterBaseScript(this);
                Panel_Web.Visible = true;
                _ucViTri_Web.LoadData();
            }
            else
            {
                Panel_Mobile.Visible = true;
                _ucViTri_Mobile.LoadData();
            }
        }
    }
}