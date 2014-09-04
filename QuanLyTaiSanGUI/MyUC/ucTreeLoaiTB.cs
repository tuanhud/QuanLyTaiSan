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
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSanGUI.QLPhong;
using QuanLyTaiSan.Libraries;
using SHARED.Libraries;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeLoaiTB : UserControl
    {
        LoaiThietBi obj = new LoaiThietBi();
        public String type = "";
        bool haveCheck = false;
        public ucTreeLoaiTB()
        {
            InitializeComponent();
            init();
        }

        public ucTreeLoaiTB(bool _haveCheck)
        {
            InitializeComponent();
            treeListLoaiTB.OptionsBehavior.AllowRecursiveNodeChecking = true;
            treeListLoaiTB.OptionsView.ShowCheckBoxes = true;
            haveCheck = _haveCheck;
            init();
        }

        public void init()
        {
            treeListLoaiTB.Columns[colten.FieldName].SortOrder = SortOrder.Ascending;
        }

        public List<LoaiThietBi> getListLoaiTB()
        {
            try
            {
                List<LoaiThietBi> list = new List<LoaiThietBi>();
                List<TreeListNode> listNode = treeListLoaiTB.GetAllCheckedNodes();
                foreach (TreeListNode node in listNode)
                {
                    LoaiThietBi obj = LoaiThietBi.getById(GUID.From(node.GetValue(colid)));
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getListLoaiTB: " + ex.Message);
                return null;
            }
        }

        public void loadData(List<LoaiThietBi> _list)
        {
            treeListLoaiTB.BeginUnboundLoad();
            treeListLoaiTB.DataSource = _list;
            treeListLoaiTB.EndUnboundLoad();
        }

        public void setLoai(LoaiThietBi _loai)
        {
            try
            {
                if (_loai != null)
                {
                    obj = _loai;
                    treeListLoaiTB.CollapseAll();
                    TreeListNode node = treeListLoaiTB.FindNodeByFieldValue(colid.FieldName, _loai.id);
                    treeListLoaiTB.FocusedNode = node;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setLoai: " + ex.Message);
            }
        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (!haveCheck)
                {
                    obj = (LoaiThietBi)treeListLoaiTB.GetDataRecordByNode(e.Node);
                    popupContainerEdit1.Text = obj.ten;
                    popupContainerEdit1.ClosePopup();
                    //if (type.Equals("add"))
                    //{
                    //    if (this.ParentForm != null)
                    //    {
                    //        frmNewThietBi frm = this.ParentForm as frmNewThietBi;
                    //        frm.LoaiTB_FocusedChanged(obj.loaichung);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLoaiTB_FocusedNodeChanged: " + ex.Message);
            }
        }

        public void setReadOnly(bool b)
        {
            popupContainerEdit1.Properties.ReadOnly = b;
        }


        public void setTextPopupContainerEdit(String text)
        {
            popupContainerEdit1.Text = text;
        }

        public String setTextPopupContainerEdit()
        {
            return popupContainerEdit1.Text;
        }

        public LoaiThietBi getLoaiThietBi()
        {
            if (obj.id != Guid.Empty)
                return LoaiThietBi.getById(obj.id);
            return null;
        }

        private void treeListLoaiTB_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                if (haveCheck)
                {
                    String str = "";
                    List<LoaiThietBi> list = getListLoaiTB();
                    foreach (LoaiThietBi loaiTB in list)
                    {
                        str += loaiTB.ten + ", ";
                    }
                    if (str.Length > 2)
                    {
                        str = str.Substring(0, str.Length - 2);
                    }
                    popupContainerEdit1.Text = str;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLoaiTB_AfterCheckNode: " + ex.Message);
            }
        }

        private void OnFilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            List<DevExpress.XtraTreeList.Columns.TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<DevExpress.XtraTreeList.Columns.TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListLoaiTB.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, DevExpress.XtraTreeList.Columns.TreeListColumn column)
        {
            string filterValue = treeListLoaiTB.FindFilterText;
            if (node.GetDisplayText(column).ToUpper().Contains(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
