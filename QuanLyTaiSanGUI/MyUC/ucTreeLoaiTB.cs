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
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeLoaiTB : UserControl
    {
        LoaiThietBi obj = new LoaiThietBi();
        List<LoaiThietBi> listLoaiThietBi = new List<LoaiThietBi>();
        public String type = "";
        bool haveCheck = false;
        public ucTreeLoaiTB()
        {
            InitializeComponent();
            init();
        }

        public ucTreeLoaiTB(bool _haveCheck)
        {
            InitializeComponent();
            treeListLoaiTB.OptionsBehavior.AllowRecursiveNodeChecking = true;
            treeListLoaiTB.OptionsView.ShowCheckBoxes = true;
            haveCheck = _haveCheck;
            init();
        }

        public void init()
        {
            treeListLoaiTB.Columns[colten.FieldName].SortOrder = SortOrder.Ascending;
        }

        public List<LoaiThietBi> getListLoaiTB()
        {
            try
            {
                List<LoaiThietBi> list = new List<LoaiThietBi>();
                GetCheckedNodes op = new GetCheckedNodes();
                treeListLoaiTB.NodesIterator.DoOperation(op);
                foreach (TreeListNode node in op.CheckedNodes)
                {
                    LoaiThietBi obj = LoaiThietBi.getById(Convert.ToInt32(node.GetValue(0)));
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : getListLoaiTB : " + ex.Message);
                return null;
            }
            finally
            { }
        }

        public void loadData(List<LoaiThietBi> _list)
        {
            listLoaiThietBi = new List<LoaiThietBi>(_list);
            treeListLoaiTB.BeginUnboundLoad();
            treeListLoaiTB.DataSource = _list;
            treeListLoaiTB.EndUnboundLoad();
        }

        public void setLoai(LoaiThietBi _loai)
        {
            try
            {
                obj = _loai;
                Console.WriteLine(listLoaiThietBi.Count.ToString());
                treeListLoaiTB.CollapseAll();
                TreeListNode node = treeListLoaiTB.FindNodeByFieldValue("id", _loai.id);
                treeListLoaiTB.FocusedNode = node;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setLoai : " + ex.Message);
            }
            finally
            { }
        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (!haveCheck)
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
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : treeListLoaiTB_FocusedNodeChanged : " + ex.Message);
            }
            finally
            { }
        }

        public void setReadOnly(bool b)
        {
            popupContainerEdit1.Properties.ReadOnly = b;
        }


        public void setTextPopupContainerEdit(String text)
        {
            popupContainerEdit1.Text = text;
            popupContainerEdit1.ClosePopup();
        }

        public String setTextPopupContainerEdit()
        {
            return popupContainerEdit1.Text;
        }

        public LoaiThietBi getLoaiThietBi()
        {
            if (obj.id > 0)
                return LoaiThietBi.getById(obj.id);
            return null;
        }

        private void treeListLoaiTB_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                if (haveCheck)
                {
                    String str = "";
                    List<LoaiThietBi> list = getListLoaiTB();
                    foreach (LoaiThietBi loaiTB in list)
                    {
                        str += loaiTB.ten + ", ";
                    }
                    if (str.Length > 2)
                    {
                        str = str.Substring(0, str.Length - 2);
                    }
                    popupContainerEdit1.Text = str;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : treeListLoaiTB_AfterCheckNode : " + ex.Message);
            }
            finally
            { }
        }
    }
}
