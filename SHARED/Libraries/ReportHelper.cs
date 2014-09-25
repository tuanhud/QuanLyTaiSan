using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHARED.Libraries
{
    public class ReportHelper
    {
        public static void SetTheme(DevExpress.XtraGrid.Views.Grid.GridView _GridView)
        {
            _GridView.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.EvenRow.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.EvenRow.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.EvenRow.Options.UseBackColor = true;
            _GridView.AppearancePrint.EvenRow.Options.UseForeColor = true;
            _GridView.AppearancePrint.EvenRow.Options.UseBorderColor = true;

            _GridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.FilterPanel.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.FilterPanel.Options.UseBackColor = true;
            _GridView.AppearancePrint.FilterPanel.Options.UseForeColor = true;
            _GridView.AppearancePrint.FilterPanel.Options.UseBorderColor = true;

            _GridView.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            _GridView.AppearancePrint.FooterPanel.Options.UseForeColor = true;
            _GridView.AppearancePrint.FooterPanel.Options.UseBorderColor = true;

            _GridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            _GridView.AppearancePrint.GroupFooter.Options.UseForeColor = true;
            _GridView.AppearancePrint.GroupFooter.Options.UseBorderColor = true;

            _GridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.GroupRow.Options.UseBackColor = true;
            _GridView.AppearancePrint.GroupRow.Options.UseForeColor = true;
            _GridView.AppearancePrint.GroupRow.Options.UseBorderColor = true;

            _GridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            _GridView.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            _GridView.AppearancePrint.HeaderPanel.Options.UseBorderColor = true;

            _GridView.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.OddRow.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.OddRow.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.OddRow.Options.UseBackColor = true;
            _GridView.AppearancePrint.OddRow.Options.UseForeColor = true;
            _GridView.AppearancePrint.OddRow.Options.UseBorderColor = true;

            _GridView.AppearancePrint.Row.BackColor = System.Drawing.Color.White;
            _GridView.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black;
            _GridView.AppearancePrint.Row.Options.UseBackColor = true;
            _GridView.AppearancePrint.Row.Options.UseForeColor = true;
            _GridView.AppearancePrint.Row.Options.UseBorderColor = true;
        }

        public static void SetTheme(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView)
        {
            _BandedGridView.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.BandPanel.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.BandPanel.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.BandPanel.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.BandPanel.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.EvenRow.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.EvenRow.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.EvenRow.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.EvenRow.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.EvenRow.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.FilterPanel.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.FilterPanel.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.FilterPanel.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.FilterPanel.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.FooterPanel.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.FooterPanel.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.GroupFooter.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.GroupFooter.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.GroupRow.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.GroupRow.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.GroupRow.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.HeaderPanel.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.OddRow.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.OddRow.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.OddRow.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.OddRow.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.OddRow.Options.UseBorderColor = true;

            _BandedGridView.AppearancePrint.Row.BackColor = System.Drawing.Color.White;
            _BandedGridView.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black;
            _BandedGridView.AppearancePrint.Row.Options.UseBackColor = true;
            _BandedGridView.AppearancePrint.Row.Options.UseForeColor = true;
            _BandedGridView.AppearancePrint.Row.Options.UseBorderColor = true;
        }

        public static void InitGridView(DevExpress.XtraGrid.GridControl _GridControl)
        {
            //BandedGridView
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            Boolean isBandedGridView = true;
            try
            {
                _BandedGridView = _GridControl.MainView as DevExpress.XtraGrid.Views.BandedGrid.BandedGridView;
            }
            catch
            {
                isBandedGridView = false;
            }
            if (isBandedGridView)
            {
                if (!Object.Equals(_BandedGridView, null))
                {
                    SetTheme(_BandedGridView);
                    _BandedGridView.GroupSummary.Clear();
                    for (int i = 0; i < _BandedGridView.Columns.Count; i++)
                    {
                        if (_BandedGridView.Columns[i].Visible && _BandedGridView.Columns[i].GroupIndex < 0)
                        {
                            if (!Object.Equals(_BandedGridView.GetRowCellValue(0, _BandedGridView.Columns[i]), null))
                            {
                                if (SHARED.Libraries.StringHelper.IsNumber(_BandedGridView.GetRowCellValue(0, _BandedGridView.Columns[i]).ToString()))
                                {
                                    _BandedGridView.Columns[i].SummaryItem.Collection.Clear();
                                    _BandedGridView.Columns[i].Summary.Add(DevExpress.Data.SummaryItemType.Sum, _BandedGridView.Columns[i].FieldName, "{0}");

                                    GridGroupSummaryItem itemTop = new GridGroupSummaryItem();
                                    itemTop.FieldName = _BandedGridView.Columns[i].FieldName;
                                    itemTop.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                    itemTop.DisplayFormat = "(" + _BandedGridView.Columns[i].Caption + ": {0})";
                                    _BandedGridView.GroupSummary.Add(itemTop);

                                    GridGroupSummaryItem itemDown = new GridGroupSummaryItem();
                                    itemDown.FieldName = _BandedGridView.Columns[i].FieldName;
                                    itemDown.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                    itemDown.DisplayFormat = "{0}";
                                    itemDown.ShowInGroupColumnFooter = _BandedGridView.Columns[i];
                                    _BandedGridView.GroupSummary.Add(itemDown);
                                }
                            }
                        }
                    }
                }
            }


            //GridView
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
    }
}
