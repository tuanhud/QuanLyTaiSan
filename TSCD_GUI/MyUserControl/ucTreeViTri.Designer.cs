namespace TSCD_GUI.MyUserControl
{
    partial class ucTreeViTri
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
            this.treeListViTri = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListViTri
            // 
            this.treeListViTri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai});
            this.treeListViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViTri.KeyFieldName = "id";
            this.treeListViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListViTri.Name = "treeListViTri";
            this.treeListViTri.OptionsBehavior.Editable = false;
            this.treeListViTri.OptionsBehavior.EnableFiltering = true;
            this.treeListViTri.OptionsFind.AllowFindPanel = true;
            this.treeListViTri.OptionsFind.AlwaysVisible = true;
            this.treeListViTri.OptionsFind.HighlightFindResults = false;
            this.treeListViTri.OptionsFind.ShowFindButton = false;
            this.treeListViTri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListViTri.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.treeListViTri.ParentFieldName = "parent_id";
            this.treeListViTri.Size = new System.Drawing.Size(298, 408);
            this.treeListViTri.TabIndex = 0;
            this.treeListViTri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListViTri_FocusedNodeChanged);
            this.treeListViTri.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
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
            // ucTreeViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListViTri);
            this.Name = "ucTreeViTri";
            this.Size = new System.Drawing.Size(298, 408);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListViTri;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
    }
}
