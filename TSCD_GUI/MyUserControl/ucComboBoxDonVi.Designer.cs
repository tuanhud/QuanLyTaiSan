namespace TSCD_GUI.MyUserControl
{
    partial class ucComboBoxDonVi
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
            this.treeListLookUpDonVi = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpDonViTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpDonViTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListLookUpDonVi
            // 
            this.treeListLookUpDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLookUpDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpDonVi.Name = "treeListLookUpDonVi";
            this.treeListLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treeListLookUpDonVi.Properties.DisplayMember = "ten";
            this.treeListLookUpDonVi.Properties.NullText = "";
            this.treeListLookUpDonVi.Properties.TreeList = this.treeListLookUpDonViTreeList;
            this.treeListLookUpDonVi.Properties.ValueMember = "id";
            this.treeListLookUpDonVi.Size = new System.Drawing.Size(200, 20);
            this.treeListLookUpDonVi.TabIndex = 0;
            this.treeListLookUpDonVi.EditValueChanged += new System.EventHandler(this.treeListLookUpDonVi_EditValueChanged);
            // 
            // treeListLookUpDonViTreeList
            // 
            this.treeListLookUpDonViTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai});
            this.treeListLookUpDonViTreeList.KeyFieldName = "id";
            this.treeListLookUpDonViTreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpDonViTreeList.Name = "treeListLookUpDonViTreeList";
            this.treeListLookUpDonViTreeList.OptionsBehavior.Editable = false;
            this.treeListLookUpDonViTreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpDonViTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLookUpDonViTreeList.OptionsView.ShowAutoFilterRow = true;
            this.treeListLookUpDonViTreeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListLookUpDonViTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpDonViTreeList.ParentFieldName = "parent_id";
            this.treeListLookUpDonViTreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpDonViTreeList.TabIndex = 0;
            this.treeListLookUpDonViTreeList.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Đơn vị";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.OptionsColumn.ReadOnly = true;
            this.colten.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "Loại đơn vị";
            this.colloai.FieldName = "loaidonvi.ten";
            this.colloai.Name = "colloai";
            this.colloai.OptionsColumn.ReadOnly = true;
            this.colloai.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colloai.Visible = true;
            this.colloai.VisibleIndex = 1;
            // 
            // ucComboBoxDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListLookUpDonVi);
            this.Name = "ucComboBoxDonVi";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpDonViTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpDonVi;
        private DevExpress.XtraTreeList.TreeList treeListLookUpDonViTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;

    }
}
