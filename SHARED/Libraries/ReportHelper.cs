using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SHARED.Libraries
{
    public class ReportHelper
    {
        public struct structColumn
        {
            public string Caption { get; set; }
            public string FieldName { get; set; }
            public int VisibleIndex { get; set; }
            public Boolean IsNumber { get; set; }
        }

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

        public static DataSet FillDatasetFromGrid(DevExpress.XtraGrid.Views.Grid.GridView _GridView)
        {
            DataSet _DataSet = new DataSet();
            DataTable _DataTable = new DataTable();
            if (!Object.Equals(_GridView, null))
            {
                foreach (GridColumn _GridColumn in _GridView.Columns)
                {
                    _DataTable.Columns.Add(_GridColumn.Name + "_" + _GridColumn.FieldName, Nullable.GetUnderlyingType(_GridColumn.ColumnType) ?? _GridColumn.ColumnType);
                    if (!(_GridColumn.Visible && _GridColumn.GroupIndex < 0))
                    {
                        if (Object.Equals(_GridColumn.ColumnType, typeof(Int32)) || Object.Equals(_GridColumn.ColumnType, typeof(float)) || Object.Equals(_GridColumn.ColumnType, typeof(DateTime)))
                        {
                            _DataTable.Columns.Add(_GridColumn.Name + "_" + _GridColumn.FieldName + "_STRING", typeof(String));
                        }
                    }
                }
                for (int i = 0; i < _GridView.DataRowCount; i++)
                {
                    DataRow _DataRow = _DataTable.NewRow();
                    foreach (GridColumn _GridColumn in _GridView.Columns)
                    {
                        var Value = _GridView.GetRowCellValue(i, _GridColumn);
                        if (Object.Equals(Value, null))
                        {
                            _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName] = DBNull.Value;
                        }
                        else
                        {
                            _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName] = _GridView.GetRowCellValue(i, _GridColumn);
                        }

                        if (!(_GridColumn.Visible && _GridColumn.GroupIndex < 0))
                        {
                            if (Object.Equals(_GridColumn.ColumnType, typeof(Int32)) || Object.Equals(_GridColumn.ColumnType, typeof(float)) || Object.Equals(_GridColumn.ColumnType, typeof(DateTime)))
                            {
                                var Value_String = _GridView.GetRowCellValue(i, _GridColumn);
                                if (Object.Equals(Value_String, null))
                                {
                                    _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName + "_STRING"] = "";
                                }
                                else
                                {
                                    _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName + "_STRING"] = _GridView.GetRowCellValue(i, _GridColumn);
                                }
                            }
                        }
                    }
                    _DataTable.Rows.Add(_DataRow);
                }
            }
            _DataSet.Tables.Add(_DataTable);
            return _DataSet;
        }

        public static DataSet FillDatasetFromGrid(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView)
        {
            DataSet _DataSet = new DataSet();
            DataTable _DataTable = new DataTable();
            if (!Object.Equals(_BandedGridView, null))
            {
                foreach (GridColumn _GridColumn in _BandedGridView.Columns)
                {
                    _DataTable.Columns.Add(_GridColumn.Name + "_" + _GridColumn.FieldName, Nullable.GetUnderlyingType(_GridColumn.ColumnType) ?? _GridColumn.ColumnType);
                    if (!(_GridColumn.Visible && _GridColumn.GroupIndex < 0))
                    {
                        if (Object.Equals(_GridColumn.ColumnType, typeof(Int32)) || Object.Equals(_GridColumn.ColumnType, typeof(float)) || Object.Equals(_GridColumn.ColumnType, typeof(DateTime)))
                        {
                            _DataTable.Columns.Add(_GridColumn.Name + "_" + _GridColumn.FieldName + "_STRING", typeof(String));
                        }
                    }
                }
                for (int i = 0; i < _BandedGridView.DataRowCount; i++)
                {
                    DataRow _DataRow = _DataTable.NewRow();
                    foreach (GridColumn _GridColumn in _BandedGridView.Columns)
                    {
                        var Value = _BandedGridView.GetRowCellValue(i, _GridColumn);
                        if (Object.Equals(Value, null))
                        {
                            _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName] = DBNull.Value;
                        }
                        else
                        {
                            _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName] = _BandedGridView.GetRowCellValue(i, _GridColumn);
                        }

                        if (!(_GridColumn.Visible && _GridColumn.GroupIndex < 0))
                        {
                            if (Object.Equals(_GridColumn.ColumnType, typeof(Int32)) || Object.Equals(_GridColumn.ColumnType, typeof(float)) || Object.Equals(_GridColumn.ColumnType, typeof(DateTime)))
                            {
                                var Value_String = _BandedGridView.GetRowCellValue(i, _GridColumn);
                                if (Object.Equals(Value_String, null))
                                {
                                    _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName + "_STRING"] = "";
                                }
                                else
                                {
                                    _DataRow[_GridColumn.Name + "_" + _GridColumn.FieldName + "_STRING"] = _BandedGridView.GetRowCellValue(i, _GridColumn);
                                }
                            }
                        }
                    }
                    _DataTable.Rows.Add(_DataRow);
                }
            }
            _DataSet.Tables.Add(_DataTable);
            return _DataSet;
        }

        public static void CreateGroupValues(DataSet _DataSet, DevExpress.XtraGrid.Views.Grid.GridView _GridView, ref int MaxLength, String strTag)
        {
            if (_DataSet.Tables[0] != null)
            {
                if (_GridView.GroupCount > 0)
                {
                    for (int i = 0; i < _GridView.GroupedColumns.Count; i++)
                    {
                        foreach (DataColumn _DataColumn in _DataSet.Tables[0].Columns)
                        {
                            if (Object.Equals(_DataColumn.ColumnName, _GridView.GroupedColumns[i].Name + "_" + _GridView.GroupedColumns[i].FieldName))
                            {
                                foreach (DataRow row in _DataSet.Tables[0].Rows)
                                {
                                    string strGroup = string.Format("{0}: {1}", _GridView.GroupedColumns[i].Caption, Object.Equals(row[_DataColumn.ColumnName], DBNull.Value) ? "" : row[_DataColumn.ColumnName]);
                                    if (Object.Equals(_GridView.GroupedColumns[i].ColumnType, typeof(Int32)) || Object.Equals(_GridView.GroupedColumns[i].ColumnType, typeof(float)) || Object.Equals(_GridView.GroupedColumns[i].ColumnType, typeof(DateTime)))
                                    {
                                        row[_DataColumn.ColumnName + strTag] = strGroup;
                                    }
                                    else
                                    {
                                        row[_DataColumn.ColumnName] = strGroup;
                                    }
                                    if (MaxLength < strGroup.Length)
                                        MaxLength = strGroup.Length;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void CreateGroupValues(DataSet _DataSet, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView, ref int MaxLength, String strTag)
        {
            if (_DataSet.Tables[0] != null)
            {
                if (_BandedGridView.GroupCount > 0)
                {
                    for (int i = 0; i < _BandedGridView.GroupedColumns.Count; i++)
                    {
                        foreach (DataColumn _DataColumn in _DataSet.Tables[0].Columns)
                        {
                            if (Object.Equals(_DataColumn.ColumnName, _BandedGridView.GroupedColumns[i].Name + "_" + _BandedGridView.GroupedColumns[i].FieldName))
                            {
                                foreach (DataRow row in _DataSet.Tables[0].Rows)
                                {
                                    string strGroup = string.Format("{0}: {1}", _BandedGridView.GroupedColumns[i].Caption, Object.Equals(row[_DataColumn.ColumnName], DBNull.Value) ? "" : row[_DataColumn.ColumnName]);
                                    if (Object.Equals(_BandedGridView.GroupedColumns[i].ColumnType, typeof(Int32)) || Object.Equals(_BandedGridView.GroupedColumns[i].ColumnType, typeof(float)) || Object.Equals(_BandedGridView.GroupedColumns[i].ColumnType, typeof(DateTime)))
                                    {
                                        row[_DataColumn.ColumnName + strTag] = strGroup;
                                    }
                                    else
                                    {
                                        row[_DataColumn.ColumnName] = strGroup;
                                    }
                                    if (MaxLength < strGroup.Length)
                                        MaxLength = strGroup.Length;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static List<structColumn> GetListColumnsVisible(DevExpress.XtraGrid.Views.Grid.GridView _GridView)
        {
            List<structColumn> ListColumns = new List<structColumn>();
            try
            {
                if (_GridView != null)
                {
                    for (int i = 0; i < _GridView.Columns.Count; i++)
                    {
                        if (_GridView.Columns[i].Visible && _GridView.Columns[i].GroupIndex < 0)
                        {
                            structColumn _structColumn = new structColumn();
                            _structColumn.Caption = _GridView.Columns[i].Caption;
                            _structColumn.FieldName = _GridView.Columns[i].Name + "_" + _GridView.Columns[i].FieldName;
                            _structColumn.VisibleIndex = _GridView.Columns[i].VisibleIndex;
                            _structColumn.IsNumber = false;
                            if (!Object.Equals(_GridView.GetRowCellValue(0, _GridView.Columns[i]), null))
                            {
                                if (SHARED.Libraries.StringHelper.IsNumber(_GridView.GetRowCellValue(0, _GridView.Columns[i]).ToString()))
                                {
                                    _structColumn.IsNumber = true;
                                }
                            }
                            ListColumns.Add(_structColumn);
                        }
                    }
                    ListColumns = ListColumns.OrderBy(item => item.VisibleIndex).ToList();
                }
            }
            catch
            { }
            return ListColumns;
        }

        public static List<structColumn> GetListColumnsVisible(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView)
        {
            List<structColumn> ListColumns = new List<structColumn>();
            try
            {
                if (_BandedGridView != null)
                {
                    for (int i = 0; i < _BandedGridView.Columns.Count; i++)
                    {
                        if (_BandedGridView.Columns[i].Visible && _BandedGridView.Columns[i].GroupIndex < 0)
                        {
                            structColumn _structColumn = new structColumn();
                            _structColumn.Caption = _BandedGridView.Columns[i].Caption;
                            _structColumn.FieldName = _BandedGridView.Columns[i].Name + "_" + _BandedGridView.Columns[i].FieldName;
                            _structColumn.VisibleIndex = _BandedGridView.Columns[i].VisibleIndex;
                            _structColumn.IsNumber = false;
                            if (!Object.Equals(_BandedGridView.GetRowCellValue(0, _BandedGridView.Columns[i]), null))
                            {
                                if (SHARED.Libraries.StringHelper.IsNumber(_BandedGridView.GetRowCellValue(0, _BandedGridView.Columns[i]).ToString()))
                                {
                                    _structColumn.IsNumber = true;
                                }
                            }
                            ListColumns.Add(_structColumn);
                        }
                    }
                    ListColumns = ListColumns.OrderBy(item => item.VisibleIndex).ToList();
                }
            }
            catch
            { }
            return ListColumns;
        }

        public static XRTable CreateLastSUMTable(XtraReport _XtraReport, List<structColumn> ListColumns, int GroupColumnLength, int pageWidth, int colWidth)
        {
            if (ListColumns.Where(item => item.IsNumber == true).ToList().Count > 0)
            {
                XRTable XRTable_Sum = new XRTable();
                XRTableRow XRTableRow_Sum = new XRTableRow();

                XRTableCell XRTableCell_CellFirst = new XRTableCell();
                XRTableCell_CellFirst.Width = GroupColumnLength;
                XRTableCell_CellFirst.Text = "";

                XRTableRow_Sum.Cells.Add(XRTableCell_CellFirst);

                for (int i = 0; i < ListColumns.Count; i++)
                {
                    XRTableCell XRTableCell_Cell = new XRTableCell();
                    XRTableCell_Cell.Width = (int)colWidth;

                    if (ListColumns[i].IsNumber)
                    {
                        XRTableCell_Cell.DataBindings.Add("Text", _XtraReport.DataSource, ListColumns[i].FieldName);
                        XRTableCell_Cell.Summary.IgnoreNullValues = true;
                        XRTableCell_Cell.Summary.Func = SummaryFunc.Sum;
                        XRTableCell_Cell.Summary.Running = SummaryRunning.Report;
                        XRTableCell_Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    }
                    else
                    {
                        XRTableCell_Cell.Text = "";
                    }

                    XRTableRow_Sum.Cells.Add(XRTableCell_Cell);
                }
                XRTable_Sum.Rows.Add(XRTableRow_Sum);
                XRTable_Sum.Width = pageWidth;
                XRTable_Sum.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);

                return XRTable_Sum;
            }
            return null;
        }

        public static XRTable CreatePageHeaderTable(List<structColumn> ListColumns, int pageWidth, int colWidth, Boolean HaveColumnGroup, int GroupColumnLength)
        {
            try
            {
                XRTable XRTable_PageHeader = new XRTable();
                XRTableRow XRTableRow_PageHeader = new XRTableRow();
                if (HaveColumnGroup)
                {
                    XRTableCell XRTableCell_Cell = new XRTableCell();

                    XRTableCell_Cell.Width = GroupColumnLength;
                    XRTableCell_Cell.Text = "Nhóm";
                    XRTableRow_PageHeader.Cells.Add(XRTableCell_Cell);
                }
                for (int i = 0; i < ListColumns.Count; i++)
                {
                    XRTableCell XRTableCell_Cell = new XRTableCell();
                    XRTableCell_Cell.Width = (int)colWidth;
                    XRTableCell_Cell.Text = ListColumns[i].Caption;
                    XRTableRow_PageHeader.Cells.Add(XRTableCell_Cell);
                }
                XRTable_PageHeader.Rows.Add(XRTableRow_PageHeader);
                XRTable_PageHeader.Width = pageWidth;
                XRTable_PageHeader.Name = "XRTable_PageHeader";

                return XRTable_PageHeader;
            }
            catch { }
            return null;
        }
    }
}
