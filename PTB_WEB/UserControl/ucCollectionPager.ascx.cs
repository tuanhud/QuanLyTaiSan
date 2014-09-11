using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB.UserControl
{
    public partial class ucCollectionPager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void ShowPanelPage(Panel _panel)
        {
            try
            {
                if (Request.QueryString["page"] != null)
                {
                    if (Session["page"] != null)
                    {
                        if (!Session["page"].Equals(Request.QueryString["page"]))
                        {
                            _panel.Visible = true;
                        }
                        else
                        {
                            _panel.Visible = false;
                        }
                    }

                    Session["page"] = Request.QueryString["page"];
                }
                else
                {
                    Session["page"] = 1;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}