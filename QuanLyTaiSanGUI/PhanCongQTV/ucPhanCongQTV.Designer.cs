namespace QuanLyTaiSanGUI.PhanCongQTV
{
    partial class ucPhanCongQTV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhanCongQTV));
            this.rbnPagePhanCongQTV_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupPhanCong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnPhanCong = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlQuanTriVien = new DevExpress.XtraGrid.GridControl();
            this.gridViewQuanTriVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhoten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsodienthoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_create = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_modified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhinh_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.listBoxPhong = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.ribbonPhanCongQTV = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMota = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuanTriVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuanTriVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonPhanCongQTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMota.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnPagePhanCongQTV_Home
            // 
            this.rbnPagePhanCongQTV_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupPhanCong});
            this.rbnPagePhanCongQTV_Home.Image = global::QuanLyTaiSanGUI.Properties.Resources.nhanvien;
            this.rbnPagePhanCongQTV_Home.Name = "rbnPagePhanCongQTV_Home";
            this.rbnPagePhanCongQTV_Home.Text = "Phân công QTV";
            // 
            // rbnGroupPhanCong
            // 
            this.rbnGroupPhanCong.ItemLinks.Add(this.barBtnPhanCong);
            this.rbnGroupPhanCong.Name = "rbnGroupPhanCong";
            this.rbnGroupPhanCong.ShowCaptionButton = false;
            this.rbnGroupPhanCong.Text = "Phân công";
            // 
            // barBtnPhanCong
            // 
            this.barBtnPhanCong.Caption = "Phân công";
            this.barBtnPhanCong.Id = 21;
            this.barBtnPhanCong.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnPhanCong.LargeGlyph")));
            this.barBtnPhanCong.Name = "barBtnPhanCong";
            this.barBtnPhanCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPhanCong_ItemClick);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlQuanTriVien);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(864, 508);
            this.splitContainerControl1.SplitterPosition = 350;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlQuanTriVien
            // 
            this.gridControlQuanTriVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQuanTriVien.Location = new System.Drawing.Point(0, 0);
            this.gridControlQuanTriVien.MainView = this.gridViewQuanTriVien;
            this.gridControlQuanTriVien.Name = "gridControlQuanTriVien";
            this.gridControlQuanTriVien.Size = new System.Drawing.Size(510, 508);
            this.gridControlQuanTriVien.TabIndex = 0;
            this.gridControlQuanTriVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQuanTriVien});
            // 
            // gridViewQuanTriVien
            // 
            this.gridViewQuanTriVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colsubId,
            this.colhoten,
            this.colsodienthoai,
            this.coldate_create,
            this.coldate_modified,
            this.colhinh_id});
            this.gridViewQuanTriVien.GridControl = this.gridControlQuanTriVien;
            this.gridViewQuanTriVien.Name = "gridViewQuanTriVien";
            this.gridViewQuanTriVien.OptionsBehavior.Editable = false;
            this.gridViewQuanTriVien.OptionsBehavior.ReadOnly = true;
            this.gridViewQuanTriVien.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewQuanTriVien.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewQuanTriVien.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewQuanTriVien.OptionsView.ShowAutoFilterRow = true;
            this.gridViewQuanTriVien.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewQuanTriVien.OptionsView.ShowGroupPanel = false;
            this.gridViewQuanTriVien.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewQuanTriVien_FocusedRowChanged);
            this.gridViewQuanTriVien.DataSourceChanged += new System.EventHandler(this.gridViewQuanTriVien_DataSourceChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            // 
            // colsubId
            // 
            this.colsubId.Caption = "Mã nhân viên";
            this.colsubId.FieldName = "subId";
            this.colsubId.Name = "colsubId";
            this.colsubId.Visible = true;
            this.colsubId.VisibleIndex = 0;
            // 
            // colhoten
            // 
            this.colhoten.Caption = "Họ tên";
            this.colhoten.FieldName = "hoten";
            this.colhoten.Name = "colhoten";
            this.colhoten.Visible = true;
            this.colhoten.VisibleIndex = 1;
            // 
            // colsodienthoai
            // 
            this.colsodienthoai.Caption = "Tên tài khoản";
            this.colsodienthoai.FieldName = "username";
            this.colsodienthoai.Name = "colsodienthoai";
            this.colsodienthoai.Visible = true;
            this.colsodienthoai.VisibleIndex = 2;
            // 
            // coldate_create
            // 
            this.coldate_create.FieldName = "date_create";
            this.coldate_create.Name = "coldate_create";
            // 
            // coldate_modified
            // 
            this.coldate_modified.FieldName = "date_modified";
            this.coldate_modified.Name = "coldate_modified";
            // 
            // colhinh_id
            // 
            this.colhinh_id.FieldName = "hinh_id";
            this.colhinh_id.Name = "colhinh_id";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.listBoxPhong);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 204);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(350, 304);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Danh sách phòng";
            // 
            // listBoxPhong
            // 
            this.listBoxPhong.DisplayMember = "ten";
            this.listBoxPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPhong.Location = new System.Drawing.Point(2, 24);
            this.listBoxPhong.Name = "listBoxPhong";
            this.listBoxPhong.Size = new System.Drawing.Size(346, 278);
            this.listBoxPhong.TabIndex = 13;
            this.listBoxPhong.ValueMember = "id";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnOK);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtUsername);
            this.groupControl1.Controls.Add(this.txtTen);
            this.groupControl1.Controls.Add(this.txtMa);
            this.groupControl1.Controls.Add(this.txtMota);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(350, 204);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(164, 175);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 85);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Tên tài khoản:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(83, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Tên nhân viên:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Mã nhân viên:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(83, 82);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(253, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(83, 56);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(253, 20);
            this.txtTen.TabIndex = 2;
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMa.Location = new System.Drawing.Point(83, 30);
            this.txtMa.Name = "txtMa";
            this.txtMa.Properties.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(253, 20);
            this.txtMa.TabIndex = 1;
            // 
            // ribbonPhanCongQTV
            // 
            this.ribbonPhanCongQTV.ApplicationIcon = global::QuanLyTaiSanGUI.Properties.Resources.Logo;
            this.ribbonPhanCongQTV.ExpandCollapseItem.Id = 0;
            this.ribbonPhanCongQTV.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonPhanCongQTV.ExpandCollapseItem,
            this.barBtnPhanCong});
            this.ribbonPhanCongQTV.Location = new System.Drawing.Point(0, 0);
            this.ribbonPhanCongQTV.MaxItemId = 40;
            this.ribbonPhanCongQTV.Name = "ribbonPhanCongQTV";
            this.ribbonPhanCongQTV.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPagePhanCongQTV_Home});
            this.ribbonPhanCongQTV.Size = new System.Drawing.Size(864, 145);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 111);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Mô tả:";
            // 
            // txtMota
            // 
            this.txtMota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMota.Location = new System.Drawing.Point(83, 108);
            this.txtMota.Name = "txtMota";
            this.txtMota.Properties.ReadOnly = true;
            this.txtMota.Size = new System.Drawing.Size(253, 61);
            this.txtMota.TabIndex = 13;
            this.txtMota.UseOptimizedRendering = true;
            // 
            // ucPhanCongQTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonPhanCongQTV);
            this.Name = "ucPhanCongQTV";
            this.Size = new System.Drawing.Size(864, 653);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQuanTriVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuanTriVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonPhanCongQTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMota.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPagePhanCongQTV_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupPhanCong;
        private DevExpress.XtraBars.BarButtonItem barBtnPhanCong;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlQuanTriVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQuanTriVien;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colsubId;
        private DevExpress.XtraGrid.Columns.GridColumn colhoten;
        private DevExpress.XtraGrid.Columns.GridColumn colsodienthoai;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_create;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_modified;
        private DevExpress.XtraGrid.Columns.GridColumn colhinh_id;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ListBoxControl listBoxPhong;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonPhanCongQTV;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtMota;

    }
}
