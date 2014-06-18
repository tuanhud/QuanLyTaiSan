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

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeLoaiTB : UserControl
    {
        LoaiThietBi obj = new LoaiThietBi();
        public ucTreeLoaiTB(List<LoaiThietBi> _list)
        {
            InitializeComponent();
            treeListLoaiTB.DataSource = _list;
        }
        public void setLoai(LoaiThietBi _loai)
        {
            obj = _loai;
            TreeListNode _node=null;
            if (obj.parent_id != null)
            {
                foreach (TreeListNode node in treeListLoaiTB.Nodes)
                {
                    foreach (TreeListNode node2 in node.Nodes)
                    {
                        if ((int)node2.GetValue(0) == obj.id)
                        {
                            _node = node2;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (TreeListNode node in treeListLoaiTB.Nodes)
                {
                    if ((int)node.GetValue(0) == obj.id)
                    {
                        _node = node;
                        break;
                    }
                }
            }
            treeListLoaiTB.SetFocusedNode(_node);
        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            obj = (LoaiThietBi)treeListLoaiTB.GetDataRecordByNode(e.Node);
            popupContainerEdit1.Text = obj.ten;
        }
    }
}
