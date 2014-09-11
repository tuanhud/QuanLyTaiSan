using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan;

namespace QuanLyTaiSanGUI.Report
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();

            
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
        public void _group()
        {
            
            
        }
        public void _bindData()
        {
            // Create a label. 
            xrTableCell1.DataBindings.Add("Text", null, "id");

            xrLabel4.DataBindings.Add("Text", null, "hoten");
            GroupField g = new GroupField();
            g.FieldName = "hoten";
            g.SortOrder = XRColumnSortOrder.Ascending;
            GroupHeader1.Controls.Add(xrLabel4);
            GroupHeader1.GroupFields.Add(g);

            xrTableCell3.DataBindings.Add("Text", null, "sodienthoai");
            xrLabel12.DataBindings.Add("Text", null, "sodienthoai");
            //// Add the label to the report's Detail band. 
            //Detail.Controls.Add(label);

            //// Set its location and size. 
            //label.Location = bounds.Location;
            //label.Size = bounds.Size;

            //// Bind it to the bindingMember data field. 
            //// When the dataSource parameter is null, the report's data source is used. 
            //label.DataBindings.Add("Text", null, bindingMember);
        }

        private void xrLabel12_SummaryRowChanged(object sender, EventArgs e)
        {
            total_unit += Convert.ToInt64(GetCurrentColumnValue("sodienthoai"));
        }

        private void xrLabel12_SummaryReset(object sender, EventArgs e)
        {
            total_unit = 0;
        }

        private void xrLabel12_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = total_unit;
            e.Handled = true;
        }
        long total_unit = 0;
    }
}
