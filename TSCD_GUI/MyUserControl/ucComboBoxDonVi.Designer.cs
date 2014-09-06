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
            this.popupContainerEditDonVi = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControlDonVi = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListDonVi = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryLookUpLoai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlDonVi)).BeginInit();
            this.popupContainerControlDonVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLookUpLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEditDonVi
            // 
            this.popupContainerEditDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEditDonVi.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEditDonVi.Name = "popupContainerEditDonVi";
            this.popupContainerEditDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEditDonVi.Properties.PopupControl = this.popupContainerControlDonVi;
            this.popupContainerEditDonVi.Size = new System.Drawing.Size(200, 20);
            this.popupContainerEditDonVi.TabIndex = 0;
            // 
            // popupContainerControlDonVi
            // 
            this.popupContainerControlDonVi.Controls.Add(this.treeListDonVi);
            this.popupContainerControlDonVi.Location = new System.Drawing.Point(59, 59);
            this.popupContainerControlDonVi.Name = "popupContainerControlDonVi";
            this.popupContainerControlDonVi.Size = new System.Drawing.Size(250, 400);
            this.popupContainerControlDonVi.TabIndex = 1;
            // 
            // treeListDonVi
            // 
            this.treeListDonVi.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai});
            this.treeListDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDonVi.KeyFieldName = "id";
            this.treeListDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListDonVi.Name = "treeListDonVi";
            this.treeListDonVi.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeListDonVi.OptionsBehavior.Editable = false;
            this.treeListDonVi.OptionsBehavior.EnableFiltering = true;
            this.treeListDonVi.OptionsFind.AllowFindPanel = true;
            this.treeListDonVi.OptionsFind.AlwaysVisible = true;
            this.treeListDonVi.OptionsFind.ShowFindButton = false;
            this.treeListDonVi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListDonVi.ParentFieldName = "parent_id";
            this.treeListDonVi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryLookUpLoai});
            this.treeListDonVi.Size = new System.Drawing.Size(250, 400);
            this.treeListDonVi.TabIndex = 0;
            this.treeListDonVi.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListDonVi_FocusedNodeChanged);
            this.treeListDonVi.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Tên đơn vị";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "Loại đơn vị";
            this.colloai.ColumnEdit = this.repositoryLookUpLoai;
            this.colloai.FieldName = "loaidonvi_id";
            this.colloai.Name = "colloai";
            this.colloai.Visible = true;
            this.colloai.VisibleIndex = 1;
            // 
            // repositoryLookUpLoai
            // 
            this.repositoryLookUpLoai.AutoHeight = false;
            this.repositoryLookUpLoai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryLookUpLoai.DisplayMember = "ten";
            this.repositoryLookUpLoai.Name = "repositoryLookUpLoai";
            this.repositoryLookUpLoai.ReadOnly = true;
            this.repositoryLookUpLoai.ValueMember = "id";
            // 
            // ucComboBoxDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControlDonVi);
            this.Controls.Add(this.popupContainerEditDonVi);
            this.Name = "ucComboBoxDonVi";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlDonVi)).EndInit();
            this.popupContainerControlDonVi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLookUpLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEditDonVi;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControlDonVi;
        private DevExpress.XtraTreeList.TreeList treeListDonVi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryLookUpLoai;
    }
}
