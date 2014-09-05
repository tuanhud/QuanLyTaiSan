namespace TSCD_GUI.QLLoaiTaiSan
{
    partial class ucQuanLyLoaiTS
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
            this.rbnControlLoaiTS = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemLoaiTS = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageLoaiTS = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupLoaiTS = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupDonViTinh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnDonViTinh = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.treeListLoaiTS = new DevExpress.XtraTreeList.TreeList();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.gridLookUpDonViTinh = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblDonViTinh = new DevExpress.XtraEditors.LabelControl();
            this.lblThuoc = new DevExpress.XtraEditors.LabelControl();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnDonViTinh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlLoaiTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDonViTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlLoaiTS
            // 
            this.rbnControlLoaiTS.ExpandCollapseItem.Id = 0;
            this.rbnControlLoaiTS.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlLoaiTS.ExpandCollapseItem,
            this.barBtnThemLoaiTS,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barBtnDonViTinh});
            this.rbnControlLoaiTS.Location = new System.Drawing.Point(0, 0);
            this.rbnControlLoaiTS.MaxItemId = 5;
            this.rbnControlLoaiTS.Name = "rbnControlLoaiTS";
            this.rbnControlLoaiTS.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageLoaiTS});
            this.rbnControlLoaiTS.Size = new System.Drawing.Size(850, 142);
            // 
            // barBtnThemLoaiTS
            // 
            this.barBtnThemLoaiTS.Caption = "Thêm loại tài sản";
            this.barBtnThemLoaiTS.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemLoaiTS.Id = 1;
            this.barBtnThemLoaiTS.Name = "barBtnThemLoaiTS";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa loại tài sản";
            this.barButtonItem2.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Xóa loại tài sản";
            this.barButtonItem3.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // rbnPageLoaiTS
            // 
            this.rbnPageLoaiTS.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupLoaiTS,
            this.rbnGroupDonViTinh});
            this.rbnPageLoaiTS.Name = "rbnPageLoaiTS";
            this.rbnPageLoaiTS.Text = "Loại tài sản";
            // 
            // rbnGroupLoaiTS
            // 
            this.rbnGroupLoaiTS.ItemLinks.Add(this.barBtnThemLoaiTS);
            this.rbnGroupLoaiTS.ItemLinks.Add(this.barButtonItem2);
            this.rbnGroupLoaiTS.ItemLinks.Add(this.barButtonItem3);
            this.rbnGroupLoaiTS.Name = "rbnGroupLoaiTS";
            this.rbnGroupLoaiTS.ShowCaptionButton = false;
            this.rbnGroupLoaiTS.Text = "Loại tài sản";
            // 
            // rbnGroupDonViTinh
            // 
            this.rbnGroupDonViTinh.ItemLinks.Add(this.barBtnDonViTinh);
            this.rbnGroupDonViTinh.Name = "rbnGroupDonViTinh";
            this.rbnGroupDonViTinh.ShowCaptionButton = false;
            this.rbnGroupDonViTinh.Text = "Đơn vị tính";
            // 
            // barBtnDonViTinh
            // 
            this.barBtnDonViTinh.Caption = "Đơn vị tính";
            this.barBtnDonViTinh.Id = 4;
            this.barBtnDonViTinh.Name = "barBtnDonViTinh";
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 142);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeListLoaiTS);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(850, 370);
            this.splitContainerControlMain.SplitterPosition = 372;
            this.splitContainerControlMain.TabIndex = 1;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.btnDonViTinh);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblThuoc);
            this.groupControlInfo.Controls.Add(this.lblDonViTinh);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.lblMa);
            this.groupControlInfo.Controls.Add(this.gridLookUpDonViTinh);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.txtMa);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(372, 370);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // treeListLoaiTS
            // 
            this.treeListLoaiTS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLoaiTS.Location = new System.Drawing.Point(0, 0);
            this.treeListLoaiTS.Name = "treeListLoaiTS";
            this.treeListLoaiTS.Size = new System.Drawing.Size(473, 370);
            this.treeListLoaiTS.TabIndex = 0;
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(333, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 12;
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_24;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(307, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 11;
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_24;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(281, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 10;
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.Location = new System.Drawing.Point(88, 28);
            this.txtMa.MenuManager = this.rbnControlLoaiTS;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(268, 20);
            this.txtMa.TabIndex = 13;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(88, 54);
            this.txtTen.MenuManager = this.rbnControlLoaiTS;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(268, 20);
            this.txtTen.TabIndex = 14;
            // 
            // gridLookUpDonViTinh
            // 
            this.gridLookUpDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpDonViTinh.Location = new System.Drawing.Point(88, 80);
            this.gridLookUpDonViTinh.MenuManager = this.rbnControlLoaiTS;
            this.gridLookUpDonViTinh.Name = "gridLookUpDonViTinh";
            this.gridLookUpDonViTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpDonViTinh.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpDonViTinh.Size = new System.Drawing.Size(193, 20);
            this.gridLookUpDonViTinh.TabIndex = 15;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(6, 31);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(72, 13);
            this.lblMa.TabIndex = 17;
            this.lblMa.Text = "Mã loại tài sản:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(6, 57);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(76, 13);
            this.lblTen.TabIndex = 18;
            this.lblTen.Text = "Tên loại tài sản:";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Location = new System.Drawing.Point(6, 83);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(56, 13);
            this.lblDonViTinh.TabIndex = 19;
            this.lblDonViTinh.Text = "Đơn vị tính:";
            // 
            // lblThuoc
            // 
            this.lblThuoc.Location = new System.Drawing.Point(6, 109);
            this.lblThuoc.Name = "lblThuoc";
            this.lblThuoc.Size = new System.Drawing.Size(33, 13);
            this.lblThuoc.TabIndex = 20;
            this.lblThuoc.Text = "Thuộc:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(6, 135);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 21;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(88, 132);
            this.txtMoTa.MenuManager = this.rbnControlLoaiTS;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(268, 83);
            this.txtMoTa.TabIndex = 16;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnDonViTinh
            // 
            this.btnDonViTinh.Location = new System.Drawing.Point(287, 78);
            this.btnDonViTinh.Name = "btnDonViTinh";
            this.btnDonViTinh.Size = new System.Drawing.Size(69, 23);
            this.btnDonViTinh.TabIndex = 22;
            this.btnDonViTinh.Text = "+";
            // 
            // ucQuanLyLoaiTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.rbnControlLoaiTS);
            this.Name = "ucQuanLyLoaiTS";
            this.Size = new System.Drawing.Size(850, 512);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlLoaiTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDonViTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlLoaiTS;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageLoaiTS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiTS;
        private DevExpress.XtraBars.BarButtonItem barBtnThemLoaiTS;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barBtnDonViTinh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupDonViTinh;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeListLoaiTS;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.SimpleButton btnDonViTinh;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblThuoc;
        private DevExpress.XtraEditors.LabelControl lblDonViTinh;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.LabelControl lblMa;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpDonViTinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
    }
}
