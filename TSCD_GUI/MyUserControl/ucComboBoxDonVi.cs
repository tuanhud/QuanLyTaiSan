using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using SHARED.Libraries;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucComboBoxDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        Guid id = Guid.Empty;
        bool edit = false;

        public ucComboBoxDonVi()
        {
            InitializeComponent();
        }

        public void loadData(List<DonVi> listDonVi, List<LoaiDonVi> listLoaiDonVi)
        {
            repositoryLookUpLoai.DataSource = listLoaiDonVi;
            treeListDonVi.BeginUnboundLoad();
            treeListDonVi.DataSource = listDonVi;
            treeListDonVi.EndUnboundLoad();
        }

        public void setID(Guid _id)
        {
            id = _id;
            edit = true;
        }

        public DonVi getDonVi()
        {
            try
            {
                TreeListNode node = treeListDonVi.FocusedNode;
                if (node != null && treeListDonVi.GetDataRecordByNode(node) != null)
                {
                    DonVi obj = treeListDonVi.GetDataRecordByNode(node) as DonVi;
                    if (obj != null && obj.id != Guid.Empty)
                        return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getDonVi: " + ex.Message);
                return null;
            }
        }

        public void setDonVi(DonVi obj)
        {
            try
            {
                edit = false;
                if (obj != null && !obj.id.Equals(Guid.Empty))
                {
                    findNode find = new findNode(obj.id, "id");
                    treeListDonVi.NodesIterator.DoOperation(find);
                    TreeListNodes n = treeListDonVi.Nodes;
                    TreeListNode node = find.Node;
                    if (node != null)
                    {
                        treeListDonVi.CollapseAll();
                        node.Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDonVi: " + ex.Message);
            }
        }

        public void setDonViById(Guid id)
        {
            try
            {
                TreeListNode node = treeListDonVi.FindNodeByKeyID(id);
                if (node != null)
                {
                    treeListDonVi.CollapseAll();
                    node.Selected = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDonVi: " + ex.Message);
            }
        }

        public void setReadOnly(bool b)
        {
            popupContainerEditDonVi.Properties.ReadOnly = b;
        }

        private void OnFilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
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

        private void treeListDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node.GetValue(colten) != null)
                {
                    if (edit)
                    {
                        if (e.Node.GetValue(colid) != null && !GUID.From(e.Node.GetValue(colid)).Equals(id))
                        {
                            popupContainerEditDonVi.EditValue = e.Node.GetValue(colten).ToString();
                            popupContainerEditDonVi.ClosePopup();
                        }
                    }
                    else
                    {
                        popupContainerEditDonVi.EditValue = e.Node.GetValue(colten).ToString();
                        popupContainerEditDonVi.ClosePopup();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListDonVi_FocusedNodeChanged: " + ex.Message);
            }
        }
    }
}
