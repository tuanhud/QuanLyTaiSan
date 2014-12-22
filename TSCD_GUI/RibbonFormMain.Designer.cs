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
            this.backstageViewClientControlPhanQuyen = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlLogHeThong = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlImport = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlGiaoDienVaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlKhoiDongLai = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlThoat = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItemCaiDatCauHinh = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorCaiDatCauHinh = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemPhanQuyen = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorPhanQuyen = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemLogHeThong = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorLogHeThong = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemImport = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorNhapLieuTuExcel = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemGiaoDienVaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorGiaoDienVaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemKhoiDongLai = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorKhoiDongLai = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemThoat = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparatorThoat = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.barBtnUser = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.backstageViewClientControl7 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem7 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
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
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlPhanQuyen);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlLogHeThong);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlImport);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlGiaoDienVaNgonNgu);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlCapNhatPhanMem);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlThongTinPhanMem);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlKhoiDongLai);
            this.backstageViewControl.Controls.Add(this.backstageViewClientControlThoat);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemCaiDatCauHinh);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorCaiDatCauHinh);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemPhanQuyen);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorPhanQuyen);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemLogHeThong);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorLogHeThong);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemImport);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorNhapLieuTuExcel);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemGiaoDienVaNgonNgu);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorGiaoDienVaNgonNgu);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemCapNhatPhanMem);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorCapNhatPhanMem);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemThongTinPhanMem);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorThongTinPhanMem);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemKhoiDongLai);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorKhoiDongLai);
            this.backstageViewControl.Items.Add(this.backstageViewTabItemThoat);
            this.backstageViewControl.Items.Add(this.backstageViewItemSeparatorThoat);
            this.backstageViewControl.Location = new System.Drawing.Point(399, 54);
            this.backstageViewControl.Name = "backstageViewControl";
            this.backstageViewControl.Ribbon = this.ribbonMain;
            this.backstageViewControl.SelectedTab = this.backstageViewTabItemImport;
            this.backstageViewControl.SelectedTabIndex = 6;
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
            // backstageViewClientControlPhanQuyen
            // 
            this.backstageViewClientControlPhanQuyen.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlPhanQuyen.Name = "backstageViewClientControlPhanQuyen";
            this.backstageViewClientControlPhanQuyen.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlPhanQuyen.TabIndex = 8;
            // 
            // backstageViewClientControlLogHeThong
            // 
            this.backstageViewClientControlLogHeThong.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlLogHeThong.Name = "backstageViewClientControlLogHeThong";
            this.backstageViewClientControlLogHeThong.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlLogHeThong.TabIndex = 9;
            // 
            // backstageViewClientControlImport
            // 
            this.backstageViewClientControlImport.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlImport.Name = "backstageViewClientControlImport";
            this.backstageViewClientControlImport.Size = new System.Drawing.Size(234, 443);
            this.backstageViewClientControlImport.TabIndex = 7;
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
            // backstageViewItemSeparatorCaiDatCauHinh
            // 
            this.backstageViewItemSeparatorCaiDatCauHinh.Name = "backstageViewItemSeparatorCaiDatCauHinh";
            // 
            // backstageViewTabItemPhanQuyen
            // 
            this.backstageViewTabItemPhanQuyen.Caption = "Phân quyền";
            this.backstageViewTabItemPhanQuyen.ContentControl = this.backstageViewClientControlPhanQuyen;
            this.backstageViewTabItemPhanQuyen.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemPhanQuyen.Glyph")));
            this.backstageViewTabItemPhanQuyen.Name = "backstageViewTabItemPhanQuyen";
            this.backstageViewTabItemPhanQuyen.Selected = false;
            this.backstageViewTabItemPhanQuyen.ItemPressed += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemPhanQuyen_ItemPressed);
            // 
            // backstageViewItemSeparatorPhanQuyen
            // 
            this.backstageViewItemSeparatorPhanQuyen.Name = "backstageViewItemSeparatorPhanQuyen";
            // 
            // backstageViewTabItemLogHeThong
            // 
            this.backstageViewTabItemLogHeThong.Caption = "Log hệ thống";
            this.backstageViewTabItemLogHeThong.ContentControl = this.backstageViewClientControlLogHeThong;
            this.backstageViewTabItemLogHeThong.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemLogHeThong.Glyph")));
            this.backstageViewTabItemLogHeThong.Name = "backstageViewTabItemLogHeThong";
            this.backstageViewTabItemLogHeThong.Selected = false;
            this.backstageViewTabItemLogHeThong.ItemPressed += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemLogHeThong_ItemPressed);
            // 
            // backstageViewItemSeparatorLogHeThong
            // 
            this.backstageViewItemSeparatorLogHeThong.Name = "backstageViewItemSeparatorLogHeThong";
            // 
            // backstageViewTabItemImport
            // 
            this.backstageViewTabItemImport.Caption = "Nhập liệu từ excel";
            this.backstageViewTabItemImport.ContentControl = this.backstageViewClientControlImport;
            this.backstageViewTabItemImport.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemImport.Glyph")));
            this.backstageViewTabItemImport.Name = "backstageViewTabItemImport";
            this.backstageViewTabItemImport.Selected = true;
            this.backstageViewTabItemImport.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemImport_SelectedChanged);
            // 
            // backstageViewItemSeparatorNhapLieuTuExcel
            // 
            this.backstageViewItemSeparatorNhapLieuTuExcel.Name = "backstageViewItemSeparatorNhapLieuTuExcel";
            // 
            // backstageViewTabItemGiaoDienVaNgonNgu
            // 
            this.backstageViewTabItemGiaoDienVaNgonNgu.Caption = "Giao diện và Ngôn ngữ";
            this.backstageViewTabItemGiaoDienVaNgonNgu.ContentControl = this.backstageViewClientControlGiaoDienVaNgonNgu;
            this.backstageViewTabItemGiaoDienVaNgonNgu.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemGiaoDienVaNgonNgu.Glyph")));
            this.backstageViewTabItemGiaoDienVaNgonNgu.Name = "backstageViewTabItemGiaoDienVaNgonNgu";
            this.backstageViewTabItemGiaoDienVaNgonNgu.Selected = false;
            this.backstageViewTabItemGiaoDienVaNgonNgu.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemGiaoDienVaNgonNgu_SelectedChanged);
            // 
            // backstageViewItemSeparatorGiaoDienVaNgonNgu
            // 
            this.backstageViewItemSeparatorGiaoDienVaNgonNgu.Name = "backstageViewItemSeparatorGiaoDienVaNgonNgu";
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
            // backstageViewItemSeparatorCapNhatPhanMem
            // 
            this.backstageViewItemSeparatorCapNhatPhanMem.Name = "backstageViewItemSeparatorCapNhatPhanMem";
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
            // backstageViewItemSeparatorThongTinPhanMem
            // 
            this.backstageViewItemSeparatorThongTinPhanMem.Name = "backstageViewItemSeparatorThongTinPhanMem";
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
            // backstageViewItemSeparatorKhoiDongLai
            // 
            this.backstageViewItemSeparatorKhoiDongLai.Name = "backstageViewItemSeparatorKhoiDongLai";
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
            // backstageViewItemSeparatorThoat
            // 
            this.backstageViewItemSeparatorThoat.Name = "backstageViewItemSeparatorThoat";
            // 
            // barBtnUser
            // 
            this.barBtnUser.Caption = "[Unkown]";
            this.barBtnUser.Id = 1;
            this.barBtnUser.Name = "barBtnUser";
            this.barBtnUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUser_ItemClick);
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
            this.Text = "Quản lý Tài sản cố định phiên bản 1.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorCaiDatCauHinh;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemGiaoDienVaNgonNgu;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorGiaoDienVaNgonNgu;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemCapNhatPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorCapNhatPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemThongTinPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorThongTinPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemKhoiDongLai;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemThoat;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorKhoiDongLai;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorNhapLieuTuExcel;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl7;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem7;
        private DevExpress.XtraBars.BarButtonItem barBtnUser;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlImport;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlPhanQuyen;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlLogHeThong;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemImport;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorPhanQuyen;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemPhanQuyen;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorThoat;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemLogHeThong;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparatorLogHeThong;
    }
}