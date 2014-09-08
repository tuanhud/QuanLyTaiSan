using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SHARED.Libraries;
using TSCD.Entities;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucTreeDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void FocusedNodeChanged();
        public FocusedNodeChanged focusedNodeChanged = null;

        public ucTreeDonVi()
        {
            InitializeComponent();
        }

        public Object DataSource
        {
            set
            {
                treeListDonVi.BeginUnboundLoad();
                treeListDonVi.DataSource = value;
                treeListDonVi.EndUnboundLoad();
            }
        }

        private void treeListDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (focusedNodeChanged != null)
                    focusedNodeChanged();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListPhong_FocusedNodeChanged: " + ex.Message);
            }
        }

        public DonVi DonVi
        {
            get
            {
                try
                {
                    TreeListNode node = treeListDonVi.FocusedNode;
                    if (node != null && treeListDonVi.GetDataRecordByNode(node) != null)
                    {
                        return treeListDonVi.GetDataRecordByNode(node) as DonVi;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->getDonVi: " + ex.Message);
                    return null;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        TreeListNode node = null;
                        if (value != null && !value.id.Equals(Guid.Empty))
                        {
                            node = treeListDonVi.FindNodeByKeyID(value.id);
                        }
                        if (node != null)
                        {
                            treeListDonVi.CollapseAll();
                            node.Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->setDonVi : " + ex.Message);
                }
            }
        }

        public TreeList getTreeList()
        {
            return treeListDonVi;
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListDonVi.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListDonVi.FindFilterText;
            if (StringHelper.CoDauThanhKhongDau(node.GetDisplayText(column)).ToUpper().Contains(StringHelper.CoDauThanhKhongDau(filterValue).ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
