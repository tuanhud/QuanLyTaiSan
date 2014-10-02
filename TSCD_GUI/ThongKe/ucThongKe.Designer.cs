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
            this.rbnPageThongKe = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupThongKe = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.rbnGroupLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnDefault = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExpandAll = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTKTaiSan = new DevExpress.XtraBars.BarButtonItem();
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
            this.barBtnTKTaiSan});
            this.rbnControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.rbnControlThongKe.MaxItemId = 6;
            this.rbnControlThongKe.Name = "rbnControlThongKe";
            this.rbnControlThongKe.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageThongKe});
            this.rbnControlThongKe.Size = new System.Drawing.Size(847, 142);
            // 
            // barBtnTKPhong
            // 
            this.barBtnTKPhong.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnTKPhong.Caption = "Thống kê phòng";
            this.barBtnTKPhong.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKPhong.Glyph")));
            this.barBtnTKPhong.Id = 1;
            this.barBtnTKPhong.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTKPhong.LargeGlyph")));
            this.barBtnTKPhong.Name = "barBtnTKPhong";
            this.barBtnTKPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKPhong_ItemClick);
            // 
            // rbnPageThongKe
            // 
            this.rbnPageThongKe.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupThongKe,
            this.rbnGroupLayout});
            this.rbnPageThongKe.Name = "rbnPageThongKe";
            this.rbnPageThongKe.Text = "Thống kê";
            // 
            // rbnGroupThongKe
            // 
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKPhong);
            this.rbnGroupThongKe.ItemLinks.Add(this.barBtnTKTaiSan);
            this.rbnGroupThongKe.Name = "rbnGroupThongKe";
            this.rbnGroupThongKe.ShowCaptionButton = false;
            this.rbnGroupThongKe.Text = "Thống kê";
            // 
            // panelControlMain
            // 
            this.panelControlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(0, 142);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(847, 347);
            this.panelControlMain.TabIndex = 1;
            // 
            // rbnGroupLayout
            // 
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnDefault);
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnExpandAll);
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnCollapseAll);
            this.rbnGroupLayout.Name = "rbnGroupLayout";
            this.rbnGroupLayout.ShowCaptionButton = false;
            this.rbnGroupLayout.Text = "Layout";
            // 
            // barBtnDefault
            // 
            this.barBtnDefault.Caption = "Default";
            this.barBtnDefault.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.Glyph")));
            this.barBtnDefault.Id = 2;
            this.barBtnDefault.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.LargeGlyph")));
            this.barBtnDefault.Name = "barBtnDefault";
            // 
            // barBtnExpandAll
            // 
            this.barBtnExpandAll.Caption = "Expand All";
            this.barBtnExpandAll.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExpandAll.Glyph")));
            this.barBtnExpandAll.Id = 3;
            this.barBtnExpandAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnExpandAll.LargeGlyph")));
            this.barBtnExpandAll.Name = "barBtnExpandAll";
            this.barBtnExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExpandAll_ItemClick);
            // 
            // barBtnCollapseAll
            // 
            this.barBtnCollapseAll.Caption = "Collapse All";
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
            this.barBtnTKTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTKTaiSan_ItemClick);
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
    }
}
