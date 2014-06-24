﻿namespace QuanLyTaiSanGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbnPageLoaiTB_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupLoaiTB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPagePhanQuyen_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageThongKe_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupPhong = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupViTri = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupLoaiTB = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupNhanVien = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupPhanQuyen = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupThongKe = new DevExpress.XtraNavBar.NavBarGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ApplicationIcon = global::QuanLyTaiSanGUI.Properties.Resources.Logo;
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 39;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageLoaiTB_Home,
            this.rbnPagePhanQuyen_Home,
            this.rbnPageThongKe_Home});
            this.ribbonMain.Size = new System.Drawing.Size(900, 144);
            this.ribbonMain.StatusBar = this.ribbonStatusBar;
            // 
            // rbnPageLoaiTB_Home
            // 
            this.rbnPageLoaiTB_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupLoaiTB});
            this.rbnPageLoaiTB_Home.Name = "rbnPageLoaiTB_Home";
            this.rbnPageLoaiTB_Home.Text = "Trang chính";
            this.rbnPageLoaiTB_Home.Visible = false;
            // 
            // rbnGroupLoaiTB
            // 
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barBtnThemLoaiTB);
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barBtnSuaLoaiTB);
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barBtnXoaLoaiTB);
            this.rbnGroupLoaiTB.Name = "rbnGroupLoaiTB";
            this.rbnGroupLoaiTB.Text = "Loại thiết bị";
            // 
            // barBtnThemLoaiTB
            // 
            this.barBtnThemLoaiTB.Caption = "Thêm loại thiết bị";
            this.barBtnThemLoaiTB.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.plus_2;
            this.barBtnThemLoaiTB.Id = 22;
            this.barBtnThemLoaiTB.Name = "barBtnThemLoaiTB";
            this.barBtnThemLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemLoaiTB_ItemClick);
            // 
            // barBtnSuaLoaiTB
            // 
            this.barBtnSuaLoaiTB.Caption = "Sửa loại thiết bị";
            this.barBtnSuaLoaiTB.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit;
            this.barBtnSuaLoaiTB.Id = 23;
            this.barBtnSuaLoaiTB.Name = "barBtnSuaLoaiTB";
            this.barBtnSuaLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaLoaiTB_ItemClick);
            // 
            // barBtnXoaLoaiTB
            // 
            this.barBtnXoaLoaiTB.Caption = "Xóa loại thiết bị";
            this.barBtnXoaLoaiTB.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.minus_2;
            this.barBtnXoaLoaiTB.Id = 24;
            this.barBtnXoaLoaiTB.Name = "barBtnXoaLoaiTB";
            this.barBtnXoaLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaLoaiTB_ItemClick);
            // 
            // rbnPagePhanQuyen_Home
            // 
            this.rbnPagePhanQuyen_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rbnPagePhanQuyen_Home.Name = "rbnPagePhanQuyen_Home";
            this.rbnPagePhanQuyen_Home.Text = "Trang chính";
            this.rbnPagePhanQuyen_Home.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Phân quyền";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm quản trị";
            this.barButtonItem1.Id = 25;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa quản trị";
            this.barButtonItem2.Id = 26;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Xóa quản trị";
            this.barButtonItem3.Id = 27;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // rbnPageThongKe_Home
            // 
            this.rbnPageThongKe_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rbnPageThongKe_Home.Name = "rbnPageThongKe_Home";
            this.rbnPageThongKe_Home.Text = "Trang chính";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Thống kê";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 29;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 668);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonMain;
            this.ribbonStatusBar.Size = new System.Drawing.Size(900, 31);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroupPhong;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer3);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupViTri,
            this.navBarGroupPhong,
            this.navBarGroupLoaiTB,
            this.navBarGroupNhanVien,
            this.navBarGroupPhanQuyen,
            this.navBarGroupThongKe});
            this.navBarControl1.Location = new System.Drawing.Point(0, 144);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 259;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(259, 524);
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_ActiveGroupChanged);
            // 
            // navBarGroupPhong
            // 
            this.navBarGroupPhong.Caption = "Quản lý phòng";
            this.navBarGroupPhong.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroupPhong.Expanded = true;
            this.navBarGroupPhong.GroupClientHeight = 80;
            this.navBarGroupPhong.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupPhong.Name = "navBarGroupPhong";
            this.navBarGroupPhong.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.phong1;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(259, 269);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(259, 281);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(259, 269);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // navBarGroupViTri
            // 
            this.navBarGroupViTri.Caption = "Quản lý vị trí";
            this.navBarGroupViTri.Name = "navBarGroupViTri";
            this.navBarGroupViTri.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.vitri1;
            // 
            // navBarGroupLoaiTB
            // 
            this.navBarGroupLoaiTB.Caption = "Quản lý loại thiết bị";
            this.navBarGroupLoaiTB.Name = "navBarGroupLoaiTB";
            this.navBarGroupLoaiTB.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.chair_icon;
            // 
            // navBarGroupNhanVien
            // 
            this.navBarGroupNhanVien.Caption = "Quản lý nhân viên phụ trách";
            this.navBarGroupNhanVien.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroupNhanVien.GroupClientHeight = 80;
            this.navBarGroupNhanVien.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupNhanVien.Name = "navBarGroupNhanVien";
            this.navBarGroupNhanVien.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.nhanvien;
            // 
            // navBarGroupPhanQuyen
            // 
            this.navBarGroupPhanQuyen.Caption = "Phân quyền";
            this.navBarGroupPhanQuyen.Name = "navBarGroupPhanQuyen";
            this.navBarGroupPhanQuyen.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.phanquyen;
            // 
            // navBarGroupThongKe
            // 
            this.navBarGroupThongKe.Caption = "Thống kê";
            this.navBarGroupThongKe.ControlContainer = this.navBarGroupControlContainer3;
            this.navBarGroupThongKe.GroupClientHeight = 80;
            this.navBarGroupThongKe.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupThongKe.Name = "navBarGroupThongKe";
            this.navBarGroupThongKe.SmallImage = global::QuanLyTaiSanGUI.Properties.Resources.thongke;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(259, 144);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(641, 524);
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
            this.Name = "frmMain";
            this.Ribbon = this.ribbonMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản lý phòng học v1.0";
            this.Load += new System.EventHandler(this.RibbonForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupPhong;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupViTri;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPagePhanQuyen_Home;
        private DevExpress.XtraBars.BarButtonItem barBtnThemCoSo;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupLoaiTB;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupNhanVien;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupPhanQuyen;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupThongKe;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnThemDay;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTang;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTang;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTang;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraBars.BarButtonItem barBtnThemLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaLoaiTB;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageLoaiTB_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiTB;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageThongKe_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
    }
}