namespace TSCD_GUI.ThongKe
{
    partial class ucTKPhong
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
            this.gridControlPhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsochongoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcoso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlThongKe = new DevExpress.XtraEditors.GroupControl();
            this.btnThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.checkedComboBoxLoaiPhong = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.checkedComboBoxCoSo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblLoaiPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblCoSo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongKe)).BeginInit();
            this.groupControlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxLoaiPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxCoSo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlPhong);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlThongKe);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(813, 517);
            this.splitContainerControlMain.SplitterPosition = 268;
            this.splitContainerControlMain.TabIndex = 0;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlPhong
            // 
            this.gridControlPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPhong.Location = new System.Drawing.Point(0, 0);
            this.gridControlPhong.MainView = this.gridViewPhong;
            this.gridControlPhong.Name = "gridControlPhong";
            this.gridControlPhong.Size = new System.Drawing.Size(540, 517);
            this.gridControlPhong.TabIndex = 0;
            this.gridControlPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhong});
            // 
            // gridViewPhong
            // 
            this.gridViewPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colphong,
            this.colloai,
            this.colsochongoi,
            this.colcoso,
            this.colday,
            this.coltang});
            this.gridViewPhong.GridControl = this.gridControlPhong;
            this.gridViewPhong.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "phong", null, "({0} phòng)")});
            this.gridViewPhong.Name = "gridViewPhong";
            this.gridViewPhong.OptionsBehavior.Editable = false;
            this.gridViewPhong.OptionsBehavior.ReadOnly = true;
            this.gridViewPhong.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colphong
            // 
            this.colphong.Caption = "Phòng";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            this.colphong.Visible = true;
            this.colphong.VisibleIndex = 0;
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
            this.colsochongoi.Visible = true;
            this.colsochongoi.VisibleIndex = 2;
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
            // groupControlThongKe
            // 
            this.groupControlThongKe.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlThongKe.AppearanceCaption.Options.UseFont = true;
            this.groupControlThongKe.Controls.Add(this.btnThongKe);
            this.groupControlThongKe.Controls.Add(this.checkedComboBoxLoaiPhong);
            this.groupControlThongKe.Controls.Add(this.checkedComboBoxCoSo);
            this.groupControlThongKe.Controls.Add(this.lblLoaiPhong);
            this.groupControlThongKe.Controls.Add(this.lblCoSo);
            this.groupControlThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.groupControlThongKe.Name = "groupControlThongKe";
            this.groupControlThongKe.Size = new System.Drawing.Size(268, 517);
            this.groupControlThongKe.TabIndex = 0;
            this.groupControlThongKe.Text = "Thống kê";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Location = new System.Drawing.Point(91, 81);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // checkedComboBoxLoaiPhong
            // 
            this.checkedComboBoxLoaiPhong.Location = new System.Drawing.Point(68, 54);
            this.checkedComboBoxLoaiPhong.Name = "checkedComboBoxLoaiPhong";
            this.checkedComboBoxLoaiPhong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxLoaiPhong.Properties.DisplayMember = "ten";
            this.checkedComboBoxLoaiPhong.Properties.ValueMember = "id";
            this.checkedComboBoxLoaiPhong.Size = new System.Drawing.Size(181, 20);
            this.checkedComboBoxLoaiPhong.TabIndex = 5;
            // 
            // checkedComboBoxCoSo
            // 
            this.checkedComboBoxCoSo.Location = new System.Drawing.Point(68, 28);
            this.checkedComboBoxCoSo.Name = "checkedComboBoxCoSo";
            this.checkedComboBoxCoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxCoSo.Properties.DisplayMember = "ten";
            this.checkedComboBoxCoSo.Properties.ValueMember = "id";
            this.checkedComboBoxCoSo.Size = new System.Drawing.Size(181, 20);
            this.checkedComboBoxCoSo.TabIndex = 4;
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Location = new System.Drawing.Point(6, 57);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(56, 13);
            this.lblLoaiPhong.TabIndex = 3;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblCoSo
            // 
            this.lblCoSo.Location = new System.Drawing.Point(6, 30);
            this.lblCoSo.Name = "lblCoSo";
            this.lblCoSo.Size = new System.Drawing.Size(31, 13);
            this.lblCoSo.TabIndex = 2;
            this.lblCoSo.Text = "Cơ sở:";
            // 
            // ucTKPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "ucTKPhong";
            this.Size = new System.Drawing.Size(813, 517);
            this.Leave += new System.EventHandler(this.ucTKPhong_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongKe)).EndInit();
            this.groupControlThongKe.ResumeLayout(false);
            this.groupControlThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxLoaiPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxCoSo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhong;
        private DevExpress.XtraEditors.GroupControl groupControlThongKe;
        private DevExpress.XtraEditors.SimpleButton btnThongKe;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxLoaiPhong;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxCoSo;
        private DevExpress.XtraEditors.LabelControl lblLoaiPhong;
        private DevExpress.XtraEditors.LabelControl lblCoSo;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colphong;
        private DevExpress.XtraGrid.Columns.GridColumn colloai;
        private DevExpress.XtraGrid.Columns.GridColumn colsochongoi;
        private DevExpress.XtraGrid.Columns.GridColumn colcoso;
        private DevExpress.XtraGrid.Columns.GridColumn colday;
        private DevExpress.XtraGrid.Columns.GridColumn coltang;
    }
}
