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
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSanGUI.MyUserControl;
using QuanLyTaiSanGUI.QLThietBi;
using DevExpress.XtraTreeList.Columns;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeViTri : UserControl
    {
        public int phongid = -1;
        public int cosoid = -1;
        public int dayid = -1;
        public int tangid = -1;
        public String type = "";
        public ucTreeViTri(String _type)
        {
            InitializeComponent();
            init(_type);
        }

        private void init(String _type)
        {
            type = _type;
            treeListViTri.Columns[colten.FieldName].SortOrder = SortOrder.Ascending;
        }

        public void loadData(List<ViTriHienThi> _list)
        {
            treeListViTri.BeginUnboundLoad();
            treeListViTri.DataSource = _list;
            treeListViTri.EndUnboundLoad();
        }

        //public void reLoad(List<ViTriHienThi> _list)
        //{
        //    loadData(_list, type);
        //}

        private void treeListPhong_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                phongid = -1;
                cosoid = -1;
                dayid = -1;
                tangid = -1;
                if(e.Node.GetValue(2)!= null)
                {
                    switch (e.Node.GetValue(2).ToString())
                    {
                        case "CoSo":
                            cosoid = Convert.ToInt32(e.Node.GetValue(0));
                            break;
                        case "Dayy":
                            dayid = Convert.ToInt32(e.Node.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            break;
                        case "Tang":
                            tangid = Convert.ToInt32(e.Node.GetValue(0));
                            dayid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                            break;
                        case "Phong":
                            phongid = Convert.ToInt32(e.Node.GetValue(0));
                            break;
                    }
                    if (this.ParentForm != null)
                    {
                        frmMain frm = this.ParentForm as frmMain;
                        switch (type)
                        {
                            case "QLPhong":
                                {
                                    if (this.Parent != null)
                                    {
                                        ucQuanLyPhong _ucQuanLyPhong = this.Parent as ucQuanLyPhong;
                                        _ucQuanLyPhong.setData(cosoid, dayid, tangid);                                        
                                    }
                                }
                                break;
                            case "QLPhongThietBi":
                                {
                                    if (this.Parent != null)
                                    {
                                        ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = this.Parent as ucQuanLyPhongThietBi;
                                        _ucQuanLyPhongThietBi.setData(cosoid, dayid, tangid);
                                    }
                                }
                                break;
                            case "QLThietBi":
                                {
                                    if (this.Parent != null)
                                    {
                                        ucQuanLyThietBi_Old _ucQuanLyThietBi = this.Parent as ucQuanLyThietBi_Old;
                                        _ucQuanLyThietBi.setData(phongid, cosoid, dayid, tangid);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : treeListPhong_FocusedNodeChanged : " + ex.Message);
            }
            finally
            { }
        }

        public ViTri getVitri()
        {
            try
            {
                ViTri obj = new ViTri();
                obj.coso = new CoSo().getById(cosoid);
                obj.day = new Dayy().getById(dayid);
                obj.tang = new Tang().getById(tangid);
                return obj;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : getVitri : " + ex.Message);
                return null;
            }
            finally
            { }
        }

        public TreeList getTreeList()
        {
            return treeListViTri;
        }

        public void setVitri(ViTri obj)
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
                        treeListViTri.CollapseAll();
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setVitri : " + ex.Message);
            }
            finally
            { }
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
            if (node.GetDisplayText(column).ToUpper().StartsWith(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }

    }
}
