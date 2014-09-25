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
        DataSet ReportDataset = new DataSet();

        public struct structColumn
        {
            public string Caption { get; set; }
            public string FieldName { get; set; }
            public int VisibleIndex { get; set; }
            public Boolean IsNumber { get; set; }
        }

        public XtraReport_Template()
        {
            InitializeComponent();
        }

        public XtraReport_Template(DataSet _DataSet, GridView GridViewVictim, Boolean Landscape)
        {
            InitializeComponent();

            NumberOfFieldGroup = GridViewVictim.GroupCount;
            this.Landscape = Landscape;
            SetPositionXRLabel();

            //if (GridViewVictim.GroupCount > 0)
            //{
            //    int intAdd = (PageSize.Width - (Margins.Left + Margins.Right)) / GridViewVictim.GroupCount;
            //    if (intAdd < WidthAdd)
            //    {
            //        if (intAdd >= 0 && intAdd <= 10)
            //            WidthAdd = 2;
            //        else
            //            WidthAdd = intAdd;
            //    }
            //}
            if (_DataSet.Tables[0] != null)
            {
                if (GridViewVictim.GroupCount > 0)
                {
                    for (int i = 0; i < GridViewVictim.Columns.Count; i++)
                    {
                        if (!(GridViewVictim.Columns[i].Visible && GridViewVictim.Columns[i].GroupIndex < 0))
                        {
                            foreach (DataColumn _DataColumn in _DataSet.Tables[0].Columns)
                            {
                                if (Object.Equals(_DataColumn.ColumnName, GridViewVictim.Columns[i].Name + "_" + GridViewVictim.Columns[i].FieldName))
                                {
                                    foreach (DataRow row in _DataSet.Tables[0].Rows)
                                    {
                                        string strGroup = string.Format("{0}: {1}", GridViewVictim.Columns[i].Caption, row[_DataColumn.ColumnName]);
                                        if (Object.Equals(GridViewVictim.Columns[i].ColumnType, typeof(Int32)))
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
            MaxLength = MaxLength != 0 ? MaxLength > intMinimum ? MaxLength : intMinimum : 0;
            GroupColumnLength = NumberOfFieldGroup * WidthAdd + MaxLength * (int)Math.Ceiling(this.myColumnStyle.Font.Size);
            InitXtraReport(_DataSet, GridViewVictim);
        }

        private void InitXtraReport(DataSet _DataSet, GridView GridViewVictim)
        {
            this.DataSource = _DataSet;
            this.DataMember = _DataSet.Tables[0].TableName;

            List<structColumn> ListColumns = new List<structColumn>();
            for (int i = 0; i < GridViewVictim.Columns.Count; i++)
            {
                if (GridViewVictim.Columns[i].Visible && GridViewVictim.Columns[i].GroupIndex < 0)
                {
                    structColumn _structColumn = new structColumn();
                    _structColumn.Caption = GridViewVictim.Columns[i].Caption;
                    _structColumn.FieldName = GridViewVictim.Columns[i].Name + "_" + GridViewVictim.Columns[i].FieldName;
                    _structColumn.VisibleIndex = GridViewVictim.Columns[i].VisibleIndex;
                    _structColumn.IsNumber = false;
                    if (!Object.Equals(GridViewVictim.GetRowCellValue(0, GridViewVictim.Columns[i]), null))
                    {
                        if (SHARED.Libraries.StringHelper.IsNumber(GridViewVictim.GetRowCellValue(0, GridViewVictim.Columns[i]).ToString()))
                        {
                            _structColumn.IsNumber = true;
                        }
                    }
                    ListColumns.Add(_structColumn);
                }
            }
            ListColumns = ListColumns.OrderBy(item => item.VisibleIndex).ToList();
            InitTables(ListColumns, GridViewVictim);
        }

        public void InitTables(List<structColumn> ListColumns, GridView GridViewVictim)
        {
            int colCount = ListColumns.Count;
            int pageWidth = (PageWidth - (Margins.Left + Margins.Right));
            int colWidth = pageWidth / colCount;

            XRTable XRTable_Column = new XRTable();
            XRTableRow XRTableRow_Column = new XRTableRow();

            XRTable XRTable_Row = new XRTable();
            XRTableRow XRTableRow_Data = new XRTableRow();

            if (NumberOfFieldGroup > 0)
            {
                XRTableCell XRTableCell_Column = new XRTableCell();

                XRTableCell_Column.Width = GroupColumnLength;
                XRTableCell_Column.Text = "Nhóm";
                XRTableRow_Column.Cells.Add(XRTableCell_Column);

                colWidth = (pageWidth - GroupColumnLength) / colCount;

                for (int i = GridViewVictim.GroupCount - 1; i >= 0; i--)
                {
                    XRTable XRTable_Group = new XRTable();
                    XRTable_Group.Styles.Style = this.myGroupStyle;
                    XRTable_Group.LocationF = new DevExpress.Utils.PointFloat(0 + i * WidthAdd, 0);

                    XRTableRow XRTableRow_Group = new XRTableRow();

                    GroupHeaderBand _GroupHeaderBand = new GroupHeaderBand();
                    _GroupHeaderBand.Height = 25;

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

                    XRTableRow_Group.Cells.Add(XRTableCell_GroupText);

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
                        XRTableRow_Group.Cells.Add(XRTableCell_SumColumn);
                    }

                    XRTable_Group.Rows.Add(XRTableRow_Group);
                    XRTable_Group.Width = pageWidth - (i * WidthAdd);


                    _GroupHeaderBand.Controls.Add(XRTable_Group);
                    GroupField _GroupField = new GroupField(GridViewVictim.GroupedColumns[i].Name + "_" + GridViewVictim.GroupedColumns[i].FieldName);
                    _GroupHeaderBand.GroupFields.Add(_GroupField);
                    this.Bands.Add(_GroupHeaderBand);
                }
            }

            for (int i = 0; i < colCount; i++)
            {
                XRTableCell XRTableCell_Column = new XRTableCell();
                XRTableCell_Column.Width = (int)colWidth;
                XRTableCell_Column.Text = ListColumns[i].Caption;
                XRTableRow_Column.Cells.Add(XRTableCell_Column);

                XRTableCell XRTableCell_Data = new XRTableCell();

                XRTableCell_Data.Width = (int)colWidth;
                XRTableCell_Data.DataBindings.Add("Text", null, ListColumns[i].FieldName);
                if (ListColumns[i].IsNumber)
                    XRTableCell_Data.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                XRTableRow_Data.Cells.Add(XRTableCell_Data);
            }
            XRTable_Column.Rows.Add(XRTableRow_Column);
            XRTable_Column.Width = pageWidth;
            XRTable_Column.Name = "XRTable_Column";
            XRTable_Column.Styles.Style = this.myColumnStyle;

            XRTable_Row.Rows.Add(XRTableRow_Data);
            if (NumberOfFieldGroup > 0)
                XRTable_Row.LocationF = new DevExpress.Utils.PointFloat((float)(GroupColumnLength), 0F);
            XRTable_Row.Width = pageWidth - GroupColumnLength;
            XRTable_Row.Name = "XRTable_Row";
            XRTable_Row.Styles.Style = this.myRowStyle;

            Bands[BandKind.PageHeader].Controls.Add(XRTable_Column);
            Bands[BandKind.Detail].Controls.Add(XRTable_Row);

            //Add Last SUM
            if (ListColumns.Where(item => item.IsNumber == true).ToList().Count > 0)
            {
                XRTable XRTable_Sum = new XRTable();
                XRTableRow XRTableRow_Sum = new XRTableRow();

                XRTableCell XRTableCell_SumFirst = new XRTableCell();
                XRTableCell_SumFirst.Width = GroupColumnLength;
                XRTableCell_SumFirst.Text = "";

                XRTableRow_Sum.Cells.Add(XRTableCell_SumFirst);

                for (int i = 0; i < colCount; i++)
                {
                    XRTableCell XRTableCell_SumTemp = new XRTableCell();
                    XRTableCell_SumTemp.Width = (int)colWidth;

                    if (ListColumns[i].IsNumber)
                    {
                        XRTableCell_SumTemp.DataBindings.Add("Text", this.DataSource, ListColumns[i].FieldName);
                        XRTableCell_SumTemp.Summary.IgnoreNullValues = true;
                        XRTableCell_SumTemp.Summary.Func = SummaryFunc.Sum;
                        XRTableCell_SumTemp.Summary.Running = SummaryRunning.Report;
                        XRTableCell_SumTemp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    }
                    else
                    {
                        XRTableCell_SumTemp.Text = "";
                    }

                    XRTableRow_Sum.Cells.Add(XRTableCell_SumTemp);
                }
                XRTable_Sum.Rows.Add(XRTableRow_Sum);
                XRTable_Sum.Width = pageWidth;
                XRTable_Sum.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);
                XRTable_Sum.Styles.Style = this.mySumTableStyle;

                Bands[BandKind.ReportFooter].Controls.Add(XRTable_Sum);
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
    }
}