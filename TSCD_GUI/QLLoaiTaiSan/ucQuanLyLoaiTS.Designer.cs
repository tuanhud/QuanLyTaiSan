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
            this.barBtnSuaLoaiTS = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaLoaiTS = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDonViTinh = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageLoaiTS = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupLoaiTS = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupDonViTinh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListLoaiTS = new DevExpress.XtraTreeList.TreeList();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnDonViTinh = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblThuoc = new DevExpress.XtraEditors.LabelControl();
            this.lblDonViTinh = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpDonVi = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpDonViView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.checkHuuHinh = new DevExpress.XtraEditors.CheckEdit();
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.panelControlParent = new DevExpress.XtraEditors.PanelControl();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldonvitinh = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colhuuhinh = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid_g = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten_g = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlLoaiTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDonViView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkHuuHinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlParent)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlLoaiTS
            // 
            this.rbnControlLoaiTS.ExpandCollapseItem.Id = 0;
            this.rbnControlLoaiTS.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlLoaiTS.ExpandCollapseItem,
            this.barBtnThemLoaiTS,
            this.barBtnSuaLoaiTS,
            this.barBtnXoaLoaiTS,
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
            // barBtnSuaLoaiTS
            // 
            this.barBtnSuaLoaiTS.Caption = "Sửa loại tài sản";
            this.barBtnSuaLoaiTS.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaLoaiTS.Id = 2;
            this.barBtnSuaLoaiTS.Name = "barBtnSuaLoaiTS";
            // 
            // barBtnXoaLoaiTS
            // 
            this.barBtnXoaLoaiTS.Caption = "Xóa loại tài sản";
            this.barBtnXoaLoaiTS.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaLoaiTS.Id = 3;
            this.barBtnXoaLoaiTS.Name = "barBtnXoaLoaiTS";
            // 
            // barBtnDonViTinh
            // 
            this.barBtnDonViTinh.Caption = "Đơn vị tính";
            this.barBtnDonViTinh.Id = 4;
            this.barBtnDonViTinh.Name = "barBtnDonViTinh";
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
            this.rbnGroupLoaiTS.ItemLinks.Add(this.barBtnSuaLoaiTS);
            this.rbnGroupLoaiTS.ItemLinks.Add(this.barBtnXoaLoaiTS);
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
            // treeListLoaiTS
            // 
            this.treeListLoaiTS.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.coldonvitinh,
            this.colhuuhinh});
            this.treeListLoaiTS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLoaiTS.KeyFieldName = "id";
            this.treeListLoaiTS.Location = new System.Drawing.Point(0, 0);
            this.treeListLoaiTS.Name = "treeListLoaiTS";
            this.treeListLoaiTS.OptionsBehavior.Editable = false;
            this.treeListLoaiTS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLoaiTS.OptionsView.ShowAutoFilterRow = true;
            this.treeListLoaiTS.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListLoaiTS.ParentFieldName = "parent_id";
            this.treeListLoaiTS.Size = new System.Drawing.Size(473, 370);
            this.treeListLoaiTS.TabIndex = 0;
            this.treeListLoaiTS.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListLoaiTS_FocusedNodeChanged);
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.panelControlParent);
            this.groupControlInfo.Controls.Add(this.checkHuuHinh);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.btnDonViTinh);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblThuoc);
            this.groupControlInfo.Controls.Add(this.lblDonViTinh);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.lblMa);
            this.groupControlInfo.Controls.Add(this.gridLookUpDonVi);
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
            // btnDonViTinh
            // 
            this.btnDonViTinh.Location = new System.Drawing.Point(287, 78);
            this.btnDonViTinh.Name = "btnDonViTinh";
            this.btnDonViTinh.Size = new System.Drawing.Size(69, 23);
            this.btnDonViTinh.TabIndex = 22;
            this.btnDonViTinh.Text = "+";
            this.btnDonViTinh.Click += new System.EventHandler(this.btnDonViTinh_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(6, 161);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 21;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblThuoc
            // 
            this.lblThuoc.Location = new System.Drawing.Point(6, 135);
            this.lblThuoc.Name = "lblThuoc";
            this.lblThuoc.Size = new System.Drawing.Size(33, 13);
            this.lblThuoc.TabIndex = 20;
            this.lblThuoc.Text = "Thuộc:";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Location = new System.Drawing.Point(6, 83);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(56, 13);
            this.lblDonViTinh.TabIndex = 19;
            this.lblDonViTinh.Text = "Đơn vị tính:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(6, 57);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(76, 13);
            this.lblTen.TabIndex = 18;
            this.lblTen.Text = "Tên loại tài sản:";
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(6, 31);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(72, 13);
            this.lblMa.TabIndex = 17;
            this.lblMa.Text = "Mã loại tài sản:";
            // 
            // gridLookUpDonVi
            // 
            this.gridLookUpDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpDonVi.Location = new System.Drawing.Point(88, 80);
            this.gridLookUpDonVi.MenuManager = this.rbnControlLoaiTS;
            this.gridLookUpDonVi.Name = "gridLookUpDonVi";
            this.gridLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpDonVi.Properties.DisplayMember = "ten";
            this.gridLookUpDonVi.Properties.ValueMember = "id";
            this.gridLookUpDonVi.Properties.View = this.gridLookUpDonViView;
            this.gridLookUpDonVi.Size = new System.Drawing.Size(193, 20);
            this.gridLookUpDonVi.TabIndex = 15;
            // 
            // gridLookUpDonViView
            // 
            this.gridLookUpDonViView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid_g,
            this.colten_g});
            this.gridLookUpDonViView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpDonViView.Name = "gridLookUpDonViView";
            this.gridLookUpDonViView.OptionsBehavior.Editable = false;
            this.gridLookUpDonViView.OptionsBehavior.ReadOnly = true;
            this.gridLookUpDonViView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpDonViView.OptionsView.ShowGroupPanel = false;
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
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(333, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 12;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
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
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
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
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(88, 158);
            this.txtMoTa.MenuManager = this.rbnControlLoaiTS;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(268, 83);
            this.txtMoTa.TabIndex = 16;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(88, 247);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(169, 247);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 25;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // checkHuuHinh
            // 
            this.checkHuuHinh.Location = new System.Drawing.Point(88, 107);
            this.checkHuuHinh.MenuManager = this.rbnControlLoaiTS;
            this.checkHuuHinh.Name = "checkHuuHinh";
            this.checkHuuHinh.Properties.Caption = "Loại tài sản hữu hình";
            this.checkHuuHinh.Size = new System.Drawing.Size(268, 19);
            this.checkHuuHinh.TabIndex = 26;
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // panelControlParent
            // 
            this.panelControlParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlParent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlParent.Location = new System.Drawing.Point(88, 132);
            this.panelControlParent.Name = "panelControlParent";
            this.panelControlParent.Size = new System.Drawing.Size(268, 20);
            this.panelControlParent.TabIndex = 27;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Loại tài sản";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // coldonvitinh
            // 
            this.coldonvitinh.Caption = "donvitinh";
            this.coldonvitinh.FieldName = "donvitinh.ten";
            this.coldonvitinh.Name = "coldonvitinh";
            this.coldonvitinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.coldonvitinh.Visible = true;
            this.coldonvitinh.VisibleIndex = 1;
            // 
            // colhuuhinh
            // 
            this.colhuuhinh.Caption = "Loại tài sản hữu hình";
            this.colhuuhinh.FieldName = "huuhinh";
            this.colhuuhinh.Name = "colhuuhinh";
            this.colhuuhinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colhuuhinh.Visible = true;
            this.colhuuhinh.VisibleIndex = 2;
            // 
            // colid_g
            // 
            this.colid_g.Caption = "id";
            this.colid_g.FieldName = "id";
            this.colid_g.Name = "colid_g";
            // 
            // colten_g
            // 
            this.colten_g.Caption = "Đơn vị tính";
            this.colten_g.FieldName = "ten";
            this.colten_g.Name = "colten_g";
            this.colten_g.Visible = true;
            this.colten_g.VisibleIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDonViView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkHuuHinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlLoaiTS;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageLoaiTS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiTS;
        private DevExpress.XtraBars.BarButtonItem barBtnThemLoaiTS;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaLoaiTS;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaLoaiTS;
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
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpDonViView;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.CheckEdit checkHuuHinh;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
        private DevExpress.XtraEditors.PanelControl panelControlParent;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldonvitinh;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colhuuhinh;
        private DevExpress.XtraGrid.Columns.GridColumn colid_g;
        private DevExpress.XtraGrid.Columns.GridColumn colten_g;
    }
}
