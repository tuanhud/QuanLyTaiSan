using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

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
            SetSumColumn();
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

        private void SetSumColumn()
        {
            if (_GridControl.ViewCollection.Count > 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView _GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
                _GridView = _GridControl.ViewCollection[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                for (int i = 0; i < _GridView.Columns.Count; i++)
                {
                    if (_GridView.Columns[i].Visible && _GridView.Columns[i].GroupIndex < 0)
                    {
                        if (!Object.Equals(_GridView.GetRowCellValue(0, _GridView.Columns[i]), null))
                        {
                            if (SHARED.Libraries.StringHelper.IsNumber(_GridView.GetRowCellValue(0, _GridView.Columns[i]).ToString()))
                            {
                                _GridView.Columns[i].SummaryItem.Collection.Clear();
                                _GridView.Columns[i].Summary.Add(DevExpress.Data.SummaryItemType.Sum, _GridView.Columns[i].FieldName, "{0}");
                            }
                        }
                    }
                }
            }
        }
    }
}
