namespace QuanLyTaiSanGUI.QLPhong.MyForm
{
    partial class frmLogThietBi
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlLogThietBi = new DevExpress.XtraGrid.GridControl();
            this.gridViewLogThietBi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldatecreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthietbi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnhanvien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogThietBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogThietBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlLogThietBi);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(743, 421);
            this.splitContainerControl1.SplitterPosition = 478;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlLogThietBi
            // 
            this.gridControlLogThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLogThietBi.Location = new System.Drawing.Point(0, 0);
            this.gridControlLogThietBi.MainView = this.gridViewLogThietBi;
            this.gridControlLogThietBi.Name = "gridControlLogThietBi";
            this.gridControlLogThietBi.Size = new System.Drawing.Size(478, 421);
            this.gridControlLogThietBi.TabIndex = 0;
            this.gridControlLogThietBi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLogThietBi});
            // 
            // gridViewLogThietBi
            // 
            this.gridViewLogThietBi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldatecreate,
            this.colthietbi,
            this.coltinhtrang,
            this.colsoluong,
            this.colmota,
            this.colnhanvien,
            this.colphong});
            this.gridViewLogThietBi.GridControl = this.gridControlLogThietBi;
            this.gridViewLogThietBi.Name = "gridViewLogThietBi";
            this.gridViewLogThietBi.OptionsBehavior.Editable = false;
            this.gridViewLogThietBi.OptionsBehavior.ReadOnly = true;
            this.gridViewLogThietBi.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewLogThietBi.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewLogThietBi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLogThietBi.OptionsView.ShowAutoFilterRow = true;
            this.gridViewLogThietBi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewLogThietBi_FocusedRowChanged);
            // 
            // coldatecreate
            // 
            this.coldatecreate.Caption = "Ngày";
            this.coldatecreate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.coldatecreate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldatecreate.FieldName = "date_create";
            this.coldatecreate.Name = "coldatecreate";
            this.coldatecreate.Visible = true;
            this.coldatecreate.VisibleIndex = 6;
            // 
            // colthietbi
            // 
            this.colthietbi.Caption = "Thiết bị";
            this.colthietbi.FieldName = "thietbi.ten";
            this.colthietbi.Name = "colthietbi";
            this.colthietbi.Visible = true;
            this.colthietbi.VisibleIndex = 0;
            // 
            // coltinhtrang
            // 
            this.coltinhtrang.Caption = "Tình trạng";
            this.coltinhtrang.FieldName = "tinhtrang.value";
            this.coltinhtrang.Name = "coltinhtrang";
            this.coltinhtrang.Visible = true;
            this.coltinhtrang.VisibleIndex = 1;
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Số lượng";
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 2;
            // 
            // colmota
            // 
            this.colmota.Caption = "Ghi chú";
            this.colmota.FieldName = "mota";
            this.colmota.Name = "colmota";
            this.colmota.Visible = true;
            this.colmota.VisibleIndex = 3;
            // 
            // colnhanvien
            // 
            this.colnhanvien.Caption = "Quản trị viên";
            this.colnhanvien.FieldName = "quantrivien.hoten";
            this.colnhanvien.Name = "colnhanvien";
            this.colnhanvien.Visible = true;
            this.colnhanvien.VisibleIndex = 4;
            // 
            // colphong
            // 
            this.colphong.Caption = "Phòng";
            this.colphong.FieldName = "phong.ten";
            this.colphong.Name = "colphong";
            this.colphong.Visible = true;
            this.colphong.VisibleIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.imageSlider1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(260, 421);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Hình ảnh";
            // 
            // imageSlider1
            // 
            this.imageSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.imageSlider1.Location = new System.Drawing.Point(4, 27);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(252, 219);
            this.imageSlider1.TabIndex = 0;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // frmLogThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 421);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmLogThietBi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log thiết bị";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogThietBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogThietBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlLogThietBi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLogThietBi;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraGrid.Columns.GridColumn colthietbi;
        private DevExpress.XtraGrid.Columns.GridColumn coltinhtrang;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn colmota;
        private DevExpress.XtraGrid.Columns.GridColumn colnhanvien;
        private DevExpress.XtraGrid.Columns.GridColumn colphong;
        private DevExpress.XtraGrid.Columns.GridColumn coldatecreate;
    }
}