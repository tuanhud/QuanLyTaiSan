namespace QuanLyTaiSanGUI
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
            this.panelControlbtnCauHinh = new DevExpress.XtraEditors.PanelControl();
            this.btnThongTinPhanMem = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhatPhanMem = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiaoDienvaNgonNgu = new DevExpress.XtraEditors.SimpleButton();
            this.btnCauHinh = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlHienThiCauHinh = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlbtnCauHinh)).BeginInit();
            this.panelControlbtnCauHinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHienThiCauHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlbtnCauHinh
            // 
            this.panelControlbtnCauHinh.Controls.Add(this.btnCancel);
            this.panelControlbtnCauHinh.Controls.Add(this.btnThongTinPhanMem);
            this.panelControlbtnCauHinh.Controls.Add(this.btnSave);
            this.panelControlbtnCauHinh.Controls.Add(this.btnCapNhatPhanMem);
            this.panelControlbtnCauHinh.Controls.Add(this.btnGiaoDienvaNgonNgu);
            this.panelControlbtnCauHinh.Controls.Add(this.btnCauHinh);
            this.panelControlbtnCauHinh.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlbtnCauHinh.Location = new System.Drawing.Point(0, 0);
            this.panelControlbtnCauHinh.Name = "panelControlbtnCauHinh";
            this.panelControlbtnCauHinh.Size = new System.Drawing.Size(154, 422);
            this.panelControlbtnCauHinh.TabIndex = 0;
            // 
            // btnThongTinPhanMem
            // 
            this.btnThongTinPhanMem.Image = ((System.Drawing.Image)(resources.GetObject("btnThongTinPhanMem.Image")));
            this.btnThongTinPhanMem.Location = new System.Drawing.Point(5, 92);
            this.btnThongTinPhanMem.Name = "btnThongTinPhanMem";
            this.btnThongTinPhanMem.Size = new System.Drawing.Size(145, 23);
            this.btnThongTinPhanMem.TabIndex = 0;
            this.btnThongTinPhanMem.Text = "Thông tin phần mềm";
            // 
            // btnCapNhatPhanMem
            // 
            this.btnCapNhatPhanMem.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatPhanMem.Image")));
            this.btnCapNhatPhanMem.Location = new System.Drawing.Point(5, 63);
            this.btnCapNhatPhanMem.Name = "btnCapNhatPhanMem";
            this.btnCapNhatPhanMem.Size = new System.Drawing.Size(145, 23);
            this.btnCapNhatPhanMem.TabIndex = 0;
            this.btnCapNhatPhanMem.Text = "Cập nhật phần mềm";
            // 
            // btnGiaoDienvaNgonNgu
            // 
            this.btnGiaoDienvaNgonNgu.Image = ((System.Drawing.Image)(resources.GetObject("btnGiaoDienvaNgonNgu.Image")));
            this.btnGiaoDienvaNgonNgu.Location = new System.Drawing.Point(5, 34);
            this.btnGiaoDienvaNgonNgu.Name = "btnGiaoDienvaNgonNgu";
            this.btnGiaoDienvaNgonNgu.Size = new System.Drawing.Size(145, 23);
            this.btnGiaoDienvaNgonNgu.TabIndex = 0;
            this.btnGiaoDienvaNgonNgu.Text = "Giao diện và ngôn ngữ";
            // 
            // btnCauHinh
            // 
            this.btnCauHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnCauHinh.Image")));
            this.btnCauHinh.Location = new System.Drawing.Point(5, 5);
            this.btnCauHinh.Name = "btnCauHinh";
            this.btnCauHinh.Size = new System.Drawing.Size(145, 23);
            this.btnCauHinh.TabIndex = 0;
            this.btnCauHinh.Text = "Cấu hình";
            this.btnCauHinh.Click += new System.EventHandler(this.btnCauHinh_Click);
            // 
            // panelControlHienThiCauHinh
            // 
            this.panelControlHienThiCauHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlHienThiCauHinh.Location = new System.Drawing.Point(154, 0);
            this.panelControlHienThiCauHinh.Name = "panelControlHienThiCauHinh";
            this.panelControlHienThiCauHinh.Size = new System.Drawing.Size(556, 422);
            this.panelControlHienThiCauHinh.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(7, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(7, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 422);
            this.Controls.Add(this.panelControlHienThiCauHinh);
            this.Controls.Add(this.panelControlbtnCauHinh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt cấu hình";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlbtnCauHinh)).EndInit();
            this.panelControlbtnCauHinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHienThiCauHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlbtnCauHinh;
        private DevExpress.XtraEditors.PanelControl panelControlHienThiCauHinh;
        private DevExpress.XtraEditors.SimpleButton btnGiaoDienvaNgonNgu;
        private DevExpress.XtraEditors.SimpleButton btnCauHinh;
        private DevExpress.XtraEditors.SimpleButton btnThongTinPhanMem;
        private DevExpress.XtraEditors.SimpleButton btnCapNhatPhanMem;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}