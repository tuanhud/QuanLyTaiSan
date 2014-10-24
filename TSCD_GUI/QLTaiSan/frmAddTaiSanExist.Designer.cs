namespace TSCD_GUI.QLTaiSan
{
    partial class frmAddTaiSanExist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTaiSanExist));
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.ucQuanLyTaiSan1 = new TSCD_GUI.QLTaiSan.ucQuanLyTaiSan();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(690, 441);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(771, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucQuanLyTaiSan1
            // 
            this.ucQuanLyTaiSan1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucQuanLyTaiSan1.Location = new System.Drawing.Point(0, 0);
            this.ucQuanLyTaiSan1.Name = "ucQuanLyTaiSan1";
            this.ucQuanLyTaiSan1.Size = new System.Drawing.Size(858, 435);
            this.ucQuanLyTaiSan1.TabIndex = 0;
            // 
            // frmAddTaiSanExist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 476);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ucQuanLyTaiSan1);
            this.MinimumSize = new System.Drawing.Size(874, 514);
            this.Name = "frmAddTaiSanExist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm tài sản vào đơn vị";
            this.ResumeLayout(false);

        }

        #endregion

        private ucQuanLyTaiSan ucQuanLyTaiSan1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}