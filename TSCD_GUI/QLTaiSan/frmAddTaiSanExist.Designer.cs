namespace TSCD_GUI.QLTaiSan
{
    partial class frmAddTaiSanExist
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
            this.gridControlTaiSan = new DevExpress.XtraGrid.GridControl();
            this.bandedGridViewTaiSan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBandngay = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colngayghi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBandchungtu = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colsohieuct = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colngayct = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBandtaisan = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colten = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldonvitinh = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colsoluong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldongia = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colthanhtien = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colnguongoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colloai = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coltinhtrang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colphong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colvitri = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldvquanly = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coldvsudung = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colghichu = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.ucComboBoxLoaiTS1 = new TSCD_GUI.MyUserControl.ucComboBoxLoaiTS();
            this.ucComboBoxDonVi1 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTaiSan
            // 
            this.gridControlTaiSan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlTaiSan.Location = new System.Drawing.Point(12, 39);
            this.gridControlTaiSan.MainView = this.bandedGridViewTaiSan;
            this.gridControlTaiSan.Name = "gridControlTaiSan";
            this.gridControlTaiSan.Size = new System.Drawing.Size(813, 365);
            this.gridControlTaiSan.TabIndex = 39;
            this.gridControlTaiSan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridViewTaiSan});
            // 
            // bandedGridViewTaiSan
            // 
            this.bandedGridViewTaiSan.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBandngay,
            this.gridBandchungtu,
            this.gridBandtaisan});
            this.bandedGridViewTaiSan.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colngayghi,
            this.colsohieuct,
            this.colngayct,
            this.colten,
            this.colloai,
            this.coldonvitinh,
            this.colsoluong,
            this.coldongia,
            this.colthanhtien,
            this.coltinhtrang,
            this.colnguongoc,
            this.colghichu,
            this.colid,
            this.colphong,
            this.colvitri,
            this.coldvquanly,
            this.coldvsudung});
            this.bandedGridViewTaiSan.GridControl = this.gridControlTaiSan;
            this.bandedGridViewTaiSan.GroupCount = 1;
            this.bandedGridViewTaiSan.Name = "bandedGridViewTaiSan";
            this.bandedGridViewTaiSan.OptionsBehavior.Editable = false;
            this.bandedGridViewTaiSan.OptionsBehavior.ReadOnly = true;
            this.bandedGridViewTaiSan.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bandedGridViewTaiSan.OptionsView.ColumnAutoWidth = false;
            this.bandedGridViewTaiSan.OptionsView.ShowGroupPanel = false;
            this.bandedGridViewTaiSan.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colloai, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBandngay
            // 
            this.gridBandngay.Columns.Add(this.colngayghi);
            this.gridBandngay.Name = "gridBandngay";
            this.gridBandngay.VisibleIndex = 0;
            this.gridBandngay.Width = 87;
            // 
            // colngayghi
            // 
            this.colngayghi.AppearanceHeader.Options.UseTextOptions = true;
            this.colngayghi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colngayghi.Caption = "Ngày, tháng ghi sổ";
            this.colngayghi.FieldName = "ngayghi";
            this.colngayghi.Name = "colngayghi";
            this.colngayghi.Visible = true;
            this.colngayghi.Width = 87;
            // 
            // gridBandchungtu
            // 
            this.gridBandchungtu.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBandchungtu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBandchungtu.Caption = "Chứng từ";
            this.gridBandchungtu.Columns.Add(this.colsohieuct);
            this.gridBandchungtu.Columns.Add(this.colngayct);
            this.gridBandchungtu.Name = "gridBandchungtu";
            this.gridBandchungtu.VisibleIndex = 1;
            this.gridBandchungtu.Width = 175;
            // 
            // colsohieuct
            // 
            this.colsohieuct.AppearanceHeader.Options.UseTextOptions = true;
            this.colsohieuct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsohieuct.Caption = "Số hiệu";
            this.colsohieuct.FieldName = "sohieu_ct";
            this.colsohieuct.Name = "colsohieuct";
            this.colsohieuct.Visible = true;
            this.colsohieuct.Width = 85;
            // 
            // colngayct
            // 
            this.colngayct.AppearanceHeader.Options.UseTextOptions = true;
            this.colngayct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colngayct.Caption = "Ngày tháng";
            this.colngayct.FieldName = "ngay_ct";
            this.colngayct.Name = "colngayct";
            this.colngayct.Visible = true;
            this.colngayct.Width = 90;
            // 
            // gridBandtaisan
            // 
            this.gridBandtaisan.Columns.Add(this.colten);
            this.gridBandtaisan.Columns.Add(this.coldonvitinh);
            this.gridBandtaisan.Columns.Add(this.colsoluong);
            this.gridBandtaisan.Columns.Add(this.coldongia);
            this.gridBandtaisan.Columns.Add(this.colthanhtien);
            this.gridBandtaisan.Columns.Add(this.colnguongoc);
            this.gridBandtaisan.Columns.Add(this.colloai);
            this.gridBandtaisan.Columns.Add(this.coltinhtrang);
            this.gridBandtaisan.Columns.Add(this.colphong);
            this.gridBandtaisan.Columns.Add(this.colvitri);
            this.gridBandtaisan.Columns.Add(this.coldvquanly);
            this.gridBandtaisan.Columns.Add(this.coldvsudung);
            this.gridBandtaisan.Columns.Add(this.colghichu);
            this.gridBandtaisan.Name = "gridBandtaisan";
            this.gridBandtaisan.VisibleIndex = 2;
            this.gridBandtaisan.Width = 815;
            // 
            // colten
            // 
            this.colten.AppearanceHeader.Options.UseTextOptions = true;
            this.colten.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colten.Caption = "Tên TSCĐ";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.Width = 128;
            // 
            // coldonvitinh
            // 
            this.coldonvitinh.AppearanceHeader.Options.UseTextOptions = true;
            this.coldonvitinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldonvitinh.Caption = "Đơn vị tính";
            this.coldonvitinh.FieldName = "donvitinh";
            this.coldonvitinh.Name = "coldonvitinh";
            this.coldonvitinh.Visible = true;
            this.coldonvitinh.Width = 36;
            // 
            // colsoluong
            // 
            this.colsoluong.AppearanceHeader.Options.UseTextOptions = true;
            this.colsoluong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsoluong.Caption = "Số lượng";
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.Width = 41;
            // 
            // coldongia
            // 
            this.coldongia.AppearanceHeader.Options.UseTextOptions = true;
            this.coldongia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldongia.Caption = "Đơn giá";
            this.coldongia.FieldName = "dongia";
            this.coldongia.Name = "coldongia";
            this.coldongia.Visible = true;
            this.coldongia.Width = 46;
            // 
            // colthanhtien
            // 
            this.colthanhtien.AppearanceHeader.Options.UseTextOptions = true;
            this.colthanhtien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colthanhtien.Caption = "Thành tiền";
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.Visible = true;
            this.colthanhtien.Width = 50;
            // 
            // colnguongoc
            // 
            this.colnguongoc.AppearanceHeader.Options.UseTextOptions = true;
            this.colnguongoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colnguongoc.Caption = "Nguồn gốc";
            this.colnguongoc.FieldName = "nguongoc";
            this.colnguongoc.Name = "colnguongoc";
            this.colnguongoc.Visible = true;
            this.colnguongoc.Width = 58;
            // 
            // colloai
            // 
            this.colloai.AppearanceHeader.Options.UseTextOptions = true;
            this.colloai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colloai.Caption = "Loại tài sản";
            this.colloai.FieldName = "loaits";
            this.colloai.Name = "colloai";
            this.colloai.Width = 63;
            // 
            // coltinhtrang
            // 
            this.coltinhtrang.AppearanceHeader.Options.UseTextOptions = true;
            this.coltinhtrang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltinhtrang.Caption = "Tình trạng";
            this.coltinhtrang.FieldName = "tinhtrang";
            this.coltinhtrang.Name = "coltinhtrang";
            this.coltinhtrang.Visible = true;
            this.coltinhtrang.Width = 71;
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
            // coldvquanly
            // 
            this.coldvquanly.Caption = "Đơn vị quản lý";
            this.coldvquanly.FieldName = "dvquanly";
            this.coldvquanly.Name = "coldvquanly";
            this.coldvquanly.Visible = true;
            // 
            // coldvsudung
            // 
            this.coldvsudung.Caption = "Đơn vị sử dụng";
            this.coldvsudung.FieldName = "dvsudung";
            this.coldvsudung.Name = "coldvsudung";
            this.coldvsudung.Visible = true;
            // 
            // colghichu
            // 
            this.colghichu.AppearanceHeader.Options.UseTextOptions = true;
            this.colghichu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colghichu.Caption = "Ghi chú";
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            this.colghichu.Visible = true;
            this.colghichu.Width = 85;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(59, 13);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 40;
            // 
            // ucComboBoxLoaiTS1
            // 
            this.ucComboBoxLoaiTS1.LoaiTS = null;
            this.ucComboBoxLoaiTS1.Location = new System.Drawing.Point(219, 12);
            this.ucComboBoxLoaiTS1.Name = "ucComboBoxLoaiTS1";
            this.ucComboBoxLoaiTS1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxLoaiTS1.TabIndex = 41;
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(447, 13);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxDonVi1.TabIndex = 42;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(750, 9);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 43;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // frmAddTaiSanExist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 464);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.ucComboBoxDonVi1);
            this.Controls.Add(this.ucComboBoxLoaiTS1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.gridControlTaiSan);
            this.Name = "frmAddTaiSanExist";
            this.Text = "frmAddTaiSanExist";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaiSan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridViewTaiSan;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandngay;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colngayghi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandchungtu;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colsohieuct;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colngayct;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtaisan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colten;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldonvitinh;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colsoluong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldongia;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colthanhtien;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colnguongoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colloai;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coltinhtrang;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colphong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colvitri;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldvquanly;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coldvsudung;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colghichu;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colid;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private MyUserControl.ucComboBoxLoaiTS ucComboBoxLoaiTS1;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi1;
        private DevExpress.XtraEditors.SimpleButton btnTim;
    }
}