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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using TSCD.Entities;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucComboBoxViTri : DevExpress.XtraEditors.XtraUserControl
    {
        bool chonDay = false;
        bool chonPhong = false;

        public ucComboBoxViTri()
        {
            InitializeComponent();
        }

        public void init(bool _chonDay, bool _chonPhong)
        {
            chonDay = _chonDay;
            chonPhong = _chonPhong;
        }

        public void loadData(List<ViTriHienThi> _list, bool _chonDay, bool _chonPhong)
        {
            init(_chonDay, _chonPhong);
            loadData(_list);
        }

        public void loadData(List<ViTriHienThi> _list)
        {
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = null;
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        public ViTri getViTri()
        {
            try
            {
                TreeListNode node = treeListViTri.FocusedNode;
                if (node != null)
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
                Debug.WriteLine(this.Name + "->getViTri: " + ex.Message);
                return null;
            }
        }

        public Phong getPhong()
        {
            try
            {
                TreeListNode node = treeListViTri.FocusedNode;
                if (node != null)
                {
                    if (node.GetValue(colloai).Equals(typeof(Phong).Name))
                    {
                        Phong obj = node.GetValue(colphong) as Phong;
                        if (obj != null)
                            return obj;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getPhong: " + ex.Message);
                return null;
            }
        }

        public void setPhong(Phong obj)
        {
            try
            {
                if (obj != null && !obj.id.Equals(Guid.Empty))
                {
                    TreeListNode node = treeListViTri.FindNodeByKeyID(obj.id);
                    if (node != null)
                    {
                        treeListViTri.CollapseAll();
                        node.Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setPhong: " + ex.Message);
            }
        }

        public void setReadOnly(bool b)
        {
            popupContainerEditViTri.Properties.ReadOnly = b;
        }

        public void reLoad(List<ViTriHienThi> _list)
        {
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = null;
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        public void setViTri(ViTri obj)
        {
            try
            {
                if (obj != null)
                {
                    TreeListNode node = null;
                    if (obj.tang != null && !obj.tang.id.Equals(Guid.Empty))
                    {
                        node = treeListViTri.FindNodeByKeyID(obj.tang.id);
                    }
                    else if (obj.day != null && !obj.day.id.Equals(Guid.Empty))
                    {
                        node = treeListViTri.FindNodeByKeyID(obj.day.id);
                    }
                    else if (obj.coso != null && !obj.coso.id.Equals(Guid.Empty))
                    {
                        node = treeListViTri.FindNodeByKeyID(obj.coso.id);
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
                Debug.WriteLine(this.Name + "->setViTri: " + ex.Message);
            }
        }

        public void setText(String text)
        {
            popupContainerEditViTri.Text = text;
        }

        private void OnFilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
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

        private void popupContainerEditViTri_QueryPopUp(object sender, CancelEventArgs e)
        {
            //popupContainerEditViTri.Properties.PopupFormSize = new Size(popupContainerEditViTri.Width, popupContainerControlVitri.Height);
        }

        private void treeListViTri_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node.GetValue(colloai).ToString().Equals(typeof(CoSo).Name))
                {
                    if (!chonDay && !chonPhong)
                    {
                        popupContainerEditViTri.Text = e.Node.GetValue(colten).ToString();
                        popupContainerEditViTri.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                {
                    if (!chonPhong)
                    {
                        popupContainerEditViTri.Text = e.Node.ParentNode.GetValue(colten).ToString() + " - " + e.Node.GetValue(colten).ToString();
                        popupContainerEditViTri.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(colloai).ToString().Equals(typeof(Tang).Name))
                {
                    if (!chonPhong)
                    {
                        popupContainerEditViTri.Text = e.Node.ParentNode.ParentNode.GetValue(colten).ToString() +
                            " - " + e.Node.ParentNode.GetValue(colten).ToString() + " - " + e.Node.GetValue(colten).ToString();
                        popupContainerEditViTri.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(colloai).ToString().Equals(typeof(Phong).Name))
                {
                    popupContainerEditViTri.Text = e.Node.GetValue(colten).ToString();
                    popupContainerEditViTri.ClosePopup();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListViTri_FocusedNodeChanged: " + ex.Message);
            }
        }
    }
}
