namespace TSCD_GUI
{
    partial class RibbonFormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.SplashScreenForm), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormMain));
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControlCaiDatCauHinh = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlGiaoDienVaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlKhoiDongLai = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlThoat = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItemCaiDatCauHinh = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemGiaoDienVaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator2 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator3 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator4 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemKhoiDongLai = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator5 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemThoat = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator6 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.backstageViewClientControl7 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem7 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.barBtnUser = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            this.backstageViewControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ApplicationButtonDropDownControl = this.backstageViewControl;
            this.ribbonMain.ApplicationIcon = global::TSCD_GUI.Properties.Resources.Logo;
            this.ribbonMain.AutoSizeItems = true;
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.barBtnUser});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 2;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonMain.Size = new System.Drawing.Size(836, 49);
            this.ribbonMain.StatusBar = this.ribbonStatusBar;
            this.ribbonMain.SelectedPageChanging += new DevExpress.XtraBars.Ribbon.RibbonPageChangingEventHandler(this.ribbonMain_SelectedPageChanging);
            this.ribbonMain.SelectedPageChanged += new System.EventHandler(this.ribbonMain_SelectedPageChanged);
            // 
            // backstageViewControl
            // 
            this.backstageViewControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlCaiDatCauHinh);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlGiaoDienVaNgonNgu);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlCapNhatPhanMem);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlThongTinPhanMem);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlKhoiDongLai);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlThoat);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemCaiDatCauHinh);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemGiaoDienVaNgonNgu);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparator2);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemCapNhatPhanMem);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparator3);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemThongTinPhanMem);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparator4);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemKhoiDongLai);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparator5);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemThoat);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparator6);
            this.backstageViewControl.Location = new System.Drawing.Point(399, 54);
            this.backstageViewControl.Name = "backstageViewControl";
            this.backstageViewControl.Ribbon = this.ribbonMain;
            this.backstageViewControl.SelectedTab = this.backstageViewTabItemGiaoDienVaNgonNgu;
            this.backstageViewControl.SelectedTabIndex = 2;
            this.backstageViewControl.Size = new System.Drawing.Size(435, 443);
            this.backstageViewControl.TabIndex = 5;
            this.backstageViewControl.Hidden += new System.EventHandler(this.backstageViewControl_Hidden);
            // 
            // backstageViewClientControlCaiDatCauHinh
            // 
            this.backstageViewClientControlCaiDatCauHinh.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlCaiDatCauHinh.Name = "backstageViewClientControlCaiDatCauHinh";
            this.backstageViewClientControlCaiDatCauHinh.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlCaiDatCauHinh.TabIndex = 0;
            // 
            // backstageViewClientControlGiaoDienVaNgonNgu
            // 
            this.backstageViewClientControlGiaoDienVaNgonNgu.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlGiaoDienVaNgonNgu.Name = "backstageViewClientControlGiaoDienVaNgonNgu";
            this.backstageViewClientControlGiaoDienVaNgonNgu.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlGiaoDienVaNgonNgu.TabIndex = 1;
            // 
            // backstageViewClientControlCapNhatPhanMem
            // 
            this.backstageViewClientControlCapNhatPhanMem.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlCapNhatPhanMem.Name = "backstageViewClientControlCapNhatPhanMem";
            this.backstageViewClientControlCapNhatPhanMem.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlCapNhatPhanMem.TabIndex = 2;
            // 
            // backstageViewClientControlThongTinPhanMem
            // 
            this.backstageViewClientControlThongTinPhanMem.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlThongTinPhanMem.Name = "backstageViewClientControlThongTinPhanMem";
            this.backstageViewClientControlThongTinPhanMem.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlThongTinPhanMem.TabIndex = 3;
            // 
            // backstageViewClientControlKhoiDongLai
            // 
            this.backstageViewClientControlKhoiDongLai.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlKhoiDongLai.Name = "backstageViewClientControlKhoiDongLai";
            this.backstageViewClientControlKhoiDongLai.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlKhoiDongLai.TabIndex = 4;
            // 
            // backstageViewClientControlThoat
            // 
            this.backstageViewClientControlThoat.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlThoat.Name = "backstageViewClientControlThoat";
            this.backstageViewClientControlThoat.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlThoat.TabIndex = 5;
            // 
            // backstageViewTabItemCaiDatCauHinh
            // 
            this.backstageViewTabItemCaiDatCauHinh.Caption = "Cài đặt cấu hình";
            this.backstageViewTabItemCaiDatCauHinh.ContentControl = this.backstageViewClientControlCaiDatCauHinh;
            this.backstageViewTabItemCaiDatCauHinh.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemCaiDatCauHinh.Glyph")));
            this.backstageViewTabItemCaiDatCauHinh.Name = "backstageViewTabItemCaiDatCauHinh";
            this.backstageViewTabItemCaiDatCauHinh.Selected = false;
            this.backstageViewTabItemCaiDatCauHinh.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemCaiDatCauHinh_SelectedChanged);
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // backstageViewTabItemGiaoDienVaNgonNgu
            // 
            this.backstageViewTabItemGiaoDienVaNgonNgu.Caption = "Giao diện và Ngôn ngữ";
            this.backstageViewTabItemGiaoDienVaNgonNgu.ContentControl = this.backstageViewClientControlGiaoDienVaNgonNgu;
            this.backstageViewTabItemGiaoDienVaNgonNgu.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemGiaoDienVaNgonNgu.Glyph")));
            this.backstageViewTabItemGiaoDienVaNgonNgu.Name = "backstageViewTabItemGiaoDienVaNgonNgu";
            this.backstageViewTabItemGiaoDienVaNgonNgu.Selected = true;
            this.backstageViewTabItemGiaoDienVaNgonNgu.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemGiaoDienVaNgonNgu_SelectedChanged);
            // 
            // backstageViewItemSeparator2
            // 
            this.backstageViewItemSeparator2.Name = "backstageViewItemSeparator2";
            // 
            // backstageViewTabItemCapNhatPhanMem
            // 
            this.backstageViewTabItemCapNhatPhanMem.Caption = "Cập nhật phần mềm";
            this.backstageViewTabItemCapNhatPhanMem.ContentControl = this.backstageViewClientControlCapNhatPhanMem;
            this.backstageViewTabItemCapNhatPhanMem.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemCapNhatPhanMem.Glyph")));
            this.backstageViewTabItemCapNhatPhanMem.Name = "backstageViewTabItemCapNhatPhanMem";
            this.backstageViewTabItemCapNhatPhanMem.Selected = false;
            this.backstageViewTabItemCapNhatPhanMem.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemCapNhatPhanMem_SelectedChanged);
            // 
            // backstageViewItemSeparator3
            // 
            this.backstageViewItemSeparator3.Name = "backstageViewItemSeparator3";
            // 
            // backstageViewTabItemThongTinPhanMem
            // 
            this.backstageViewTabItemThongTinPhanMem.Caption = "Thông tin phần mềm";
            this.backstageViewTabItemThongTinPhanMem.ContentControl = this.backstageViewClientControlThongTinPhanMem;
            this.backstageViewTabItemThongTinPhanMem.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemThongTinPhanMem.Glyph")));
            this.backstageViewTabItemThongTinPhanMem.Name = "backstageViewTabItemThongTinPhanMem";
            this.backstageViewTabItemThongTinPhanMem.Selected = false;
            this.backstageViewTabItemThongTinPhanMem.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemThongTinPhanMem_SelectedChanged);
            // 
            // backstageViewItemSeparator4
            // 
            this.backstageViewItemSeparator4.Name = "backstageViewItemSeparator4";
            // 
            // backstageViewTabItemKhoiDongLai
            // 
            this.backstageViewTabItemKhoiDongLai.Caption = "Khởi động lại";
            this.backstageViewTabItemKhoiDongLai.ContentControl = this.backstageViewClientControlKhoiDongLai;
            this.backstageViewTabItemKhoiDongLai.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemKhoiDongLai.Glyph")));
            this.backstageViewTabItemKhoiDongLai.Name = "backstageViewTabItemKhoiDongLai";
            this.backstageViewTabItemKhoiDongLai.Selected = false;
            this.backstageViewTabItemKhoiDongLai.ItemPressed += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemKhoiDongLai_ItemPressed);
            // 
            // backstageViewItemSeparator5
            // 
            this.backstageViewItemSeparator5.Name = "backstageViewItemSeparator5";
            // 
            // backstageViewTabItemThoat
            // 
            this.backstageViewTabItemThoat.Caption = "Thoát";
            this.backstageViewTabItemThoat.ContentControl = this.backstageViewClientControlThoat;
            this.backstageViewTabItemThoat.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemThoat.Glyph")));
            this.backstageViewTabItemThoat.Name = "backstageViewTabItemThoat";
            this.backstageViewTabItemThoat.Selected = false;
            this.backstageViewTabItemThoat.ItemPressed += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemThoat_ItemPressed);
            // 
            // backstageViewItemSeparator6
            // 
            this.backstageViewItemSeparator6.Name = "backstageViewItemSeparator6";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barBtnUser);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 489);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonMain;
            this.ribbonStatusBar.Size = new System.Drawing.Size(836, 31);
            // 
            // panelControlMain
            // 
            this.panelControlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(0, 49);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(836, 440);
            this.panelControlMain.TabIndex = 2;
            // 
            // backstageViewClientControl7
            // 
            this.backstageViewClientControl7.Location = new System.Drawing.Point(205, 0);
            this.backstageViewClientControl7.Name = "backstageViewClientControl7";
            this.backstageViewClientControl7.Size = new System.Drawing.Size(228, 441);
            this.backstageViewClientControl7.TabIndex = 6;
            // 
            // backstageViewTabItem7
            // 
            this.backstageViewTabItem7.Caption = "backstageViewTabItem7";
            this.backstageViewTabItem7.ContentControl = this.backstageViewClientControl7;
            this.backstageViewTabItem7.Name = "backstageViewTabItem7";
            this.backstageViewTabItem7.Selected = false;
            // 
            // barBtnUser
            // 
            this.barBtnUser.Caption = "[Unkown]";
            this.barBtnUser.Id = 1;
            this.barBtnUser.Name = "barBtnUser";
            this.barBtnUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUser_ItemClick);
            // 
            // RibbonFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 520);
            this.Controls.Add(this.backstageViewControl);
            this.Controls.Add(this.panelControlMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RibbonFormMain";
            this.Ribbon = this.ribbonMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản lý Tài sản cố định v1.0";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            this.backstageViewControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl panelControlMain;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlCaiDatCauHinh;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlGiaoDienVaNgonNgu;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlCapNhatPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlThongTinPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlKhoiDongLai;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlThoat;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemCaiDatCauHinh;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemGiaoDienVaNgonNgu;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator2;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemCapNhatPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator3;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemThongTinPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator4;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemKhoiDongLai;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemThoat;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator5;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator6;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl7;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem7;
        private DevExpress.XtraBars.BarButtonItem barBtnUser;
    }
}