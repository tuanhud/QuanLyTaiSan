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

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreePhongHaveCheck : UserControl
    {
        public ucTreePhongHaveCheck()
        {
            InitializeComponent();
        }

        public void loadData(List<ViTriFilter> list, NhanVienPT nhanvien)
        {
            treeListPhong.BeginUnboundLoad();
            treeListPhong.DataSource = list;
            treeListPhong.EndUnboundLoad();
            List<Phong> _list = nhanvien.phongs.ToList();
            foreach (Phong p in _list)
            {
                FindNode findNode = new FindNode(p.id, typeof(Phong).Name);
                treeListPhong.NodesIterator.DoOperation(findNode);
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
                Phong obj = new Phong().getById(Convert.ToInt32(node.GetValue(0)));
                listPhong.Add(obj);
            }
            return listPhong;
        }
    }
}
