using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReportTSCD : DevExpress.XtraReports.UI.XtraReport
    {
        int intMinimum = 4;
        String strTag = "_STRING";

        //Variable
        DataSet ReportDataset = new DataSet();
        int NumberOfFieldGroup = 0;
        int WidthAdd = 20;
        int MaxLength = 0;
        int GroupColumnLength = 0;

        public XtraReportTSCD()
        {
            InitializeComponent();
        }

        public XtraReportTSCD(DevExpress.XtraGrid.GridControl _GridControl)
        {
            InitializeComponent();
            this.Landscape = true;
            DevExpress.XtraGrid.Views.Grid.GridView _GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            try
            {
                _GridView = _GridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                _BandedGridView = _GridControl.MainView as DevExpress.XtraGrid.Views.BandedGrid.BandedGridView;
            }
            catch { }
            int intType = -1;
            if (Object.Equals(_GridView, null))
            {
                _GridView.Dispose();
            }
            else
                intType = 0;
            if (Object.Equals(_BandedGridView, null))
            {
                _BandedGridView.Dispose();
            }
            else
                intType = 1;

            switch (intType)
            {
                case 0:
                    ReportDataset = SHARED.Libraries.ReportHelper.FillDatasetFromGrid(_GridView);
                    NumberOfFieldGroup = _GridView.GroupCount;

                    SHARED.Libraries.ReportHelper.CreateGroupValues(ReportDataset, _GridView, ref MaxLength, strTag);

                    MaxLength = MaxLength != 0 ? MaxLength > intMinimum ? MaxLength : intMinimum : 0;
                    GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * (int)Math.Ceiling(this.myColumnStyle.Font.Size);

                    InitXtraReport(ReportDataset, _GridView);
                    break;
                case 1:
                    ReportDataset = SHARED.Libraries.ReportHelper.FillDatasetFromGrid(_BandedGridView);

                    NumberOfFieldGroup = _BandedGridView.GroupCount;

                    SHARED.Libraries.ReportHelper.CreateGroupValues(ReportDataset, _BandedGridView, ref MaxLength, strTag);

                    MaxLength = MaxLength != 0 ? MaxLength > intMinimum ? MaxLength : intMinimum : 0;
                    GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * (int)Math.Ceiling(this.myColumnStyle.Font.Size);

                    InitXtraReport(ReportDataset, _BandedGridView);
                    break;
            }
        }

        private void InitXtraReport(DataSet _DataSet, GridView _GridView)
        {
            this.DataSource = _DataSet;
            this.DataMember = _DataSet.Tables[0].TableName;

            List<SHARED.Libraries.ReportHelper.structColumn> ListColumns = SHARED.Libraries.ReportHelper.GetListColumnsVisible(_GridView);

            InitTables(ListColumns, _GridView);
        }

        private void InitXtraReport(DataSet _DataSet, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView)
        {
            this.DataSource = _DataSet;
            this.DataMember = _DataSet.Tables[0].TableName;

            List<SHARED.Libraries.ReportHelper.structColumn> ListColumns = SHARED.Libraries.ReportHelper.GetListColumnsVisible(_BandedGridView);

            InitTables(ListColumns, _BandedGridView);
        }

        public void InitTables(List<SHARED.Libraries.ReportHelper.structColumn> ListColumns, GridView _GridView)
        {
            int colCount = ListColumns.Count;
            int pageWidth = (PageWidth - (Margins.Left + Margins.Right));
            int colWidth = pageWidth / colCount;

            if (NumberOfFieldGroup > 0)
            {
                colWidth = (pageWidth - GroupColumnLength) / colCount;


                for (int i = _GridView.GroupCount - 1; i >= 0; i--)
                {
                    XRTable XRTable_GroupHeaderBand = new XRTable();
                    XRTable_GroupHeaderBand.Styles.Style = this.myRowStyle;
                    XRTable_GroupHeaderBand.LocationF = new DevExpress.Utils.PointFloat(0 + i * WidthAdd, 0);

                    XRTableRow XRTableRow_GroupHeaderBand = new XRTableRow();

                    XRTableCell XRTableCell_GroupText = new XRTableCell();
                    if (Object.Equals(_GridView.GroupedColumns[i].ColumnType, typeof(Int32)))
                    {
                        XRTableCell_GroupText.DataBindings.Add("Text", this.DataSource, _GridView.GroupedColumns[i].Name + "_" + _GridView.GroupedColumns[i].FieldName + strTag);
                    }
                    else
                    {
                        XRTableCell_GroupText.DataBindings.Add("Text", this.DataSource, _GridView.GroupedColumns[i].Name + "_" + _GridView.GroupedColumns[i].FieldName);
                    }
                    XRTableCell_GroupText.Width = GroupColumnLength - i * WidthAdd;

                    XRTableRow_GroupHeaderBand.Cells.Add(XRTableCell_GroupText);

                    for (int j = 0; j < colCount; j++)
                    {
                        XRTableCell XRTableCell_SumColumn = new XRTableCell();
                        XRTableCell_SumColumn.Width = (int)colWidth;
                        if (ListColumns[j].IsNumber)
                        {
                            XRTableCell_SumColumn.DataBindings.Add("Text", this.DataSource, ListColumns[j].FieldName);
                            XRTableCell_SumColumn.Summary.IgnoreNullValues = true;
                            XRTableCell_SumColumn.Summary.Func = SummaryFunc.Sum;
                            XRTableCell_SumColumn.Summary.Running = SummaryRunning.Group;
                            XRTableCell_SumColumn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                        }
                        else
                        {
                            XRTableCell_SumColumn.Text = "";
                        }
                        XRTableRow_GroupHeaderBand.Cells.Add(XRTableCell_SumColumn);
                    }

                    XRTable_GroupHeaderBand.Rows.Add(XRTableRow_GroupHeaderBand);
                    XRTable_GroupHeaderBand.Width = pageWidth - (i * WidthAdd);

                    GroupHeaderBand _GroupHeaderBand = new GroupHeaderBand();
                    _GroupHeaderBand.Controls.Add(XRTable_GroupHeaderBand);
                    _GroupHeaderBand.Height = XRTable_GroupHeaderBand.Height;
                    GroupField _GroupField = new GroupField(_GridView.GroupedColumns[i].Name + "_" + _GridView.GroupedColumns[i].FieldName);
                    _GroupHeaderBand.GroupFields.Add(_GroupField);
                    this.Bands.Add(_GroupHeaderBand);
                }
            }


            XRTable XRTable_PageHeader = null;
            if (NumberOfFieldGroup > 0)
            {
                XRTable_PageHeader = SHARED.Libraries.ReportHelper.CreatePageHeaderTable(ListColumns, pageWidth, colWidth, true, GroupColumnLength);
            }
            else
            {
                XRTable_PageHeader = SHARED.Libraries.ReportHelper.CreatePageHeaderTable(ListColumns, pageWidth, colWidth, false, 0);
            }
            if (!Object.Equals(XRTable_PageHeader, null))
            {
                XRTable_PageHeader.Styles.Style = this.myColumnStyle;
                Bands[BandKind.PageHeader].Controls.Add(XRTable_PageHeader);
            }

            XRTable XRTable_Detail = new XRTable();
            XRTableRow XRTableRow_Detail = new XRTableRow();
            for (int i = 0; i < colCount; i++)
            {
                XRTableCell XRTableCell_Cell = new XRTableCell();
                XRTableCell_Cell.Width = (int)colWidth;
                XRTableCell_Cell.DataBindings.Add("Text", null, ListColumns[i].FieldName);
                if (ListColumns[i].IsNumber)
                    XRTableCell_Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                XRTableRow_Detail.Cells.Add(XRTableCell_Cell);
            }
            XRTable_Detail.Rows.Add(XRTableRow_Detail);
            if (NumberOfFieldGroup > 0)
                XRTable_Detail.LocationF = new DevExpress.Utils.PointFloat((float)(GroupColumnLength), 0F);
            XRTable_Detail.Width = pageWidth - GroupColumnLength;
            XRTable_Detail.Name = "XRTableRow_Detail";
            XRTable_Detail.Styles.Style = this.myRowStyle;
            Bands[BandKind.Detail].Controls.Add(XRTable_Detail);


            //XRTable XRTable_LastSum = SHARED.Libraries.ReportHelper.CreateLastSUMTable(this, ListColumns, GroupColumnLength, pageWidth, colWidth);
            //if (!Object.Equals(XRTable_LastSum, null))
            //{
            //    XRTable_LastSum.Styles.Style = this.myRowStyle;
            //    Bands[BandKind.ReportFooter].Controls.Add(XRTable_LastSum);
            //}
        }

        public void InitTables(List<SHARED.Libraries.ReportHelper.structColumn> ListColumns, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView)
        {

        }
    }
}
