namespace QuanLyTaiSanGUI.MyUC
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
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListViTri = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            this.SuspendLayout();
            // 
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // treeListViTri
            // 
            this.treeListViTri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai});
            this.treeListViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colloai;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "Phong";
            this.treeListViTri.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.treeListViTri.KeyFieldName = "id_c";
            this.treeListViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListViTri.Name = "treeListViTri";
            this.treeListViTri.OptionsBehavior.Editable = false;
            this.treeListViTri.OptionsBehavior.EnableFiltering = true;
            this.treeListViTri.OptionsFind.AllowFindPanel = true;
            this.treeListViTri.OptionsFind.AlwaysVisible = true;
            this.treeListViTri.OptionsFind.ShowCloseButton = false;
            this.treeListViTri.OptionsFind.ShowFindButton = false;
            this.treeListViTri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListViTri.ParentFieldName = "id_p";
            this.treeListViTri.Size = new System.Drawing.Size(276, 373);
            this.treeListViTri.TabIndex = 0;
            this.treeListViTri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListPhong_FocusedNodeChanged);
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
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // ucTreeViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListViTri);
            this.Name = "ucTreeViTri";
            this.Size = new System.Drawing.Size(276, 373);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraTreeList.TreeList treeListViTri;
    }
}
