namespace QuanLyTaiSanGUI.MyUC
{
    partial class ucTreeListLookUpViTri
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
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTriTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListLookUpViTri
            // 
            this.treeListLookUpViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLookUpViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpViTri.Name = "treeListLookUpViTri";
            this.treeListLookUpViTri.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeListLookUpViTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treeListLookUpViTri.Properties.TreeList = this.treeListLookUpViTriTreeList;
            this.treeListLookUpViTri.Properties.ValueMember = "id";
            this.treeListLookUpViTri.Size = new System.Drawing.Size(200, 18);
            this.treeListLookUpViTri.TabIndex = 0;
            this.treeListLookUpViTri.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.treeListLookUpViTri_CustomDisplayText);
            // 
            // treeListLookUpViTriTreeList
            // 
            this.treeListLookUpViTriTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colten,
            this.colloai});
            this.treeListLookUpViTriTreeList.KeyFieldName = "id";
            this.treeListLookUpViTriTreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpViTriTreeList.Name = "treeListLookUpViTriTreeList";
            this.treeListLookUpViTriTreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpViTriTreeList.OptionsFind.AllowFindPanel = true;
            this.treeListLookUpViTriTreeList.OptionsFind.AlwaysVisible = true;
            this.treeListLookUpViTriTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLookUpViTriTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpViTriTreeList.ParentFieldName = "parent_id";
            this.treeListLookUpViTriTreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpViTriTreeList.TabIndex = 0;
            this.treeListLookUpViTriTreeList.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colten
            // 
            this.colten.Caption = "Vị trí";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // ucTreeListLookUpViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListLookUpViTri);
            this.Name = "ucTreeListLookUpViTri";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpViTriTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpViTri;
        private DevExpress.XtraTreeList.TreeList treeListLookUpViTriTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
    }
}
