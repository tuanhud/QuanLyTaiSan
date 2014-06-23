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

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreePhongHaveCheck : UserControl
    {
        List<ViTriFilter> listVT = null;
        int idTang = -1;
        int idCoSo = -1;
        int idDay = -1;
        int idPhong = -1;
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
            try
            {
                if (e.Node.GetValue(2).ToString().Equals(typeof(CoSo).Name))
                {
                    idCoSo = Convert.ToInt32(e.Node.GetValue(0));
                    idTang = -1;
                    idDay = -1;
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                {
                    idCoSo = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                    idDay = Convert.ToInt32(e.Node.GetValue(0));
                    idTang = -1;
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Tang).Name))
                {
                    idCoSo = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                    idDay = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                    idTang = Convert.ToInt32(e.Node.GetValue(0));
                }
                else if (e.Node.GetValue(2).ToString().Equals(typeof(Phong).Name))
                {
                    idPhong = Convert.ToInt32(e.Node.GetValue(0));
                }
            }
            catch (Exception ex)
            { }
            finally
            { }
        }
    }
}
