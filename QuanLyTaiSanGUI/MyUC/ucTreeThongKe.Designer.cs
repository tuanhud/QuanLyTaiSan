namespace PTB_GUI.MyUC
{
    partial class ucTreeThongKe
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
            this.treeListThongKe = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeListThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListThongKe
            // 
            this.treeListThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListThongKe.Location = new System.Drawing.Point(0, 0);
            this.treeListThongKe.Name = "treeListThongKe";
            this.treeListThongKe.Size = new System.Drawing.Size(276, 373);
            this.treeListThongKe.TabIndex = 0;
            this.treeListThongKe.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListThongKe_FocusedNodeChanged);
            // 
            // ucTreeThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListThongKe);
            this.Name = "ucTreeThongKe";
            this.Size = new System.Drawing.Size(276, 373);
            ((System.ComponentModel.ISupportInitialize)(this.treeListThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListThongKe;

    }
}
