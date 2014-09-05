﻿namespace TSCD_GUI.QLDonVi
{
    partial class ucQuanLyDonVi
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
            this.rbnControlDonVi = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbnPageDonVi = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupDonVi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.treeListDonVi = new DevExpress.XtraTreeList.TreeList();
            this.rbnGroupLoaiDonVi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnLoaiDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.gridLookUpLoai = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpLoaiView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblLoai = new DevExpress.XtraEditors.LabelControl();
            this.lblThuoc = new DevExpress.XtraEditors.LabelControl();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoaiDonVi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoaiView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlDonVi
            // 
            this.rbnControlDonVi.ExpandCollapseItem.Id = 0;
            this.rbnControlDonVi.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlDonVi.ExpandCollapseItem,
            this.barBtnThemDonVi,
            this.barBtnSuaDonVi,
            this.barBtnXoaDonVi,
            this.barBtnLoaiDonVi});
            this.rbnControlDonVi.Location = new System.Drawing.Point(0, 0);
            this.rbnControlDonVi.MaxItemId = 5;
            this.rbnControlDonVi.Name = "rbnControlDonVi";
            this.rbnControlDonVi.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageDonVi});
            this.rbnControlDonVi.Size = new System.Drawing.Size(852, 142);
            // 
            // rbnPageDonVi
            // 
            this.rbnPageDonVi.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupDonVi,
            this.rbnGroupLoaiDonVi});
            this.rbnPageDonVi.Name = "rbnPageDonVi";
            this.rbnPageDonVi.Text = "Đơn vị";
            // 
            // rbnGroupDonVi
            // 
            this.rbnGroupDonVi.ItemLinks.Add(this.barBtnThemDonVi);
            this.rbnGroupDonVi.ItemLinks.Add(this.barBtnSuaDonVi);
            this.rbnGroupDonVi.ItemLinks.Add(this.barBtnXoaDonVi);
            this.rbnGroupDonVi.Name = "rbnGroupDonVi";
            this.rbnGroupDonVi.ShowCaptionButton = false;
            this.rbnGroupDonVi.Text = "Đơn vị";
            // 
            // barBtnThemDonVi
            // 
            this.barBtnThemDonVi.Caption = "Thêm đơn vị";
            this.barBtnThemDonVi.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemDonVi.Id = 1;
            this.barBtnThemDonVi.Name = "barBtnThemDonVi";
            // 
            // barBtnSuaDonVi
            // 
            this.barBtnSuaDonVi.Caption = "Sửa đơn vị";
            this.barBtnSuaDonVi.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaDonVi.Id = 2;
            this.barBtnSuaDonVi.Name = "barBtnSuaDonVi";
            // 
            // barBtnXoaDonVi
            // 
            this.barBtnXoaDonVi.Caption = "Xóa đơn vị";
            this.barBtnXoaDonVi.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaDonVi.Id = 3;
            this.barBtnXoaDonVi.Name = "barBtnXoaDonVi";
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 142);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeListDonVi);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(852, 366);
            this.splitContainerControlMain.SplitterPosition = 381;
            this.splitContainerControlMain.TabIndex = 1;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.btnLoaiDonVi);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblThuoc);
            this.groupControlInfo.Controls.Add(this.lblLoai);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.lblMa);
            this.groupControlInfo.Controls.Add(this.gridLookUpLoai);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.txtMa);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(381, 366);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // treeListDonVi
            // 
            this.treeListDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListDonVi.Name = "treeListDonVi";
            this.treeListDonVi.Size = new System.Drawing.Size(466, 366);
            this.treeListDonVi.TabIndex = 0;
            // 
            // rbnGroupLoaiDonVi
            // 
            this.rbnGroupLoaiDonVi.ItemLinks.Add(this.barBtnLoaiDonVi);
            this.rbnGroupLoaiDonVi.Name = "rbnGroupLoaiDonVi";
            this.rbnGroupLoaiDonVi.ShowCaptionButton = false;
            this.rbnGroupLoaiDonVi.Text = "Loại đơn vị";
            // 
            // barBtnLoaiDonVi
            // 
            this.barBtnLoaiDonVi.Caption = "Loại đơn vị";
            this.barBtnLoaiDonVi.Id = 4;
            this.barBtnLoaiDonVi.Name = "barBtnLoaiDonVi";
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.Location = new System.Drawing.Point(67, 28);
            this.txtMa.MenuManager = this.rbnControlDonVi;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(299, 20);
            this.txtMa.TabIndex = 0;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(67, 55);
            this.txtTen.MenuManager = this.rbnControlDonVi;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(299, 20);
            this.txtTen.TabIndex = 1;
            // 
            // gridLookUpLoai
            // 
            this.gridLookUpLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpLoai.Location = new System.Drawing.Point(67, 82);
            this.gridLookUpLoai.MenuManager = this.rbnControlDonVi;
            this.gridLookUpLoai.Name = "gridLookUpLoai";
            this.gridLookUpLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpLoai.Properties.View = this.gridLookUpLoaiView;
            this.gridLookUpLoai.Size = new System.Drawing.Size(227, 20);
            this.gridLookUpLoai.TabIndex = 3;
            // 
            // gridLookUpLoaiView
            // 
            this.gridLookUpLoaiView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpLoaiView.Name = "gridLookUpLoaiView";
            this.gridLookUpLoaiView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpLoaiView.OptionsView.ShowGroupPanel = false;
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(6, 31);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(50, 13);
            this.lblMa.TabIndex = 4;
            this.lblMa.Text = "Mã đơn vị:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(6, 58);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(54, 13);
            this.lblTen.TabIndex = 5;
            this.lblTen.Text = "Tên đơn vị:";
            // 
            // lblLoai
            // 
            this.lblLoai.Location = new System.Drawing.Point(6, 85);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(55, 13);
            this.lblLoai.TabIndex = 6;
            this.lblLoai.Text = "Loại đơn vị:";
            // 
            // lblThuoc
            // 
            this.lblThuoc.Location = new System.Drawing.Point(6, 110);
            this.lblThuoc.Name = "lblThuoc";
            this.lblThuoc.Size = new System.Drawing.Size(33, 13);
            this.lblThuoc.TabIndex = 7;
            this.lblThuoc.Text = "Thuộc:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(6, 136);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(343, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 12;
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_24;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(317, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 11;
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_24;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(291, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 10;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(67, 133);
            this.txtMoTa.MenuManager = this.rbnControlDonVi;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(299, 73);
            this.txtMoTa.TabIndex = 2;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(100, 212);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(181, 212);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 15;
            this.btnHuy.Text = "Hủy";
            // 
            // btnLoaiDonVi
            // 
            this.btnLoaiDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoaiDonVi.Location = new System.Drawing.Point(300, 80);
            this.btnLoaiDonVi.Name = "btnLoaiDonVi";
            this.btnLoaiDonVi.Size = new System.Drawing.Size(66, 23);
            this.btnLoaiDonVi.TabIndex = 16;
            this.btnLoaiDonVi.Text = "+";
            // 
            // ucQuanLyDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.rbnControlDonVi);
            this.Name = "ucQuanLyDonVi";
            this.Size = new System.Drawing.Size(852, 508);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoaiView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlDonVi;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageDonVi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupDonVi;
        private DevExpress.XtraBars.BarButtonItem barBtnThemDonVi;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaDonVi;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaDonVi;
        private DevExpress.XtraBars.BarButtonItem barBtnLoaiDonVi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiDonVi;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeListDonVi;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblThuoc;
        private DevExpress.XtraEditors.LabelControl lblLoai;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.LabelControl lblMa;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpLoai;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpLoaiView;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.SimpleButton btnLoaiDonVi;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
    }
}