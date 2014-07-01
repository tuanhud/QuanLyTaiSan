﻿namespace QuanLyTaiSanGUI.QLLoaiThietBi
{
    partial class ucQuanLyLoaiTB
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListLoaiTB = new DevExpress.XtraTreeList.TreeList();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueThuoc = new DevExpress.XtraEditors.LookUpEdit();
            this.ceTBsoluonglon = new DevExpress.XtraEditors.CheckEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ribbonLoaiTB = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonThemLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSuaLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonXoaLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageLoaiTB_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupLoaiTB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueThuoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceTBsoluonglon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonLoaiTB)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListLoaiTB);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(866, 477);
            this.splitContainerControl1.SplitterPosition = 485;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListLoaiTB
            // 
            this.treeListLoaiTB.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colten});
            this.treeListLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLoaiTB.KeyFieldName = "id";
            this.treeListLoaiTB.Location = new System.Drawing.Point(0, 0);
            this.treeListLoaiTB.Name = "treeListLoaiTB";
            this.treeListLoaiTB.OptionsBehavior.Editable = false;
            this.treeListLoaiTB.OptionsBehavior.EnableFiltering = true;
            this.treeListLoaiTB.OptionsFind.AllowFindPanel = true;
            this.treeListLoaiTB.OptionsFind.AlwaysVisible = true;
            this.treeListLoaiTB.ParentFieldName = "parent_id";
            this.treeListLoaiTB.Size = new System.Drawing.Size(485, 477);
            this.treeListLoaiTB.TabIndex = 0;
            this.treeListLoaiTB.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListLoaiTB_FocusedNodeChanged);
            this.treeListLoaiTB.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colten
            // 
            this.colten.Caption = "Loại thiết bị";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtMoTa);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnOk);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.ceTBsoluonglon);
            this.groupControl1.Controls.Add(this.txtTen);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(376, 477);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(57, 53);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Properties.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(314, 120);
            this.txtMoTa.TabIndex = 2;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(127, 227);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(45, 228);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lueThuoc);
            this.panelControl1.Location = new System.Drawing.Point(57, 179);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(314, 20);
            this.panelControl1.TabIndex = 7;
            // 
            // lueThuoc
            // 
            this.lueThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueThuoc.Location = new System.Drawing.Point(0, 0);
            this.lueThuoc.Name = "lueThuoc";
            this.lueThuoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueThuoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Loại")});
            this.lueThuoc.Properties.DisplayMember = "ten";
            this.lueThuoc.Properties.NullText = "";
            this.lueThuoc.Properties.ReadOnly = true;
            this.lueThuoc.Properties.ValueMember = "id";
            this.lueThuoc.Size = new System.Drawing.Size(314, 20);
            this.lueThuoc.TabIndex = 3;
            // 
            // ceTBsoluonglon
            // 
            this.ceTBsoluonglon.Location = new System.Drawing.Point(55, 202);
            this.ceTBsoluonglon.Name = "ceTBsoluonglon";
            this.ceTBsoluonglon.Properties.Caption = "Thiết bị được quản lý với số lượng lớn";
            this.ceTBsoluonglon.Properties.ReadOnly = true;
            this.ceTBsoluonglon.Size = new System.Drawing.Size(222, 19);
            this.ceTBsoluonglon.TabIndex = 4;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(57, 27);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(314, 20);
            this.txtTen.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 182);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Thuộc:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên loại:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // ribbonLoaiTB
            // 
            this.ribbonLoaiTB.ApplicationIcon = global::QuanLyTaiSanGUI.Properties.Resources.Logo;
            this.ribbonLoaiTB.ExpandCollapseItem.Id = 0;
            this.ribbonLoaiTB.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonLoaiTB.ExpandCollapseItem,
            this.barButtonThemLoaiTB,
            this.barButtonSuaLoaiTB,
            this.barButtonXoaLoaiTB});
            this.ribbonLoaiTB.Location = new System.Drawing.Point(0, 0);
            this.ribbonLoaiTB.MaxItemId = 42;
            this.ribbonLoaiTB.Name = "ribbonLoaiTB";
            this.ribbonLoaiTB.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageLoaiTB_Home});
            this.ribbonLoaiTB.Size = new System.Drawing.Size(866, 145);
            // 
            // barButtonThemLoaiTB
            // 
            this.barButtonThemLoaiTB.Caption = "Thêm loại thiết bị";
            this.barButtonThemLoaiTB.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.plus_2;
            this.barButtonThemLoaiTB.Id = 39;
            this.barButtonThemLoaiTB.Name = "barButtonThemLoaiTB";
            this.barButtonThemLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonThemLoaiTB_ItemClick);
            // 
            // barButtonSuaLoaiTB
            // 
            this.barButtonSuaLoaiTB.Caption = "Sửa loại thiết bị";
            this.barButtonSuaLoaiTB.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit;
            this.barButtonSuaLoaiTB.Id = 40;
            this.barButtonSuaLoaiTB.Name = "barButtonSuaLoaiTB";
            this.barButtonSuaLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSuaLoaiTB_ItemClick);
            // 
            // barButtonXoaLoaiTB
            // 
            this.barButtonXoaLoaiTB.Caption = "Xóa loại thiết bị";
            this.barButtonXoaLoaiTB.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.minus_2;
            this.barButtonXoaLoaiTB.Id = 41;
            this.barButtonXoaLoaiTB.Name = "barButtonXoaLoaiTB";
            this.barButtonXoaLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonXoaLoaiTB_ItemClick);
            // 
            // rbnPageLoaiTB_Home
            // 
            this.rbnPageLoaiTB_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupLoaiTB});
            this.rbnPageLoaiTB_Home.Image = global::QuanLyTaiSanGUI.Properties.Resources.chair_icon;
            this.rbnPageLoaiTB_Home.Name = "rbnPageLoaiTB_Home";
            this.rbnPageLoaiTB_Home.Text = "Loại thiết bị";
            // 
            // rbnGroupLoaiTB
            // 
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barButtonThemLoaiTB);
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barButtonSuaLoaiTB);
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barButtonXoaLoaiTB);
            this.rbnGroupLoaiTB.Name = "rbnGroupLoaiTB";
            this.rbnGroupLoaiTB.Text = "Loại thiết bị";
            // 
            // ucQuanLyLoaiTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonLoaiTB);
            this.Name = "ucQuanLyLoaiTB";
            this.Size = new System.Drawing.Size(866, 622);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueThuoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceTBsoluonglon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonLoaiTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListLoaiTB;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraEditors.CheckEdit ceTBsoluonglon;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueThuoc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonThemLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonSuaLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonXoaLoaiTB;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageLoaiTB_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiTB;
    }
}
