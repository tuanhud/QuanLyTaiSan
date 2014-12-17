using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using TSCD.Entities;
using System.Collections.Generic;
using TSCD.DataFilter;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_SoChiTietTaiSanCoDinh : DevExpress.XtraReports.UI.XtraReport
    {
        const int padding = 5;

        public XtraReport_SoChiTietTaiSanCoDinh()
        {
            InitializeComponent();
        }

        public XtraReport_SoChiTietTaiSanCoDinh(Object Data, int Year, String TenDonVi)
        {
            InitializeComponent();
            if (!Object.Equals(Data, null))
            {
                this.DataSource = Data;
                xrLabel_Nam.Text = "Năm " + Year.ToString();
                xrLabel_PhongBan.Text = "Phòng ban: " + TenDonVi;
                IntReport();
            }
        }

        public XtraReport_SoChiTietTaiSanCoDinh(Object Data)
        {
            InitializeComponent();
            if (!Object.Equals(Data, null))
            {
                this.DataSource = Data;
                IntReport();
            }
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTable_Detail.Padding = padding;
                xrTable1.Padding = padding;
                xrTable2.Padding = padding;
                xrTable3.Padding = padding;

                xrTableCell_TenTSCD.DataBindings.Add("Text", null, "ten");
                xrTableCell_NuocSanXuat.DataBindings.Add("Text", null, "nuocsx");
                xrTableCell_NgaySuDung.DataBindings.Add("Text", null, "ngay", "{0:dd/MM/yyyy}");

                xrTableCell_NguyenGia.DataBindings.Add("Text", null, "dongia", "{0:### ### ### ###}");
                xrTableCell_TyLeHM.DataBindings.Add("Text", null, "phantramhaomon_32", "{0:0.00}");

                xrTableCell_GiaTriHMDauKi.DataBindings.Add("Text", null, "haomonnamtruocchuyensang", "{0:### ### ### ###}");
                xrTableCell_SoHMTrongKi.DataBindings.Add("Text", null, "haomon_1nam", "{0:### ### ### ###}");
                xrTableCell_GiaTriHMLuyKe.DataBindings.Add("Text", null, "haomonluyke", "{0:### ### ### ###}");

                xrTableCell_GiaTriConLai.DataBindings.Add("Text", null, "giatriconlai_final", "{0:### ### ### ###}");

                IntGROUP();
                IntSUM();
            }
        }

        private void IntGROUP()
        {
            #region Padding
            xrTableCell_GROUP_NguyenGiaParent.Padding = 5;
            xrTableCell_GROUP_HaoMonDauKyParent.Padding = 5;
            xrTableCell_GROUP_HaoMonTrongKyParent.Padding = 5;
            xrTableCell_GROUP_HaoMonLuyKeParent.Padding = 5;
            xrTableCell_GROUP_GiaTriConLaiParent.Padding = 5;

            xrTableCell_GROUP_NguyenGia.Padding = 5;
            xrTableCell_GROUP_HaoMonDauKy.Padding = 5;
            xrTableCell_GROUP_HaoMonTrongKy.Padding = 5;
            xrTableCell_GROUP_HaoMonLuyKe.Padding = 5;
            xrTableCell_GROUP_GiaTriConLai.Padding = 5;
            #endregion

            #region Loai tai san parent
            GroupField _GroupField = new GroupField("loaitaisan_parent");
            GroupHeader_Parent.GroupFields.Add(_GroupField);

            xrTableCell_GROUP_NameParent.DataBindings.Add("Text", this.DataSource, "tenloaitaisan");

            xrTableCell_GROUP_NguyenGiaParent.DataBindings.Add("Text", this.DataSource, "dongia");
            xrTableCell_GROUP_NguyenGiaParent.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_NguyenGiaParent.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_NguyenGiaParent.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_NguyenGiaParent.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_NguyenGiaParent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_HaoMonDauKyParent.DataBindings.Add("Text", this.DataSource, "haomonnamtruocchuyensang");
            xrTableCell_GROUP_HaoMonDauKyParent.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonDauKyParent.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonDauKyParent.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonDauKyParent.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonDauKyParent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_HaoMonTrongKyParent.DataBindings.Add("Text", this.DataSource, "haomon_1nam");
            xrTableCell_GROUP_HaoMonTrongKyParent.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonTrongKyParent.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonTrongKyParent.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonTrongKyParent.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonTrongKyParent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_HaoMonLuyKeParent.DataBindings.Add("Text", this.DataSource, "haomonluyke");
            xrTableCell_GROUP_HaoMonLuyKeParent.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonLuyKeParent.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonLuyKeParent.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonLuyKeParent.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonLuyKeParent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_GiaTriConLaiParent.DataBindings.Add("Text", this.DataSource, "giatriconlai_final");
            xrTableCell_GROUP_GiaTriConLaiParent.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_GiaTriConLaiParent.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_GiaTriConLaiParent.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_GiaTriConLaiParent.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_GiaTriConLaiParent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            #endregion

            #region Loai tai san
            GroupField _GroupFieldLoaiTaiSan = new GroupField("loaitaisan");
            GroupHeader_LoaiTaiSan.GroupFields.Add(_GroupFieldLoaiTaiSan);

            xrTableCell_GROUP_Name.DataBindings.Add("Text", this.DataSource, "tenloaitaisan");

            xrTableCell_GROUP_NguyenGia.DataBindings.Add("Text", this.DataSource, "dongia");
            xrTableCell_GROUP_NguyenGia.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_NguyenGia.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_NguyenGia.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_NguyenGia.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_NguyenGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_HaoMonDauKy.DataBindings.Add("Text", this.DataSource, "haomonnamtruocchuyensang");
            xrTableCell_GROUP_HaoMonDauKy.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonDauKy.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonDauKy.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonDauKy.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonDauKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_HaoMonTrongKy.DataBindings.Add("Text", this.DataSource, "haomon_1nam");
            xrTableCell_GROUP_HaoMonTrongKy.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonTrongKy.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonTrongKy.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonTrongKy.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonTrongKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_HaoMonLuyKe.DataBindings.Add("Text", this.DataSource, "haomonluyke");
            xrTableCell_GROUP_HaoMonLuyKe.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonLuyKe.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonLuyKe.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonLuyKe.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonLuyKe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_GROUP_GiaTriConLai.DataBindings.Add("Text", this.DataSource, "giatriconlai_final");
            xrTableCell_GROUP_GiaTriConLai.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_GiaTriConLai.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_GiaTriConLai.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_GiaTriConLai.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_GiaTriConLai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            #endregion
        }

        private void IntSUM()
        {
            xrTableCell_SUM_NguyenGia.DataBindings.Add("Text", this.DataSource, "dongia");
            xrTableCell_SUM_NguyenGia.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_NguyenGia.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_NguyenGia.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_NguyenGia.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_NguyenGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_GiaTriHMDauKi.DataBindings.Add("Text", this.DataSource, "haomonnamtruocchuyensang");
            xrTableCell_SUM_GiaTriHMDauKi.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_GiaTriHMDauKi.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiaTriHMDauKi.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiaTriHMDauKi.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiaTriHMDauKi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_SoHaoMonTrongKy.DataBindings.Add("Text", this.DataSource, "haomon_1nam");
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoHaoMonTrongKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_GiaTriHMLuyKe.DataBindings.Add("Text", this.DataSource, "haomonluyke");
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiaTriHMLuyKe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_GiaTriConLai.DataBindings.Add("Text", this.DataSource, "giatriconlai_final");
            xrTableCell_SUM_GiaTriConLai.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_GiaTriConLai.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiaTriConLai.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiaTriConLai.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiaTriConLai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        }
    }
}
