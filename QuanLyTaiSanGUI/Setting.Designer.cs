namespace PTB_GUI
{
    partial class Setting
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.panelControlHienThiCauHinh = new DevExpress.XtraEditors.PanelControl();
            this.ucCauHinh1 = new PTB_GUI.Settings.ucCauHinh();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHienThiCauHinh)).BeginInit();
            this.panelControlHienThiCauHinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControlHienThiCauHinh
            // 
            this.panelControlHienThiCauHinh.Controls.Add(this.ucCauHinh1);
            this.panelControlHienThiCauHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlHienThiCauHinh.Location = new System.Drawing.Point(0, 0);
            this.panelControlHienThiCauHinh.Name = "panelControlHienThiCauHinh";
            this.panelControlHienThiCauHinh.Size = new System.Drawing.Size(940, 401);
            this.panelControlHienThiCauHinh.TabIndex = 0;
            // 
            // ucCauHinh1
            // 
            this.ucCauHinh1.AutoSize = true;
            this.ucCauHinh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCauHinh1.Location = new System.Drawing.Point(2, 2);
            this.ucCauHinh1.MinimumSize = new System.Drawing.Size(600, 411);
            this.ucCauHinh1.Name = "ucCauHinh1";
            this.ucCauHinh1.Size = new System.Drawing.Size(936, 411);
            this.ucCauHinh1.TabIndex = 0;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 401);
            this.Controls.Add(this.panelControlHienThiCauHinh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt cấu hình";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHienThiCauHinh)).EndInit();
            this.panelControlHienThiCauHinh.ResumeLayout(false);
            this.panelControlHienThiCauHinh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlHienThiCauHinh;
        private Settings.ucCauHinh ucCauHinh1;
    }
}