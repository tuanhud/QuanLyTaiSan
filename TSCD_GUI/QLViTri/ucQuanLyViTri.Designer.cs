namespace TSCD_GUI.QLViTri
{
    partial class ucQuanLyViTri
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
            this.rbnControlViTri = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemCoSo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaCoSo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaCoSo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnThemDay = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaDay = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaDay = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnThemTang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTang = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageViTri = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupCoSo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupDay = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupTang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListViTri = new DevExpress.XtraTreeList.TreeList();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.panelControlViTri = new DevExpress.XtraEditors.PanelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.lblThuoc = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlViTri
            // 
            this.rbnControlViTri.ExpandCollapseItem.Id = 0;
            this.rbnControlViTri.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlViTri.ExpandCollapseItem,
            this.barBtnThemCoSo,
            this.barBtnSuaCoSo,
            this.barBtnXoaCoSo,
            this.barBtnThemDay,
            this.barBtnSuaDay,
            this.barBtnXoaDay,
            this.barBtnThemTang,
            this.barBtnSuaTang,
            this.barBtnXoaTang});
            this.rbnControlViTri.Location = new System.Drawing.Point(0, 0);
            this.rbnControlViTri.MaxItemId = 10;
            this.rbnControlViTri.Name = "rbnControlViTri";
            this.rbnControlViTri.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageViTri});
            this.rbnControlViTri.Size = new System.Drawing.Size(840, 142);
            // 
            // barBtnThemCoSo
            // 
            this.barBtnThemCoSo.Caption = "Thêm cơ sở";
            this.barBtnThemCoSo.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemCoSo.Id = 1;
            this.barBtnThemCoSo.Name = "barBtnThemCoSo";
            this.barBtnThemCoSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemCoSo_ItemClick);
            // 
            // barBtnSuaCoSo
            // 
            this.barBtnSuaCoSo.Caption = "Sửa cơ sở";
            this.barBtnSuaCoSo.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaCoSo.Id = 2;
            this.barBtnSuaCoSo.Name = "barBtnSuaCoSo";
            this.barBtnSuaCoSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaCoSo_ItemClick);
            // 
            // barBtnXoaCoSo
            // 
            this.barBtnXoaCoSo.Caption = "Xóa cơ sở";
            this.barBtnXoaCoSo.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaCoSo.Id = 3;
            this.barBtnXoaCoSo.Name = "barBtnXoaCoSo";
            this.barBtnXoaCoSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaCoSo_ItemClick);
            // 
            // barBtnThemDay
            // 
            this.barBtnThemDay.Caption = "Thêm dãy";
            this.barBtnThemDay.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemDay.Id = 4;
            this.barBtnThemDay.Name = "barBtnThemDay";
            this.barBtnThemDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemDay_ItemClick);
            // 
            // barBtnSuaDay
            // 
            this.barBtnSuaDay.Caption = "Sửa dãy";
            this.barBtnSuaDay.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaDay.Id = 5;
            this.barBtnSuaDay.Name = "barBtnSuaDay";
            this.barBtnSuaDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaDay_ItemClick);
            // 
            // barBtnXoaDay
            // 
            this.barBtnXoaDay.Caption = "Xóa dãy";
            this.barBtnXoaDay.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaDay.Id = 6;
            this.barBtnXoaDay.Name = "barBtnXoaDay";
            this.barBtnXoaDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaDay_ItemClick);
            // 
            // barBtnThemTang
            // 
            this.barBtnThemTang.Caption = "Thêm tầng";
            this.barBtnThemTang.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemTang.Id = 7;
            this.barBtnThemTang.Name = "barBtnThemTang";
            this.barBtnThemTang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemTang_ItemClick);
            // 
            // barBtnSuaTang
            // 
            this.barBtnSuaTang.Caption = "Sửa tầng";
            this.barBtnSuaTang.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaTang.Id = 8;
            this.barBtnSuaTang.Name = "barBtnSuaTang";
            this.barBtnSuaTang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaTang_ItemClick);
            // 
            // barBtnXoaTang
            // 
            this.barBtnXoaTang.Caption = "Xóa tầng";
            this.barBtnXoaTang.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaTang.Id = 9;
            this.barBtnXoaTang.Name = "barBtnXoaTang";
            this.barBtnXoaTang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaTang_ItemClick);
            // 
            // rbnPageViTri
            // 
            this.rbnPageViTri.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupCoSo,
            this.rbnGroupDay,
            this.rbnGroupTang});
            this.rbnPageViTri.Name = "rbnPageViTri";
            this.rbnPageViTri.Text = "Vị trí";
            // 
            // rbnGroupCoSo
            // 
            this.rbnGroupCoSo.ItemLinks.Add(this.barBtnThemCoSo);
            this.rbnGroupCoSo.ItemLinks.Add(this.barBtnSuaCoSo);
            this.rbnGroupCoSo.ItemLinks.Add(this.barBtnXoaCoSo);
            this.rbnGroupCoSo.Name = "rbnGroupCoSo";
            this.rbnGroupCoSo.ShowCaptionButton = false;
            this.rbnGroupCoSo.Text = "Cơ sở";
            // 
            // rbnGroupDay
            // 
            this.rbnGroupDay.ItemLinks.Add(this.barBtnThemDay);
            this.rbnGroupDay.ItemLinks.Add(this.barBtnSuaDay);
            this.rbnGroupDay.ItemLinks.Add(this.barBtnXoaDay);
            this.rbnGroupDay.Name = "rbnGroupDay";
            this.rbnGroupDay.ShowCaptionButton = false;
            this.rbnGroupDay.Text = "Dãy";
            // 
            // rbnGroupTang
            // 
            this.rbnGroupTang.ItemLinks.Add(this.barBtnThemTang);
            this.rbnGroupTang.ItemLinks.Add(this.barBtnSuaTang);
            this.rbnGroupTang.ItemLinks.Add(this.barBtnXoaTang);
            this.rbnGroupTang.Name = "rbnGroupTang";
            this.rbnGroupTang.ShowCaptionButton = false;
            this.rbnGroupTang.Text = "Tầng";
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 142);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeListViTri);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(840, 375);
            this.splitContainerControlMain.SplitterPosition = 358;
            this.splitContainerControlMain.TabIndex = 1;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // treeListViTri
            // 
            this.treeListViTri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colten,
            this.colloai,
            this.colid});
            this.treeListViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViTri.KeyFieldName = "id";
            this.treeListViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListViTri.Name = "treeListViTri";
            this.treeListViTri.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeListViTri.OptionsBehavior.Editable = false;
            this.treeListViTri.OptionsBehavior.EnableFiltering = true;
            this.treeListViTri.OptionsFind.AllowFindPanel = true;
            this.treeListViTri.OptionsFind.AlwaysVisible = true;
            this.treeListViTri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListViTri.ParentFieldName = "parent_id";
            this.treeListViTri.Size = new System.Drawing.Size(478, 375);
            this.treeListViTri.TabIndex = 0;
            this.treeListViTri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListViTri_FocusedNodeChanged);
            this.treeListViTri.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colten
            // 
            this.colten.Caption = "Vị trí";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.lblThuoc);
            this.groupControlInfo.Controls.Add(this.panelControlViTri);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(358, 375);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // panelControlViTri
            // 
            this.panelControlViTri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlViTri.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlViTri.Location = new System.Drawing.Point(43, 54);
            this.panelControlViTri.Name = "panelControlViTri";
            this.panelControlViTri.Size = new System.Drawing.Size(297, 20);
            this.panelControlViTri.TabIndex = 11;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(168, 169);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(6, 83);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(6, 31);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(22, 13);
            this.lblTen.TabIndex = 6;
            this.lblTen.Text = "Tên:";
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(43, 28);
            this.txtTen.MenuManager = this.rbnControlViTri;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(297, 20);
            this.txtTen.TabIndex = 3;
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(317, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 2;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_24;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(291, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 1;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_24;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(265, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 0;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(43, 80);
            this.txtMoTa.MenuManager = this.rbnControlViTri;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(297, 83);
            this.txtMoTa.TabIndex = 4;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // lblThuoc
            // 
            this.lblThuoc.Location = new System.Drawing.Point(6, 57);
            this.lblThuoc.Name = "lblThuoc";
            this.lblThuoc.Size = new System.Drawing.Size(33, 13);
            this.lblThuoc.TabIndex = 12;
            this.lblThuoc.Text = "Thuộc:";
            // 
            // ucQuanLyViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.rbnControlViTri);
            this.Name = "ucQuanLyViTri";
            this.Size = new System.Drawing.Size(840, 517);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlViTri;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageViTri;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupCoSo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraBars.BarButtonItem barBtnThemCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnThemDay;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTang;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTang;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupDay;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupTang;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraTreeList.TreeList treeListViTri;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraEditors.PanelControl panelControlViTri;
        private DevExpress.XtraEditors.LabelControl lblThuoc;
    }
}
