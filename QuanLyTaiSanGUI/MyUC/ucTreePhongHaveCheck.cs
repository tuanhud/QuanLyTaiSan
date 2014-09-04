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
using SHARED.Libraries;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreePhongHaveCheck : UserControl
    {
        public delegate void LoadListPhong(List<Phong> list);
        public LoadListPhong loadListPhong = null;

        public ucTreePhongHaveCheck()
        {
            InitializeComponent();
        }

        public void loadData(List<ViTriHienThi> list, NhanVienPT nhanvien)
        {
            try
            {
                treeListPhong.BeginUnboundLoad();
                treeListPhong.DataSource = list;
                treeListPhong.EndUnboundLoad();
                List<Phong> _list = nhanvien.phongs.ToList();
                foreach (Phong p in _list)
                {
                    if (!p.id.Equals(Guid.Empty))
                    {
                        TreeListNode node = treeListPhong.FindNodeByKeyID(p.id);
                        if (node != null)
                        {
                            treeListPhong.SetNodeCheckState(node, CheckState.Checked, true);
                            node.Selected = true;
                        }
                    }
                }
                if (treeListPhong.Nodes.Count > 0)
                    treeListPhong.FocusedNode = treeListPhong.Nodes[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        public void loadData(List<ViTriHienThi> list, QuanTriVien quantrivien)
        {
            try
            {
                treeListPhong.BeginUnboundLoad();
                treeListPhong.DataSource = list;
                treeListPhong.EndUnboundLoad();
                List<Phong> _list = quantrivien.phongs.ToList();
                foreach (Phong p in _list)
                {
                    if (!p.id.Equals(Guid.Empty))
                    {
                        TreeListNode node = treeListPhong.FindNodeByKeyID(p.id);
                        if (node != null)
                        {
                            treeListPhong.SetNodeCheckState(node, CheckState.Checked, true);
                            node.Selected = true;
                        }
                    }
                }
                if (treeListPhong.Nodes.Count > 0)
                    treeListPhong.FocusedNode = treeListPhong.Nodes[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void treeListPhong_AfterCheckNode(object sender, NodeEventArgs e)
        {
            try
            {
                if(loadListPhong != null)
                    loadListPhong(getListPhong());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListPhong_AfterCheckNode: " + ex.Message);
            }
        }

        public List<Phong> getListPhong()
        {
            List<Phong> listPhong = new List<Phong>();
            List<TreeListNode> listNode = treeListPhong.GetAllCheckedNodes();
            foreach (TreeListNode node in listNode)
            {
                if (node.GetValue(colloai).Equals(typeof(Phong).Name))
                {
                    Phong obj = node.GetValue(colphong) as Phong;
                    listPhong.Add(obj);
                }
            }
            return listPhong;
        }

        //public List<int> getListPhongId()
        //{
        //    List<int> list = new List<int>();
        //    GetCheckedNodes op = new GetCheckedNodes("loai", typeof(Phong).Name);
        //    treeListPhong.NodesIterator.DoOperation(op);
        //    foreach (TreeListNode node in op.CheckedNodes)
        //    {
        //        list.Add(Convert.ToInt32(node.GetValue(0)));
        //    }
        //    return list;
        //}

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
