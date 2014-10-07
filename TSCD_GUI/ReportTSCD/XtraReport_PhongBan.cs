using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using TSCD.DataFilter;
using System.Collections.Generic;
using TSCD.Entities;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_PhongBan : DevExpress.XtraReports.UI.XtraReport
    {
        List<TaiSanHienThi> list = new List<TaiSanHienThi>();
        DonVi obj = new DonVi();

        public XtraReport_PhongBan()
        {
            InitializeComponent();
        }

        public XtraReport_PhongBan(List<TaiSanHienThi> list, DonVi obj)
        {
            InitializeComponent();
            this.list = list;
            this.obj = obj;
            this.DataSource = list;
        }

        private void IntReport()
        {
            if (!Object.Equals(list, null))
            {
                if (list.Count > 0)
                {
                    xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");
                    xrTableCell_NgayThang.DataBindings.Add("Text", null, "ngay_ct");
                    xrTableCell_Ten.DataBindings.Add("Text", null, "ten");
                    xrTableCell_DonViTinh.DataBindings.Add("Text", null, "donvitinh");
                    
                    xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");
                    xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");
                    xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");

                }
            }
        }
    }
}
