namespace TSCD_GUI.QLLoaiTaiSan
{
    partial class frmQuanLyDonViTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyDonViTinh));
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlDonViTinh = new DevExpress.XtraGrid.GridControl();
            this.gridViewDonViTinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
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
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlDonViTinh);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(608, 321);
            this.splitContainerControlMain.SplitterPosition = 290;
            this.splitContainerControlMain.TabIndex = 0;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlDonViTinh
            // 
            this.gridControlDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDonViTinh.Location = new System.Drawing.Point(0, 0);
            this.gridControlDonViTinh.MainView = this.gridViewDonViTinh;
            this.gridControlDonViTinh.Name = "gridControlDonViTinh";
            this.gridControlDonViTinh.Size = new System.Drawing.Size(313, 321);
            this.gridControlDonViTinh.TabIndex = 0;
            this.gridControlDonViTinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDonViTinh});
            // 
            // gridViewDonViTinh
            // 
            this.gridViewDonViTinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colten});
            this.gridViewDonViTinh.GridControl = this.gridControlDonViTinh;
            this.gridViewDonViTinh.Name = "gridViewDonViTinh";
            this.gridViewDonViTinh.OptionsBehavior.Editable = false;
            this.gridViewDonViTinh.OptionsBehavior.ReadOnly = true;
            this.gridViewDonViTinh.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDonViTinh.OptionsView.ShowGroupPanel = false;
            this.gridViewDonViTinh.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDonViTinh_FocusedRowChanged);
            this.gridViewDonViTinh.DataSourceChanged += new System.EventHandler(this.gridViewDonViTinh_DataSourceChanged);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Tên đơn vị tính";
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
            this.groupControlInfo.Controls.Add(this.lblMa);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.txtMa);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(290, 321);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(203, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(147, 155);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 20;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(66, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(5, 84);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 18;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(5, 58);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(75, 13);
            this.lblTen.TabIndex = 17;
            this.lblTen.Text = "Tên đơn vị tính:";
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(5, 32);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(71, 13);
            this.lblMa.TabIndex = 16;
            this.lblMa.Text = "Mã đơn vị tính:";
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(251, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 15;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_22;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(225, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 14;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_22;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(199, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 13;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(86, 55);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(188, 20);
            this.txtTen.TabIndex = 1;
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.Location = new System.Drawing.Point(86, 29);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(188, 20);
            this.txtMa.TabIndex = 0;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(86, 81);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(188, 68);
            this.txtMoTa.TabIndex = 2;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // frmQuanLyDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 321);
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "frmQuanLyDonViTinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đơn vị tính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLyDonViTinh_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlDonViTinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDonViTinh;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.LabelControl lblMa;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
    }
}