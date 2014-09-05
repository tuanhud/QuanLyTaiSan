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
            this.popupContainerEditViTri = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControlVitri = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListViTri = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloaiphong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colphong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlVitri)).BeginInit();
            this.popupContainerControlVitri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEditViTri
            // 
            this.popupContainerEditViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEditViTri.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEditViTri.Name = "popupContainerEditViTri";
            this.popupContainerEditViTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEditViTri.Properties.PopupControl = this.popupContainerControlVitri;
            this.popupContainerEditViTri.Size = new System.Drawing.Size(200, 20);
            this.popupContainerEditViTri.TabIndex = 0;
            // 
            // popupContainerControlVitri
            // 
            this.popupContainerControlVitri.Controls.Add(this.treeListViTri);
            this.popupContainerControlVitri.Location = new System.Drawing.Point(3, 26);
            this.popupContainerControlVitri.Name = "popupContainerControlVitri";
            this.popupContainerControlVitri.Size = new System.Drawing.Size(376, 187);
            this.popupContainerControlVitri.TabIndex = 1;
            // 
            // treeListViTri
            // 
            this.treeListViTri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai,
            this.colloaiphong,
            this.colphong});
            this.treeListViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListViTri.Name = "treeListViTri";
            this.treeListViTri.Size = new System.Drawing.Size(376, 187);
            this.treeListViTri.TabIndex = 0;
            this.treeListViTri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListViTri_FocusedNodeChanged);
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
            this.colten.FieldName = "Vị trí";
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
            // colloaiphong
            // 
            this.colloaiphong.Caption = "loaiphong";
            this.colloaiphong.FieldName = "loaiphong";
            this.colloaiphong.Name = "colloaiphong";
            // 
            // colphong
            // 
            this.colphong.Caption = "phong";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            // 
            // ucComboBoxViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControlVitri);
            this.Controls.Add(this.popupContainerEditViTri);
            this.Name = "ucComboBoxViTri";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditViTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlVitri)).EndInit();
            this.popupContainerControlVitri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEditViTri;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControlVitri;
        private DevExpress.XtraTreeList.TreeList treeListViTri;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloaiphong;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colphong;
    }
}
