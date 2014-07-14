using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using QuanLyTaiSan.Entities;
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSanGUI.QLNhanVien;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraTreeList.Columns;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreePhongHaveCheck : UserControl
    {
        public ucTreePhongHaveCheck()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            //treeListPhong.Columns[colten.FieldName].SortOrder = SortOrder.Ascending;
            treeListPhong.Columns[colid.FieldName].SortOrder = SortOrder.Ascending;
        }

        public void loadData(List<ViTriHienThi> list, NhanVienPT nhanvien)
        {
            treeListPhong.BeginUnboundLoad();
            treeListPhong.DataSource = list;
            treeListPhong.EndUnboundLoad();
            List<Phong> _list = nhanvien.phongs.ToList();
            foreach (Phong p in _list)
            {
                FindNode findNode = new FindNode(p.id, typeof(Phong).Name);
                treeListPhong.NodesIterator.DoOperation(findNode);
                treeListPhong.FocusedNode = findNode.Node;
                treeListPhong.SetNodeCheckState(findNode.Node, CheckState.Checked, true);
            }
        }

        private void treeListPhong_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (this.Parent.Parent.Parent != null)
            {
                ucQuanLyNhanVien _ucQuanLyNhanVien = this.Parent.Parent.Parent as ucQuanLyNhanVien;
                _ucQuanLyNhanVien.LoadListPhong(getListPhong());
            }
        }

        public List<Phong> getListPhong()
        {
            List<Phong> listPhong = new List<Phong>();
            GetCheckedNodes op = new GetCheckedNodes("loai",typeof(Phong).Name);
            treeListPhong.NodesIterator.DoOperation(op);
            foreach (TreeListNode node in op.CheckedNodes)
            {
                Phong obj = Phong.getById(Convert.ToInt32(node.GetValue(0)));
                listPhong.Add(obj);
            }
            return listPhong;
        }

        public List<int> getListPhongId()
        {
            List<int> list = new List<int>();
            GetCheckedNodes op = new GetCheckedNodes("loai", typeof(Phong).Name);
            treeListPhong.NodesIterator.DoOperation(op);
            foreach (TreeListNode node in op.CheckedNodes)
            {
                list.Add(Convert.ToInt32(node.GetValue(0)));
            }
            return list;
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListPhong.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListPhong.FindFilterText;
            if (node.GetDisplayText(column).ToUpper().Contains(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
