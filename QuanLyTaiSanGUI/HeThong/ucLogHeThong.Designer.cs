namespace QuanLyTaiSanGUI.HeThong
{
    partial class ucLogHeThong
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
            this.ribbonLogHeThong = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditTuNgay = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditDenNgay = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditGioiHan = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barBtnViewLog = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageLogHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupLogHeThong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControlLogHeThong = new DevExpress.XtraGrid.GridControl();
            this.gridViewLogHeThong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnoidung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngay = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonLogHeThong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogHeThong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogHeThong)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonLogHeThong
            // 
            this.ribbonLogHeThong.AutoSizeItems = true;
            this.ribbonLogHeThong.ExpandCollapseItem.Id = 0;
            this.ribbonLogHeThong.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonLogHeThong.ExpandCollapseItem,
            this.barEditTuNgay,
            this.barEditDenNgay,
            this.barEditGioiHan,
            this.barBtnViewLog});
            this.ribbonLogHeThong.Location = new System.Drawing.Point(0, 0);
            this.ribbonLogHeThong.MaxItemId = 5;
            this.ribbonLogHeThong.Name = "ribbonLogHeThong";
            this.ribbonLogHeThong.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageLogHeThong});
            this.ribbonLogHeThong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemSpinEdit1});
            this.ribbonLogHeThong.Size = new System.Drawing.Size(756, 145);
            // 
            // barEditTuNgay
            // 
            this.barEditTuNgay.Caption = "Từ ngày:";
            this.barEditTuNgay.Edit = this.repositoryItemDateEdit1;
            this.barEditTuNgay.Id = 1;
            this.barEditTuNgay.Name = "barEditTuNgay";
            this.barEditTuNgay.Width = 80;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // barEditDenNgay
            // 
            this.barEditDenNgay.Caption = "Đến ngày:";
            this.barEditDenNgay.Edit = this.repositoryItemDateEdit2;
            this.barEditDenNgay.Id = 2;
            this.barEditDenNgay.Name = "barEditDenNgay";
            this.barEditDenNgay.Width = 80;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // barEditGioiHan
            // 
            this.barEditGioiHan.Caption = "Giới hạn:";
            this.barEditGioiHan.Edit = this.repositoryItemSpinEdit1;
            this.barEditGioiHan.Id = 3;
            this.barEditGioiHan.Name = "barEditGioiHan";
            this.barEditGioiHan.Width = 80;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // barBtnViewLog
            // 
            this.barBtnViewLog.Caption = "Xem Log";
            this.barBtnViewLog.Id = 4;
            this.barBtnViewLog.LargeGlyph = global::QuanLyTaiSanGUI.Properties.Resources.log_icon_32;
            this.barBtnViewLog.Name = "barBtnViewLog";
            this.barBtnViewLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnViewLog_ItemClick);
            // 
            // rbnPageLogHeThong
            // 
            this.rbnPageLogHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupLogHeThong});
            this.rbnPageLogHeThong.Image = global::QuanLyTaiSanGUI.Properties.Resources.log_icon_16;
            this.rbnPageLogHeThong.Name = "rbnPageLogHeThong";
            this.rbnPageLogHeThong.Text = "Log hệ thống";
            // 
            // rbnGroupLogHeThong
            // 
            this.rbnGroupLogHeThong.ItemLinks.Add(this.barEditTuNgay);
            this.rbnGroupLogHeThong.ItemLinks.Add(this.barEditDenNgay);
            this.rbnGroupLogHeThong.ItemLinks.Add(this.barEditGioiHan);
            this.rbnGroupLogHeThong.ItemLinks.Add(this.barBtnViewLog);
            this.rbnGroupLogHeThong.Name = "rbnGroupLogHeThong";
            this.rbnGroupLogHeThong.ShowCaptionButton = false;
            this.rbnGroupLogHeThong.Text = "Log hệ thống";
            // 
            // gridControlLogHeThong
            // 
            this.gridControlLogHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLogHeThong.Location = new System.Drawing.Point(0, 145);
            this.gridControlLogHeThong.MainView = this.gridViewLogHeThong;
            this.gridControlLogHeThong.MenuManager = this.ribbonLogHeThong;
            this.gridControlLogHeThong.Name = "gridControlLogHeThong";
            this.gridControlLogHeThong.Size = new System.Drawing.Size(756, 409);
            this.gridControlLogHeThong.TabIndex = 1;
            this.gridControlLogHeThong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLogHeThong});
            // 
            // gridViewLogHeThong
            // 
            this.gridViewLogHeThong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colnoidung,
            this.colngay});
            this.gridViewLogHeThong.GridControl = this.gridControlLogHeThong;
            this.gridViewLogHeThong.Name = "gridViewLogHeThong";
            this.gridViewLogHeThong.OptionsBehavior.Editable = false;
            this.gridViewLogHeThong.OptionsBehavior.ReadOnly = true;
            this.gridViewLogHeThong.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewLogHeThong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLogHeThong.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colnoidung
            // 
            this.colnoidung.Caption = "Nội dung";
            this.colnoidung.FieldName = "mota";
            this.colnoidung.Name = "colnoidung";
            this.colnoidung.Visible = true;
            this.colnoidung.VisibleIndex = 1;
            this.colnoidung.Width = 589;
            // 
            // colngay
            // 
            this.colngay.Caption = "Thời gian";
            this.colngay.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colngay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colngay.FieldName = "date_create";
            this.colngay.Name = "colngay";
            this.colngay.Visible = true;
            this.colngay.VisibleIndex = 0;
            this.colngay.Width = 149;
            // 
            // ucLogHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlLogHeThong);
            this.Controls.Add(this.ribbonLogHeThong);
            this.Name = "ucLogHeThong";
            this.Size = new System.Drawing.Size(756, 554);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonLogHeThong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogHeThong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogHeThong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonLogHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageLogHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLogHeThong;
        private DevExpress.XtraGrid.GridControl gridControlLogHeThong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLogHeThong;
        private DevExpress.XtraBars.BarEditItem barEditTuNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barEditDenNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarEditItem barEditGioiHan;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarButtonItem barBtnViewLog;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colnoidung;
        private DevExpress.XtraGrid.Columns.GridColumn colngay;
    }
}
