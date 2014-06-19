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

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeViTri : UserControl
    {
        List<CoSo> listCoSos = new List<CoSo>();
        int idTang = -1;
        int idCoSo = -1;
        int idDay = -1;
        bool haveTang = true;
        bool haveDay = true;
        public ucTreeViTri(List<CoSo> _lists, bool _haveDay, bool _haveTang)
        {
            InitializeComponent();
            listCoSos = _lists;
            haveTang = _haveTang;
            haveDay = _haveDay;
            CreateNodes(treeListViTri);
        }
        private void CreateNodes(TreeList tl)
        {
            try
            {
                List<Dayy> listDays = new List<Dayy>();
                List<Tang> listTangs = new List<Tang>();
                tl.BeginUnboundLoad();
                // Create a root node .
                TreeListNode parentForRootNodes = null;
                if (listCoSos != null)
                {
                    foreach (CoSo _coso in listCoSos)
                    {
                        TreeListNode rootNode = tl.AppendNode(new object[] { _coso.id, _coso.ten, "coso" }, parentForRootNodes);
                        if (haveDay)
                        {
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
                    }
                }
                tl.EndUnboundLoad();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node.GetValue(2).ToString().Equals("coso"))
                {
                    if (!haveDay || haveTang)
                    {
                        popupContainerEdit1.Text = e.Node.GetValue(1).ToString();
                        idCoSo = Convert.ToInt32(e.Node.GetValue(0));
                        idTang = -1;
                        idDay = -1;
                    }
                }
                else if (e.Node.GetValue(2).ToString().Equals("day"))
                {
                    popupContainerEdit1.Text = e.Node.ParentNode.GetValue(1).ToString() + " - " + e.Node.GetValue(1).ToString();
                    idCoSo = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                    idDay = Convert.ToInt32(e.Node.GetValue(0));
                    idTang = -1;
                }
                else if (e.Node.GetValue(2).ToString().Equals("tang"))
                {
                    popupContainerEdit1.Text = e.Node.ParentNode.ParentNode.GetValue(1).ToString() + " - " + e.Node.ParentNode.GetValue(1).ToString() + " - " + e.Node.GetValue(1).ToString();
                    idCoSo = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                    idDay = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                    idTang = Convert.ToInt32(e.Node.GetValue(0));
                }
            }
            catch (Exception ex)
            { }
            finally
            { }
        }
        public ViTri getViTri(MyDB db)
        {
            ViTri objViTri = new ViTri(db);
            CoSo objCoSo = new CoSo(db).getById(idCoSo);
            Dayy objDay = new Dayy(db).getById(idDay);
            Tang objTang = new Tang(db).getById(idTang);
            objViTri.coso = objCoSo;
            objViTri.day = objDay;
            objViTri.tang = objTang;
            return objViTri;
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
        
        public void setReadOnly(bool b)
        {
            popupContainerEdit1.Properties.ReadOnly = b;
        }
        public void reLoad(List<CoSo> _list)
        {
            listCoSos = _list;
            treeListViTri.ClearNodes();
            CreateNodes(treeListViTri);
        }

        public class TreeListOperationFindNodeByProductAndCountryValues : TreeListOperation
        {
            public const string idColumnName = "id";
            public const string loaiColumnName = "loai";
            private TreeListNode nodeCore;
            private object id;
            private object loai;
            private bool isNullCore;
            public TreeListOperationFindNodeByProductAndCountryValues(object _id, object _loai)
            {
                this.id = _id;
                this.loai = _loai;
                this.nodeCore = null;
                this.isNullCore = TreeListData.IsNull(id) || TreeListData.IsNull(loai);
            }
            public override void Execute(TreeListNode node)
            {
                if (IsLookedFor(node.GetValue(idColumnName), node.GetValue(loaiColumnName)))
                    this.nodeCore = node;
            }
            bool IsLookedFor(object _id, object _loai)
            {
                if (IsNull) return (id == _id && loai == _loai);
                return id.Equals(_id) && loai.Equals(_loai);
            }
            protected bool IsNull { get { return isNullCore; } }
            public override bool CanContinueIteration(TreeListNode node) { return Node == null; }
            public TreeListNode Node { get { return nodeCore; } }
        }

        public void setViTri(ViTri obj)
        {
            TreeListOperationFindNodeByProductAndCountryValues findNode = null;
            if (obj.tang != null)
            {
                findNode = new TreeListOperationFindNodeByProductAndCountryValues(obj.tang.id, "tang");
            }
            else if (obj.day != null)
            {
                findNode = new TreeListOperationFindNodeByProductAndCountryValues(obj.day.id, "day");
            } 
            else if (obj.coso != null)
            {
                findNode = new TreeListOperationFindNodeByProductAndCountryValues(obj.coso.id, "coso");
            }
            treeListViTri.NodesIterator.DoOperation(findNode);
            treeListViTri.FocusedNode = findNode.Node;
        }
    }
}
