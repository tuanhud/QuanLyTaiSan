namespace QuanLyTaiSanGUI.HeThong
{
    partial class frmGeneralSetting
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.imageListBoxControl_left = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panelControl_commit = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraScrollableControl_view = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_commit)).BeginInit();
            this.panelControl_commit.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.imageListBoxControl_left);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraScrollableControl_view);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl_commit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(894, 359);
            this.splitContainerControl1.SplitterPosition = 195;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // imageListBoxControl_left
            // 
            this.imageListBoxControl_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxControl_left.Location = new System.Drawing.Point(0, 0);
            this.imageListBoxControl_left.Name = "imageListBoxControl_left";
            this.imageListBoxControl_left.Size = new System.Drawing.Size(195, 359);
            this.imageListBoxControl_left.TabIndex = 0;
            this.imageListBoxControl_left.SelectedIndexChanged += new System.EventHandler(this.imageListBoxControl_left_SelectedIndexChanged);
            // 
            // panelControl_commit
            // 
            this.panelControl_commit.Controls.Add(this.simpleButton2);
            this.panelControl_commit.Controls.Add(this.simpleButton1);
            this.panelControl_commit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_commit.Location = new System.Drawing.Point(0, 316);
            this.panelControl_commit.Name = "panelControl_commit";
            this.panelControl_commit.Size = new System.Drawing.Size(694, 43);
            this.panelControl_commit.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(504, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 32);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(601, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 33);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // xtraScrollableControl_view
            // 
            this.xtraScrollableControl_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl_view.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl_view.Name = "xtraScrollableControl_view";
            this.xtraScrollableControl_view.Size = new System.Drawing.Size(694, 316);
            this.xtraScrollableControl_view.TabIndex = 1;
            // 
            // frmGeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 359);
            this.Controls.Add(this.splitContainerControl1);
            this.MinimumSize = new System.Drawing.Size(910, 390);
            this.Name = "frmGeneralSetting";
            this.Text = "GeneralSettingFrm";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_commit)).EndInit();
            this.panelControl_commit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ImageListBoxControl imageListBoxControl_left;
        private DevExpress.XtraEditors.PanelControl panelControl_commit;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl_view;
    }
}