namespace TSCD_GUI.QLTaiSan
{
    partial class frmChuyenTinhTrang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenTinhTrang));
            this.lookUpTinhTrang = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTinhTrang = new DevExpress.XtraEditors.LabelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.lbltxtDonViTinh = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.txtSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnTinhTrang = new DevExpress.XtraEditors.SimpleButton();
            this.lblTenTaiSan = new DevExpress.XtraEditors.LabelControl();
            this.lblMaTaiSan = new DevExpress.XtraEditors.LabelControl();
            this.txtTenTS = new DevExpress.XtraEditors.MemoEdit();
            this.txtMaTS = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTinhTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTS.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpTinhTrang
            // 
            this.lookUpTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpTinhTrang.Location = new System.Drawing.Point(71, 107);
            this.lookUpTinhTrang.Name = "lookUpTinhTrang";
            this.lookUpTinhTrang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTinhTrang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("value", "Tình trạng")});
            this.lookUpTinhTrang.Properties.DisplayMember = "value";
            this.lookUpTinhTrang.Properties.NullText = "[Chưa chọn tình trạng]";
            this.lookUpTinhTrang.Properties.ValueMember = "id";
            this.lookUpTinhTrang.Size = new System.Drawing.Size(367, 20);
            this.lookUpTinhTrang.TabIndex = 5;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(12, 110);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(53, 13);
            this.lblTinhTrang.TabIndex = 38;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(240, 214);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(159, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(12, 136);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(39, 13);
            this.lblGhiChu.TabIndex = 40;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(71, 133);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(395, 75);
            this.txtGhiChu.TabIndex = 7;
            this.txtGhiChu.UseOptimizedRendering = true;
            // 
            // lbltxtDonViTinh
            // 
            this.lbltxtDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltxtDonViTinh.Location = new System.Drawing.Point(388, 84);
            this.lbltxtDonViTinh.Name = "lbltxtDonViTinh";
            this.lbltxtDonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lbltxtDonViTinh.TabIndex = 45;
            this.lbltxtDonViTinh.Text = "[Đơn vị tính]";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(12, 84);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(46, 13);
            this.lblSoLuong.TabIndex = 43;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSoLuong.Location = new System.Drawing.Point(71, 81);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoLuong.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSoLuong.Properties.Mask.EditMask = "N00";
            this.txtSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtSoLuong.Size = new System.Drawing.Size(311, 20);
            this.txtSoLuong.TabIndex = 4;
            // 
            // btnTinhTrang
            // 
            this.btnTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhTrang.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhTrang.Image")));
            this.btnTinhTrang.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTinhTrang.Location = new System.Drawing.Point(443, 105);
            this.btnTinhTrang.Name = "btnTinhTrang";
            this.btnTinhTrang.Size = new System.Drawing.Size(23, 23);
            this.btnTinhTrang.TabIndex = 6;
            this.btnTinhTrang.Click += new System.EventHandler(this.btnTinhTrang_Click);
            // 
            // lblTenTaiSan
            // 
            this.lblTenTaiSan.Location = new System.Drawing.Point(12, 38);
            this.lblTenTaiSan.Name = "lblTenTaiSan";
            this.lblTenTaiSan.Size = new System.Drawing.Size(57, 13);
            this.lblTenTaiSan.TabIndex = 47;
            this.lblTenTaiSan.Text = "Tên tài sản:";
            // 
            // lblMaTaiSan
            // 
            this.lblMaTaiSan.Location = new System.Drawing.Point(12, 12);
            this.lblMaTaiSan.Name = "lblMaTaiSan";
            this.lblMaTaiSan.Size = new System.Drawing.Size(53, 13);
            this.lblMaTaiSan.TabIndex = 46;
            this.lblMaTaiSan.Text = "Mã tài sản:";
            // 
            // txtTenTS
            // 
            this.txtTenTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenTS.Location = new System.Drawing.Point(71, 35);
            this.txtTenTS.Name = "txtTenTS";
            this.txtTenTS.Properties.ReadOnly = true;
            this.txtTenTS.Size = new System.Drawing.Size(399, 40);
            this.txtTenTS.TabIndex = 49;
            this.txtTenTS.UseOptimizedRendering = true;
            // 
            // txtMaTS
            // 
            this.txtMaTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaTS.Location = new System.Drawing.Point(71, 9);
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Properties.ReadOnly = true;
            this.txtMaTS.Size = new System.Drawing.Size(399, 20);
            this.txtMaTS.TabIndex = 48;
            // 
            // frmChuyenTinhTrang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 243);
            this.Controls.Add(this.txtTenTS);
            this.Controls.Add(this.txtMaTS);
            this.Controls.Add(this.lblTenTaiSan);
            this.Controls.Add(this.lblMaTaiSan);
            this.Controls.Add(this.btnTinhTrang);
            this.Controls.Add(this.lbltxtDonViTinh);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lookUpTinhTrang);
            this.MinimumSize = new System.Drawing.Size(498, 267);
            this.Name = "frmChuyenTinhTrang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển tình trạng";
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTS.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpTinhTrang;
        private DevExpress.XtraEditors.LabelControl lblTinhTrang;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraEditors.LabelControl lbltxtDonViTinh;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.SpinEdit txtSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnTinhTrang;
        private DevExpress.XtraEditors.LabelControl lblTenTaiSan;
        private DevExpress.XtraEditors.LabelControl lblMaTaiSan;
        private DevExpress.XtraEditors.MemoEdit txtTenTS;
        private DevExpress.XtraEditors.TextEdit txtMaTS;
    }
}