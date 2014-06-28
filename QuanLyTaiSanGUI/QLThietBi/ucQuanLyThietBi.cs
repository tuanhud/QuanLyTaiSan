using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi : UserControl
    {
        ucQuanLyThietBi_Control _ucQuanLyThietBi_Control = new ucQuanLyThietBi_Control();
        List<ThietBiHienThi> listThietBi = null;
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();
        public ucQuanLyThietBi()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonThietBi.Parent = null;
            _ucQuanLyThietBi_Control.Parent = this;
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
        }

        public PanelControl getControl()
        {
            return _ucQuanLyThietBi_Control.getControl();
        }

        public RibbonControl getRibbon()
        {
            return ribbonThietBi;
        }

        public void loadData(bool _loaichung)
        {
            listThietBi = new ThietBiHienThi().getAllByTypeLoai(_loaichung);
            gridControlThietBi.DataSource = listThietBi;
            List<LoaiThietBi> listLoaiTB = new LoaiThietBi().getAll();
            _ucTreeLoaiTB.loadData(listLoaiTB);
        }
    }
}
