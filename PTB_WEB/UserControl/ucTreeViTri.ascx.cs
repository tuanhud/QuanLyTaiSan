using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB.UserControl
{
    public partial class ucTreeViTri : System.Web.UI.UserControl
    {
        public void NotFocusOnCreated()
        {
            ASPxTreeList_ViTri.ClientSideEvents.Init = "function(s, e) { s.SetFocusedNodeKey(''); }";
        }

        protected void ASPxTreeList_ViTri_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ViTri.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
        }

        protected void LinkButton_Expand_Click(object sender, EventArgs e)
        {
            ASPxTreeList_ViTri.ExpandAll();
        }

        protected void LinkButton_Collapse_Click(object sender, EventArgs e)
        {
            ASPxTreeList_ViTri.CollapseAll();
        }

        public void FocusAndExpandToNode(DevExpress.Web.ASPxTreeList.TreeListNode node)
        {
            node.Focus();
            node.Expanded = true;
            while (node.ParentNode != null)
            {
                node = node.ParentNode;
                node.Expanded = true;
            }
        }
    }
}