namespace TSCD_GUI.QLDonVi
{
    partial class frmQuanLyLoaiDV
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
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlLoaiDV = new DevExpress.XtraGrid.GridControl();
            this.gridViewLoaiDV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLoaiDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLoaiDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlLoaiDV);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(658, 364);
            this.splitContainerControlMain.SplitterPosition = 335;
            this.splitContainerControlMain.TabIndex = 0;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlLoaiDV
            // 
            this.gridControlLoaiDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLoaiDV.Location = new System.Drawing.Point(0, 0);
            this.gridControlLoaiDV.MainView = this.gridViewLoaiDV;
            this.gridControlLoaiDV.Name = "gridControlLoaiDV";
            this.gridControlLoaiDV.Size = new System.Drawing.Size(318, 364);
            this.gridControlLoaiDV.TabIndex = 0;
            this.gridControlLoaiDV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLoaiDV});
            // 
            // gridViewLoaiDV
            // 
            this.gridViewLoaiDV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colten});
            this.gridViewLoaiDV.GridControl = this.gridControlLoaiDV;
            this.gridViewLoaiDV.Name = "gridViewLoaiDV";
            this.gridViewLoaiDV.OptionsBehavior.Editable = false;
            this.gridViewLoaiDV.OptionsBehavior.ReadOnly = true;
            this.gridViewLoaiDV.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLoaiDV.OptionsView.ShowGroupPanel = false;
            this.gridViewLoaiDV.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewLoaiDV_FocusedRowChanged);
            this.gridViewLoaiDV.DataSourceChanged += new System.EventHandler(this.gridViewLoaiDV_DataSourceChanged);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Tên loại đơn vị";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.btnClose);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(335, 364);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(248, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(166, 128);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(85, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(6, 56);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 10;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(6, 30);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(73, 13);
            this.lblTen.TabIndex = 9;
            this.lblTen.Text = "Tên loại đơn vị:";
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(294, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 8;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_24;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(268, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 7;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_24;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(242, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 6;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(85, 27);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(232, 20);
            this.txtTen.TabIndex = 0;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(85, 53);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(232, 69);
            this.txtMoTa.TabIndex = 1;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // frmQuanLyLoaiDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 364);
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "frmQuanLyLoaiDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý loại đơn vị";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLoaiDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLoaiDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlLoaiDV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLoaiDV;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
    }
}