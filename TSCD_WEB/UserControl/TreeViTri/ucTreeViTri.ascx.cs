using DevExpress.Web.ASPxTreeList;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB.UserControl.TreeViTri
{
    public partial class ucTreeViTri : System.Web.UI.UserControl
    {
        public ASPxTreeList ASPxTreeList_ViTri = new ASPxTreeList();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CreateTreeList()
        {
            Boolean IsMobile = MobileDetect.fBrowserIsMobile();

            TreeListDataColumn colTen = new TreeListDataColumn("ten", "Tên");
            ASPxTreeList_ViTri.Columns.Add(colTen);

            ASPxTreeList_ViTri.AutoGenerateColumns = false;
            ASPxTreeList_ViTri.ClientInstanceName = "treeList";
            ASPxTreeList_ViTri.KeyFieldName = "id";
            ASPxTreeList_ViTri.ParentFieldName = "parent_id";
            ASPxTreeList_ViTri.Width = 100 / 100;
            ASPxTreeList_ViTri.Settings.ShowColumnHeaders = false;
            ASPxTreeList_ViTri.SettingsBehavior.AllowFocusedNode = true;
            ASPxTreeList_ViTri.SettingsBehavior.FocusNodeOnExpandButtonClick = false;
            ASPxTreeList_ViTri.SettingsCookies.StoreExpandedNodes = true;
            ASPxTreeList_ViTri.SettingsCookies.StorePaging = true;
            ASPxTreeList_ViTri.SettingsDataSecurity.AllowEdit = false;
            ASPxTreeList_ViTri.SettingsDataSecurity.AllowDelete = false;
            ASPxTreeList_ViTri.SettingsDataSecurity.AllowInsert = false;

            ASPxTreeList_ViTri.ClientSideEvents.CustomDataCallback = "function(s, e) {if(e.result != '') document.location = e.result;}";
            ASPxTreeList_ViTri.ClientSideEvents.NodeClick = "function(s, e) { var key = e.nodeKey; treeList.PerformCustomDataCallback(key)}";

            ASPxTreeList_ViTri.CustomDataCallback += ASPxTreeList_ViTri_CustomDataCallback;

            if (IsMobile)
                ASPxTreeList_ViTri.Theme = "Moderno";
            else
                ASPxTreeList_ViTri.Theme = "Aqua";

            PanelTreeList.Controls.Add(ASPxTreeList_ViTri);
        }
        public void NotFocusOnCreated()
        {
            ASPxTreeList_ViTri.ClientSideEvents.Init = "function(s, e) { s.SetFocusedNodeKey(''); }";
        }
        private void ASPxTreeList_ViTri_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
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