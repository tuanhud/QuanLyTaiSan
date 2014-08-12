namespace QuanLyTaiSanGUI
{
    partial class frmMain
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::QuanLyTaiSanGUI.SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControlCauHinh = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlGiaoDienvaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControlThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewItemSeparator2 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemCauHinh = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator6 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemGiaoDienvaNgonNgu = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator4 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemCapNhatPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator5 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemThongTinPhanMem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemRestart = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator7 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItemLogout = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.barStaticUser = new DevExpress.XtraBars.BarStaticItem();
            this.rbnPageNothing = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupQLPhong = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupQlTaiSan = new DevExpress.XtraNavBar.NavBarGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonMain.ApplicationIcon = global::QuanLyTaiSanGUI.Properties.Resources.Logo;
            this.ribbonMain.AutoSizeItems = true;
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.barStaticUser});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 3;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageNothing});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonMain.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonMain.Size = new System.Drawing.Size(900, 147);
            this.ribbonMain.StatusBar = this.ribbonStatusBar;
            this.ribbonMain.SelectedPageChanging += new DevExpress.XtraBars.Ribbon.RibbonPageChangingEventHandler(this.ribbonMain_SelectedPageChanging);
            this.ribbonMain.SelectedPageChanged += new System.EventHandler(this.ribbonMain_SelectedPageChanged);
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControlCauHinh);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControlGiaoDienvaNgonNgu);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControlCapNhatPhanMem);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControlThongTinPhanMem);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl2);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator2);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItemCauHinh);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator6);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItemGiaoDienvaNgonNgu);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator4);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItemCapNhatPhanMem);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator5);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItemThongTinPhanMem);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItemRestart);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator7);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItemLogout);
            this.backstageViewControl1.Location = new System.Drawing.Point(0, 0);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.Ribbon = this.ribbonMain;
            this.backstageViewControl1.SelectedTab = null;
            this.backstageViewControl1.Size = new System.Drawing.Size(641, 529);
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            this.backstageViewControl1.Hidden += new System.EventHandler(this.backstageViewControl1_Hidden);
            // 
            // backstageViewClientControlCauHinh
            // 
            this.backstageViewClientControlCauHinh.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlCauHinh.Name = "backstageViewClientControlCauHinh";
            this.backstageViewClientControlCauHinh.Size = new System.Drawing.Size(440, 529);
            this.backstageViewClientControlCauHinh.TabIndex = 0;
            // 
            // backstageViewClientControlGiaoDienvaNgonNgu
            // 
            this.backstageViewClientControlGiaoDienvaNgonNgu.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlGiaoDienvaNgonNgu.Name = "backstageViewClientControlGiaoDienvaNgonNgu";
            this.backstageViewClientControlGiaoDienvaNgonNgu.Size = new System.Drawing.Size(440, 529);
            this.backstageViewClientControlGiaoDienvaNgonNgu.TabIndex = 1;
            // 
            // backstageViewClientControlCapNhatPhanMem
            // 
            this.backstageViewClientControlCapNhatPhanMem.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlCapNhatPhanMem.Name = "backstageViewClientControlCapNhatPhanMem";
            this.backstageViewClientControlCapNhatPhanMem.Size = new System.Drawing.Size(440, 529);
            this.backstageViewClientControlCapNhatPhanMem.TabIndex = 2;
            // 
            // backstageViewClientControlThongTinPhanMem
            // 
            this.backstageViewClientControlThongTinPhanMem.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControlThongTinPhanMem.Name = "backstageViewClientControlThongTinPhanMem";
            this.backstageViewClientControlThongTinPhanMem.Size = new System.Drawing.Size(440, 529);
            this.backstageViewClientControlThongTinPhanMem.TabIndex = 3;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(440, 529);
            this.backstageViewClientControl1.TabIndex = 5;
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Location = new System.Drawing.Point(201, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new System.Drawing.Size(440, 529);
            this.backstageViewClientControl2.TabIndex = 6;
            // 
            // backstageViewItemSeparator2
            // 
            this.backstageViewItemSeparator2.Name = "backstageViewItemSeparator2";
            // 
            // backstageViewTabItemCauHinh
            // 
            this.backstageViewTabItemCauHinh.Caption = "Cài đặt cấu hình";
            this.backstageViewTabItemCauHinh.ContentControl = this.backstageViewClientControlCauHinh;
            this.backstageViewTabItemCauHinh.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemCauHinh.Glyph")));
            this.backstageViewTabItemCauHinh.Name = "backstageViewTabItemCauHinh";
            this.backstageViewTabItemCauHinh.Selected = false;
            this.backstageViewTabItemCauHinh.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemCauHinh_SelectedChanged);
            // 
            // backstageViewItemSeparator6
            // 
            this.backstageViewItemSeparator6.Name = "backstageViewItemSeparator6";
            // 
            // backstageViewTabItemGiaoDienvaNgonNgu
            // 
            this.backstageViewTabItemGiaoDienvaNgonNgu.Caption = "Giao diện và Ngôn ngữ";
            this.backstageViewTabItemGiaoDienvaNgonNgu.ContentControl = this.backstageViewClientControlGiaoDienvaNgonNgu;
            this.backstageViewTabItemGiaoDienvaNgonNgu.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemGiaoDienvaNgonNgu.Glyph")));
            this.backstageViewTabItemGiaoDienvaNgonNgu.Name = "backstageViewTabItemGiaoDienvaNgonNgu";
            this.backstageViewTabItemGiaoDienvaNgonNgu.Selected = false;
            this.backstageViewTabItemGiaoDienvaNgonNgu.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemGiaoDienvaNgonNgu_SelectedChanged);
            // 
            // backstageViewItemSeparator4
            // 
            this.backstageViewItemSeparator4.Name = "backstageViewItemSeparator4";
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
            // backstageViewItemSeparator5
            // 
            this.backstageViewItemSeparator5.Name = "backstageViewItemSeparator5";
            // 
            // backstageViewTabItemThongTinPhanMem
            // 
            this.backstageViewTabItemThongTinPhanMem.Caption = "Thông tin phần mềm";
            this.backstageViewTabItemThongTinPhanMem.ContentControl = this.backstageViewClientControlThongTinPhanMem;
            this.backstageViewTabItemThongTinPhanMem.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemThongTinPhanMem.Glyph")));
            this.backstageViewTabItemThongTinPhanMem.Name = "backstageViewTabItemThongTinPhanMem";
            this.backstageViewTabItemThongTinPhanMem.Selected = false;
            this.backstageViewTabItemThongTinPhanMem.Tag = "1";
            this.backstageViewTabItemThongTinPhanMem.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemThongTinPhanMem_SelectedChanged);
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // backstageViewTabItemRestart
            // 
            this.backstageViewTabItemRestart.Caption = "Khởi động lại";
            this.backstageViewTabItemRestart.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItemRestart.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemRestart.Glyph")));
            this.backstageViewTabItemRestart.Name = "backstageViewTabItemRestart";
            this.backstageViewTabItemRestart.Selected = false;
            this.backstageViewTabItemRestart.ItemPressed += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemRestart_ItemPressed);
            // 
            // backstageViewItemSeparator7
            // 
            this.backstageViewItemSeparator7.Name = "backstageViewItemSeparator7";
            // 
            // backstageViewTabItemLogout
            // 
            this.backstageViewTabItemLogout.Caption = "Thoát";
            this.backstageViewTabItemLogout.ContentControl = this.backstageViewClientControl2;
            this.backstageViewTabItemLogout.Glyph = ((System.Drawing.Image)(resources.GetObject("backstageViewTabItemLogout.Glyph")));
            this.backstageViewTabItemLogout.Name = "backstageViewTabItemLogout";
            this.backstageViewTabItemLogout.Selected = false;
            this.backstageViewTabItemLogout.ItemPressed += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewTabItemLogout_ItemPressed);
            // 
            // barStaticUser
            // 
            this.barStaticUser.Caption = "null";
            this.barStaticUser.Id = 2;
            this.barStaticUser.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticUser.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticUser.Name = "barStaticUser";
            this.barStaticUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // rbnPageNothing
            // 
            this.rbnPageNothing.Name = "rbnPageNothing";
            this.rbnPageNothing.Text = "Nothing";
            this.rbnPageNothing.Visible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticUser);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 676);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonMain;
            this.ribbonStatusBar.Size = new System.Drawing.Size(900, 23);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroupQLPhong;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupQLPhong,
            this.navBarGroupQlTaiSan});
            this.navBarControl1.Location = new System.Drawing.Point(0, 147);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 259;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(259, 529);
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.GroupCollapsing += new DevExpress.XtraNavBar.NavBarGroupCancelEventHandler(this.navBarControl1_GroupCollapsing);
            this.navBarControl1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_ActiveGroupChanged);
            // 
            // navBarGroupQLPhong
            // 
            this.navBarGroupQLPhong.Caption = "Quản lý phòng học";
            this.navBarGroupQLPhong.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroupQLPhong.Expanded = true;
            this.navBarGroupQLPhong.GroupClientHeight = 80;
            this.navBarGroupQLPhong.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupQLPhong.Name = "navBarGroupQLPhong";
            this.navBarGroupQLPhong.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.phong1;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(257, 406);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // navBarGroupQlTaiSan
            // 
            this.navBarGroupQlTaiSan.Caption = "Quản lý tài sản cố định";
            this.navBarGroupQlTaiSan.Name = "navBarGroupQlTaiSan";
            this.navBarGroupQlTaiSan.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.thongke;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.backstageViewControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(259, 147);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(641, 529);
            this.panelControl1.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 699);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(908, 600);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản lý phòng học v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupQLPhong;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupQlTaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageNothing;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlCauHinh;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlGiaoDienvaNgonNgu;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlCapNhatPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControlThongTinPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemCauHinh;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator2;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemGiaoDienvaNgonNgu;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator4;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemCapNhatPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator5;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemThongTinPhanMem;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator6;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemRestart;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator7;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItemLogout;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.BarStaticItem barStaticUser;    
        
    }
}