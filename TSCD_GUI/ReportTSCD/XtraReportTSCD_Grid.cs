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

        public XtraReportTSCD_Grid(DevExpress.XtraGrid.GridControl _GridControl, Boolean Landscape)
        {
            InitializeComponent();
            this.Landscape = Landscape;
            this._GridControl = _GridControl;
            this._GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            InitGridView();
            winControlContainer_GridControl.WinControl = this._GridControl;
        }

        public void SetGridControl(DevExpress.XtraGrid.GridControl _GridControl)
        {
            this._GridControl = _GridControl;
        }

        private void InitGridView()
        {
            if (_GridControl.ViewCollection.Count > 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView _GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
                _GridView = _GridControl.ViewCollection[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                SetTheme(_GridView);
                _GridView.GroupSummary.Clear();

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

                                GridGroupSummaryItem itemTop = new GridGroupSummaryItem();
                                itemTop.FieldName = _GridView.Columns[i].FieldName;
                                itemTop.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                itemTop.DisplayFormat = "(" + _GridView.Columns[i].Caption + ": {0})";
                                _GridView.GroupSummary.Add(itemTop);

                                GridGroupSummaryItem itemDown = new GridGroupSummaryItem();
                                itemDown.FieldName = _GridView.Columns[i].FieldName;
                                itemDown.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                itemDown.DisplayFormat = "{0}";
                                itemDown.ShowInGroupColumnFooter = _GridView.Columns[i];
                                _GridView.GroupSummary.Add(itemDown);
                            }
                        }
                    }
                }
            }
        }

        private void SetTheme(DevExpress.XtraGrid.Views.Grid.GridView _GridView)
        {
            _GridView.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            _GridView.AppearancePrint.FooterPanel.Options.UseForeColor = true;

            _GridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.GroupFooter.Options.UseBackColor = true;

            _GridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.GroupRow.Options.UseBackColor = true;
            _GridView.AppearancePrint.GroupRow.Options.UseForeColor = true;

            _GridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
        }
    }
}
