namespace TSCD_GUI.QLTaiSan
{
    partial class ucQuanLyTaiSan
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
            this.rbnControlTaiSan = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.colnguôngc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colloai = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.coltinhtrang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colghichu = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnControlTaiSan
            // 
            this.rbnControlTaiSan.ExpandCollapseItem.Id = 0;
            this.rbnControlTaiSan.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlTaiSan.ExpandCollapseItem,
            this.barBtnThemTaiSan,
            this.barBtnSuaTaiSan,
            this.barBtnXoaTaiSan});
            this.rbnControlTaiSan.Location = new System.Drawing.Point(0, 0);
            this.rbnControlTaiSan.MaxItemId = 5;
            this.rbnControlTaiSan.Name = "rbnControlTaiSan";
            this.rbnControlTaiSan.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageTaiSan});
            this.rbnControlTaiSan.Size = new System.Drawing.Size(858, 142);
            // 
            // barBtnThemTaiSan
            // 
            this.barBtnThemTaiSan.Caption = "Thêm tài sản";
            this.barBtnThemTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemTaiSan.Id = 1;
            this.barBtnThemTaiSan.Name = "barBtnThemTaiSan";
            this.barBtnThemTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemTaiSan_ItemClick);
            // 
            // barBtnSuaTaiSan
            // 
            this.barBtnSuaTaiSan.Caption = "Sửa tài sản";
            this.barBtnSuaTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaTaiSan.Id = 2;
            this.barBtnSuaTaiSan.Name = "barBtnSuaTaiSan";
            this.barBtnSuaTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaTaiSan_ItemClick);
            // 
            // barBtnXoaTaiSan
            // 
            this.barBtnXoaTaiSan.Caption = "Xóa tài sản";
            this.barBtnXoaTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaTaiSan.Id = 3;
            this.barBtnXoaTaiSan.Name = "barBtnXoaTaiSan";
            // 
            // rbnPageTaiSan
            // 
            this.rbnPageTaiSan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupTaiSan});
            this.rbnPageTaiSan.Name = "rbnPageTaiSan";
            this.rbnPageTaiSan.Text = "Tài sản";
            // 
            // rbnGroupTaiSan
            // 
            this.rbnGroupTaiSan.ItemLinks.Add(this.barBtnThemTaiSan);
            this.rbnGroupTaiSan.ItemLinks.Add(this.barBtnSuaTaiSan);
            this.rbnGroupTaiSan.ItemLinks.Add(this.barBtnXoaTaiSan);
            this.rbnGroupTaiSan.Name = "rbnGroupTaiSan";
            this.rbnGroupTaiSan.ShowCaptionButton = false;
            this.rbnGroupTaiSan.Text = "Tài sản";
            // 
            // gridControlTaiSan
            // 
            this.gridControlTaiSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTaiSan.Location = new System.Drawing.Point(2, 24);
            this.gridControlTaiSan.MainView = this.bandedGridViewTaiSan;
            this.gridControlTaiSan.MenuManager = this.rbnControlTaiSan;
            this.gridControlTaiSan.Name = "gridControlTaiSan";
            this.gridControlTaiSan.Size = new System.Drawing.Size(854, 341);
            this.gridControlTaiSan.TabIndex = 1;
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
            this.colnguôngc,
            this.colghichu,
            this.colid});
            this.bandedGridViewTaiSan.GridControl = this.gridControlTaiSan;
            this.bandedGridViewTaiSan.GroupCount = 1;
            this.bandedGridViewTaiSan.Name = "bandedGridViewTaiSan";
            this.bandedGridViewTaiSan.OptionsBehavior.Editable = false;
            this.bandedGridViewTaiSan.OptionsBehavior.ReadOnly = true;
            this.bandedGridViewTaiSan.OptionsSelection.EnableAppearanceFocusedCell = false;
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
            this.gridBandtaisan.Columns.Add(this.colnguôngc);
            this.gridBandtaisan.Columns.Add(this.colloai);
            this.gridBandtaisan.Columns.Add(this.coltinhtrang);
            this.gridBandtaisan.Columns.Add(this.colghichu);
            this.gridBandtaisan.Name = "gridBandtaisan";
            this.gridBandtaisan.VisibleIndex = 2;
            this.gridBandtaisan.Width = 515;
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
            // colnguôngc
            // 
            this.colnguôngc.AppearanceHeader.Options.UseTextOptions = true;
            this.colnguôngc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colnguôngc.Caption = "Nguồn gốc";
            this.colnguôngc.FieldName = "nguongoc";
            this.colnguôngc.Name = "colnguôngc";
            this.colnguôngc.Visible = true;
            this.colnguôngc.Width = 58;
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
            // groupControlMain
            // 
            this.groupControlMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlMain.AppearanceCaption.Options.UseFont = true;
            this.groupControlMain.Controls.Add(this.gridControlTaiSan);
            this.groupControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMain.Location = new System.Drawing.Point(0, 142);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(858, 367);
            this.groupControlMain.TabIndex = 3;
            this.groupControlMain.Text = "Tài sản";
            // 
            // ucQuanLyTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlMain);
            this.Controls.Add(this.rbnControlTaiSan);
            this.Name = "ucQuanLyTaiSan";
            this.Size = new System.Drawing.Size(858, 509);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlTaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageTaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTaiSan;
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
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colnguôngc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colloai;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn coltinhtrang;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colghichu;
        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colid;
    }
}
