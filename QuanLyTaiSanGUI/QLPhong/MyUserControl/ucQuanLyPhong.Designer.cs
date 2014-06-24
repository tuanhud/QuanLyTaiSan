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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlPhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenthietbi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.subId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date_create = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date_modified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nhanvienpt_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlPhong);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(675, 469);
            this.splitContainerControl1.SplitterPosition = 283;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlPhong
            // 
            this.gridControlPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPhong.Location = new System.Drawing.Point(0, 0);
            this.gridControlPhong.MainView = this.gridViewPhong;
            this.gridControlPhong.Name = "gridControlPhong";
            this.gridControlPhong.Size = new System.Drawing.Size(387, 469);
            this.gridControlPhong.TabIndex = 0;
            this.gridControlPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhong});
            // 
            // gridViewPhong
            // 
            this.gridViewPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.subId,
            this.ten,
            this.mota,
            this.date_create,
            this.date_modified,
            this.nhanvienpt_id,
            this.id});
            this.gridViewPhong.GridControl = this.gridControlPhong;
            this.gridViewPhong.Name = "gridViewPhong";
            this.gridViewPhong.OptionsBehavior.Editable = false;
            this.gridViewPhong.OptionsBehavior.ReadOnly = true;
            this.gridViewPhong.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewPhong.OptionsFind.AlwaysVisible = true;
            this.gridViewPhong.OptionsView.ShowGroupPanel = false;
            this.gridViewPhong.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridViewThietBi_MasterRowExpanded);
            this.gridViewPhong.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewThietBi_FocusedRowChanged);
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Số lượng";
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Width = 202;
            // 
            // coltinhtrang
            // 
            this.coltinhtrang.Caption = "Tình trạng";
            this.coltinhtrang.FieldName = "tinhtrang";
            this.coltinhtrang.Name = "coltinhtrang";
            this.coltinhtrang.Width = 293;
            // 
            // coltenthietbi
            // 
            this.coltenthietbi.Caption = "Tên thiết bị";
            this.coltenthietbi.FieldName = "ten";
            this.coltenthietbi.Name = "coltenthietbi";
            this.coltenthietbi.Width = 432;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            // 
            // subId
            // 
            this.subId.Caption = "Mã phòng";
            this.subId.FieldName = "subId";
            this.subId.Name = "subId";
            this.subId.Visible = true;
            this.subId.VisibleIndex = 0;
            // 
            // ten
            // 
            this.ten.Caption = "Tên phòng";
            this.ten.FieldName = "ten";
            this.ten.Name = "ten";
            this.ten.Visible = true;
            this.ten.VisibleIndex = 1;
            // 
            // mota
            // 
            this.mota.Caption = "Mô tả";
            this.mota.FieldName = "mota";
            this.mota.Name = "mota";
            this.mota.Visible = true;
            this.mota.VisibleIndex = 2;
            // 
            // date_create
            // 
            this.date_create.Caption = "Ngày tạo";
            this.date_create.FieldName = "date_create";
            this.date_create.Name = "date_create";
            this.date_create.Visible = true;
            this.date_create.VisibleIndex = 3;
            // 
            // date_modified
            // 
            this.date_modified.Caption = "Ngày cập nhật";
            this.date_modified.FieldName = "date_modified";
            this.date_modified.Name = "date_modified";
            this.date_modified.Visible = true;
            this.date_modified.VisibleIndex = 4;
            // 
            // nhanvienpt_id
            // 
            this.nhanvienpt_id.Caption = "Nhân viên phụ trách";
            this.nhanvienpt_id.FieldName = "nhanvienpt.hoten";
            this.nhanvienpt_id.Name = "nhanvienpt_id";
            this.nhanvienpt_id.Visible = true;
            this.nhanvienpt_id.VisibleIndex = 5;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn coltinhtrang;
        private DevExpress.XtraGrid.Columns.GridColumn coltenthietbi;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn subId;
        private DevExpress.XtraGrid.Columns.GridColumn ten;
        private DevExpress.XtraGrid.Columns.GridColumn mota;
        private DevExpress.XtraGrid.Columns.GridColumn date_create;
        private DevExpress.XtraGrid.Columns.GridColumn date_modified;
        private DevExpress.XtraGrid.Columns.GridColumn nhanvienpt_id;
        private DevExpress.XtraGrid.Columns.GridColumn id;
    }
}
