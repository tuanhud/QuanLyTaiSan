using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using SHARED.Libraries;
using TSCD.Entities;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucTreeViTri : DevExpress.XtraEditors.XtraUserControl
    {

        public delegate void FocusedRow_phong();
        public FocusedRow_phong focusedRow_phong = null;

        public ucTreeViTri()
        {
            InitializeComponent();
        }

        public Object DataSource
        {
            set
            {
                treeListViTri.BeginUnboundLoad();
                treeListViTri.DataSource = value;
                treeListViTri.EndUnboundLoad();
            }
        }

        private void treeListViTri_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (focusedRow_phong != null)
                    focusedRow_phong();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListPhong_FocusedNodeChanged: " + ex.Message);
            }
        }

        public ViTri Vitri
        {
            get
            {
                try
                {
                    TreeListNode node = treeListViTri.FocusedNode;
                    if (node != null && node.GetValue(colloai) != null && node.GetValue(colid) != null)
                    {
                        if (node.GetValue(colloai).Equals(typeof(CoSo).Name))
                        {
                            CoSo obj = CoSo.getById(GUID.From(node.GetValue(colid)));
                            if (obj != null)
                                return ViTri.request(obj, null, null);
                        }
                        else if (node.GetValue(colloai).Equals(typeof(Dayy).Name))
                        {
                            Dayy obj = Dayy.getById(GUID.From(node.GetValue(colid)));
                            if (obj != null)
                                return ViTri.request(null, obj, null);
                        }
                        else if (node.GetValue(colloai).Equals(typeof(Tang).Name))
                        {
                            Tang obj = Tang.getById(GUID.From(node.GetValue(colid)));
                            if (obj != null)
                                return ViTri.request(null, null, obj);
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->getVitri: " + ex.Message);
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
                        if (value.tang != null && !value.tang.id.Equals(Guid.Empty))
                        {
                            node = treeListViTri.FindNodeByKeyID(value.tang.id);
                        }
                        else if (value.day != null && !value.day.id.Equals(Guid.Empty))
                        {
                            node = treeListViTri.FindNodeByKeyID(value.day.id);
                        }
                        else if (value.coso != null && !value.coso.id.Equals(Guid.Empty))
                        {
                            node = treeListViTri.FindNodeByKeyID(value.coso.id);
                        }
                        if (node != null)
                        {
                            treeListViTri.CollapseAll();
                            node.Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->setVitri : " + ex.Message);
                }
            }
        }

        public TreeList getTreeList()
        {
            return treeListViTri;
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListViTri.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListViTri.FindFilterText;
            if (StringHelper.CoDauThanhKhongDau(node.GetDisplayText(column)).ToUpper().Contains(StringHelper.CoDauThanhKhongDau(filterValue).ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
