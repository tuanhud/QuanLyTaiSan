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
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlDonVi)).BeginInit();
            this.popupContainerControlDonVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEditDonVi
            // 
            this.popupContainerEditDonVi.Location = new System.Drawing.Point(15, 14);
            this.popupContainerEditDonVi.Name = "popupContainerEditDonVi";
            this.popupContainerEditDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEditDonVi.Size = new System.Drawing.Size(100, 20);
            this.popupContainerEditDonVi.TabIndex = 0;
            // 
            // popupContainerControlDonVi
            // 
            this.popupContainerControlDonVi.Controls.Add(this.treeListDonVi);
            this.popupContainerControlDonVi.Location = new System.Drawing.Point(59, 59);
            this.popupContainerControlDonVi.Name = "popupContainerControlDonVi";
            this.popupContainerControlDonVi.Size = new System.Drawing.Size(352, 224);
            this.popupContainerControlDonVi.TabIndex = 1;
            // 
            // treeListDonVi
            // 
            this.treeListDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListDonVi.Name = "treeListDonVi";
            this.treeListDonVi.Size = new System.Drawing.Size(352, 224);
            this.treeListDonVi.TabIndex = 0;
            // 
            // ucComboBoxDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControlDonVi);
            this.Controls.Add(this.popupContainerEditDonVi);
            this.Name = "ucComboBoxDonVi";
            this.Size = new System.Drawing.Size(539, 315);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEditDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlDonVi)).EndInit();
            this.popupContainerControlDonVi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEditDonVi;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControlDonVi;
        private DevExpress.XtraTreeList.TreeList treeListDonVi;
    }
}
