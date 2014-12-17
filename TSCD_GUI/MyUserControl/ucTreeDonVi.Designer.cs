namespace TSCD_GUI.MyUserControl
{
    partial class ucTreeDonVi
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
            this.treeListDonVi = new DevExpress.XtraTreeList.TreeList();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListDonVi
            // 
            this.treeListDonVi.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colten,
            this.colloai,
            this.colid});
            this.treeListDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDonVi.KeyFieldName = "id";
            this.treeListDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListDonVi.Name = "treeListDonVi";
            this.treeListDonVi.OptionsBehavior.Editable = false;
            this.treeListDonVi.OptionsBehavior.EnableFiltering = true;
            this.treeListDonVi.OptionsFind.AllowFindPanel = true;
            this.treeListDonVi.OptionsFind.AlwaysVisible = true;
            this.treeListDonVi.OptionsFind.HighlightFindResults = false;
            this.treeListDonVi.OptionsFind.ShowClearButton = false;
            this.treeListDonVi.OptionsFind.ShowFindButton = false;
            this.treeListDonVi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListDonVi.ParentFieldName = "parent_id";
            this.treeListDonVi.Size = new System.Drawing.Size(289, 450);
            this.treeListDonVi.TabIndex = 0;
            this.treeListDonVi.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListDonVi_FocusedNodeChanged);
            this.treeListDonVi.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colten
            // 
            this.colten.Caption = "Đơn vị";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            this.colten.Width = 181;
            // 
            // colloai
            // 
            this.colloai.Caption = "Loại đơn vị";
            this.colloai.FieldName = "loaidonvi";
            this.colloai.Name = "colloai";
            this.colloai.Visible = true;
            this.colloai.VisibleIndex = 1;
            this.colloai.Width = 90;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // ucTreeDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListDonVi);
            this.Name = "ucTreeDonVi";
            this.Size = new System.Drawing.Size(289, 450);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListDonVi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
    }
}
