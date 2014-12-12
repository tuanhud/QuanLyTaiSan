namespace TSCD_GUI.ThongKe
{
    partial class ucTKTHPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTKTHPhong));
            this.panelSearch = new DevExpress.XtraEditors.PanelControl();
            this.checkLoaiPhong = new DevExpress.XtraEditors.CheckEdit();
            this.checkSoLuongChoNgoi = new DevExpress.XtraEditors.CheckEdit();
            this.spinSoChoNgoi = new DevExpress.XtraEditors.SpinEdit();
            this.cbxEquation = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.ucComboBoxViTri1 = new TSCD_GUI.MyUserControl.ucComboBoxViTri();
            this.ucComboBoxDonVi1 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.checkDonVi = new DevExpress.XtraEditors.CheckEdit();
            this.checkViTri = new DevExpress.XtraEditors.CheckEdit();
            this.checkedCbxLoaiPhong = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.gridControlPhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsochongoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltonggiatritaisan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcoso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltang = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkLoaiPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSoLuongChoNgoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoChoNgoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEquation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCbxLoaiPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.checkLoaiPhong);
            this.panelSearch.Controls.Add(this.checkSoLuongChoNgoi);
            this.panelSearch.Controls.Add(this.spinSoChoNgoi);
            this.panelSearch.Controls.Add(this.cbxEquation);
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Controls.Add(this.btnTim);
            this.panelSearch.Controls.Add(this.ucComboBoxViTri1);
            this.panelSearch.Controls.Add(this.ucComboBoxDonVi1);
            this.panelSearch.Controls.Add(this.checkDonVi);
            this.panelSearch.Controls.Add(this.checkViTri);
            this.panelSearch.Controls.Add(this.checkedCbxLoaiPhong);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(834, 56);
            this.panelSearch.TabIndex = 0;
            // 
            // checkLoaiPhong
            // 
            this.checkLoaiPhong.Location = new System.Drawing.Point(5, 6);
            this.checkLoaiPhong.Name = "checkLoaiPhong";
            this.checkLoaiPhong.Properties.Caption = "Loại phòng:";
            this.checkLoaiPhong.Size = new System.Drawing.Size(78, 19);
            this.checkLoaiPhong.TabIndex = 36;
            // 
            // checkSoLuongChoNgoi
            // 
            this.checkSoLuongChoNgoi.Location = new System.Drawing.Point(5, 31);
            this.checkSoLuongChoNgoi.Name = "checkSoLuongChoNgoi";
            this.checkSoLuongChoNgoi.Properties.Caption = "Số lượng chỗ ngồi:";
            this.checkSoLuongChoNgoi.Size = new System.Drawing.Size(113, 19);
            this.checkSoLuongChoNgoi.TabIndex = 35;
            // 
            // spinSoChoNgoi
            // 
            this.spinSoChoNgoi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinSoChoNgoi.Location = new System.Drawing.Point(159, 29);
            this.spinSoChoNgoi.Name = "spinSoChoNgoi";
            this.spinSoChoNgoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSoChoNgoi.Size = new System.Drawing.Size(90, 20);
            this.spinSoChoNgoi.TabIndex = 34;
            this.spinSoChoNgoi.EditValueChanged += new System.EventHandler(this.spinSoChoNgoi_EditValueChanged);
            // 
            // cbxEquation
            // 
            this.cbxEquation.Location = new System.Drawing.Point(119, 29);
            this.cbxEquation.Name = "cbxEquation";
            this.cbxEquation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxEquation.Properties.Items.AddRange(new object[] {
            "=",
            ">=",
            ">",
            "<=",
            "<"});
            this.cbxEquation.Size = new System.Drawing.Size(34, 20);
            this.cbxEquation.TabIndex = 33;
            this.cbxEquation.EditValueChanged += new System.EventHandler(this.cbxEquation_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(719, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Làm sạch";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(638, 14);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 28;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // ucComboBoxViTri1
            // 
            this.ucComboBoxViTri1.EditValue = null;
            this.ucComboBoxViTri1.Location = new System.Drawing.Point(380, 5);
            this.ucComboBoxViTri1.Name = "ucComboBoxViTri1";
            this.ucComboBoxViTri1.Phong = null;
            this.ucComboBoxViTri1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxViTri1.TabIndex = 5;
            this.ucComboBoxViTri1.ViTri = null;
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.EditValue = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(380, 29);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxDonVi1.TabIndex = 4;
            // 
            // checkDonVi
            // 
            this.checkDonVi.Location = new System.Drawing.Point(313, 31);
            this.checkDonVi.Name = "checkDonVi";
            this.checkDonVi.Properties.Caption = "Đơn vị:";
            this.checkDonVi.Size = new System.Drawing.Size(59, 19);
            this.checkDonVi.TabIndex = 3;
            // 
            // checkViTri
            // 
            this.checkViTri.Location = new System.Drawing.Point(313, 5);
            this.checkViTri.Name = "checkViTri";
            this.checkViTri.Properties.Caption = "Vị trí:";
            this.checkViTri.Size = new System.Drawing.Size(51, 19);
            this.checkViTri.TabIndex = 2;
            // 
            // checkedCbxLoaiPhong
            // 
            this.checkedCbxLoaiPhong.Location = new System.Drawing.Point(119, 5);
            this.checkedCbxLoaiPhong.Name = "checkedCbxLoaiPhong";
            this.checkedCbxLoaiPhong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCbxLoaiPhong.Properties.DisplayMember = "ten";
            this.checkedCbxLoaiPhong.Properties.ValueMember = "id";
            this.checkedCbxLoaiPhong.Size = new System.Drawing.Size(130, 20);
            this.checkedCbxLoaiPhong.TabIndex = 1;
            this.checkedCbxLoaiPhong.EditValueChanged += new System.EventHandler(this.checkedCbxLoaiPhong_EditValueChanged);
            // 
            // gridControlPhong
            // 
            this.gridControlPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPhong.Location = new System.Drawing.Point(0, 56);
            this.gridControlPhong.MainView = this.gridViewPhong;
            this.gridControlPhong.Name = "gridControlPhong";
            this.gridControlPhong.Size = new System.Drawing.Size(834, 469);
            this.gridControlPhong.TabIndex = 1;
            this.gridControlPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhong});
            // 
            // gridViewPhong
            // 
            this.gridViewPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colten,
            this.colloai,
            this.colsochongoi,
            this.coltonggiatritaisan,
            this.colcoso,
            this.colday,
            this.coltang});
            this.gridViewPhong.GridControl = this.gridControlPhong;
            this.gridViewPhong.GroupCount = 1;
            this.gridViewPhong.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ten", this.colten, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sochongoi", this.colsochongoi, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tonggiatritaisan", this.coltonggiatritaisan, "{0:### ### ### ##0}")});
            this.gridViewPhong.Name = "gridViewPhong";
            this.gridViewPhong.OptionsBehavior.Editable = false;
            this.gridViewPhong.OptionsBehavior.ReadOnly = true;
            this.gridViewPhong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPhong.OptionsView.ShowFooter = true;
            this.gridViewPhong.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colloai, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewPhong.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridViewPhong_CustomSummaryCalculate);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Tên phòng";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "Loại phòng";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            this.colloai.Visible = true;
            this.colloai.VisibleIndex = 1;
            // 
            // colsochongoi
            // 
            this.colsochongoi.Caption = "Số chỗ ngồi";
            this.colsochongoi.FieldName = "sochongoi";
            this.colsochongoi.Name = "colsochongoi";
            this.colsochongoi.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colsochongoi.Visible = true;
            this.colsochongoi.VisibleIndex = 1;
            // 
            // coltonggiatritaisan
            // 
            this.coltonggiatritaisan.Caption = "Giá trị";
            this.coltonggiatritaisan.DisplayFormat.FormatString = "### ### ### ##0";
            this.coltonggiatritaisan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltonggiatritaisan.FieldName = "tonggiatritaisan";
            this.coltonggiatritaisan.Name = "coltonggiatritaisan";
            this.coltonggiatritaisan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tonggiatritaisan", "{0:### ### ### ##0}")});
            this.coltonggiatritaisan.Visible = true;
            this.coltonggiatritaisan.VisibleIndex = 2;
            // 
            // colcoso
            // 
            this.colcoso.Caption = "Cơ sở";
            this.colcoso.FieldName = "coso";
            this.colcoso.Name = "colcoso";
            this.colcoso.Visible = true;
            this.colcoso.VisibleIndex = 3;
            // 
            // colday
            // 
            this.colday.Caption = "Dãy";
            this.colday.FieldName = "day";
            this.colday.Name = "colday";
            this.colday.Visible = true;
            this.colday.VisibleIndex = 4;
            // 
            // coltang
            // 
            this.coltang.Caption = "Tầng";
            this.coltang.FieldName = "tang";
            this.coltang.Name = "coltang";
            this.coltang.Visible = true;
            this.coltang.VisibleIndex = 5;
            // 
            // ucTKTHPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlPhong);
            this.Controls.Add(this.panelSearch);
            this.Name = "ucTKTHPhong";
            this.Size = new System.Drawing.Size(834, 525);
            this.Leave += new System.EventHandler(this.ucTKTHPhong_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).EndInit();
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkLoaiPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSoLuongChoNgoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoChoNgoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEquation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCbxLoaiPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSearch;
        public DevExpress.XtraGrid.GridControl gridControlPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhong;
        private MyUserControl.ucComboBoxViTri ucComboBoxViTri1;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi1;
        private DevExpress.XtraEditors.CheckEdit checkDonVi;
        private DevExpress.XtraEditors.CheckEdit checkViTri;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCbxLoaiPhong;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colloai;
        private DevExpress.XtraGrid.Columns.GridColumn colsochongoi;
        private DevExpress.XtraGrid.Columns.GridColumn colcoso;
        private DevExpress.XtraGrid.Columns.GridColumn colday;
        private DevExpress.XtraGrid.Columns.GridColumn coltang;
        private DevExpress.XtraEditors.SpinEdit spinSoChoNgoi;
        private DevExpress.XtraEditors.ComboBoxEdit cbxEquation;
        private DevExpress.XtraGrid.Columns.GridColumn coltonggiatritaisan;
        private DevExpress.XtraEditors.CheckEdit checkLoaiPhong;
        private DevExpress.XtraEditors.CheckEdit checkSoLuongChoNgoi;
    }
}
