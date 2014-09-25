using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;

namespace PTB_GUI.ThongKe
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

        public XtraReport_XtraGrid(DevExpress.XtraGrid.GridControl _GridControl, Boolean Landscape)
        {
            InitializeComponent();
            this.Landscape = Landscape;
            SetPositionXRLabel();
            this._GridControl = _GridControl;
            this._GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            SHARED.Libraries.ReportHelper.InitGridView(this._GridControl);
            winControlContainer_GridControl.WinControl = this._GridControl;
        }

        public void SetGridControl(DevExpress.XtraGrid.GridControl _GridControl)
        {
            this._GridControl = _GridControl;
        }

        private void SetPositionXRLabel()
        {
            int pageWidth = (PageWidth - (Margins.Left + Margins.Right));

            xrLabel_Title.LocationF = new DevExpress.Utils.PointFloat((float)((pageWidth - (int)Math.Ceiling(xrLabel_Title.WidthF)) * 1.0 / 2), xrLabel_Title.LocationF.Y);
            xrPageInfo_CurrentDay.LocationF = new DevExpress.Utils.PointFloat((float)(pageWidth - (int)Math.Ceiling(xrPageInfo_CurrentDay.WidthF)), xrPageInfo_CurrentDay.LocationF.Y);
            xrLabel_BanGiamHieu.LocationF = new DevExpress.Utils.PointFloat((float)(pageWidth - (int)Math.Ceiling(xrLabel_BanGiamHieu.WidthF)), xrLabel_BanGiamHieu.LocationF.Y);
            xrLabel_KeToanTruong.LocationF = new DevExpress.Utils.PointFloat((float)((pageWidth - (int)Math.Ceiling(xrLabel_KeToanTruong.WidthF)) * 1.0 / 2), xrLabel_KeToanTruong.LocationF.Y);
        }
    }
}
