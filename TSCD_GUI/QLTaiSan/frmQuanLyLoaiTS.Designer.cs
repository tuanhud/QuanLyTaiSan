namespace TSCD_GUI.QLTaiSan
{
    partial class frmQuanLyLoaiTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyLoaiTS));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.ucQuanLyLoaiTS1 = new TSCD_GUI.QLLoaiTaiSan.ucQuanLyLoaiTS();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(669, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucQuanLyLoaiTS1
            // 
            this.ucQuanLyLoaiTS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQuanLyLoaiTS1.Location = new System.Drawing.Point(0, 0);
            this.ucQuanLyLoaiTS1.Name = "ucQuanLyLoaiTS1";
            this.ucQuanLyLoaiTS1.Size = new System.Drawing.Size(756, 454);
            this.ucQuanLyLoaiTS1.TabIndex = 0;
            // 
            // frmQuanLyLoaiTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 454);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucQuanLyLoaiTS1);
            this.Name = "frmQuanLyLoaiTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý loại tài sản";
            this.ResumeLayout(false);

        }

        #endregion

        private QLLoaiTaiSan.ucQuanLyLoaiTS ucQuanLyLoaiTS1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}