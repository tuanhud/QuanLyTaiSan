namespace TSCD_GUI.ReportTSCD
{
    partial class XtraReportTSCD_Grid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer_GridControl = new DevExpress.XtraReports.UI.WinControlContainer();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel_DonViTinh = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_Title = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_MauBaoCao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_MaChuong = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel_NguoiLapBieu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_KeToanTruong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_GiamDoc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo_CurrentDay = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo_Page = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrControlStyle_ColumnTitle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrControlStyle_Row = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer_GridControl});
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer_GridControl
            // 
            this.winControlContainer_GridControl.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.winControlContainer_GridControl.Name = "winControlContainer_GridControl";
            this.winControlContainer_GridControl.SizeF = new System.Drawing.SizeF(999.9999F, 100F);
            this.winControlContainer_GridControl.WinControl = null;
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 12F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel_DonViTinh,
            this.xrLabel_Title,
            this.xrLabel_MauBaoCao,
            this.xrLabel_MaChuong});
            this.ReportHeader.HeightF = 150F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel_DonViTinh
            // 
            this.xrLabel_DonViTinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_DonViTinh.LocationFloat = new DevExpress.Utils.PointFloat(850.0001F, 125F);
            this.xrLabel_DonViTinh.Multiline = true;
            this.xrLabel_DonViTinh.Name = "xrLabel_DonViTinh";
            this.xrLabel_DonViTinh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_DonViTinh.SizeF = new System.Drawing.SizeF(150F, 25F);
            this.xrLabel_DonViTinh.StylePriority.UseFont = false;
            this.xrLabel_DonViTinh.StylePriority.UseTextAlignment = false;
            this.xrLabel_DonViTinh.Text = "Đơn vị tính: đồng";
            this.xrLabel_DonViTinh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel_Title
            // 
            this.xrLabel_Title.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_Title.LocationFloat = new DevExpress.Utils.PointFloat(187.5F, 75F);
            this.xrLabel_Title.Multiline = true;
            this.xrLabel_Title.Name = "xrLabel_Title";
            this.xrLabel_Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_Title.SizeF = new System.Drawing.SizeF(621.2501F, 49.54168F);
            this.xrLabel_Title.StylePriority.UseFont = false;
            this.xrLabel_Title.StylePriority.UseTextAlignment = false;
            this.xrLabel_Title.Text = "BÁO CÁO TÌNH HÌNH TĂNG, GIẢM TÀI SẢN CỐ ĐỊNH\r\nNăm 2014";
            this.xrLabel_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel_MauBaoCao
            // 
            this.xrLabel_MauBaoCao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_MauBaoCao.LocationFloat = new DevExpress.Utils.PointFloat(732.9165F, 0F);
            this.xrLabel_MauBaoCao.Multiline = true;
            this.xrLabel_MauBaoCao.Name = "xrLabel_MauBaoCao";
            this.xrLabel_MauBaoCao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_MauBaoCao.SizeF = new System.Drawing.SizeF(267.0834F, 49.54168F);
            this.xrLabel_MauBaoCao.StylePriority.UseFont = false;
            this.xrLabel_MauBaoCao.StylePriority.UseTextAlignment = false;
            this.xrLabel_MauBaoCao.Text = "Mẫu số B04_H1\r\n(Ban hành theo QĐ 19/2006/QĐ-BTC ngày 30/3/2006 của Bộ trưởng Bộ T" +
    "ài chính)";
            this.xrLabel_MauBaoCao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel_MaChuong
            // 
            this.xrLabel_MaChuong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_MaChuong.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel_MaChuong.Multiline = true;
            this.xrLabel_MaChuong.Name = "xrLabel_MaChuong";
            this.xrLabel_MaChuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_MaChuong.SizeF = new System.Drawing.SizeF(267.0834F, 49.54168F);
            this.xrLabel_MaChuong.StylePriority.UseFont = false;
            this.xrLabel_MaChuong.StylePriority.UseTextAlignment = false;
            this.xrLabel_MaChuong.Text = "Mã chương: 599\r\nĐơn vị báo cáo: Trường Đại học Sài Gòn\r\nMã ĐV có QH với NS: 10860" +
    "78";
            this.xrLabel_MaChuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel_NguoiLapBieu,
            this.xrLabel_KeToanTruong,
            this.xrLabel_GiamDoc,
            this.xrPageInfo_CurrentDay});
            this.ReportFooter.HeightF = 300F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel_NguoiLapBieu
            // 
            this.xrLabel_NguoiLapBieu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_NguoiLapBieu.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.xrLabel_NguoiLapBieu.Multiline = true;
            this.xrLabel_NguoiLapBieu.Name = "xrLabel_NguoiLapBieu";
            this.xrLabel_NguoiLapBieu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_NguoiLapBieu.SizeF = new System.Drawing.SizeF(200.0854F, 49.54168F);
            this.xrLabel_NguoiLapBieu.StylePriority.UseFont = false;
            this.xrLabel_NguoiLapBieu.StylePriority.UseTextAlignment = false;
            this.xrLabel_NguoiLapBieu.Text = "Người lập biểu";
            this.xrLabel_NguoiLapBieu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel_KeToanTruong
            // 
            this.xrLabel_KeToanTruong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_KeToanTruong.LocationFloat = new DevExpress.Utils.PointFloat(400F, 100F);
            this.xrLabel_KeToanTruong.Multiline = true;
            this.xrLabel_KeToanTruong.Name = "xrLabel_KeToanTruong";
            this.xrLabel_KeToanTruong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_KeToanTruong.SizeF = new System.Drawing.SizeF(200.0854F, 49.54168F);
            this.xrLabel_KeToanTruong.StylePriority.UseFont = false;
            this.xrLabel_KeToanTruong.StylePriority.UseTextAlignment = false;
            this.xrLabel_KeToanTruong.Text = "Kế toán trưởng";
            this.xrLabel_KeToanTruong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel_GiamDoc
            // 
            this.xrLabel_GiamDoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_GiamDoc.LocationFloat = new DevExpress.Utils.PointFloat(799.9147F, 100F);
            this.xrLabel_GiamDoc.Multiline = true;
            this.xrLabel_GiamDoc.Name = "xrLabel_GiamDoc";
            this.xrLabel_GiamDoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_GiamDoc.SizeF = new System.Drawing.SizeF(200.0854F, 49.54168F);
            this.xrLabel_GiamDoc.StylePriority.UseFont = false;
            this.xrLabel_GiamDoc.StylePriority.UseTextAlignment = false;
            this.xrLabel_GiamDoc.Text = "Giám đốc";
            this.xrLabel_GiamDoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPageInfo_CurrentDay
            // 
            this.xrPageInfo_CurrentDay.Format = "{0:\"TP HCM, ngày\" dd \"tháng\" MM \"năm\" yyyy}";
            this.xrPageInfo_CurrentDay.LocationFloat = new DevExpress.Utils.PointFloat(722.8313F, 50F);
            this.xrPageInfo_CurrentDay.Name = "xrPageInfo_CurrentDay";
            this.xrPageInfo_CurrentDay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo_CurrentDay.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo_CurrentDay.SizeF = new System.Drawing.SizeF(277.1688F, 23F);
            this.xrPageInfo_CurrentDay.StylePriority.UseTextAlignment = false;
            this.xrPageInfo_CurrentDay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo_Page});
            this.PageFooter.HeightF = 50F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo_Page
            // 
            this.xrPageInfo_Page.Format = "Trang {0}/ {1}";
            this.xrPageInfo_Page.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999974F);
            this.xrPageInfo_Page.Name = "xrPageInfo_Page";
            this.xrPageInfo_Page.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo_Page.SizeF = new System.Drawing.SizeF(116.625F, 23F);
            // 
            // xrControlStyle_ColumnTitle
            // 
            this.xrControlStyle_ColumnTitle.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControlStyle_ColumnTitle.BorderWidth = 0.5F;
            this.xrControlStyle_ColumnTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrControlStyle_ColumnTitle.Name = "xrControlStyle_ColumnTitle";
            this.xrControlStyle_ColumnTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrControlStyle_Row
            // 
            this.xrControlStyle_Row.BackColor = System.Drawing.Color.Transparent;
            this.xrControlStyle_Row.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControlStyle_Row.BorderWidth = 0.5F;
            this.xrControlStyle_Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrControlStyle_Row.Name = "xrControlStyle_Row";
            this.xrControlStyle_Row.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XtraReportTSCD_Grid
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 100, 12);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle_ColumnTitle,
            this.xrControlStyle_Row});
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo_Page;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo_CurrentDay;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_NguoiLapBieu;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_KeToanTruong;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_GiamDoc;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_Title;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_MauBaoCao;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_MaChuong;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_DonViTinh;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle_ColumnTitle;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle_Row;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer_GridControl;
    }
}
