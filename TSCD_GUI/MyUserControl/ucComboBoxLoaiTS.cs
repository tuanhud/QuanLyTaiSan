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
using SHARED.Libraries;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucComboBoxLoaiTS : DevExpress.XtraEditors.XtraUserControl
    {
        bool isCheck = false;
        public delegate void EditValueChanged();
        public EditValueChanged editValueChanged = null;

        public ucComboBoxLoaiTS()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            set
            {
                treeListLookUpLoaiTS.Properties.DataSource = value;
            }
        }

        public void showCheck()
        {
            isCheck = true;
            treeListLookUpLoaiTSTreeList.OptionsView.ShowCheckBoxes = true;
            treeListLookUpLoaiTSTreeList.OptionsBehavior.AllowRecursiveNodeChecking = true;
            treeListLookUpLoaiTSTreeList.OptionsView.ShowAutoFilterRow = false;
            treeListLookUpLoaiTS.CustomDisplayText += treeListLookUpLoaiTS_CustomDisplayText;
            treeListLookUpLoaiTS.Closed += treeListLookUpLoaiTS_Closed;
        }

        public LoaiTaiSan LoaiTS
        {
            get
            {
                try
                {
                    if (treeListLookUpLoaiTS.EditValue != null)
                        return LoaiTaiSan.getById(GUID.From(treeListLookUpLoaiTS.EditValue));
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->getLoaiTS: " + ex.Message);
                    return null;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                        treeListLookUpLoaiTS.EditValue = value.id;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->setLoaiTS: " + ex.Message);
                }
            }
        }

        public bool ReadOnly
        {
            set
            {
                treeListLookUpLoaiTS.Properties.ReadOnly = value;
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

        private void OnFilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            //List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>().ToList();
            //if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(getValue(treeListLookUpLoaiTSTreeList.FilterPanelText))) return;
            e.Handled = true;
            //e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Visible = IsNodeMatchFilter(e.Node, colten);
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = getValue(treeListLookUpLoaiTSTreeList.FilterPanelText);
            if (StringHelper.CoDauThanhKhongDau(node.GetDisplayText(column).ToUpper()).Contains(StringHelper.CoDauThanhKhongDau(filterValue.ToUpper()))) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }

        private void treeListLookUpLoaiTS_EditValueChanged(object sender, EventArgs e)
        {
            if (editValueChanged != null)
                editValueChanged();
        }

        private void treeListLookUpLoaiTS_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                if (isCheck)
                {
                    String str = "";
                    List<LoaiTaiSan> list = getListLoaiTS();
                    foreach (LoaiTaiSan loaiTS in list)
                    {
                        str += loaiTS.ten + ", ";
                    }
                    if (str.Length > 2)
                    {
                        str = str.Substring(0, str.Length - 2);
                    }
                    e.DisplayText = str;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLookUpLoaiTS_CustomDisplayText: " + ex.Message);
            }
        }

        public List<LoaiTaiSan> getListLoaiTS()
        {
            try
            {
                List<LoaiTaiSan> list = new List<LoaiTaiSan>();
                List<TreeListNode> listNode = treeListLookUpLoaiTSTreeList.GetAllCheckedNodes();
                foreach (TreeListNode node in listNode)
                {
                    LoaiTaiSan obj = node.GetValue(colobj) as LoaiTaiSan;
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getListLoaiTS: " + ex.Message);
                return null;
            }
        }

        private void treeListLookUpLoaiTS_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                if (isCheck)
                {
                    String str = "";
                    List<LoaiTaiSan> list = getListLoaiTS();
                    foreach (LoaiTaiSan loaiTS in list)
                    {
                        str += loaiTS.ten + ", ";
                    }
                    if (str.Length > 2)
                    {
                        str = str.Substring(0, str.Length - 2);
                    }
                    treeListLookUpLoaiTS.Text = str;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLookUpLoaiTS_CustomDisplayText: " + ex.Message);
            }
        }

        public List<Guid> list_loaitaisan
        {
            get 
            {
            return getListLoaiTS().Select(c => c.id).ToList();
            }
        }
    }
}
