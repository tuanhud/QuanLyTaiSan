using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Data;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Localization;
using QuanLyTaiSan.Libraries;
using SHARED.Libraries;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucComboBoxViTri : UserControl
    {
        bool chonDay = false;
        bool chonPhong = false;
        public ucComboBoxViTri(bool _chonDay, bool _chonPhong)
        {
            InitializeComponent();
            init(_chonDay, _chonPhong);
        }

        private void init(bool _chonDay, bool _chonPhong)
        {
            chonDay = _chonDay;
            chonPhong = _chonPhong;
        }

        public void loadData(List<ViTriHienThi> _list)
        {
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node.GetValue(colloai).ToString().Equals(typeof(CoSo).Name))
                {
                    if (!chonDay && !chonPhong)
                    {
                        popupContainerEdit1.Text = e.Node.GetValue(colten).ToString();
                        popupContainerEdit1.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                {
                    if (!chonPhong)
                    {
                        popupContainerEdit1.Text = e.Node.ParentNode.GetValue(colten).ToString() + " - " + e.Node.GetValue(colten).ToString();
                        popupContainerEdit1.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(colloai).ToString().Equals(typeof(Tang).Name))
                {
                    if (!chonPhong)
                    {
                        popupContainerEdit1.Text = e.Node.ParentNode.ParentNode.GetValue(colten).ToString() + " - " + e.Node.ParentNode.GetValue(colten).ToString() + " - " + e.Node.GetValue(colten).ToString();
                        popupContainerEdit1.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(colloai).ToString().Equals(typeof(Phong).Name))
                {
                    popupContainerEdit1.Text = e.Node.GetValue(colten).ToString();
                    popupContainerEdit1.ClosePopup();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListViTri_FocusedNodeChanged: " + ex.Message);
            }
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
            popupContainerEdit1.Properties.ReadOnly = b;
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

        public void setTextPopupContainerEdit(String text)
        {
            popupContainerEdit1.Text = text;
        }

        public String getTextPopupContainerEdit()
        {
            return popupContainerEdit1.Text;
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

        private void popupContainerEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            popupContainerEdit1.Properties.PopupFormSize = new Size(popupContainerEdit1.Width, popupContainerControl1.Height);       
        }
    }
}
