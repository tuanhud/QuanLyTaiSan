﻿using System;
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
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeLoaiTB : UserControl
    {
        LoaiThietBi obj = new LoaiThietBi();
        public String type = "";
        public ucTreeLoaiTB()
        {
            InitializeComponent();
        }

        public ucTreeLoaiTB(bool haveCheck)
        {
            InitializeComponent();
            treeListLoaiTB.OptionsBehavior.AllowRecursiveNodeChecking = true;
            treeListLoaiTB.OptionsView.ShowCheckBoxes = true;
        }

        public List<LoaiThietBi> getListLoaiTB()
        {
            List<LoaiThietBi> list = new List<LoaiThietBi>();
            GetCheckedNodes op = new GetCheckedNodes();
            treeListLoaiTB.NodesIterator.DoOperation(op);
            foreach (TreeListNode node in op.CheckedNodes)
            {
                LoaiThietBi obj = new LoaiThietBi().getById(Convert.ToInt32(node.GetValue(0)));
                list.Add(obj);
            }
            return list;
        }

        public void loadData(List<LoaiThietBi> _list)
        {
            treeListLoaiTB.BeginUnboundLoad();
            treeListLoaiTB.DataSource = _list;
            treeListLoaiTB.EndUnboundLoad();
        }

        public void setLoai(LoaiThietBi _loai)
        {
            obj = _loai;
            TreeListNode _node=null;
            treeListLoaiTB.CollapseAll();
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
            popupContainerEdit1.ClosePopup();
            if (type.Equals("add"))
            {
                if (this.ParentForm != null)
                {
                    frmNewThietBi frm = this.ParentForm as frmNewThietBi;
                    frm.LoaiTB_FocusedChanged(obj.loaichung);
                }
            }
        }

        public void setReadOnly(bool b)
        {
            popupContainerEdit1.Properties.ReadOnly = b;
        }

    }
}
