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

        public ucComboBoxViTri()
        {
            InitializeComponent();
        }

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

        public Object DataSource
        {
            set
            {
                treeListLookUpViTri.Properties.DataSource = value;
            }
        }

        public ViTri ViTri
        {
            get
            {
                try
                {
                    TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(treeListLookUpViTri.EditValue);
                    if (node != null)
                    {
                        if (node.GetValue(colloai).Equals(typeof(CoSo).Name))
                        {
                            CoSo obj = CoSo.getById(GUID.From(treeListLookUpViTri.EditValue));
                            if (obj != null)
                                return ViTri.request(obj, null, null);
                        }
                        else if (node.GetValue(colloai).Equals(typeof(Dayy).Name))
                        {
                            Dayy obj = Dayy.getById(GUID.From(treeListLookUpViTri.EditValue));
                            if (obj != null)
                                return ViTri.request(null, obj, null);
                        } 
                        else if (node.GetValue(colloai).Equals(typeof(Tang).Name))
                        {
                            Tang obj = Tang.getById(GUID.From(treeListLookUpViTri.EditValue));
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
            set
            {
                try
                {
                    if (value != null)
                    {
                        if (value.tang != null && !value.tang.id.Equals(Guid.Empty))
                        {
                            treeListLookUpViTri.EditValue = value.tang.id;
                        }
                        else if (value.day != null && !value.day.id.Equals(Guid.Empty))
                        {
                            treeListLookUpViTri.EditValue = value.day.id;
                        }
                        else if (value.coso != null && !value.coso.id.Equals(Guid.Empty))
                        {
                            treeListLookUpViTri.EditValue = value.coso.id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->setViTri: " + ex.Message);
                }
            }
        }

        public Phong Phong
        {
            get
            {
                try
                {
                    TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(treeListLookUpViTri.EditValue);
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
            set
            {
                try
                {
                    if (value != null && !value.id.Equals(Guid.Empty))
                    {
                        treeListLookUpViTri.EditValue = value.id;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->setPhong: " + ex.Message);
                }
            }
        }

        private String getValue(String s)
        {
            try
            {
                if (!String.IsNullOrEmpty(s))
                    return s.Split(new char[] { '\'' })[1];
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        public bool ReadOnly
        {
            set
            {
                treeListLookUpViTri.Properties.ReadOnly = value;
            }
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            //List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>().ToList();
            //if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(getValue(treeListLookUpViTriTreeList.FilterPanelText))) return;
            e.Handled = true;
            //e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Visible = IsNodeMatchFilter(e.Node, colten);
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = getValue(treeListLookUpViTriTreeList.FilterPanelText);
            if (StringHelper.CoDauThanhKhongDau(node.GetDisplayText(column).ToUpper()).Contains(StringHelper.CoDauThanhKhongDau(filterValue.ToUpper()))) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }

        private void treeListLookUpViTri_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                if (e.Value != null && treeListLookUpViTriTreeList.Nodes.Count > 0)
                {
                    TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(e.Value);
                    if (node.GetValue(colloai).ToString().Equals(typeof(CoSo).Name))
                    {
                        e.DisplayText = node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                    {
                        e.DisplayText = node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Tang).Name))
                    {
                        e.DisplayText = node.ParentNode.ParentNode.GetValue(colten).ToString() + " - " +
                            node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Phong).Name))
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

        private void treeListLookUpViTri_QueryCloseUp(object sender, CancelEventArgs e)
        {
            try
            {
                if (treeListLookUpViTriTreeList.FocusedNode != null)
                {
                    TreeListNode node = treeListLookUpViTriTreeList.FocusedNode;
                    if (chonDay)
                    {
                        if (node.GetValue(colloai) != null && node.GetValue(colloai).Equals(typeof(Dayy).Name))
                        { }
                        else
                            e.Cancel = true;
                    }
                    else if (chonPhong)
                    {
                        if (node.GetValue(colloai) != null && node.GetValue(colloai).Equals(typeof(Phong).Name))
                        { }
                        else
                            e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLookUpViTri_QueryCloseUp: " + ex.Message);
            }
        }
    }
}
