using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

namespace TSCD_GUI.ThongKe
{
    public partial class ucThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        ucTKPhong _ucTKPhong = new ucTKPhong();
        ucTKTaiSan _ucTKTaiSan = new ucTKTaiSan();
        Control current = null;

        public ucThongKe()
        {
            InitializeComponent();
            rbnControlThongKe.Parent = null;
            _ucTKPhong.Dock = DockStyle.Fill;
            _ucTKTaiSan.Dock = DockStyle.Fill;
        }

        public RibbonControl getRibbonControl()
        {
            return rbnControlThongKe;
        }

        public void loadData()
        {
            barBtnTKTaiSan.PerformClick();
        }

        private void barBtnTKPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKPhong.Down)
                barBtnTKPhong.Down = true;
            else
            {
                barBtnTKTaiSan.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKPhong);
                current = _ucTKPhong;
                _ucTKPhong.loadData();
            }
        }

        private void barBtnExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKPhong))
            {
                _ucTKPhong.ExpandAllGroups();
            }
            else if (current.Equals(_ucTKTaiSan))
            {
                _ucTKTaiSan.ExpandAllGroups();
            }
        }

        private void barBtnCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKPhong))
            {
                _ucTKPhong.CollapseAllGroups();
            }
            else if (current.Equals(_ucTKTaiSan))
            {
                _ucTKTaiSan.CollapseAllGroups();
            }
        }

        private void barBtnTKTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKTaiSan.Down)
                barBtnTKTaiSan.Down = true;
            else
            {
                barBtnTKPhong.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKTaiSan);
                current = _ucTKTaiSan;
                _ucTKTaiSan.loadData();
            }
        }

        private void barBtnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(current.Equals(_ucTKTaiSan))
            {
                _ucTKTaiSan.loadLayout(true);
            }
        }
    }
}
