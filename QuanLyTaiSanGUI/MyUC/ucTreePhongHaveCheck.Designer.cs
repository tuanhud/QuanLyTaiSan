namespace PTB_GUI.MyUC
{
    partial class ucTreePhongHaveCheck
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
            this.treeListPhong = new DevExpress.XtraTreeList.TreeList();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colphong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // treeListPhong
            // 
            this.treeListPhong.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai,
            this.colphong});
            this.treeListPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colloai;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "Phong";
            this.treeListPhong.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.treeListPhong.KeyFieldName = "id";
            this.treeListPhong.Location = new System.Drawing.Point(0, 0);
            this.treeListPhong.Name = "treeListPhong";
            this.treeListPhong.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeListPhong.OptionsBehavior.Editable = false;
            this.treeListPhong.OptionsBehavior.EnableFiltering = true;
            this.treeListPhong.OptionsFind.AllowFindPanel = true;
            this.treeListPhong.OptionsFind.AlwaysVisible = true;
            this.treeListPhong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListPhong.OptionsView.ShowCheckBoxes = true;
            this.treeListPhong.ParentFieldName = "parent_id";
            this.treeListPhong.Size = new System.Drawing.Size(407, 375);
            this.treeListPhong.TabIndex = 0;
            this.treeListPhong.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeListPhong_AfterCheckNode);
            this.treeListPhong.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colten
            // 
            this.colten.Caption = "Phòng";
            this.colten.FieldName = "ten";
            this.colten.MinWidth = 32;
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colphong
            // 
            this.colphong.Caption = "phong";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // ucTreePhongHaveCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListPhong);
            this.Name = "ucTreePhongHaveCheck";
            this.Size = new System.Drawing.Size(407, 375);
            ((System.ComponentModel.ISupportInitialize)(this.treeListPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListPhong;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colphong;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
    }
}
