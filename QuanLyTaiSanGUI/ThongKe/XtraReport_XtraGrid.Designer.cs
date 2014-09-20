namespace PTB_GUI.ThongKe
{
    partial class XtraReport_XtraGrid
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
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrPageInfo_CurrentDay = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_KeToanTruong = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_BanGiamHieu = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel_Title = new DevExpress.XtraReports.UI.XRLabel();
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
            this.winControlContainer_GridControl.KeepTogether = false;
            this.winControlContainer_GridControl.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.winControlContainer_GridControl.Name = "winControlContainer_GridControl";
            this.winControlContainer_GridControl.SizeF = new System.Drawing.SizeF(650F, 100F);
            this.winControlContainer_GridControl.WinControl = null;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 46.87497F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 11.45833F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 34.375F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Format = "Trang {0}/ {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 11.37498F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(116.625F, 23F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo_CurrentDay,
            this.xrLabel2,
            this.xrLabel_KeToanTruong,
            this.xrLabel_BanGiamHieu});
            this.ReportFooter.HeightF = 298.9583F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrPageInfo_CurrentDay
            // 
            this.xrPageInfo_CurrentDay.Format = "{0:\"TP HCM, ngày\" dd \"tháng\" MM \"năm\" yyyy}";
            this.xrPageInfo_CurrentDay.LocationFloat = new DevExpress.Utils.PointFloat(372.8312F, 48.12495F);
            this.xrPageInfo_CurrentDay.Name = "xrPageInfo_CurrentDay";
            this.xrPageInfo_CurrentDay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo_CurrentDay.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo_CurrentDay.SizeF = new System.Drawing.SizeF(277.1688F, 23F);
            this.xrPageInfo_CurrentDay.StylePriority.UseTextAlignment = false;
            this.xrPageInfo_CurrentDay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.49999F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(200.0854F, 49.54168F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "NGƯỜI LẬP BIỂU\r\n(Ký, ghi rõ họ tên)";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel_KeToanTruong
            // 
            this.xrLabel_KeToanTruong.LocationFloat = new DevExpress.Utils.PointFloat(221.875F, 81.49999F);
            this.xrLabel_KeToanTruong.Multiline = true;
            this.xrLabel_KeToanTruong.Name = "xrLabel_KeToanTruong";
            this.xrLabel_KeToanTruong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_KeToanTruong.SizeF = new System.Drawing.SizeF(200.0854F, 49.54168F);
            this.xrLabel_KeToanTruong.StylePriority.UseTextAlignment = false;
            this.xrLabel_KeToanTruong.Text = "KẾ TOÁN TRƯỞNG\r\n(Ký, ghi rõ họ tên)";
            this.xrLabel_KeToanTruong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel_BanGiamHieu
            // 
            this.xrLabel_BanGiamHieu.LocationFloat = new DevExpress.Utils.PointFloat(449.9146F, 81.49999F);
            this.xrLabel_BanGiamHieu.Multiline = true;
            this.xrLabel_BanGiamHieu.Name = "xrLabel_BanGiamHieu";
            this.xrLabel_BanGiamHieu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_BanGiamHieu.SizeF = new System.Drawing.SizeF(200.0854F, 49.54168F);
            this.xrLabel_BanGiamHieu.StylePriority.UseTextAlignment = false;
            this.xrLabel_BanGiamHieu.Text = "BAN GIÁM HIỆU\r\n(Ký, ghi rõ họ tên)";
            this.xrLabel_BanGiamHieu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel_Title});
            this.ReportHeader.HeightF = 147.9166F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(267.0834F, 49.54168F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "ỦY BAN NHÂN DÂN TP. HỒ CHÍ MINH\r\nTRƯỜNG ĐẠI HỌC SÀI GÒN";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel_Title
            // 
            this.xrLabel_Title.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.xrLabel_Title.LocationFloat = new DevExpress.Utils.PointFloat(9.99999F, 95.41661F);
            this.xrLabel_Title.Multiline = true;
            this.xrLabel_Title.Name = "xrLabel_Title";
            this.xrLabel_Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_Title.SizeF = new System.Drawing.SizeF(630F, 29.62497F);
            this.xrLabel_Title.StylePriority.UseFont = false;
            this.xrLabel_Title.StylePriority.UseTextAlignment = false;
            this.xrLabel_Title.Text = "Báo Cáo Thống Kê Quản Lý Phòng - Ban Cơ Sở Hạ Tầng";
            this.xrLabel_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XtraReport_XtraGrid
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter,
            this.ReportFooter,
            this.ReportHeader});
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 47, 11);
            this.Version = "13.2";
            this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer_GridControl;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo_CurrentDay;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_KeToanTruong;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_BanGiamHieu;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel_Title;
    }
}
