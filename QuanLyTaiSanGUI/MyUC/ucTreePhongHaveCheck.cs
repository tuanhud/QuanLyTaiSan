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
        public ucTreePhongHaveCheck()
        {
            InitializeComponent();
        }

        public void loadData(List<ViTriFilter> list)
        {
            treeListPhong.DataSource = list;
        }
    }
}
