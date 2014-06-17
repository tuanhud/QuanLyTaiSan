namespace QuanLyTaiSanGUI.MyUserControl
{
    partial class ucComboBoxPhong
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
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcoso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltang = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLookUpEdit1.Location = new System.Drawing.Point(0, 0);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.DisplayMember = "ten";
            this.searchLookUpEdit1.Properties.ValueMember = "id";
            this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(200, 20);
            this.searchLookUpEdit1.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colten,
            this.colcoso,
            this.colday,
            this.coltang});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.GroupCount = 3;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colcoso, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colday, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coltang, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            this.colid.Width = 83;
            // 
            // colten
            // 
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 1;
            // 
            // colcoso
            // 
            this.colcoso.Caption = "tencoso";
            this.colcoso.FieldName = "tencoso";
            this.colcoso.Name = "colcoso";
            this.colcoso.Visible = true;
            this.colcoso.VisibleIndex = 2;
            // 
            // colday
            // 
            this.colday.Caption = "tenday";
            this.colday.FieldName = "tenday";
            this.colday.Name = "colday";
            this.colday.Visible = true;
            this.colday.VisibleIndex = 2;
            // 
            // coltang
            // 
            this.coltang.Caption = "tentang";
            this.coltang.FieldName = "tentang";
            this.coltang.Name = "coltang";
            this.coltang.Visible = true;
            this.coltang.VisibleIndex = 2;
            // 
            // ucComboBoxPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchLookUpEdit1);
            this.Name = "ucComboBoxPhong";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colcoso;
        private DevExpress.XtraGrid.Columns.GridColumn colday;
        private DevExpress.XtraGrid.Columns.GridColumn coltang;
    }
}
