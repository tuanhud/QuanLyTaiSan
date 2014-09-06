namespace TSCD_GUI.MyUserControl
{
    partial class ucComboBoxLoaiTS
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
            this.treeListLookUpLoaiTS = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpLoaiTSTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldonvitinh = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpLoaiTS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpLoaiTSTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListLookUpLoaiTS
            // 
            this.treeListLookUpLoaiTS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLookUpLoaiTS.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpLoaiTS.Name = "treeListLookUpLoaiTS";
            this.treeListLookUpLoaiTS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treeListLookUpLoaiTS.Properties.DisplayMember = "ten";
            this.treeListLookUpLoaiTS.Properties.TreeList = this.treeListLookUpLoaiTSTreeList;
            this.treeListLookUpLoaiTS.Properties.ValueMember = "id";
            this.treeListLookUpLoaiTS.Size = new System.Drawing.Size(200, 20);
            this.treeListLookUpLoaiTS.TabIndex = 0;
            // 
            // treeListLookUpLoaiTSTreeList
            // 
            this.treeListLookUpLoaiTSTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.coldonvitinh});
            this.treeListLookUpLoaiTSTreeList.KeyFieldName = "id";
            this.treeListLookUpLoaiTSTreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpLoaiTSTreeList.Name = "treeListLookUpLoaiTSTreeList";
            this.treeListLookUpLoaiTSTreeList.OptionsBehavior.Editable = false;
            this.treeListLookUpLoaiTSTreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpLoaiTSTreeList.OptionsBehavior.ReadOnly = true;
            this.treeListLookUpLoaiTSTreeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeListLookUpLoaiTSTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLookUpLoaiTSTreeList.OptionsView.ShowAutoFilterRow = true;
            this.treeListLookUpLoaiTSTreeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListLookUpLoaiTSTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpLoaiTSTreeList.ParentFieldName = "parent_id";
            this.treeListLookUpLoaiTSTreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpLoaiTSTreeList.TabIndex = 0;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Loại tài sản";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.OptionsColumn.ReadOnly = true;
            this.colten.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // coldonvitinh
            // 
            this.coldonvitinh.Caption = "donvitinh";
            this.coldonvitinh.FieldName = "donvitinh.ten";
            this.coldonvitinh.Name = "coldonvitinh";
            this.coldonvitinh.OptionsColumn.ReadOnly = true;
            this.coldonvitinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.coldonvitinh.Visible = true;
            this.coldonvitinh.VisibleIndex = 1;
            // 
            // ucComboBoxLoaiTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListLookUpLoaiTS);
            this.Name = "ucComboBoxLoaiTS";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpLoaiTS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpLoaiTSTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpLoaiTS;
        private DevExpress.XtraTreeList.TreeList treeListLookUpLoaiTSTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldonvitinh;
    }
}
