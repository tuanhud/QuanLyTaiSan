using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReportTSCD_Grid : DevExpress.XtraReports.UI.XtraReport
    {
        DevExpress.XtraGrid.GridControl _GridControl = new DevExpress.XtraGrid.GridControl();

        public XtraReportTSCD_Grid()
        {
            InitializeComponent();
            _GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            winControlContainer_GridControl.WinControl = _GridControl;
        }

        public XtraReportTSCD_Grid(DevExpress.XtraGrid.GridControl _GridControl)
        {
            InitializeComponent();
            this._GridControl = _GridControl;
            this._GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            SHARED.Libraries.ReportHelper.InitGridView(this._GridControl);
            winControlContainer_GridControl.WinControl = this._GridControl;
        }

        public void SetGridControl(DevExpress.XtraGrid.GridControl _GridControl)
        {
            this._GridControl = _GridControl;
        }
    }
}
