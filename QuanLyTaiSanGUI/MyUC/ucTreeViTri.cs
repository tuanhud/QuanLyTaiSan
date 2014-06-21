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
using QuanLyTaiSan.DataFilter;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeViTri : UserControl
    {
        int idTang = -1;
        int idCoSo = -1;
        int idDay = -1;
        bool haveTang = true;
        bool haveDay = true;
        public ucTreeViTri(List<ViTriFilter> _list, bool _haveDay, bool _haveTang)
        {
            InitializeComponent();
            loadData(_list, _haveDay, _haveTang);
        }

        private void loadData(List<ViTriFilter> _list, bool _haveDay, bool _haveTang)
        {
            haveTang = _haveTang;
            haveDay = _haveDay;
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node.GetValue(2).ToString().Equals(typeof(CoSo).Name))
                {
                    if (!haveDay || haveTang)
                    {
                        popupContainerEdit1.Text = e.Node.GetValue(1).ToString();
                        idCoSo = Convert.ToInt32(e.Node.GetValue(0));
                        idTang = -1;
                        idDay = -1;
                    }
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                {
                    popupContainerEdit1.Text = e.Node.ParentNode.GetValue(1).ToString() + " - " + e.Node.GetValue(1).ToString();
                    idCoSo = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                    idDay = Convert.ToInt32(e.Node.GetValue(0));
                    idTang = -1;
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Tang).Name))
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
        public void reLoad(List<ViTriFilter> _list)
        {
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = null;
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        public void setViTri(ViTri obj)
        {
            FindNode findNode = null;
            if (obj.tang != null)
            {
                findNode = new FindNode(obj.tang.id, typeof(Tang).Name);
            }
            else if (obj.day != null)
            {
                findNode = new FindNode(obj.day.id, typeof(Dayy).Name);
            } 
            else if (obj.coso != null)
            {
                findNode = new FindNode(obj.coso.id, typeof(CoSo).Name);
            }
            treeListViTri.NodesIterator.DoOperation(findNode);
            treeListViTri.FocusedNode = findNode.Node;
        }
    }
}
