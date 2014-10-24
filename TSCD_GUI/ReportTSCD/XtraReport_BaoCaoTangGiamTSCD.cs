using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using TSCD.DataFilter;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_BaoCaoTangGiamTSCD : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime From, To;
        public XtraReport_BaoCaoTangGiamTSCD()
        {
            InitializeComponent();
        }

        public XtraReport_BaoCaoTangGiamTSCD(List<TK_TangGiam_TheoLoaiTS> List, DateTime From, DateTime To)
        {
            InitializeComponent();
            this.DataSource = List;
            this.From = From;
            this.To = To;
            IntReport();
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                //IntGROUP();

                xrTableCell_LoaiTaiSanNhomTaiSan.DataBindings.Add("Text", null, "tenloai");
                xrTableCell_DonViTinh.DataBindings.Add("Text", null, "donvitinh");

                xrTableCell_SoLuongDauNam.DataBindings.Add("Text", null, "sodaunam_soluong", "{0:### ### ### ###}");
                xrTableCell_NguyenGiaDauNam.DataBindings.Add("Text", null, "sodaunam_giatri", "{0:### ### ### ###}");

                xrTableCell_SoLuongTangTrongNam.DataBindings.Add("Text", null, "tangtrongnam_soluong", "{0:### ### ### ###}");
                xrTableCell_NguyenGiaTangTrongNam.DataBindings.Add("Text", null, "tangtrongnam_giatri", "{0:### ### ### ###}");

                xrTableCell_SoLuongGiamTrongNam.DataBindings.Add("Text", null, "giamtrongnam_soluong", "{0:### ### ### ###}");
                xrTableCell_NguyenGiaGiamTrongNam.DataBindings.Add("Text", null, "giamtrongnam_giatri", "{0:### ### ### ###}");

                xrTableCell_SoLuongCuoiNam.DataBindings.Add("Text", null, "socuoinam_soluong", "{0:### ### ### ###}");
                xrTableCell_NguyenGiaCuoiNam.DataBindings.Add("Text", null, "socuoinam_giatri", "{0:### ### ### ###}");

                IntSUM();
            }
            xrLabel_Nam.Text = From.ToString("dd/MM/yyyy") + " - " + To.ToString("dd/MM/yyyy");
        }

        /*private void IntGROUP()
        {
            GroupField _GroupField = new GroupField("id");
            GroupHeader_LoaiTaiSan.GroupFields.Add(_GroupField);

            xrTableCell_Group_TenLoaiTaiSan.DataBindings.Add("Text", null, "tenloai");

            #region SUM GROUP
            xrTableCell_Group_SoLuongDauNam.DataBindings.Add("Text", this.DataSource, "sodaunam_soluong");
            xrTableCell_Group_SoLuongDauNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_SoLuongDauNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_SoLuongDauNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_SoLuongDauNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_NguyenGiaDauNam.DataBindings.Add("Text", this.DataSource, "sodaunam_giatri");
            xrTableCell_Group_NguyenGiaDauNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_NguyenGiaDauNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_NguyenGiaDauNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_NguyenGiaDauNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_SoLuongTangTrongNam.DataBindings.Add("Text", this.DataSource, "tangtrongnam_soluong");
            xrTableCell_Group_SoLuongTangTrongNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_SoLuongTangTrongNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_SoLuongTangTrongNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_SoLuongTangTrongNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_NguyenGiaTangTrongNam.DataBindings.Add("Text", this.DataSource, "tangtrongnam_giatri");
            xrTableCell_Group_NguyenGiaTangTrongNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_NguyenGiaTangTrongNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_NguyenGiaTangTrongNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_NguyenGiaTangTrongNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_SoLuongGiamTrongNam.DataBindings.Add("Text", this.DataSource, "giamtrongnam_soluong");
            xrTableCell_Group_SoLuongGiamTrongNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_SoLuongGiamTrongNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_SoLuongGiamTrongNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_SoLuongGiamTrongNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_NguyenGiaGiamTrongNam.DataBindings.Add("Text", this.DataSource, "giamtrongnam_giatri");
            xrTableCell_Group_NguyenGiaGiamTrongNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_NguyenGiaGiamTrongNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_NguyenGiaGiamTrongNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_NguyenGiaGiamTrongNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_SoLuongCuoiNam.DataBindings.Add("Text", this.DataSource, "socuoinam_soluong");
            xrTableCell_Group_SoLuongCuoiNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_SoLuongCuoiNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_SoLuongCuoiNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_SoLuongCuoiNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_Group_NguyenGiaCuoiNam.DataBindings.Add("Text", this.DataSource, "socuoinam_giatri");
            xrTableCell_Group_NguyenGiaCuoiNam.Summary.IgnoreNullValues = true;
            xrTableCell_Group_NguyenGiaCuoiNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_Group_NguyenGiaCuoiNam.Summary.Running = SummaryRunning.Group;
            xrTableCell_Group_NguyenGiaCuoiNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            #endregion
        }*/

        private void IntSUM()
        {
            xrTableCell_SUM_SoDauNam.DataBindings.Add("Text", this.DataSource, "sodaunam_giatri", "{0:### ### ### ###}");
            xrTableCell_SUM_SoDauNam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoDauNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoDauNam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoDauNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_TangTrongNam.DataBindings.Add("Text", this.DataSource, "tangtrongnam_giatri", "{0:### ### ### ###}");
            xrTableCell_SUM_TangTrongNam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_TangTrongNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_TangTrongNam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_TangTrongNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_GiamTrongNam.DataBindings.Add("Text", this.DataSource, "giamtrongnam_giatri", "{0:### ### ### ###}");
            xrTableCell_SUM_GiamTrongNam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiamTrongNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiamTrongNam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiamTrongNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_SoCuoiNam.DataBindings.Add("Text", this.DataSource, "socuoinam_giatri", "{0:### ### ### ###}");
            xrTableCell_SUM_SoCuoiNam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoCuoiNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoCuoiNam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoCuoiNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        }
    }
}
