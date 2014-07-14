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
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Localization;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucComboBoxViTri : UserControl
    {
        int idTang = -1;
        int idCoSo = -1;
        int idDay = -1;
        int idPhong = -1;
        bool chonDay = false;
        bool chonPhong = false;
        public ucComboBoxViTri(bool _chonDay, bool _chonPhong)
        {
            InitializeComponent();
            init(_chonDay, _chonPhong);
        }

        private void init(bool _chonDay, bool _chonPhong)
        {
            chonDay = _chonDay;
            chonPhong = _chonPhong;
            //treeListViTri.Columns[colten.FieldName].SortOrder = SortOrder.Ascending;
            treeListViTri.Columns[colid.FieldName].SortOrder = SortOrder.Ascending;
        }

        public void loadData(List<ViTriHienThi> _list)
        {
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
                    if (!chonDay && !chonPhong)
                    {
                        popupContainerEdit1.Text = e.Node.GetValue(1).ToString();
                        idCoSo = Convert.ToInt32(e.Node.GetValue(0));
                        idTang = -1;
                        idDay = -1;
                        popupContainerEdit1.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                {
                    if (!chonPhong)
                    {
                        popupContainerEdit1.Text = e.Node.ParentNode.GetValue(1).ToString() + " - " + e.Node.GetValue(1).ToString();
                        idCoSo = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                        idDay = Convert.ToInt32(e.Node.GetValue(0));
                        idTang = -1;
                        popupContainerEdit1.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Tang).Name))
                {
                    if (!chonPhong)
                    {
                        popupContainerEdit1.Text = e.Node.ParentNode.ParentNode.GetValue(1).ToString() + " - " + e.Node.ParentNode.GetValue(1).ToString() + " - " + e.Node.GetValue(1).ToString();
                        idCoSo = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                        idDay = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                        idTang = Convert.ToInt32(e.Node.GetValue(0));
                        popupContainerEdit1.ClosePopup();
                    }
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Phong).Name))
                {
                    popupContainerEdit1.Text = e.Node.GetValue(1).ToString();
                    idPhong = Convert.ToInt32(e.Node.GetValue(0));
                    popupContainerEdit1.ClosePopup();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : treeListViTri_FocusedNodeChanged : " + ex.Message);
            }
            finally
            { }
        }

        public ViTri getViTri()
        {
            try
            {
                ViTri objViTri = new ViTri();
                CoSo objCoSo = CoSo.getById(idCoSo);
                Dayy objDay = Dayy.getById(idDay);
                Tang objTang = Tang.getById(idTang);
                objViTri.coso = objCoSo;
                objViTri.day = objDay;
                objViTri.tang = objTang;
                return objViTri;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : getViTri : " + ex.Message);
                return null;
            }
            finally
            { }
        }

        public Phong getPhong()
        {
            try
            {
                Phong obj = Phong.getById(idPhong);
                return obj;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : getPhong : " + ex.Message);
                return null;
            }
            finally
            { }
        }

        public void setPhong(Phong obj)
        {
            try
            {
                FindNode findNode = null;
                findNode = new FindNode(obj.id, typeof(Phong).Name);
                treeListViTri.NodesIterator.DoOperation(findNode);
                treeListViTri.FocusedNode = findNode.Node;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setPhong : " + ex.Message);
            }
            finally
            { }
        }
        
        public void setReadOnly(bool b)
        {
            popupContainerEdit1.Properties.ReadOnly = b;
        }


        public void reLoad(List<ViTriHienThi> _list)
        {
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = null;
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        //public void reLoad(List<ViTriFilter> _list)
        //{
        //    treeListViTri.BeginUnboundLoad();
        //    treeListViTri.DataSource = null;
        //    treeListViTri.DataSource = _list;
        //    treeListViTri.EndUnboundLoad();
        //}


        public void setViTri(ViTri obj)
        {
            try
            {
                if (obj != null)
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
                    if (findNode != null)
                    {
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setViTri : " + ex.Message);
            }
            finally
            { }
        }

        public void setTextPopupContainerEdit(String text)
        {
            popupContainerEdit1.Text = text;
        }

        public String getTextPopupContainerEdit()
        {
            return popupContainerEdit1.Text;
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListViTri.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListViTri.FindFilterText;
            if (node.GetDisplayText(column).ToUpper().Contains(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }
    }
}
