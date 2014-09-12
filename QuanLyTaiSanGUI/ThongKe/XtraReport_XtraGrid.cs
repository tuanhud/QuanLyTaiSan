using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyTaiSanGUI.ThongKe
{
    public partial class XtraReport_XtraGrid : DevExpress.XtraReports.UI.XtraReport
    {
        DevExpress.XtraGrid.GridControl _GridControl = new DevExpress.XtraGrid.GridControl();

        public XtraReport_XtraGrid()
        {
            InitializeComponent();
            _GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            winControlContainer_GridControl.WinControl = _GridControl;
        }

        public XtraReport_XtraGrid(DevExpress.XtraGrid.GridControl _GridControl)
        {
            InitializeComponent();
            this._GridControl = _GridControl;
            this._GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            winControlContainer_GridControl.WinControl = this._GridControl;
        }

        public void SetGridControl(DevExpress.XtraGrid.GridControl _GridControl)
        {
            this._GridControl = _GridControl;
        }
    }
}
