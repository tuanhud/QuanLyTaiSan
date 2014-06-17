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

namespace QuanLyTaiSanGUI.QLLoaiThietBi
{
    public partial class ucQuanLyLoaiTB : UserControl
    {
        List<LoaiThietBi> listLoaiTBs = new List<LoaiThietBi>();
        public ucQuanLyLoaiTB()
        {
            InitializeComponent();
            listLoaiTBs = new LoaiThietBi().getAll().ToList();
            treeListLoaiTB.DataSource = listLoaiTBs;
            lookUpEdit1.Properties.DataSource = listLoaiTBs;
        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (treeListLoaiTB.GetDataRecordByNode(e.Node) != null)
            {
                LoaiThietBi obj = (LoaiThietBi)treeListLoaiTB.GetDataRecordByNode(e.Node);
                txtten.Text = obj.ten;
                lookUpEdit1.EditValue = obj.parent_id;
            }
        }
    }
}
