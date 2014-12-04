namespace TSCD_GUI.ThongKe
{
    partial class ucThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThongKe));
            this.rbnControlThongKe = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnTKPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDefault = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExpandAll = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTKTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXuatBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXuatThongKe = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTKHaoMon = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTKTHPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTKTHTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageThongKe = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupThongKe = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.QLTaiSan.WaitForm_Report), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlThongKe
            // 
            this.rbnControlThongKe.ExpandCollapseItem.Id = 0;
            this.rbnControlThongKe.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlThongKe.ExpandCollapseItem,
            this.barBtnTKPhong,
            this.barBtnDefault,
            this.barBtnExpandAll,
            this.barBtnCollapseAll,
            this.barBtnTKTaiSan,
            this.barBtnXuatBaoCao,
            this.barButtonItemXuatThongKe,
            this.barBtnTKHaoMon,
            this.barBtnTKTHPhong,
            this.barBtnTKTHTaiSan});
            this.rbnControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.rbnControlThongKe.MaxItemId = 12;
            this.rbnControlThongKe.Name = "rbnControlThongKe";
            this.rbnControlThongKe.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageThongKe});
            this.rbnControlThongKe.Size = new System.Drawing.Size(847, 145);
            // 
            // barBtnTKPhong
            // 
            this.barBtnTKPhong.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnTKPhong.Caption = "Thống kê phòng";
            this.barBtnTKPhong.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKPhong.Glyph")));
            this.barBtnTKPhong.Id = 1;
            this.barBtnTKPhong.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKPhong.LargeGlyph")));
            this.barBtnTKPhong.Name = "barBtnTKPhong";
            this.barBtnTKPhong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnTKPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKPhong_ItemClick);
            // 
            // barBtnDefault
            // 
            this.barBtnDefault.Caption = "Mặc định";
            this.barBtnDefault.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.Glyph")));
            this.barBtnDefault.Id = 2;
            this.barBtnDefault.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.LargeGlyph")));
            this.barBtnDefault.Name = "barBtnDefault";
            this.barBtnDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDefault_ItemClick);
            // 
            // barBtnExpandAll
            // 
            this.barBtnExpandAll.Caption = "Mở rộng tất cả";
            this.barBtnExpandAll.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExpandAll.Glyph")));
            this.barBtnExpandAll.Id = 3;
            this.barBtnExpandAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnExpandAll.LargeGlyph")));
            this.barBtnExpandAll.Name = "barBtnExpandAll";
            this.barBtnExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExpandAll_ItemClick);
            // 
            // barBtnCollapseAll
            // 
            this.barBtnCollapseAll.Caption = "Thu gọn tất cả";
            this.barBtnCollapseAll.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnCollapseAll.Glyph")));
            this.barBtnCollapseAll.Id = 4;
            this.barBtnCollapseAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnCollapseAll.LargeGlyph")));
            this.barBtnCollapseAll.Name = "barBtnCollapseAll";
            this.barBtnCollapseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCollapseAll_ItemClick);
            // 
            // barBtnTKTaiSan
            // 
            this.barBtnTKTaiSan.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnTKTaiSan.Caption = "Thống kê tài sản";
            this.barBtnTKTaiSan.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKTaiSan.Glyph")));
            this.barBtnTKTaiSan.Id = 5;
            this.barBtnTKTaiSan.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKTaiSan.LargeGlyph")));
            this.barBtnTKTaiSan.Name = "barBtnTKTaiSan";
            this.barBtnTKTaiSan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnTKTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKTaiSan_ItemClick);
            // 
            // barBtnXuatBaoCao
            // 
            this.barBtnXuatBaoCao.Caption = "Xuất báo cáo";
            this.barBtnXuatBaoCao.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnXuatBaoCao.Glyph")));
            this.barBtnXuatBaoCao.Id = 6;
            this.barBtnXuatBaoCao.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnXuatBaoCao.LargeGlyph")));
            this.barBtnXuatBaoCao.Name = "barBtnXuatBaoCao";
            this.barBtnXuatBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXuatBaoCao_ItemClick);
            // 
            // barButtonItemXuatThongKe
            // 
            this.barButtonItemXuatThongKe.Caption = "Xuất thống kê";
            this.barButtonItemXuatThongKe.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemXuatThongKe.Glyph")));
            this.barButtonItemXuatThongKe.Id = 8;
            this.barButtonItemXuatThongKe.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemXuatThongKe.LargeGlyph")));
            this.barButtonItemXuatThongKe.Name = "barButtonItemXuatThongKe";
            this.barButtonItemXuatThongKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemXuatThongKe_ItemClick);
            // 
            // barBtnTKHaoMon
            // 
            this.barBtnTKHaoMon.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnTKHaoMon.Caption = "Thống kê hao mòn";
            this.barBtnTKHaoMon.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKHaoMon.Glyph")));
            this.barBtnTKHaoMon.Id = 9;
            this.barBtnTKHaoMon.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKHaoMon.LargeGlyph")));
            this.barBtnTKHaoMon.Name = "barBtnTKHaoMon";
            this.barBtnTKHaoMon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKHaoMon_ItemClick);
            // 
            // barBtnTKTHPhong
            // 
            this.barBtnTKTHPhong.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnTKTHPhong.Caption = "Thống kê tổng hợp phòng";
            this.barBtnTKTHPhong.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKTHPhong.Glyph")));
            this.barBtnTKTHPhong.Id = 10;
            this.barBtnTKTHPhong.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKTHPhong.LargeGlyph")));
            this.barBtnTKTHPhong.Name = "barBtnTKTHPhong";
            this.barBtnTKTHPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKTHPhong_ItemClick);
            // 
            // barBtnTKTHTaiSan
            // 
            this.barBtnTKTHTaiSan.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnTKTHTaiSan.Caption = "Thống kê tổng hợp tài sản";
            this.barBtnTKTHTaiSan.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKTHTaiSan.Glyph")));
            this.barBtnTKTHTaiSan.Id = 11;
            this.barBtnTKTHTaiSan.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKTHTaiSan.LargeGlyph")));
            this.barBtnTKTHTaiSan.Name = "barBtnTKTHTaiSan";
            this.barBtnTKTHTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKTHTaiSan_ItemClick);
            // 
            // rbnPageThongKe
            // 
            this.rbnPageThongKe.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupThongKe,
            this.rbnGroupLayout,
            this.rbnGroupBaoCao});
            this.rbnPageThongKe.Image = ((System.Drawing.Image)(resources.GetObject("rbnPageThongKe.Image")));
            this.rbnPageThongKe.Name = "rbnPageThongKe";
            this.rbnPageThongKe.Text = "Thống kê";
            // 
            // rbnGroupThongKe
            // 
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKPhong);
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKTaiSan);
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKHaoMon);
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKTHPhong);
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKTHTaiSan);
            this.rbnGroupThongKe.Name = "rbnGroupThongKe";
            this.rbnGroupThongKe.ShowCaptionButton = false;
            this.rbnGroupThongKe.Text = "Thống kê";
            // 
            // rbnGroupLayout
            // 
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnDefault);
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnExpandAll);
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnCollapseAll);
            this.rbnGroupLayout.Name = "rbnGroupLayout";
            this.rbnGroupLayout.ShowCaptionButton = false;
            this.rbnGroupLayout.Text = "Trình bài";
            // 
            // rbnGroupBaoCao
            // 
            this.rbnGroupBaoCao.ItemLinks.Add(this.barBtnXuatBaoCao);
            this.rbnGroupBaoCao.ItemLinks.Add(this.barButtonItemXuatThongKe);
            this.rbnGroupBaoCao.Name = "rbnGroupBaoCao";
            this.rbnGroupBaoCao.ShowCaptionButton = false;
            this.rbnGroupBaoCao.Text = "Báo cáo";
            // 
            // panelControlMain
            // 
            this.panelControlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(0, 145);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(847, 344);
            this.panelControlMain.TabIndex = 1;
            // 
            // ucThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControlMain);
            this.Controls.Add(this.rbnControlThongKe);
            this.Name = "ucThongKe";
            this.Size = new System.Drawing.Size(847, 489);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlThongKe;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageThongKe;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupThongKe;
        private DevExpress.XtraBars.BarButtonItem barBtnTKPhong;
        private DevExpress.XtraEditors.PanelControl panelControlMain;
        private DevExpress.XtraBars.BarButtonItem barBtnDefault;
        private DevExpress.XtraBars.BarButtonItem barBtnExpandAll;
        private DevExpress.XtraBars.BarButtonItem barBtnCollapseAll;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLayout;
        private DevExpress.XtraBars.BarButtonItem barBtnTKTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnXuatBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupBaoCao;
        private DevExpress.XtraBars.BarButtonItem barButtonItemXuatThongKe;
        private DevExpress.XtraBars.BarButtonItem barBtnTKHaoMon;
        private DevExpress.XtraBars.BarButtonItem barBtnTKTHPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnTKTHTaiSan;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report;
    }
}