namespace TSCD_GUI.MyUserControl
{
    partial class ucComboBoxViTri
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
            this.treeListLookUpViTri = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpViTriTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colphong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloaiphong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTriTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListLookUpViTri
            // 
            this.treeListLookUpViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLookUpViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpViTri.Name = "treeListLookUpViTri";
            this.treeListLookUpViTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treeListLookUpViTri.Properties.NullText = "";
            this.treeListLookUpViTri.Properties.TreeList = this.treeListLookUpViTriTreeList;
            this.treeListLookUpViTri.Properties.ValueMember = "id";
            this.treeListLookUpViTri.Size = new System.Drawing.Size(200, 20);
            this.treeListLookUpViTri.TabIndex = 0;
            this.treeListLookUpViTri.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.treeListLookUpViTri_QueryCloseUp);
            this.treeListLookUpViTri.EditValueChanged += new System.EventHandler(this.treeListLookUpViTri_EditValueChanged);
            this.treeListLookUpViTri.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.treeListLookUpViTri_CustomDisplayText);
            // 
            // treeListLookUpViTriTreeList
            // 
            this.treeListLookUpViTriTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai,
            this.colphong,
            this.colloaiphong});
            this.treeListLookUpViTriTreeList.KeyFieldName = "id";
            this.treeListLookUpViTriTreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpViTriTreeList.Name = "treeListLookUpViTriTreeList";
            this.treeListLookUpViTriTreeList.OptionsBehavior.Editable = false;
            this.treeListLookUpViTriTreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpViTriTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLookUpViTriTreeList.OptionsView.ShowAutoFilterRow = true;
            this.treeListLookUpViTriTreeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListLookUpViTriTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpViTriTreeList.ParentFieldName = "parent_id";
            this.treeListLookUpViTriTreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpViTriTreeList.TabIndex = 0;
            this.treeListLookUpViTriTreeList.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Vị trí";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.OptionsColumn.ReadOnly = true;
            this.colten.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // colphong
            // 
            this.colphong.Caption = "phong";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            // 
            // colloaiphong
            // 
            this.colloaiphong.Caption = "Loại phòng";
            this.colloaiphong.FieldName = "loaiphong";
            this.colloaiphong.Name = "colloaiphong";
            // 
            // ucComboBoxViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListLookUpViTri);
            this.Name = "ucComboBoxViTri";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTriTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpViTri;
        private DevExpress.XtraTreeList.TreeList treeListLookUpViTriTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colphong;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloaiphong;

    }
}
