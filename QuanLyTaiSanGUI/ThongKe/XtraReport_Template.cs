using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace PTB_GUI.ThongKe
{
    public partial class XtraReport_Template : DevExpress.XtraReports.UI.XtraReport
    {
        int intMinimum = 4;
        String strTag = "_STRING";

        //Variable
        int NumberOfFieldGroup = 0;
        int WidthAdd = 20;
        int MaxLength = 0;
        int GroupColumnLength = 0;
        Boolean LastSUM = true;

        DataSet ReportDataset = new DataSet();

        public XtraReport_Template()
        {
            InitializeComponent();
        }

        public XtraReport_Template(DevExpress.XtraGrid.GridControl _GridControl, Boolean Landscape)
        {
            InitializeComponent();
            this.Landscape = Landscape;
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
                    break;
                case 1:
                    ReportDataset = SHARED.Libraries.ReportHelper.FillDatasetFromGrid(_BandedGridView);
                    break;
            }
        }

        public XtraReport_Template(DataSet _DataSet, GridView GridViewVictim, Boolean Landscape)
        {
            InitializeComponent();

            NumberOfFieldGroup = GridViewVictim.GroupCount;
            this.Landscape = Landscape;
            SetPositionXRLabel();

            SHARED.Libraries.ReportHelper.CreateGroupValues(_DataSet, GridViewVictim, ref MaxLength, strTag);

            MaxLength = MaxLength != 0 ? MaxLength > intMinimum ? MaxLength : intMinimum : 0;
            //GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * (int)Math.Ceiling(this.myColumnStyle.Font.Size);
            GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * 6;

            InitXtraReport(_DataSet, GridViewVictim);
        }

        public XtraReport_Template(DataSet _DataSet, GridView GridViewVictim, Boolean Landscape, Boolean LastSUM)
        {
            InitializeComponent();
            this.LastSUM = LastSUM;
            NumberOfFieldGroup = GridViewVictim.GroupCount;
            this.Landscape = Landscape;
            SetPositionXRLabel();

            SHARED.Libraries.ReportHelper.CreateGroupValues(_DataSet, GridViewVictim, ref MaxLength, strTag);

            MaxLength = MaxLength != 0 ? MaxLength > intMinimum ? MaxLength : intMinimum : 0;
            //GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * (int)Math.Ceiling(this.myColumnStyle.Font.Size);
            GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * 6;

            InitXtraReport(_DataSet, GridViewVictim);
        }

        private void InitXtraReport(DataSet _DataSet, GridView GridViewVictim)
        {
            this.DataSource = _DataSet;
            this.DataMember = _DataSet.Tables[0].TableName;

            List<SHARED.Libraries.ReportHelper.structColumn> ListColumns = SHARED.Libraries.ReportHelper.GetListColumnsVisible(GridViewVictim);

            InitTables(ListColumns, GridViewVictim);
        }

        public void InitTables(List<SHARED.Libraries.ReportHelper.structColumn> ListColumns, GridView GridViewVictim)
        {
            int colCount = ListColumns.Count;
            int pageWidth = (PageWidth - (Margins.Left + Margins.Right));
            int colWidth = pageWidth / colCount;

            if (NumberOfFieldGroup > 0)
            {
                colWidth = (pageWidth - GroupColumnLength) / colCount;


                for (int i = GridViewVictim.GroupCount - 1; i >= 0; i--)
                {
                    XRTable XRTable_GroupHeaderBand = new XRTable();
                    XRTable_GroupHeaderBand.Styles.Style = this.myGroupStyle;
                    XRTable_GroupHeaderBand.LocationF = new DevExpress.Utils.PointFloat(0 + i * WidthAdd, 0);

                    XRTableRow XRTableRow_GroupHeaderBand = new XRTableRow();

                    XRTableCell XRTableCell_GroupText = new XRTableCell();
                    if (Object.Equals(GridViewVictim.GroupedColumns[i].ColumnType, typeof(Int32)))
                    {
                        XRTableCell_GroupText.DataBindings.Add("Text", this.DataSource, GridViewVictim.GroupedColumns[i].Name + "_" + GridViewVictim.GroupedColumns[i].FieldName + strTag);
                    }
                    else
                    {
                        XRTableCell_GroupText.DataBindings.Add("Text", this.DataSource, GridViewVictim.GroupedColumns[i].Name + "_" + GridViewVictim.GroupedColumns[i].FieldName);
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
                    GroupField _GroupField = new GroupField(GridViewVictim.GroupedColumns[i].Name + "_" + GridViewVictim.GroupedColumns[i].FieldName);
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


            if (LastSUM)
            {
                XRTable XRTable_LastSum = null;
                if (NumberOfFieldGroup > 0)
                {
                    XRTable_LastSum = SHARED.Libraries.ReportHelper.CreateLastSUMTable(this, ListColumns, pageWidth, colWidth, true, GroupColumnLength);
                }
                else
                {
                    XRTable_LastSum = SHARED.Libraries.ReportHelper.CreateLastSUMTable(this, ListColumns, pageWidth, colWidth, false, 0);
                }
                if (!Object.Equals(XRTable_LastSum, null))
                {
                    XRTable_LastSum.Styles.Style = this.mySumTableStyle;
                    XRTable_LastSum.Location = new Point(0, 0);
                    XRTable_LastSum.Width = pageWidth;
                    Bands[BandKind.ReportFooter].Controls.Add(XRTable_LastSum);
                }
            }
        }

        private void SetPositionXRLabel()
        {
            int pageWidth = (PageWidth - (Margins.Left + Margins.Right));

            xrLabel_Title.LocationF = new DevExpress.Utils.PointFloat((float)((pageWidth - (int)Math.Ceiling(xrLabel_Title.WidthF)) * 1.0 / 2), xrLabel_Title.LocationF.Y);
            xrPageInfo_CurrentDay.LocationF = new DevExpress.Utils.PointFloat((float)(pageWidth - (int)Math.Ceiling(xrPageInfo_CurrentDay.WidthF)), xrPageInfo_CurrentDay.LocationF.Y);
            xrLabel_BanGiamHieu.LocationF = new DevExpress.Utils.PointFloat((float)(pageWidth - (int)Math.Ceiling(xrLabel_BanGiamHieu.WidthF)), xrLabel_BanGiamHieu.LocationF.Y);
            xrLabel_KeToanTruong.LocationF = new DevExpress.Utils.PointFloat((float)((pageWidth - (int)Math.Ceiling(xrLabel_KeToanTruong.WidthF)) * 1.0 / 2), xrLabel_KeToanTruong.LocationF.Y);
        }

        public void SetTitleText(String strText)
        {
            xrLabel_Title.Text = strText;
        }
    }
}