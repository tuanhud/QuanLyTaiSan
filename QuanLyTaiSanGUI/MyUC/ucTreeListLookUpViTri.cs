using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeListLookUpViTri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTreeListLookUpViTri()
        {
            InitializeComponent();
        }

        private void treeListLookUpViTri_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(e.Value);
                if (node != null)
                {
                    if (node.GetValue(colloai).Equals(typeof(CoSo).Name))
                    {
                        e.DisplayText = node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                    {
                        e.DisplayText = node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).Equals(typeof(Tang).Name))
                    {
                        e.DisplayText = node.ParentNode.ParentNode.GetValue(colten).ToString() + " - " + node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).Equals(typeof(Phong).Name))
                    {
                        e.DisplayText = node.GetValue(colten).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLookUpViTri_CustomDisplayText: " + ex.Message);
            }
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListLookUpViTriTreeList.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListLookUpViTriTreeList.FindFilterText;
            if (node.GetDisplayText(column).ToUpper().Contains(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
