using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars.Ribbon;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi : UserControl
    {
        ucTreePhong _ucTreePhong = null;
        List<ThietBiFilter> listThietBi = null;
        public ucQuanLyThietBi()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ribbonThietBi.Parent = null;
            List<ViTriFilter> list = new ViTriFilter().getAllHavePhong();
            _ucTreePhong = new ucTreePhong(list, "QLThietBi");
            _ucTreePhong.Parent = this;
            listThietBi = new ThietBiFilter().getAllBy4Id(-1,-1,-1,-1);
            gridControlThietBi.DataSource = listThietBi;
        }

        public TreeList getTreeList()
        {
            return _ucTreePhong.getTreeList();
        }

        public void setData(int phongid, int cosoid, int dayid, int tangid)
        {
            listThietBi = new ThietBiFilter().getAllBy4Id(phongid, cosoid, dayid, tangid);
            gridControlThietBi.DataSource = null;
            gridControlThietBi.DataSource = listThietBi;
        }

        public RibbonControl getRibbon()
        {
            return ribbonThietBi;  
        }
    }
}
