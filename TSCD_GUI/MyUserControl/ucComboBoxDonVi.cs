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
        public ucComboBoxDonVi()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            set
            {
                treeListLookUpDonVi.Properties.DataSource = value;
            }
        }

        public DonVi DonVi
        {
            get
            {
                try
                {
                    return DonVi.getById(GUID.From(treeListLookUpDonVi.EditValue));
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
                        treeListLookUpDonVi.EditValue = value.id;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->setDonVi: " + ex.Message);
                }
            }
        }

        public bool ReadOnly
        {
            set
            {
                treeListLookUpDonVi.Properties.ReadOnly = value;
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

        public String NullText
        {
            set
            {
                treeListLookUpDonVi.Properties.NullText = value;
            }
        }

        private void OnFilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            //List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>().ToList();
            //if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(getValue(treeListLookUpDonViTreeList.FilterPanelText))) return;
            e.Handled = true;
            //e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Visible = IsNodeMatchFilter(e.Node, colten);
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = getValue(treeListLookUpDonViTreeList.FilterPanelText);
            if (StringHelper.CoDauThanhKhongDau(node.GetDisplayText(column).ToUpper()).Contains(StringHelper.CoDauThanhKhongDau(filterValue.ToUpper()))) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
