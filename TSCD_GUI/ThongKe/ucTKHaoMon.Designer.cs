namespace TSCD_GUI.ThongKe
{
    partial class ucTKHaoMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTKHaoMon));
            this.gridControlHaoMon = new DevExpress.XtraGrid.GridControl();
            this.gridViewHaoMon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsohieuct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaits = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldonvitinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnuocsx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaysudung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldongia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthanhtien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldvql = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvitri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphantramhaomon_351 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphantramhaomon_32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsonamdasudung_cuoi2008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsonamsudung_351 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsonamsudung_32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsonamsudungconlai_351 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsonamsudungconlai_32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgiatriconlai_351 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgiatriconlai_32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSearch = new DevExpress.XtraEditors.PanelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.ucComboBoxViTri1 = new TSCD_GUI.MyUserControl.ucComboBoxViTri();
            this.ucComboBoxLoaiTS1 = new TSCD_GUI.MyUserControl.ucComboBoxLoaiTS();
            this.checkViTri = new DevExpress.XtraEditors.CheckEdit();
            this.checkLoaiTS = new DevExpress.XtraEditors.CheckEdit();
            this.checkDonVi = new DevExpress.XtraEditors.CheckEdit();
            this.checkedCbxTinhTrang = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.ucComboBoxDonVi1 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.dateNgayTK = new DevExpress.XtraEditors.DateEdit();
            this.labelTinhTrang = new DevExpress.XtraEditors.LabelControl();
            this.labelNgayTK = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHaoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHaoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLoaiTS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCbxTinhTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayTK.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayTK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlHaoMon
            // 
            this.gridControlHaoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlHaoMon.Location = new System.Drawing.Point(0, 82);
            this.gridControlHaoMon.MainView = this.gridViewHaoMon;
            this.gridControlHaoMon.Name = "gridControlHaoMon";
            this.gridControlHaoMon.Size = new System.Drawing.Size(862, 446);
            this.gridControlHaoMon.TabIndex = 0;
            this.gridControlHaoMon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHaoMon});
            // 
            // gridViewHaoMon
            // 
            this.gridViewHaoMon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colsohieuct,
            this.colten,
            this.colloaits,
            this.coldonvitinh,
            this.colnuocsx,
            this.colngaysudung,
            this.coldongia,
            this.colsoluong,
            this.colthanhtien,
            this.coldvql,
            this.colphong,
            this.colvitri,
            this.colphantramhaomon_351,
            this.colphantramhaomon_32,
            this.colsonamdasudung_cuoi2008,
            this.colsonamsudung_351,
            this.colsonamsudung_32,
            this.colsonamsudungconlai_351,
            this.colsonamsudungconlai_32,
            this.colgiatriconlai_351,
            this.colgiatriconlai_32});
            this.gridViewHaoMon.GridControl = this.gridControlHaoMon;
            this.gridViewHaoMon.Name = "gridViewHaoMon";
            this.gridViewHaoMon.OptionsView.ColumnAutoWidth = false;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colsohieuct
            // 
            this.colsohieuct.Caption = "Số hiệu chứng từ";
            this.colsohieuct.FieldName = "sohieuct";
            this.colsohieuct.Name = "colsohieuct";
            this.colsohieuct.Visible = true;
            this.colsohieuct.VisibleIndex = 0;
            // 
            // colten
            // 
            this.colten.Caption = "Tên tài sản";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 1;
            // 
            // colloaits
            // 
            this.colloaits.Caption = "Loại tài sản";
            this.colloaits.FieldName = "loaits";
            this.colloaits.Name = "colloaits";
            this.colloaits.Visible = true;
            this.colloaits.VisibleIndex = 2;
            // 
            // coldonvitinh
            // 
            this.coldonvitinh.Caption = "Đơn vị tính";
            this.coldonvitinh.FieldName = "donvitinh";
            this.coldonvitinh.Name = "coldonvitinh";
            this.coldonvitinh.Visible = true;
            this.coldonvitinh.VisibleIndex = 3;
            // 
            // colnuocsx
            // 
            this.colnuocsx.Caption = "Nước sản xuất";
            this.colnuocsx.FieldName = "nuocsx";
            this.colnuocsx.Name = "colnuocsx";
            this.colnuocsx.Visible = true;
            this.colnuocsx.VisibleIndex = 4;
            // 
            // colngaysudung
            // 
            this.colngaysudung.Caption = "Ngày sử dụng";
            this.colngaysudung.FieldName = "ngaysudung";
            this.colngaysudung.Name = "colngaysudung";
            this.colngaysudung.Visible = true;
            this.colngaysudung.VisibleIndex = 5;
            // 
            // coldongia
            // 
            this.coldongia.Caption = "Đơn giá";
            this.coldongia.FieldName = "dongia";
            this.coldongia.Name = "coldongia";
            this.coldongia.Visible = true;
            this.coldongia.VisibleIndex = 6;
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Số lượng";
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 7;
            // 
            // colthanhtien
            // 
            this.colthanhtien.Caption = "Thành tiền";
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.Visible = true;
            this.colthanhtien.VisibleIndex = 8;
            // 
            // coldvql
            // 
            this.coldvql.Caption = "Đơn vị quản lý";
            this.coldvql.FieldName = "donviquanly";
            this.coldvql.Name = "coldvql";
            this.coldvql.Visible = true;
            this.coldvql.VisibleIndex = 9;
            // 
            // colphong
            // 
            this.colphong.Caption = "Phòng";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            this.colphong.Visible = true;
            this.colphong.VisibleIndex = 10;
            // 
            // colvitri
            // 
            this.colvitri.Caption = "Vị trí";
            this.colvitri.FieldName = "vitri";
            this.colvitri.Name = "colvitri";
            this.colvitri.Visible = true;
            this.colvitri.VisibleIndex = 11;
            // 
            // colphantramhaomon_351
            // 
            this.colphantramhaomon_351.Caption = "Tỷ lệ hao mòn theo QĐ 351";
            this.colphantramhaomon_351.FieldName = "phantramhaomon_351";
            this.colphantramhaomon_351.Name = "colphantramhaomon_351";
            this.colphantramhaomon_351.Visible = true;
            this.colphantramhaomon_351.VisibleIndex = 12;
            // 
            // colphantramhaomon_32
            // 
            this.colphantramhaomon_32.Caption = "Tỷ lệ hao mòn theo QĐ 32";
            this.colphantramhaomon_32.FieldName = "phantramhaomon_32";
            this.colphantramhaomon_32.Name = "colphantramhaomon_32";
            this.colphantramhaomon_32.Visible = true;
            this.colphantramhaomon_32.VisibleIndex = 13;
            // 
            // colsonamdasudung_cuoi2008
            // 
            this.colsonamdasudung_cuoi2008.Caption = "Số năm đã sử dụng tính đến cuối năm 2008";
            this.colsonamdasudung_cuoi2008.FieldName = "sonamdasudung_cuoi2008";
            this.colsonamdasudung_cuoi2008.Name = "colsonamdasudung_cuoi2008";
            this.colsonamdasudung_cuoi2008.Visible = true;
            this.colsonamdasudung_cuoi2008.VisibleIndex = 14;
            // 
            // colsonamsudung_351
            // 
            this.colsonamsudung_351.Caption = "Thời gian sử dụng theo QĐ 351";
            this.colsonamsudung_351.FieldName = "sonamsudung_351";
            this.colsonamsudung_351.Name = "colsonamsudung_351";
            this.colsonamsudung_351.Visible = true;
            this.colsonamsudung_351.VisibleIndex = 15;
            // 
            // colsonamsudung_32
            // 
            this.colsonamsudung_32.Caption = "Thời gian sử dụng theo QĐ 32";
            this.colsonamsudung_32.FieldName = "sonamsudung_32";
            this.colsonamsudung_32.Name = "colsonamsudung_32";
            this.colsonamsudung_32.Visible = true;
            this.colsonamsudung_32.VisibleIndex = 16;
            // 
            // colsonamsudungconlai_351
            // 
            this.colsonamsudungconlai_351.Caption = "Số năm sử dụng còn lại theo QĐ 351";
            this.colsonamsudungconlai_351.FieldName = "sonamsudungconlai_351";
            this.colsonamsudungconlai_351.Name = "colsonamsudungconlai_351";
            this.colsonamsudungconlai_351.Visible = true;
            this.colsonamsudungconlai_351.VisibleIndex = 17;
            // 
            // colsonamsudungconlai_32
            // 
            this.colsonamsudungconlai_32.Caption = "Số năm sử dụng còn lại theo QĐ 32";
            this.colsonamsudungconlai_32.FieldName = "sonamsudungconlai_32";
            this.colsonamsudungconlai_32.Name = "colsonamsudungconlai_32";
            this.colsonamsudungconlai_32.Visible = true;
            this.colsonamsudungconlai_32.VisibleIndex = 18;
            // 
            // colgiatriconlai_351
            // 
            this.colgiatriconlai_351.Caption = "Giá trị còn lại theo QĐ 351";
            this.colgiatriconlai_351.FieldName = "giatriconlai_351";
            this.colgiatriconlai_351.Name = "colgiatriconlai_351";
            this.colgiatriconlai_351.Visible = true;
            this.colgiatriconlai_351.VisibleIndex = 19;
            // 
            // colgiatriconlai_32
            // 
            this.colgiatriconlai_32.Caption = "Giá trị còn lại theo QĐ 32";
            this.colgiatriconlai_32.FieldName = "giatriconlai_32";
            this.colgiatriconlai_32.Name = "colgiatriconlai_32";
            this.colgiatriconlai_32.Visible = true;
            this.colgiatriconlai_32.VisibleIndex = 20;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Controls.Add(this.btnTim);
            this.panelSearch.Controls.Add(this.ucComboBoxViTri1);
            this.panelSearch.Controls.Add(this.ucComboBoxLoaiTS1);
            this.panelSearch.Controls.Add(this.checkViTri);
            this.panelSearch.Controls.Add(this.checkLoaiTS);
            this.panelSearch.Controls.Add(this.checkDonVi);
            this.panelSearch.Controls.Add(this.checkedCbxTinhTrang);
            this.panelSearch.Controls.Add(this.ucComboBoxDonVi1);
            this.panelSearch.Controls.Add(this.dateNgayTK);
            this.panelSearch.Controls.Add(this.labelTinhTrang);
            this.panelSearch.Controls.Add(this.labelNgayTK);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(862, 82);
            this.panelSearch.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(765, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Làm sạch";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(684, 29);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 14;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // ucComboBoxViTri1
            // 
            this.ucComboBoxViTri1.EditValue = null;
            this.ucComboBoxViTri1.Location = new System.Drawing.Point(400, 54);
            this.ucComboBoxViTri1.Name = "ucComboBoxViTri1";
            this.ucComboBoxViTri1.Phong = null;
            this.ucComboBoxViTri1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxViTri1.TabIndex = 12;
            this.ucComboBoxViTri1.ViTri = null;
            // 
            // ucComboBoxLoaiTS1
            // 
            this.ucComboBoxLoaiTS1.EditValue = null;
            this.ucComboBoxLoaiTS1.LoaiTS = null;
            this.ucComboBoxLoaiTS1.Location = new System.Drawing.Point(400, 29);
            this.ucComboBoxLoaiTS1.Name = "ucComboBoxLoaiTS1";
            this.ucComboBoxLoaiTS1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxLoaiTS1.TabIndex = 11;
            // 
            // checkViTri
            // 
            this.checkViTri.Location = new System.Drawing.Point(304, 54);
            this.checkViTri.Name = "checkViTri";
            this.checkViTri.Properties.Caption = "Vị trí:";
            this.checkViTri.Size = new System.Drawing.Size(58, 19);
            this.checkViTri.TabIndex = 10;
            // 
            // checkLoaiTS
            // 
            this.checkLoaiTS.Location = new System.Drawing.Point(304, 29);
            this.checkLoaiTS.Name = "checkLoaiTS";
            this.checkLoaiTS.Properties.Caption = "Loại tài sản:";
            this.checkLoaiTS.Size = new System.Drawing.Size(82, 19);
            this.checkLoaiTS.TabIndex = 9;
            // 
            // checkDonVi
            // 
            this.checkDonVi.Location = new System.Drawing.Point(304, 5);
            this.checkDonVi.Name = "checkDonVi";
            this.checkDonVi.Properties.Caption = "Đơn vị quản lý:";
            this.checkDonVi.Size = new System.Drawing.Size(93, 19);
            this.checkDonVi.TabIndex = 8;
            // 
            // checkedCbxTinhTrang
            // 
            this.checkedCbxTinhTrang.Location = new System.Drawing.Point(85, 55);
            this.checkedCbxTinhTrang.Name = "checkedCbxTinhTrang";
            this.checkedCbxTinhTrang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCbxTinhTrang.Properties.DisplayMember = "value";
            this.checkedCbxTinhTrang.Properties.ValueMember = "id";
            this.checkedCbxTinhTrang.Size = new System.Drawing.Size(130, 20);
            this.checkedCbxTinhTrang.TabIndex = 7;
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.EditValue = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(400, 5);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxDonVi1.TabIndex = 6;
            // 
            // dateNgayTK
            // 
            this.dateNgayTK.EditValue = null;
            this.dateNgayTK.Location = new System.Drawing.Point(85, 29);
            this.dateNgayTK.Name = "dateNgayTK";
            this.dateNgayTK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayTK.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayTK.Size = new System.Drawing.Size(130, 20);
            this.dateNgayTK.TabIndex = 5;
            // 
            // labelTinhTrang
            // 
            this.labelTinhTrang.Location = new System.Drawing.Point(5, 58);
            this.labelTinhTrang.Name = "labelTinhTrang";
            this.labelTinhTrang.Size = new System.Drawing.Size(53, 13);
            this.labelTinhTrang.TabIndex = 3;
            this.labelTinhTrang.Text = "Tình trạng:";
            // 
            // labelNgayTK
            // 
            this.labelNgayTK.Location = new System.Drawing.Point(5, 32);
            this.labelNgayTK.Name = "labelNgayTK";
            this.labelNgayTK.Size = new System.Drawing.Size(74, 13);
            this.labelNgayTK.TabIndex = 0;
            this.labelNgayTK.Text = "Ngày thống kê:";
            // 
            // ucTKHaoMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlHaoMon);
            this.Controls.Add(this.panelSearch);
            this.Name = "ucTKHaoMon";
            this.Size = new System.Drawing.Size(862, 528);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHaoMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHaoMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLoaiTS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCbxTinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayTK.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayTK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlHaoMon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHaoMon;
        private DevExpress.XtraEditors.PanelControl panelSearch;
        private DevExpress.XtraEditors.LabelControl labelNgayTK;
        private DevExpress.XtraEditors.LabelControl labelTinhTrang;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi1;
        private DevExpress.XtraEditors.DateEdit dateNgayTK;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCbxTinhTrang;
        private DevExpress.XtraEditors.CheckEdit checkDonVi;
        private MyUserControl.ucComboBoxViTri ucComboBoxViTri1;
        private MyUserControl.ucComboBoxLoaiTS ucComboBoxLoaiTS1;
        private DevExpress.XtraEditors.CheckEdit checkViTri;
        private DevExpress.XtraEditors.CheckEdit checkLoaiTS;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colloaits;
        private DevExpress.XtraGrid.Columns.GridColumn coldonvitinh;
        private DevExpress.XtraGrid.Columns.GridColumn colnuocsx;
        private DevExpress.XtraGrid.Columns.GridColumn coldongia;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn colthanhtien;
        private DevExpress.XtraGrid.Columns.GridColumn coldvql;
        private DevExpress.XtraGrid.Columns.GridColumn colphong;
        private DevExpress.XtraGrid.Columns.GridColumn colvitri;
        private DevExpress.XtraGrid.Columns.GridColumn colphantramhaomon_351;
        private DevExpress.XtraGrid.Columns.GridColumn colphantramhaomon_32;
        private DevExpress.XtraGrid.Columns.GridColumn colsonamdasudung_cuoi2008;
        private DevExpress.XtraGrid.Columns.GridColumn colsonamsudung_351;
        private DevExpress.XtraGrid.Columns.GridColumn colsohieuct;
        private DevExpress.XtraGrid.Columns.GridColumn colngaysudung;
        private DevExpress.XtraGrid.Columns.GridColumn colsonamsudung_32;
        private DevExpress.XtraGrid.Columns.GridColumn colsonamsudungconlai_351;
        private DevExpress.XtraGrid.Columns.GridColumn colsonamsudungconlai_32;
        private DevExpress.XtraGrid.Columns.GridColumn colgiatriconlai_351;
        private DevExpress.XtraGrid.Columns.GridColumn colgiatriconlai_32;
    }
}
