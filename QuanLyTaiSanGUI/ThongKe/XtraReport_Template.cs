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

namespace QuanLyTaiSanGUI.ThongKe
{
    public partial class XtraReport_Template : DevExpress.XtraReports.UI.XtraReport
    {
        int NumberOfFieldGroup = 0;
        int WidthAdd = 20;

        public struct structColumn
        {
            public string Caption { get; set; }
            public string FieldName { get; set; }
            public int VisibleIndex { get; set; }
        }

        public XtraReport_Template()
        {
            InitializeComponent();
        }

        public XtraReport_Template(DataSet GridData, GridView GridViewVictim)
        {
            InitializeComponent();
            InitXtraReport(GridData, GridViewVictim);
        }

        public XtraReport_Template(DataSet GridData, GridView GridViewVictim, Boolean FixGroupCaption)
        {
            InitializeComponent();
            if (FixGroupCaption)
            {
                if (GridData.Tables[0] != null)
                {
                    if (GridViewVictim.GroupCount > 0)
                    {
                        for (int i = 0; i < GridViewVictim.Columns.Count; i++)
                        {
                            if (!(GridViewVictim.Columns[i].Visible && GridViewVictim.Columns[i].GroupIndex < 0))
                            {
                                foreach (DataColumn column in GridData.Tables[0].Columns)
                                {
                                    if (Object.Equals(column.ColumnName, GridViewVictim.Columns[i].FieldName))
                                    {
                                        foreach (DataRow row in GridData.Tables[0].Rows)
                                        {
                                            row[column.ColumnName] = string.Format("{0}: {1}", GridViewVictim.Columns[i].Caption, row[column.ColumnName]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            InitXtraReport(GridData, GridViewVictim);
        }

        private void InitXtraReport(DataSet GridData, GridView GridViewVictim)
        {
            this.DataSource = GridData;
            this.DataMember = GridData.Tables[0].TableName;
            NumberOfFieldGroup = GridViewVictim.GroupCount;
            if (GridViewVictim.GroupCount > 0)
            {
                int add = (PageSize.Width - (Margins.Left + Margins.Right)) / GridViewVictim.GroupCount;
                if (add < WidthAdd)
                {
                    if (add >= 2 && add <= 5)
                        WidthAdd = 2;
                    else
                        WidthAdd = add;
                }
                for (int i = GridViewVictim.GroupCount - 1; i >= 0; i--)
                    InsertGroupBand(GridViewVictim.GroupedColumns[i], i);
            }

            //ArrayList listVisibleIndex = new ArrayList();
            //for (int i = 0; i < GridViewVictim.Columns.Count; i++)
            //{
            //    listVisibleIndex.Add(string.Format("{0} - ({1})", GridViewVictim.Columns[i].Caption, GridViewVictim.Columns[i].VisibleIndex.ToString()));
            //}
            List<structColumn> listColumn = new List<structColumn>();
            for (int i = 0; i < GridViewVictim.Columns.Count; i++)
            {
                if (GridViewVictim.Columns[i].Visible && GridViewVictim.Columns[i].GroupIndex < 0)
                {
                    structColumn _structColumn = new structColumn();
                    _structColumn.Caption = GridViewVictim.Columns[i].Caption;
                    _structColumn.FieldName = GridViewVictim.Columns[i].FieldName;
                    _structColumn.VisibleIndex = GridViewVictim.Columns[i].VisibleIndex;
                    listColumn.Add(_structColumn);
                }
            }
            listColumn = listColumn.OrderBy(item => item.VisibleIndex).ToList();
            InitTables(listColumn);
        }

        private void InsertGroupBand(GridColumn gridColumn, int i)
        {
            GroupHeaderBand _GroupHeaderBand = new GroupHeaderBand();
            _GroupHeaderBand.Height = 25;
            _GroupHeaderBand.RepeatEveryPage = true;
            XRLabel _XRLabel = new XRLabel();
            _XRLabel.DataBindings.Add("Text", this.DataSource, gridColumn.FieldName);
            _XRLabel.Size = new Size(PageSize.Width - (0 + i * WidthAdd + Margins.Left + Margins.Right), 25);
            _XRLabel.Location = new Point(0 + i * WidthAdd, 0);
            //l.BackColor = Color.Beige;
            //l.Borders = BorderSide.All;
            //l.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            _XRLabel.Styles.Style = this.myGroupStyle;
            _GroupHeaderBand.Controls.Add(_XRLabel);
            GroupField _GroupField = new GroupField(gridColumn.FieldName);
            _GroupHeaderBand.GroupFields.Add(_GroupField);
            this.Bands.Add(_GroupHeaderBand);
        }
        public void InitTables(List<structColumn> listColumn)
        {

            int colCount = listColumn.Count;
            int pageWidth = (PageWidth - (Margins.Left + Margins.Right));
            int colWidth = pageWidth / colCount;

            XRTable XRTable_Column = new XRTable();
            XRTableRow XRTableRow_Column = new XRTableRow();
            XRTable XRTable_Row = new XRTable();
            XRTableRow XRTableRow_Data = new XRTableRow();

            for (int i = 0; i < colCount; i++)
            {
                XRTableCell XRTableCell_Column = new XRTableCell();
                XRTableCell_Column.Width = (int)colWidth;
                XRTableCell_Column.Text = listColumn[i].Caption;
                XRTableRow_Column.Cells.Add(XRTableCell_Column);

                XRTableCell XRTableCell_Data = new XRTableCell();
                if (i == 0)
                {
                    XRTableCell_Data.Width = (int)colWidth - NumberOfFieldGroup * WidthAdd;
                    XRTable_Row.LocationF = new DevExpress.Utils.PointFloat((float)(NumberOfFieldGroup * WidthAdd), 0F);
                }
                else
                    XRTableCell_Data.Width = (int)colWidth;
                XRTableCell_Data.DataBindings.Add("Text", null, listColumn[i].FieldName);
                XRTableRow_Data.Cells.Add(XRTableCell_Data);
            }
            XRTable_Column.Rows.Add(XRTableRow_Column);
            XRTable_Column.Width = pageWidth;
            XRTable_Column.Name = "XRTable_Column";
            XRTable_Column.Styles.Style = this.myColumnStyle;

            XRTable_Row.Rows.Add(XRTableRow_Data);
            XRTable_Row.Width = pageWidth - NumberOfFieldGroup * WidthAdd;
            XRTable_Row.Name = "XRTable_Row";
            XRTable_Row.Styles.Style = this.myRowStyle;

            Bands[BandKind.PageHeader].Controls.Add(XRTable_Column);
            Bands[BandKind.Detail].Controls.Add(XRTable_Row);
        }
    }
}
