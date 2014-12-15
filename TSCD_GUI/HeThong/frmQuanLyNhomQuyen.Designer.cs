namespace TSCD_GUI.HeThong
{
    partial class frmQuanLyNhomQuyen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyNhomQuyen));
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblKey = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnPhanQuyen = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlInfo = new DevExpress.XtraEditors.PanelControl();
            this.groupControlList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlQuyen = new DevExpress.XtraGrid.GridControl();
            this.gridViewQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coltranslated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryMemoMoTa = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.gridViewGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlGroup = new DevExpress.XtraGrid.GridControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlInfo)).BeginInit();
            this.panelControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlList)).BeginInit();
            this.groupControlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryMemoMoTa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(144, 171);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(63, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(6, 83);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 5;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(6, 57);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(51, 13);
            this.lblTen.TabIndex = 4;
            this.lblTen.Text = "Tên nhóm:";
            // 
            // lblKey
            // 
            this.lblKey.Location = new System.Drawing.Point(6, 31);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(22, 13);
            this.lblKey.TabIndex = 3;
            this.lblKey.Text = "Key:";
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(63, 54);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(237, 20);
            this.txtTen.TabIndex = 5;
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(63, 28);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(237, 20);
            this.txtKey.TabIndex = 4;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(63, 80);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(237, 84);
            this.txtMoTa.TabIndex = 6;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhanQuyen.Location = new System.Drawing.Point(233, 0);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(75, 23);
            this.btnPhanQuyen.TabIndex = 9;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.ToolTip = "Chỉ có thể phân quyền cho Group\r\nkhác Group người đang đang nhập";
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // panelControlInfo
            // 
            this.panelControlInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlInfo.Controls.Add(this.groupControlList);
            this.panelControlInfo.Controls.Add(this.groupControlInfo);
            this.panelControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlInfo.Location = new System.Drawing.Point(0, 0);
            this.panelControlInfo.Name = "panelControlInfo";
            this.panelControlInfo.Size = new System.Drawing.Size(320, 428);
            this.panelControlInfo.TabIndex = 2;
            // 
            // groupControlList
            // 
            this.groupControlList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlList.AppearanceCaption.Options.UseFont = true;
            this.groupControlList.Controls.Add(this.gridControlQuyen);
            this.groupControlList.Controls.Add(this.btnClose);
            this.groupControlList.Controls.Add(this.btnPhanQuyen);
            this.groupControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlList.Location = new System.Drawing.Point(0, 202);
            this.groupControlList.Name = "groupControlList";
            this.groupControlList.Size = new System.Drawing.Size(320, 226);
            this.groupControlList.TabIndex = 1;
            this.groupControlList.Text = "Quyền";
            // 
            // gridControlQuyen
            // 
            this.gridControlQuyen.Location = new System.Drawing.Point(6, 29);
            this.gridControlQuyen.MainView = this.gridViewQuyen;
            this.gridControlQuyen.Name = "gridControlQuyen";
            this.gridControlQuyen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryMemoMoTa});
            this.gridControlQuyen.Size = new System.Drawing.Size(302, 156);
            this.gridControlQuyen.TabIndex = 8;
            this.gridControlQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQuyen});
            // 
            // gridViewQuyen
            // 
            this.gridViewQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coltranslated});
            this.gridViewQuyen.GridControl = this.gridControlQuyen;
            this.gridViewQuyen.Name = "gridViewQuyen";
            this.gridViewQuyen.OptionsBehavior.Editable = false;
            this.gridViewQuyen.OptionsBehavior.ReadOnly = true;
            this.gridViewQuyen.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewQuyen.OptionsView.RowAutoHeight = true;
            this.gridViewQuyen.OptionsView.ShowGroupPanel = false;
            // 
            // coltranslated
            // 
            this.coltranslated.Caption = "Quyền";
            this.coltranslated.ColumnEdit = this.repositoryMemoMoTa;
            this.coltranslated.FieldName = "translated";
            this.coltranslated.Name = "coltranslated";
            this.coltranslated.Visible = true;
            this.coltranslated.VisibleIndex = 0;
            // 
            // repositoryMemoMoTa
            // 
            this.repositoryMemoMoTa.Name = "repositoryMemoMoTa";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(233, 191);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.lblKey);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.txtKey);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(320, 202);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.delete_19;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(277, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 3;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_19;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(251, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 2;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_19;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(225, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 1;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // gridViewGroup
            // 
            this.gridViewGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colkey,
            this.colten,
            this.colmota});
            this.gridViewGroup.GridControl = this.gridControlGroup;
            this.gridViewGroup.Name = "gridViewGroup";
            this.gridViewGroup.OptionsBehavior.Editable = false;
            this.gridViewGroup.OptionsBehavior.ReadOnly = true;
            this.gridViewGroup.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewGroup.OptionsView.ShowGroupPanel = false;
            this.gridViewGroup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewGroup_FocusedRowChanged);
            this.gridViewGroup.DataSourceChanged += new System.EventHandler(this.gridViewGroup_DataSourceChanged);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colkey
            // 
            this.colkey.Caption = "Key";
            this.colkey.FieldName = "key";
            this.colkey.Name = "colkey";
            this.colkey.Visible = true;
            this.colkey.VisibleIndex = 0;
            // 
            // colten
            // 
            this.colten.Caption = "Tên nhóm";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 1;
            // 
            // colmota
            // 
            this.colmota.Caption = "mota";
            this.colmota.FieldName = "mota";
            this.colmota.Name = "colmota";
            // 
            // gridControlGroup
            // 
            this.gridControlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlGroup.Location = new System.Drawing.Point(0, 0);
            this.gridControlGroup.MainView = this.gridViewGroup;
            this.gridControlGroup.Name = "gridControlGroup";
            this.gridControlGroup.Size = new System.Drawing.Size(433, 428);
            this.gridControlGroup.TabIndex = 0;
            this.gridControlGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGroup});
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlGroup);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.panelControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(757, 428);
            this.splitContainerControlMain.SplitterPosition = 320;
            this.splitContainerControlMain.TabIndex = 1;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // frmQuanLyNhomQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 428);
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "frmQuanLyNhomQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhóm quyền";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLyNhomQuyen_FormClosing);
            this.Load += new System.EventHandler(this.frmQuanLyNhomQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlInfo)).EndInit();
            this.panelControlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlList)).EndInit();
            this.groupControlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryMemoMoTa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colmota;
        private DevExpress.XtraEditors.PanelControl panelControlInfo;
        private DevExpress.XtraEditors.GroupControl groupControlList;
        private DevExpress.XtraEditors.SimpleButton btnPhanQuyen;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.LabelControl lblKey;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtKey;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControlQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn coltranslated;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryMemoMoTa;
    }
}