namespace QuanLyTaiSanGUI.MyUC
{
    partial class ucTreePhong
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
            this.treeListPhong = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeListPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListPhong
            // 
            this.treeListPhong.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeListPhong.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListPhong.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai});
            this.treeListPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListPhong.KeyFieldName = "id_c";
            this.treeListPhong.Location = new System.Drawing.Point(0, 0);
            this.treeListPhong.Name = "treeListPhong";
            this.treeListPhong.OptionsBehavior.Editable = false;
            this.treeListPhong.ParentFieldName = "id_p";
            this.treeListPhong.Size = new System.Drawing.Size(276, 373);
            this.treeListPhong.TabIndex = 0;
            this.treeListPhong.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListPhong_FocusedNodeChanged);
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
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // ucTreePhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListPhong);
            this.Name = "ucTreePhong";
            this.Size = new System.Drawing.Size(276, 373);
            ((System.ComponentModel.ISupportInitialize)(this.treeListPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        public DevExpress.XtraTreeList.TreeList treeListPhong;
    }
}
