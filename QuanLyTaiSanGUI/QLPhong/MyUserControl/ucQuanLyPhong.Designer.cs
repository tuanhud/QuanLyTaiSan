namespace QuanLyTaiSanGUI.MyUserControl
{
    partial class ucQuanLyPhong
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlThietBi = new DevExpress.XtraGrid.GridControl();
            this.gridViewThietBi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphong_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthietbi_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltinhtrang_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenthietbi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenloai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenphong = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThietBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlThietBi);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(675, 469);
            this.splitContainerControl1.SplitterPosition = 283;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlThietBi
            // 
            this.gridControlThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThietBi.Location = new System.Drawing.Point(0, 0);
            this.gridControlThietBi.MainView = this.gridViewThietBi;
            this.gridControlThietBi.Name = "gridControlThietBi";
            this.gridControlThietBi.Size = new System.Drawing.Size(387, 469);
            this.gridControlThietBi.TabIndex = 0;
            this.gridControlThietBi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThietBi});
            // 
            // gridViewThietBi
            // 
            this.gridViewThietBi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colphong_id,
            this.colthietbi_id,
            this.coltinhtrang_id,
            this.coltenthietbi,
            this.coltenloai,
            this.coltinhtrang,
            this.colsoluong,
            this.coltenphong});
            this.gridViewThietBi.GridControl = this.gridControlThietBi;
            this.gridViewThietBi.GroupCount = 2;
            this.gridViewThietBi.Name = "gridViewThietBi";
            this.gridViewThietBi.OptionsBehavior.ReadOnly = true;
            this.gridViewThietBi.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewThietBi.OptionsFind.AlwaysVisible = true;
            this.gridViewThietBi.OptionsView.ShowGroupPanel = false;
            this.gridViewThietBi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coltenphong, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coltinhtrang, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewThietBi.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridViewThietBi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            // 
            // colphong_id
            // 
            this.colphong_id.FieldName = "phong_id";
            this.colphong_id.Name = "colphong_id";
            // 
            // colthietbi_id
            // 
            this.colthietbi_id.FieldName = "thietbi_id";
            this.colthietbi_id.Name = "colthietbi_id";
            // 
            // coltinhtrang_id
            // 
            this.coltinhtrang_id.FieldName = "tinhtrang_id";
            this.coltinhtrang_id.Name = "coltinhtrang_id";
            // 
            // coltenthietbi
            // 
            this.coltenthietbi.Caption = "Tên thiết bị";
            this.coltenthietbi.FieldName = "ten";
            this.coltenthietbi.Name = "coltenthietbi";
            this.coltenthietbi.Visible = true;
            this.coltenthietbi.VisibleIndex = 0;
            this.coltenthietbi.Width = 432;
            // 
            // coltenloai
            // 
            this.coltenloai.Caption = "Loại";
            this.coltenloai.FieldName = "tenloai";
            this.coltenloai.Name = "coltenloai";
            this.coltenloai.Width = 323;
            // 
            // coltinhtrang
            // 
            this.coltinhtrang.Caption = "Tình trạng";
            this.coltinhtrang.FieldName = "value";
            this.coltinhtrang.Name = "coltinhtrang";
            this.coltinhtrang.Visible = true;
            this.coltinhtrang.VisibleIndex = 2;
            this.coltinhtrang.Width = 293;
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Số lượng";
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 1;
            this.colsoluong.Width = 202;
            // 
            // coltenphong
            // 
            this.coltenphong.Caption = "Phòng";
            this.coltenphong.FieldName = "tenphong";
            this.coltenphong.Name = "coltenphong";
            this.coltenphong.Visible = true;
            this.coltenphong.VisibleIndex = 4;
            // 
            // ucQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucQuanLyPhong";
            this.Size = new System.Drawing.Size(675, 469);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThietBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThietBi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlThietBi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewThietBi;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn colphong_id;
        private DevExpress.XtraGrid.Columns.GridColumn colthietbi_id;
        private DevExpress.XtraGrid.Columns.GridColumn coltinhtrang_id;
        private DevExpress.XtraGrid.Columns.GridColumn coltenthietbi;
        private DevExpress.XtraGrid.Columns.GridColumn coltinhtrang;
        private DevExpress.XtraGrid.Columns.GridColumn coltenphong;
        private DevExpress.XtraGrid.Columns.GridColumn coltenloai;
    }
}
