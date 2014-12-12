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
            this.colngayct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryMemoTen = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
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
            this.colphantramhm1nam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhaomon_1nam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsonamsudungconlai_final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgiatriconlai_final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSearch = new DevExpress.XtraEditors.PanelControl();
            this.checkTinhTrang = new DevExpress.XtraEditors.CheckEdit();
            this.checkNamTK = new DevExpress.XtraEditors.CheckEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHaoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHaoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryMemoTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkTinhTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNamTK.Properties)).BeginInit();
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
            this.gridControlHaoMon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryMemoTen});
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
            this.colngayct,
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
            this.colphantramhm1nam,
            this.colhaomon_1nam,
            this.colsonamsudungconlai_final,
            this.colgiatriconlai_final});
            this.gridViewHaoMon.GridControl = this.gridControlHaoMon;
            this.gridViewHaoMon.GroupCount = 1;
            this.gridViewHaoMon.Name = "gridViewHaoMon";
            this.gridViewHaoMon.OptionsBehavior.Editable = false;
            this.gridViewHaoMon.OptionsBehavior.ReadOnly = true;
            this.gridViewHaoMon.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewHaoMon.OptionsView.ColumnAutoWidth = false;
            this.gridViewHaoMon.OptionsView.RowAutoHeight = true;
            this.gridViewHaoMon.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colloaits, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.colsohieuct.FieldName = "sohieu_ct";
            this.colsohieuct.Name = "colsohieuct";
            this.colsohieuct.Visible = true;
            this.colsohieuct.VisibleIndex = 0;
            this.colsohieuct.Width = 97;
            // 
            // colngayct
            // 
            this.colngayct.Caption = "Ngày chứng từ";
            this.colngayct.FieldName = "ngay_ct";
            this.colngayct.Name = "colngayct";
            this.colngayct.Visible = true;
            this.colngayct.VisibleIndex = 1;
            this.colngayct.Width = 86;
            // 
            // colten
            // 
            this.colten.Caption = "Tên tài sản";
            this.colten.ColumnEdit = this.repositoryMemoTen;
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 2;
            this.colten.Width = 153;
            // 
            // repositoryMemoTen
            // 
            this.repositoryMemoTen.Name = "repositoryMemoTen";
            // 
            // colloaits
            // 
            this.colloaits.Caption = "Loại tài sản";
            this.colloaits.FieldName = "loaits";
            this.colloaits.Name = "colloaits";
            this.colloaits.Visible = true;
            this.colloaits.VisibleIndex = 3;
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
            this.colnuocsx.Width = 86;
            // 
            // colngaysudung
            // 
            this.colngaysudung.Caption = "Ngày sử dụng";
            this.colngaysudung.FieldName = "ngay";
            this.colngaysudung.Name = "colngaysudung";
            this.colngaysudung.Visible = true;
            this.colngaysudung.VisibleIndex = 5;
            // 
            // coldongia
            // 
            this.coldongia.Caption = "Đơn giá";
            this.coldongia.DisplayFormat.FormatString = "### ### ### ##0";
            this.coldongia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldongia.FieldName = "dongia";
            this.coldongia.Name = "coldongia";
            this.coldongia.Visible = true;
            this.coldongia.VisibleIndex = 7;
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Số lượng";
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 6;
            // 
            // colthanhtien
            // 
            this.colthanhtien.Caption = "Thành tiền";
            this.colthanhtien.DisplayFormat.FormatString = "### ### ### ##0";
            this.colthanhtien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.Visible = true;
            this.colthanhtien.VisibleIndex = 8;
            this.colthanhtien.Width = 84;
            // 
            // coldvql
            // 
            this.coldvql.Caption = "Đơn vị quản lý";
            this.coldvql.FieldName = "dvquanly";
            this.coldvql.Name = "coldvql";
            this.coldvql.Visible = true;
            this.coldvql.VisibleIndex = 9;
            this.coldvql.Width = 118;
            // 
            // colphong
            // 
            this.colphong.Caption = "Phòng";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            this.colphong.Visible = true;
            this.colphong.VisibleIndex = 10;
            this.colphong.Width = 77;
            // 
            // colvitri
            // 
            this.colvitri.Caption = "Vị trí";
            this.colvitri.FieldName = "vitri";
            this.colvitri.Name = "colvitri";
            this.colvitri.Visible = true;
            this.colvitri.VisibleIndex = 11;
            this.colvitri.Width = 82;
            // 
            // colphantramhm1nam
            // 
            this.colphantramhm1nam.Caption = "Tỷ lệ hao mòn 1 năm";
            this.colphantramhm1nam.DisplayFormat.FormatString = "p";
            this.colphantramhm1nam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colphantramhm1nam.FieldName = "phantramhm1nam";
            this.colphantramhm1nam.Name = "colphantramhm1nam";
            this.colphantramhm1nam.Visible = true;
            this.colphantramhm1nam.VisibleIndex = 12;
            this.colphantramhm1nam.Width = 112;
            // 
            // colhaomon_1nam
            // 
            this.colhaomon_1nam.Caption = "Giá trị hao mòn 1 năm";
            this.colhaomon_1nam.DisplayFormat.FormatString = "### ### ### ##0";
            this.colhaomon_1nam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colhaomon_1nam.FieldName = "haomon_1nam";
            this.colhaomon_1nam.Name = "colhaomon_1nam";
            this.colhaomon_1nam.Visible = true;
            this.colhaomon_1nam.VisibleIndex = 13;
            this.colhaomon_1nam.Width = 112;
            // 
            // colsonamsudungconlai_final
            // 
            this.colsonamsudungconlai_final.Caption = "Số năm sử dụng còn lại";
            this.colsonamsudungconlai_final.FieldName = "sonamsudungconlai_final";
            this.colsonamsudungconlai_final.Name = "colsonamsudungconlai_final";
            this.colsonamsudungconlai_final.Visible = true;
            this.colsonamsudungconlai_final.VisibleIndex = 14;
            this.colsonamsudungconlai_final.Width = 123;
            // 
            // colgiatriconlai_final
            // 
            this.colgiatriconlai_final.Caption = "Giá trị còn lại";
            this.colgiatriconlai_final.DisplayFormat.FormatString = "### ### ### ##0";
            this.colgiatriconlai_final.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colgiatriconlai_final.FieldName = "giatriconlai_final";
            this.colgiatriconlai_final.Name = "colgiatriconlai_final";
            this.colgiatriconlai_final.Visible = true;
            this.colgiatriconlai_final.VisibleIndex = 15;
            this.colgiatriconlai_final.Width = 87;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.checkTinhTrang);
            this.panelSearch.Controls.Add(this.checkNamTK);
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
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(862, 82);
            this.panelSearch.TabIndex = 1;
            // 
            // checkTinhTrang
            // 
            this.checkTinhTrang.Location = new System.Drawing.Point(5, 55);
            this.checkTinhTrang.Name = "checkTinhTrang";
            this.checkTinhTrang.Properties.Caption = "Tình trạng:";
            this.checkTinhTrang.Size = new System.Drawing.Size(82, 19);
            this.checkTinhTrang.TabIndex = 5;
            // 
            // checkNamTK
            // 
            this.checkNamTK.EditValue = true;
            this.checkNamTK.Location = new System.Drawing.Point(5, 5);
            this.checkNamTK.Name = "checkNamTK";
            this.checkNamTK.Properties.Caption = "Năm thống kê:";
            this.checkNamTK.Properties.ReadOnly = true;
            this.checkNamTK.Size = new System.Drawing.Size(93, 19);
            this.checkNamTK.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(679, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Làm sạch";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(679, 3);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 14;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // ucComboBoxViTri1
            // 
            this.ucComboBoxViTri1.EditValue = null;
            this.ucComboBoxViTri1.Location = new System.Drawing.Point(437, 31);
            this.ucComboBoxViTri1.Name = "ucComboBoxViTri1";
            this.ucComboBoxViTri1.Phong = null;
            this.ucComboBoxViTri1.Size = new System.Drawing.Size(160, 20);
            this.ucComboBoxViTri1.TabIndex = 10;
            this.ucComboBoxViTri1.ViTri = null;
            // 
            // ucComboBoxLoaiTS1
            // 
            this.ucComboBoxLoaiTS1.EditValue = null;
            this.ucComboBoxLoaiTS1.LoaiTS = null;
            this.ucComboBoxLoaiTS1.Location = new System.Drawing.Point(101, 32);
            this.ucComboBoxLoaiTS1.Name = "ucComboBoxLoaiTS1";
            this.ucComboBoxLoaiTS1.Size = new System.Drawing.Size(160, 20);
            this.ucComboBoxLoaiTS1.TabIndex = 4;
            // 
            // checkViTri
            // 
            this.checkViTri.Location = new System.Drawing.Point(341, 31);
            this.checkViTri.Name = "checkViTri";
            this.checkViTri.Properties.Caption = "Vị trí:";
            this.checkViTri.Size = new System.Drawing.Size(58, 19);
            this.checkViTri.TabIndex = 9;
            // 
            // checkLoaiTS
            // 
            this.checkLoaiTS.Location = new System.Drawing.Point(5, 31);
            this.checkLoaiTS.Name = "checkLoaiTS";
            this.checkLoaiTS.Properties.Caption = "Loại tài sản:";
            this.checkLoaiTS.Size = new System.Drawing.Size(82, 19);
            this.checkLoaiTS.TabIndex = 3;
            // 
            // checkDonVi
            // 
            this.checkDonVi.Location = new System.Drawing.Point(341, 5);
            this.checkDonVi.Name = "checkDonVi";
            this.checkDonVi.Properties.Caption = "Đơn vị quản lý:";
            this.checkDonVi.Size = new System.Drawing.Size(93, 19);
            this.checkDonVi.TabIndex = 7;
            // 
            // checkedCbxTinhTrang
            // 
            this.checkedCbxTinhTrang.Location = new System.Drawing.Point(101, 58);
            this.checkedCbxTinhTrang.Name = "checkedCbxTinhTrang";
            this.checkedCbxTinhTrang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCbxTinhTrang.Properties.DisplayMember = "value";
            this.checkedCbxTinhTrang.Properties.ValueMember = "id";
            this.checkedCbxTinhTrang.Size = new System.Drawing.Size(160, 20);
            this.checkedCbxTinhTrang.TabIndex = 6;
            this.checkedCbxTinhTrang.EditValueChanged += new System.EventHandler(this.checkedCbxTinhTrang_EditValueChanged);
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.EditValue = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(437, 5);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(160, 20);
            this.ucComboBoxDonVi1.TabIndex = 8;
            // 
            // dateNgayTK
            // 
            this.dateNgayTK.EditValue = null;
            this.dateNgayTK.Location = new System.Drawing.Point(101, 6);
            this.dateNgayTK.Name = "dateNgayTK";
            this.dateNgayTK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayTK.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayTK.Properties.DisplayFormat.FormatString = "yyyy";
            this.dateNgayTK.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateNgayTK.Properties.EditFormat.FormatString = "yyyy";
            this.dateNgayTK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateNgayTK.Properties.Mask.EditMask = "yyyy";
            this.dateNgayTK.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.dateNgayTK.Size = new System.Drawing.Size(160, 20);
            this.dateNgayTK.TabIndex = 2;
            // 
            // ucTKHaoMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlHaoMon);
            this.Controls.Add(this.panelSearch);
            this.Name = "ucTKHaoMon";
            this.Size = new System.Drawing.Size(862, 528);
            this.Leave += new System.EventHandler(this.ucTKHaoMon_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHaoMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHaoMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryMemoTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).EndInit();
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkTinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNamTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLoaiTS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCbxTinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayTK.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayTK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControlHaoMon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHaoMon;
        private DevExpress.XtraEditors.PanelControl panelSearch;
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
        private DevExpress.XtraGrid.Columns.GridColumn colphantramhm1nam;
        private DevExpress.XtraGrid.Columns.GridColumn colsohieuct;
        private DevExpress.XtraGrid.Columns.GridColumn colngaysudung;
        private DevExpress.XtraGrid.Columns.GridColumn colhaomon_1nam;
        private DevExpress.XtraGrid.Columns.GridColumn colngayct;
        private DevExpress.XtraGrid.Columns.GridColumn colsonamsudungconlai_final;
        private DevExpress.XtraGrid.Columns.GridColumn colgiatriconlai_final;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryMemoTen;
        private DevExpress.XtraEditors.CheckEdit checkTinhTrang;
        private DevExpress.XtraEditors.CheckEdit checkNamTK;
    }
}
