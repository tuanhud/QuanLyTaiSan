namespace PTB_GUI.QLTinhTrang
{
    partial class ucQuanLyTinhTrang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyTinhTrang));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlTinhTrang = new DevExpress.XtraGrid.GridControl();
            this.gridViewTinhTrang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnR_Sua = new DevExpress.XtraEditors.SimpleButton();
            this.btnR_Them = new DevExpress.XtraEditors.SimpleButton();
            this.btnR_Xoa = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonTinhTrang = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonThemTinhTrang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSuaTinhTrang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonXoaTinhTrang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDown = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageTinhTrang_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupTinhTrang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupOrder = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlTinhTrang);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(789, 396);
            this.splitContainerControl1.SplitterPosition = 332;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlTinhTrang
            // 
            this.gridControlTinhTrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTinhTrang.Location = new System.Drawing.Point(0, 0);
            this.gridControlTinhTrang.MainView = this.gridViewTinhTrang;
            this.gridControlTinhTrang.Name = "gridControlTinhTrang";
            this.gridControlTinhTrang.Size = new System.Drawing.Size(453, 396);
            this.gridControlTinhTrang.TabIndex = 0;
            this.gridControlTinhTrang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTinhTrang});
            // 
            // gridViewTinhTrang
            // 
            this.gridViewTinhTrang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.coltinhtrang});
            this.gridViewTinhTrang.GridControl = this.gridControlTinhTrang;
            this.gridViewTinhTrang.Name = "gridViewTinhTrang";
            this.gridViewTinhTrang.OptionsBehavior.Editable = false;
            this.gridViewTinhTrang.OptionsBehavior.ReadOnly = true;
            this.gridViewTinhTrang.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewTinhTrang.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewTinhTrang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewTinhTrang.OptionsView.ShowGroupPanel = false;
            this.gridViewTinhTrang.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewTinhTrang_FocusedRowChanged);
            this.gridViewTinhTrang.DataSourceChanged += new System.EventHandler(this.gridViewTinhTrang_DataSourceChanged);
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // coltinhtrang
            // 
            this.coltinhtrang.Caption = "Tình trạng";
            this.coltinhtrang.FieldName = "value";
            this.coltinhtrang.Name = "coltinhtrang";
            this.coltinhtrang.Visible = true;
            this.coltinhtrang.VisibleIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnR_Sua);
            this.groupControl1.Controls.Add(this.btnR_Them);
            this.groupControl1.Controls.Add(this.btnR_Xoa);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtMoTa);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnOk);
            this.groupControl1.Controls.Add(this.txtTen);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(332, 396);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết";
            // 
            // btnR_Sua
            // 
            this.btnR_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Sua.Image = global::PTB_GUI.Properties.Resources.pencil_19;
            this.btnR_Sua.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Sua.Location = new System.Drawing.Point(268, 0);
            this.btnR_Sua.Name = "btnR_Sua";
            this.btnR_Sua.Size = new System.Drawing.Size(23, 23);
            this.btnR_Sua.TabIndex = 2;
            this.btnR_Sua.Click += new System.EventHandler(this.btnR_Sua_Click);
            // 
            // btnR_Them
            // 
            this.btnR_Them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Them.Image = global::PTB_GUI.Properties.Resources.plus_19;
            this.btnR_Them.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Them.Location = new System.Drawing.Point(242, 0);
            this.btnR_Them.Name = "btnR_Them";
            this.btnR_Them.Size = new System.Drawing.Size(23, 23);
            this.btnR_Them.TabIndex = 1;
            this.btnR_Them.Visible = false;
            this.btnR_Them.Click += new System.EventHandler(this.btnR_Them_Click);
            // 
            // btnR_Xoa
            // 
            this.btnR_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Xoa.Image = global::PTB_GUI.Properties.Resources.delete_19;
            this.btnR_Xoa.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Xoa.Location = new System.Drawing.Point(294, 0);
            this.btnR_Xoa.Name = "btnR_Xoa";
            this.btnR_Xoa.Size = new System.Drawing.Size(23, 23);
            this.btnR_Xoa.TabIndex = 3;
            this.btnR_Xoa.Click += new System.EventHandler(this.btnR_Xoa_Click);
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
            this.txtMoTa.Size = new System.Drawing.Size(260, 120);
            this.txtMoTa.TabIndex = 5;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(138, 179);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(57, 179);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(57, 27);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(260, 20);
            this.txtTen.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên:";
            // 
            // ribbonTinhTrang
            // 
            this.ribbonTinhTrang.ApplicationIcon = global::PTB_GUI.Properties.Resources.Logo;
            this.ribbonTinhTrang.ExpandCollapseItem.Id = 0;
            this.ribbonTinhTrang.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonTinhTrang.ExpandCollapseItem,
            this.barButtonThemTinhTrang,
            this.barButtonSuaTinhTrang,
            this.barButtonXoaTinhTrang,
            this.barBtnUp,
            this.barBtnDown,
            this.barBtnImport});
            this.ribbonTinhTrang.Location = new System.Drawing.Point(0, 0);
            this.ribbonTinhTrang.MaxItemId = 46;
            this.ribbonTinhTrang.Name = "ribbonTinhTrang";
            this.ribbonTinhTrang.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageTinhTrang_Home});
            this.ribbonTinhTrang.Size = new System.Drawing.Size(789, 145);
            // 
            // barButtonThemTinhTrang
            // 
            this.barButtonThemTinhTrang.Caption = "Thêm tình trạng";
            this.barButtonThemTinhTrang.Glyph = global::PTB_GUI.Properties.Resources.plus_32;
            this.barButtonThemTinhTrang.Id = 39;
            this.barButtonThemTinhTrang.Name = "barButtonThemTinhTrang";
            this.barButtonThemTinhTrang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonThemTinhTrang_ItemClick);
            // 
            // barButtonSuaTinhTrang
            // 
            this.barButtonSuaTinhTrang.Caption = "Sửa tình trạng";
            this.barButtonSuaTinhTrang.Glyph = global::PTB_GUI.Properties.Resources.pencil_32;
            this.barButtonSuaTinhTrang.Id = 40;
            this.barButtonSuaTinhTrang.Name = "barButtonSuaTinhTrang";
            this.barButtonSuaTinhTrang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSuaTinhTrang_ItemClick);
            // 
            // barButtonXoaTinhTrang
            // 
            this.barButtonXoaTinhTrang.Caption = "Xóa tình trạng";
            this.barButtonXoaTinhTrang.Glyph = global::PTB_GUI.Properties.Resources.delete_32;
            this.barButtonXoaTinhTrang.Id = 41;
            this.barButtonXoaTinhTrang.Name = "barButtonXoaTinhTrang";
            this.barButtonXoaTinhTrang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonXoaTinhTrang_ItemClick);
            // 
            // barBtnUp
            // 
            this.barBtnUp.Caption = "Lên";
            this.barBtnUp.Glyph = global::PTB_GUI.Properties.Resources.arrow_up;
            this.barBtnUp.Id = 43;
            this.barBtnUp.Name = "barBtnUp";
            this.barBtnUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUp_ItemClick);
            // 
            // barBtnDown
            // 
            this.barBtnDown.Caption = "Xuống";
            this.barBtnDown.Glyph = global::PTB_GUI.Properties.Resources.arrow_down;
            this.barBtnDown.Id = 44;
            this.barBtnDown.Name = "barBtnDown";
            this.barBtnDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDown_ItemClick);
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "Import";
            this.barBtnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.Glyph")));
            this.barBtnImport.Id = 45;
            this.barBtnImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.LargeGlyph")));
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImport_ItemClick);
            // 
            // rbnPageTinhTrang_Home
            // 
            this.rbnPageTinhTrang_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupTinhTrang,
            this.rbnGroupOrder,
            this.rbnGroupImport});
            this.rbnPageTinhTrang_Home.Image = ((System.Drawing.Image)(resources.GetObject("rbnPageTinhTrang_Home.Image")));
            this.rbnPageTinhTrang_Home.Name = "rbnPageTinhTrang_Home";
            this.rbnPageTinhTrang_Home.Text = "Tình trạng";
            // 
            // rbnGroupTinhTrang
            // 
            this.rbnGroupTinhTrang.ItemLinks.Add(this.barButtonThemTinhTrang);
            this.rbnGroupTinhTrang.ItemLinks.Add(this.barButtonSuaTinhTrang);
            this.rbnGroupTinhTrang.ItemLinks.Add(this.barButtonXoaTinhTrang);
            this.rbnGroupTinhTrang.Name = "rbnGroupTinhTrang";
            this.rbnGroupTinhTrang.ShowCaptionButton = false;
            this.rbnGroupTinhTrang.Text = "Loại thiết bị";
            // 
            // rbnGroupOrder
            // 
            this.rbnGroupOrder.ItemLinks.Add(this.barBtnUp);
            this.rbnGroupOrder.ItemLinks.Add(this.barBtnDown);
            this.rbnGroupOrder.Name = "rbnGroupOrder";
            this.rbnGroupOrder.ShowCaptionButton = false;
            this.rbnGroupOrder.Text = "Sắp xếp";
            // 
            // rbnGroupImport
            // 
            this.rbnGroupImport.ItemLinks.Add(this.barBtnImport);
            this.rbnGroupImport.Name = "rbnGroupImport";
            this.rbnGroupImport.ShowCaptionButton = false;
            this.rbnGroupImport.Text = "Import";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // ucQuanLyTinhTrang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonTinhTrang);
            this.Name = "ucQuanLyTinhTrang";
            this.Size = new System.Drawing.Size(789, 541);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.SimpleButton btnR_Sua;
        private DevExpress.XtraEditors.SimpleButton btnR_Them;
        private DevExpress.XtraEditors.SimpleButton btnR_Xoa;
        private DevExpress.XtraGrid.GridControl gridControlTinhTrang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn coltinhtrang;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barButtonThemTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barButtonSuaTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barButtonXoaTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barBtnUp;
        private DevExpress.XtraBars.BarButtonItem barBtnDown;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageTinhTrang_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupTinhTrang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupOrder;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.BarButtonItem barBtnImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupImport;
    }
}
