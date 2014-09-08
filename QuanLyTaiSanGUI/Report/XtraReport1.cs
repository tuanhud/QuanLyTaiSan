using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QuanLyTaiSan.Entities;

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

        public void AddBoundLabel(string bindingMember, Rectangle bounds)
        {
            // Create a label. 
            if (bindingMember.Equals("id"))
            {
                xrTableCell1.DataBindings.Add("Text", null, bindingMember);
            } 
            else if (bindingMember.Equals("hoten"))
            {
                xrTableCell2.DataBindings.Add("Text", null, bindingMember);
            }
            else if (bindingMember.Equals("sodienthoai"))
            {
                xrTableCell3.DataBindings.Add("Text", null, bindingMember);
            }

            //// Add the label to the report's Detail band. 
            //Detail.Controls.Add(label);

            //// Set its location and size. 
            //label.Location = bounds.Location;
            //label.Size = bounds.Size;

            //// Bind it to the bindingMember data field. 
            //// When the dataSource parameter is null, the report's data source is used. 
            //label.DataBindings.Add("Text", null, bindingMember);
        }
    }
}
