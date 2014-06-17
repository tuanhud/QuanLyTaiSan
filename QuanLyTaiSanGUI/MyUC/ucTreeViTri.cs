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

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeViTri : UserControl
    {
        List<CoSo> listCoSos = new List<CoSo>();
        List<Dayy> listDays = new List<Dayy>();
        List<Tang> listTangs = new List<Tang>();
        int idTang = -1;
        int idCoSo = -1;
        int idDay = -1;
        bool haveTang = true;
        public ucTreeViTri(bool _haveTang)
        {
            InitializeComponent();
            haveTang = _haveTang;
            CreateNodes(treeListViTri);
        }
        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            listCoSos = new CoSo().getAll();
            foreach (CoSo _coso in listCoSos)
            {
                TreeListNode rootNode = tl.AppendNode(new object[] { _coso.id, _coso.ten, "coso" }, parentForRootNodes);
                // Create a child of the rootNode
                listDays = _coso.days.ToList();
                foreach (Dayy _day in listDays)
                {
                    TreeListNode rootNode2 = tl.AppendNode(new object[] { _day.id, _day.ten, "day" }, rootNode);
                    if (haveTang)
                    {
                        // Create a child of the rootNode
                        listTangs = _day.tangs.ToList();
                        foreach (Tang _tang in listTangs)
                        {
                            tl.AppendNode(new object[] { _tang.id, _tang.ten, "tang" }, rootNode2);
                            // Creating more nodes
                            // ...
                        }
                    }
                }
            }
            tl.EndUnboundLoad();
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node.GetValue(2).ToString().Equals("coso"))
            {
                popupContainerEdit1.Text = e.Node.GetValue(1).ToString();
                idCoSo = Convert.ToInt32(e.Node.GetValue(0));
            }
            else if (e.Node.GetValue(2).ToString().Equals("day"))
            {
                popupContainerEdit1.Text = e.Node.ParentNode.GetValue(1).ToString() +">"+ e.Node.GetValue(1).ToString();
                idCoSo = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                idDay = Convert.ToInt32(e.Node.GetValue(0));
            }
            else if (e.Node.GetValue(2).ToString().Equals("tang"))
            {
                popupContainerEdit1.Text = e.Node.ParentNode.ParentNode.GetValue(1).ToString() + ">" + e.Node.ParentNode.GetValue(1).ToString() + ">" + e.Node.GetValue(1).ToString();
                idCoSo = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                idDay = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                idTang = Convert.ToInt32(e.Node.GetValue(0));
            }

        }
        public ViTri getViTri()
        {
            ViTri objViTri = new ViTri();
            CoSo objCoSo = new CoSo().getById(idCoSo);
            Dayy objDay = new Dayy().getById(idDay);
            Tang objTang = new Tang().getById(idTang);
            objViTri.coso = objCoSo;
            objViTri.day = objDay;
            objViTri.tang = objTang;
            return objViTri;
        }
        public void setViTri(ViTri _vitri)
        {
            idCoSo = -1;
            idDay = -1;
            idTang = -1;
            TreeListNode _node = null;
            if(_vitri.tang!=null)
            {
                foreach (TreeListNode node in treeListViTri.Nodes)
                {
                    foreach (TreeListNode node2 in node.Nodes)
                    {
                        foreach (TreeListNode node3 in node2.Nodes)
                        {
                            if ((int)node3.GetValue(0) == _vitri.tang.id && node3.GetValue(2).ToString().Equals("tang"))
                            {
                                _node = node3;
                                break;
                            }
                        }
                    }
                }
            }
            else if (_vitri.day != null)
            {
                foreach (TreeListNode node in treeListViTri.Nodes)
                {
                    foreach (TreeListNode node2 in node.Nodes)
                    {
                        if ((int)node2.GetValue(0) == _vitri.day.id && node2.GetValue(2).ToString().Equals("day"))
                        {
                            _node = node2;
                            break;
                        }
                    }
                }
            }
            else if (_vitri.coso != null)
            {
                foreach (TreeListNode node in treeListViTri.Nodes)
                {
                    if ((int)node.GetValue(0) == _vitri.coso.id && node.GetValue(2).ToString().Equals("coso"))
                    {
                        _node = node;
                        break;
                    }
                }
            }
            treeListViTri.SetFocusedNode(_node);
            
        }
        public void setReadOnly(bool b)
        {
            if (b)
                popupContainerEdit1.Properties.ReadOnly = true;
            else
                popupContainerEdit1.Properties.ReadOnly = false;
        }
    }
}
