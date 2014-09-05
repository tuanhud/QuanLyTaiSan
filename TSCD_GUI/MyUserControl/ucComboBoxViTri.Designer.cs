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
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditViTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlVitri)).BeginInit();
            this.popupContainerControlVitri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEditViTri
            // 
            this.popupContainerEditViTri.Location = new System.Drawing.Point(31, 33);
            this.popupContainerEditViTri.Name = "popupContainerEditViTri";
            this.popupContainerEditViTri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEditViTri.Properties.PopupControl = this.popupContainerControlVitri;
            this.popupContainerEditViTri.Size = new System.Drawing.Size(100, 20);
            this.popupContainerEditViTri.TabIndex = 0;
            // 
            // popupContainerControlVitri
            // 
            this.popupContainerControlVitri.Controls.Add(this.treeListViTri);
            this.popupContainerControlVitri.Location = new System.Drawing.Point(74, 106);
            this.popupContainerControlVitri.Name = "popupContainerControlVitri";
            this.popupContainerControlVitri.Size = new System.Drawing.Size(376, 187);
            this.popupContainerControlVitri.TabIndex = 1;
            // 
            // treeListViTri
            // 
            this.treeListViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListViTri.Name = "treeListViTri";
            this.treeListViTri.Size = new System.Drawing.Size(376, 187);
            this.treeListViTri.TabIndex = 0;
            // 
            // ucComboBoxViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControlVitri);
            this.Controls.Add(this.popupContainerEditViTri);
            this.Name = "ucComboBoxViTri";
            this.Size = new System.Drawing.Size(546, 366);
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
    }
}
