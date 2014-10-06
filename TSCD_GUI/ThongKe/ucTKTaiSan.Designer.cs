namespace TSCD_GUI.ThongKe
{
    partial class ucTKTaiSan
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
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlTaiSan = new DevExpress.XtraGrid.GridControl();
            this.bandedGridViewTaiSan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colchungtu_sohieu = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colchungtu_ngay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colten = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colngaysudung = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldonvitinh = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colsoluong_tang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldongia_tang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colthanhtien_tang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colsoluong_giam = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldongia_giam = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colthanhtien_giam = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colphong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colvitri = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldvsudung = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldvquanly = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colloaits = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.groupControlThongKe = new DevExpress.XtraEditors.GroupControl();
            this.checkedComboBoxCoSo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.ucComboBoxLoaiTS1 = new TSCD_GUI.MyUserControl.ucComboBoxLoaiTS();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.dateDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dateTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblCoSo = new DevExpress.XtraEditors.LabelControl();
            this.lblDonViQL = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiTaiSan = new DevExpress.XtraEditors.LabelControl();
            this.btnThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.ucComboBoxDonVi1 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongKe)).BeginInit();
            this.groupControlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxCoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlTaiSan);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlThongKe);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(790, 491);
            this.splitContainerControlMain.SplitterPosition = 291;
            this.splitContainerControlMain.TabIndex = 0;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlTaiSan
            // 
            this.gridControlTaiSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTaiSan.Location = new System.Drawing.Point(0, 0);
            this.gridControlTaiSan.MainView = this.bandedGridViewTaiSan;
            this.gridControlTaiSan.Name = "gridControlTaiSan";
            this.gridControlTaiSan.Size = new System.Drawing.Size(494, 491);
            this.gridControlTaiSan.TabIndex = 0;
            this.gridControlTaiSan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridViewTaiSan});
            // 
            // bandedGridViewTaiSan
            // 
            this.bandedGridViewTaiSan.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand5,
            this.gridBand4,
            this.gridBand6});
            this.bandedGridViewTaiSan.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colid,
            this.colchungtu_ngay,
            this.colchungtu_sohieu,
            this.colten,
            this.colloaits,
            this.coldonvitinh,
            this.colsoluong_tang,
            this.coldongia_tang,
            this.colthanhtien_tang,
            this.colsoluong_giam,
            this.coldongia_giam,
            this.colthanhtien_giam,
            this.colphong,
            this.colvitri,
            this.coldvquanly,
            this.coldvsudung,
            this.colngaysudung});
            this.bandedGridViewTaiSan.GridControl = this.gridControlTaiSan;
            this.bandedGridViewTaiSan.GroupCount = 1;
            this.bandedGridViewTaiSan.Name = "bandedGridViewTaiSan";
            this.bandedGridViewTaiSan.OptionsBehavior.Editable = false;
            this.bandedGridViewTaiSan.OptionsBehavior.ReadOnly = true;
            this.bandedGridViewTaiSan.OptionsView.ColumnAutoWidth = false;
            this.bandedGridViewTaiSan.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colloaits, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Chứng từ";
            this.gridBand2.Columns.Add(this.colchungtu_sohieu);
            this.gridBand2.Columns.Add(this.colchungtu_ngay);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 150;
            // 
            // colchungtu_sohieu
            // 
            this.colchungtu_sohieu.Caption = "Số hiệu chứng từ";
            this.colchungtu_sohieu.FieldName = "sohieu_ct";
            this.colchungtu_sohieu.Name = "colchungtu_sohieu";
            this.colchungtu_sohieu.Visible = true;
            // 
            // colchungtu_ngay
            // 
            this.colchungtu_ngay.Caption = "Ngày chứng từ";
            this.colchungtu_ngay.FieldName = "ngay_ct";
            this.colchungtu_ngay.Name = "colchungtu_ngay";
            this.colchungtu_ngay.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.colten);
            this.gridBand3.Columns.Add(this.colngaysudung);
            this.gridBand3.Columns.Add(this.coldonvitinh);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 225;
            // 
            // colten
            // 
            this.colten.Caption = "Tên tài sản";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            // 
            // colngaysudung
            // 
            this.colngaysudung.Caption = "Ngày sử dụng";
            this.colngaysudung.FieldName = "ngay";
            this.colngaysudung.Name = "colngaysudung";
            this.colngaysudung.Visible = true;
            // 
            // coldonvitinh
            // 
            this.coldonvitinh.Caption = "Đơn vị tính";
            this.coldonvitinh.FieldName = "donvitinh";
            this.coldonvitinh.Name = "coldonvitinh";
            this.coldonvitinh.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "Tăng tài sản";
            this.gridBand5.Columns.Add(this.colsoluong_tang);
            this.gridBand5.Columns.Add(this.coldongia_tang);
            this.gridBand5.Columns.Add(this.colthanhtien_tang);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 225;
            // 
            // colsoluong_tang
            // 
            this.colsoluong_tang.Caption = "Số lượng";
            this.colsoluong_tang.FieldName = "soluong_tang";
            this.colsoluong_tang.Name = "colsoluong_tang";
            this.colsoluong_tang.Visible = true;
            // 
            // coldongia_tang
            // 
            this.coldongia_tang.Caption = "Đơn giá";
            this.coldongia_tang.FieldName = "dongia_tang";
            this.coldongia_tang.Name = "coldongia_tang";
            this.coldongia_tang.Visible = true;
            // 
            // colthanhtien_tang
            // 
            this.colthanhtien_tang.Caption = "Thành tiền";
            this.colthanhtien_tang.FieldName = "thanhtien_tang";
            this.colthanhtien_tang.Name = "colthanhtien_tang";
            this.colthanhtien_tang.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Giảm tài sản";
            this.gridBand4.Columns.Add(this.colsoluong_giam);
            this.gridBand4.Columns.Add(this.coldongia_giam);
            this.gridBand4.Columns.Add(this.colthanhtien_giam);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 225;
            // 
            // colsoluong_giam
            // 
            this.colsoluong_giam.Caption = "Số lượng";
            this.colsoluong_giam.FieldName = "soluong_giam";
            this.colsoluong_giam.Name = "colsoluong_giam";
            this.colsoluong_giam.Visible = true;
            // 
            // coldongia_giam
            // 
            this.coldongia_giam.Caption = "Đơn giá";
            this.coldongia_giam.FieldName = "dongia_giam";
            this.coldongia_giam.Name = "coldongia_giam";
            this.coldongia_giam.Visible = true;
            // 
            // colthanhtien_giam
            // 
            this.colthanhtien_giam.Caption = "Thành tiền";
            this.colthanhtien_giam.FieldName = "thanhtien_giam";
            this.colthanhtien_giam.Name = "colthanhtien_giam";
            this.colthanhtien_giam.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.Columns.Add(this.colphong);
            this.gridBand6.Columns.Add(this.colvitri);
            this.gridBand6.Columns.Add(this.coldvsudung);
            this.gridBand6.Columns.Add(this.coldvquanly);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 4;
            this.gridBand6.Width = 300;
            // 
            // colphong
            // 
            this.colphong.Caption = "Phòng";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            this.colphong.Visible = true;
            // 
            // colvitri
            // 
            this.colvitri.Caption = "Vị trí";
            this.colvitri.FieldName = "vitri";
            this.colvitri.Name = "colvitri";
            this.colvitri.Visible = true;
            // 
            // coldvsudung
            // 
            this.coldvsudung.Caption = "Đơn vị sử dụng";
            this.coldvsudung.FieldName = "dvsudung";
            this.coldvsudung.Name = "coldvsudung";
            this.coldvsudung.Visible = true;
            // 
            // coldvquanly
            // 
            this.coldvquanly.Caption = "Đơn vị quản lý";
            this.coldvquanly.FieldName = "dvquanly";
            this.coldvquanly.Name = "coldvquanly";
            this.coldvquanly.Visible = true;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colloaits
            // 
            this.colloaits.Caption = "Loại tài sản";
            this.colloaits.FieldName = "loaits";
            this.colloaits.Name = "colloaits";
            // 
            // groupControlThongKe
            // 
            this.groupControlThongKe.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlThongKe.AppearanceCaption.Options.UseFont = true;
            this.groupControlThongKe.Controls.Add(this.ucComboBoxDonVi1);
            this.groupControlThongKe.Controls.Add(this.checkedComboBoxCoSo);
            this.groupControlThongKe.Controls.Add(this.ucComboBoxLoaiTS1);
            this.groupControlThongKe.Controls.Add(this.lblDenNgay);
            this.groupControlThongKe.Controls.Add(this.lblTuNgay);
            this.groupControlThongKe.Controls.Add(this.dateDenNgay);
            this.groupControlThongKe.Controls.Add(this.dateTuNgay);
            this.groupControlThongKe.Controls.Add(this.lblCoSo);
            this.groupControlThongKe.Controls.Add(this.lblDonViQL);
            this.groupControlThongKe.Controls.Add(this.lblLoaiTaiSan);
            this.groupControlThongKe.Controls.Add(this.btnThongKe);
            this.groupControlThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.groupControlThongKe.Name = "groupControlThongKe";
            this.groupControlThongKe.Size = new System.Drawing.Size(291, 491);
            this.groupControlThongKe.TabIndex = 0;
            this.groupControlThongKe.Text = "Thống kê";
            // 
            // checkedComboBoxCoSo
            // 
            this.checkedComboBoxCoSo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedComboBoxCoSo.Location = new System.Drawing.Point(88, 137);
            this.checkedComboBoxCoSo.Name = "checkedComboBoxCoSo";
            this.checkedComboBoxCoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxCoSo.Properties.DisplayMember = "ten";
            this.checkedComboBoxCoSo.Properties.ValueMember = "id";
            this.checkedComboBoxCoSo.Size = new System.Drawing.Size(185, 20);
            this.checkedComboBoxCoSo.TabIndex = 16;
            // 
            // ucComboBoxLoaiTS1
            // 
            this.ucComboBoxLoaiTS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucComboBoxLoaiTS1.LoaiTS = null;
            this.ucComboBoxLoaiTS1.Location = new System.Drawing.Point(88, 80);
            this.ucComboBoxLoaiTS1.Name = "ucComboBoxLoaiTS1";
            this.ucComboBoxLoaiTS1.Size = new System.Drawing.Size(185, 20);
            this.ucComboBoxLoaiTS1.TabIndex = 15;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Location = new System.Drawing.Point(5, 56);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(51, 13);
            this.lblDenNgay.TabIndex = 14;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Location = new System.Drawing.Point(5, 30);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(44, 13);
            this.lblTuNgay.TabIndex = 13;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDenNgay.EditValue = null;
            this.dateDenNgay.Location = new System.Drawing.Point(88, 53);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Size = new System.Drawing.Size(185, 20);
            this.dateDenNgay.TabIndex = 12;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTuNgay.EditValue = null;
            this.dateTuNgay.Location = new System.Drawing.Point(88, 27);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Size = new System.Drawing.Size(185, 20);
            this.dateTuNgay.TabIndex = 11;
            // 
            // lblCoSo
            // 
            this.lblCoSo.Location = new System.Drawing.Point(5, 140);
            this.lblCoSo.Name = "lblCoSo";
            this.lblCoSo.Size = new System.Drawing.Size(31, 13);
            this.lblCoSo.TabIndex = 9;
            this.lblCoSo.Text = "Cơ sở:";
            // 
            // lblDonViQL
            // 
            this.lblDonViQL.Location = new System.Drawing.Point(5, 108);
            this.lblDonViQL.Name = "lblDonViQL";
            this.lblDonViQL.Size = new System.Drawing.Size(73, 13);
            this.lblDonViQL.TabIndex = 7;
            this.lblDonViQL.Text = "Đơn vị quản lý:";
            // 
            // lblLoaiTaiSan
            // 
            this.lblLoaiTaiSan.Location = new System.Drawing.Point(5, 82);
            this.lblLoaiTaiSan.Name = "lblLoaiTaiSan";
            this.lblLoaiTaiSan.Size = new System.Drawing.Size(58, 13);
            this.lblLoaiTaiSan.TabIndex = 6;
            this.lblLoaiTaiSan.Text = "Loại tài sản:";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Location = new System.Drawing.Point(88, 163);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(88, 108);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(185, 20);
            this.ucComboBoxDonVi1.TabIndex = 17;
            // 
            // ucTKTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "ucTKTaiSan";
            this.Size = new System.Drawing.Size(790, 491);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongKe)).EndInit();
            this.groupControlThongKe.ResumeLayout(false);
            this.groupControlThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxCoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlTaiSan;
        private DevExpress.XtraEditors.GroupControl groupControlThongKe;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.DateEdit dateDenNgay;
        private DevExpress.XtraEditors.DateEdit dateTuNgay;
        private DevExpress.XtraEditors.LabelControl lblCoSo;
        private DevExpress.XtraEditors.LabelControl lblDonViQL;
        private DevExpress.XtraEditors.LabelControl lblLoaiTaiSan;
        private DevExpress.XtraEditors.SimpleButton btnThongKe;
        private MyUserControl.ucComboBoxLoaiTS ucComboBoxLoaiTS1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxCoSo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridViewTaiSan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colchungtu_ngay;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colchungtu_sohieu;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colten;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colloaits;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldonvitinh;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colsoluong_tang;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldongia_tang;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colthanhtien_tang;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colsoluong_giam;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldongia_giam;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colthanhtien_giam;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colphong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colvitri;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldvquanly;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldvsudung;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colngaysudung;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi1;

    }
}
