using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi_Control : UserControl
    {
        public ucQuanLyThietBi_Control()
        {
            InitializeComponent();
            CreateNode(treeList1);
            treeList1.ExpandAll();
        }

        public PanelControl getControl()
        {
            return panelControl1;
        }

        private void CreateNode(DevExpress.XtraTreeList.TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node
            DevExpress.XtraTreeList.Nodes.TreeListNode parentForRootNodes = null;

            DevExpress.XtraTreeList.Nodes.TreeListNode rootNode2 = tl.AppendNode(new object[] { "Thiết bị quản lý theo số lượng", 0 }, parentForRootNodes);

            DevExpress.XtraTreeList.Nodes.TreeListNode rootNode = tl.AppendNode(new object[] { "Thiết bị quản lý theo cá thể", 1 }, parentForRootNodes);
            // Create a child for a root Node
            tl.AppendNode(new object[] { "Thiết bị đang được sử dụng", 2 }, rootNode);
            tl.AppendNode(new object[] { "Thiết bị chưa được sử dụng", 3 }, rootNode);

            tl.EndUnboundLoad();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (this.Parent != null)
            {
                ucQuanLyThietBi _ucQuanLyThietBi = this.Parent as ucQuanLyThietBi;
                if (e.Node != null && e.Node.GetValue(colid).Equals(0))
                {
                    _ucQuanLyThietBi.loadData(true);
                }
                else if (e.Node != null && e.Node.GetValue(colid).Equals(1))
                {
                    _ucQuanLyThietBi.loadData(false);
                }
                else if (e.Node != null && e.Node.GetValue(colid).Equals(2))
                {
                    _ucQuanLyThietBi.loadData(false);
                }
                else if (e.Node != null && e.Node.GetValue(colid).Equals(3))
                {
                    _ucQuanLyThietBi.loadData(false);
                }
            }
        }

        public void FocusedNode(int id)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList1.FindNodeByFieldValue(colid.FieldName, id);
            node.Selected = true;
        }
    }
}
