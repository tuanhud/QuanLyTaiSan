using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeThongKe : UserControl
    {
        String type = "";
        public ucTreeThongKe()
        {
            InitializeComponent();
            CreateColumns(treeListThongKe);
            CreateNodes(treeListThongKe);
        }

        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            tl.Columns.Add();
            tl.Columns[0].Caption = "id";
            tl.Columns[0].VisibleIndex = 0;
            tl.Columns.Add();
            tl.Columns[1].Caption = "Thống kê";
            tl.Columns[1].VisibleIndex = 1;
            tl.Columns.Add();
            tl.EndUpdate();
        }

        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            TreeListNode rootNode = tl.AppendNode(new object[] { "Thống kê tổng quát" }, parentForRootNodes);
            TreeListNode rootNode1 = tl.AppendNode(new object[] { "Thống kê chi tiết" }, parentForRootNodes);
            // Create a child of the rootNode
            tl.AppendNode(new object[] { "Cơ sở"}, rootNode1);
            tl.AppendNode(new object[] { "Dãy" }, rootNode1);
            tl.AppendNode(new object[] { "Tầng" }, rootNode1);
            tl.AppendNode(new object[] { "Phòng" }, rootNode1);
            tl.AppendNode(new object[] { "Thiết bị" }, rootNode1);
            TreeListNode rootNode2 = tl.AppendNode(new object[] { "Thống kê động" }, parentForRootNodes);
            // Creating more nodes
            // ...
            tl.EndUnboundLoad();
        }

        private void treeListThongKe_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                type = e.Node.GetValue(0).ToString();
            }
            catch (Exception ex)
            {

            }
        }


    }
}
