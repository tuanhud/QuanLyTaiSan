namespace TSCD_GUI.Settings
{
    partial class ucCauHinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCauHinh));
            this.simpleButton_Import = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Export = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.viewCauHinhLocal1 = new SHARED.Views.viewCauHinhLocal();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton_Import
            // 
            this.simpleButton_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_Import.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Import.Image")));
            this.simpleButton_Import.Location = new System.Drawing.Point(9, 27);
            this.simpleButton_Import.Name = "simpleButton_Import";
            this.simpleButton_Import.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Import.TabIndex = 32;
            this.simpleButton_Import.Text = "Import";
            this.simpleButton_Import.Click += new System.EventHandler(this.simpleButton_Import_Click);
            // 
            // simpleButton_Export
            // 
            this.simpleButton_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_Export.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Export.Image")));
            this.simpleButton_Export.Location = new System.Drawing.Point(9, 56);
            this.simpleButton_Export.Name = "simpleButton_Export";
            this.simpleButton_Export.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Export.TabIndex = 33;
            this.simpleButton_Export.Text = "Export";
            this.simpleButton_Export.Click += new System.EventHandler(this.simpleButton_Export_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(859, 452);
            this.xtraTabControl1.TabIndex = 132;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.viewCauHinhLocal1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(853, 424);
            this.xtraTabPage1.Text = "Cấu hình cục bộ (Local)";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton_Import);
            this.panelControl1.Controls.Add(this.simpleButton_Export);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(859, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(91, 452);
            this.panelControl1.TabIndex = 133;
            // 
            // viewCauHinhLocal1
            // 
            this.viewCauHinhLocal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewCauHinhLocal1.Location = new System.Drawing.Point(0, 0);
            this.viewCauHinhLocal1.Name = "viewCauHinhLocal1";
            this.viewCauHinhLocal1.Size = new System.Drawing.Size(853, 424);
            this.viewCauHinhLocal1.TabIndex = 0;
            // 
            // ucCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(600, 411);
            this.Name = "ucCauHinh";
            this.Size = new System.Drawing.Size(950, 452);
            this.Load += new System.EventHandler(this.ucCauHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_Export;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Import;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private SHARED.Views.viewCauHinhLocal viewCauHinhLocal1;
    }
}
