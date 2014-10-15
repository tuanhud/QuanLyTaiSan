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
            this.lblChungTu = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay_CT = new DevExpress.XtraEditors.LabelControl();
            this.lblSoHieu_CT = new DevExpress.XtraEditors.LabelControl();
            this.txtSoHieu_CT = new DevExpress.XtraEditors.TextEdit();
            this.dateNgay_CT = new DevExpress.XtraEditors.DateEdit();
            this.lblTinhTrang = new DevExpress.XtraEditors.LabelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.lblNgayGhi = new DevExpress.XtraEditors.LabelControl();
            this.dateNgayGhi = new DevExpress.XtraEditors.DateEdit();
            this.lbltxtDonViTinh = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.txtSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnTinhTrang = new DevExpress.XtraEditors.SimpleButton();
            this.btnAttachment = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTinhTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu_CT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpTinhTrang
            // 
            this.lookUpTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpTinhTrang.Location = new System.Drawing.Point(95, 87);
            this.lookUpTinhTrang.Name = "lookUpTinhTrang";
            this.lookUpTinhTrang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTinhTrang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("value", "Tình trạng")});
            this.lookUpTinhTrang.Properties.DisplayMember = "value";
            this.lookUpTinhTrang.Properties.NullText = "[Chưa chọn tình trạng]";
            this.lookUpTinhTrang.Properties.ValueMember = "id";
            this.lookUpTinhTrang.Size = new System.Drawing.Size(347, 20);
            this.lookUpTinhTrang.TabIndex = 5;
            // 
            // lblChungTu
            // 
            this.lblChungTu.Location = new System.Drawing.Point(12, 38);
            this.lblChungTu.Name = "lblChungTu";
            this.lblChungTu.Size = new System.Drawing.Size(50, 13);
            this.lblChungTu.TabIndex = 37;
            this.lblChungTu.Text = "Chứng từ:";
            // 
            // lblNgay_CT
            // 
            this.lblNgay_CT.Location = new System.Drawing.Point(261, 38);
            this.lblNgay_CT.Name = "lblNgay_CT";
            this.lblNgay_CT.Size = new System.Drawing.Size(60, 13);
            this.lblNgay_CT.TabIndex = 36;
            this.lblNgay_CT.Text = "Ngày tháng:";
            // 
            // lblSoHieu_CT
            // 
            this.lblSoHieu_CT.Location = new System.Drawing.Point(95, 38);
            this.lblSoHieu_CT.Name = "lblSoHieu_CT";
            this.lblSoHieu_CT.Size = new System.Drawing.Size(39, 13);
            this.lblSoHieu_CT.TabIndex = 35;
            this.lblSoHieu_CT.Text = "Số hiệu:";
            // 
            // txtSoHieu_CT
            // 
            this.txtSoHieu_CT.Location = new System.Drawing.Point(140, 35);
            this.txtSoHieu_CT.Name = "txtSoHieu_CT";
            this.txtSoHieu_CT.Size = new System.Drawing.Size(100, 20);
            this.txtSoHieu_CT.TabIndex = 1;
            // 
            // dateNgay_CT
            // 
            this.dateNgay_CT.EditValue = null;
            this.dateNgay_CT.Location = new System.Drawing.Point(327, 35);
            this.dateNgay_CT.Name = "dateNgay_CT";
            this.dateNgay_CT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay_CT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay_CT.Size = new System.Drawing.Size(114, 20);
            this.dateNgay_CT.TabIndex = 2;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(12, 90);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(53, 13);
            this.lblTinhTrang.TabIndex = 38;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(244, 194);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(163, 194);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(12, 116);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(39, 13);
            this.lblGhiChu.TabIndex = 40;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(95, 113);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(375, 75);
            this.txtGhiChu.TabIndex = 7;
            this.txtGhiChu.UseOptimizedRendering = true;
            // 
            // lblNgayGhi
            // 
            this.lblNgayGhi.Location = new System.Drawing.Point(12, 12);
            this.lblNgayGhi.Name = "lblNgayGhi";
            this.lblNgayGhi.Size = new System.Drawing.Size(71, 13);
            this.lblNgayGhi.TabIndex = 47;
            this.lblNgayGhi.Text = "Ngày sử dụng:";
            // 
            // dateNgayGhi
            // 
            this.dateNgayGhi.EditValue = null;
            this.dateNgayGhi.Location = new System.Drawing.Point(95, 9);
            this.dateNgayGhi.Name = "dateNgayGhi";
            this.dateNgayGhi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayGhi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayGhi.Size = new System.Drawing.Size(280, 20);
            this.dateNgayGhi.TabIndex = 0;
            // 
            // lbltxtDonViTinh
            // 
            this.lbltxtDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltxtDonViTinh.Location = new System.Drawing.Point(392, 64);
            this.lbltxtDonViTinh.Name = "lbltxtDonViTinh";
            this.lbltxtDonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lbltxtDonViTinh.TabIndex = 45;
            this.lbltxtDonViTinh.Text = "[Đơn vị tính]";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(12, 64);
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
            this.txtSoLuong.Location = new System.Drawing.Point(95, 61);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoLuong.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSoLuong.Properties.Mask.EditMask = "N00";
            this.txtSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtSoLuong.Size = new System.Drawing.Size(291, 20);
            this.txtSoLuong.TabIndex = 4;
            // 
            // btnTinhTrang
            // 
            this.btnTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhTrang.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhTrang.Image")));
            this.btnTinhTrang.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTinhTrang.Location = new System.Drawing.Point(447, 85);
            this.btnTinhTrang.Name = "btnTinhTrang";
            this.btnTinhTrang.Size = new System.Drawing.Size(23, 23);
            this.btnTinhTrang.TabIndex = 6;
            this.btnTinhTrang.Click += new System.EventHandler(this.btnTinhTrang_Click);
            // 
            // btnAttachment
            // 
            this.btnAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachment.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachment.Image")));
            this.btnAttachment.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAttachment.Location = new System.Drawing.Point(447, 35);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(23, 23);
            this.btnAttachment.TabIndex = 3;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // frmChuyenTinhTrang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 229);
            this.Controls.Add(this.btnAttachment);
            this.Controls.Add(this.btnTinhTrang);
            this.Controls.Add(this.lblNgayGhi);
            this.Controls.Add(this.dateNgayGhi);
            this.Controls.Add(this.lbltxtDonViTinh);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblChungTu);
            this.Controls.Add(this.lblNgay_CT);
            this.Controls.Add(this.lblSoHieu_CT);
            this.Controls.Add(this.txtSoHieu_CT);
            this.Controls.Add(this.dateNgay_CT);
            this.Controls.Add(this.lookUpTinhTrang);
            this.MinimumSize = new System.Drawing.Size(498, 267);
            this.Name = "frmChuyenTinhTrang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển tình trạng";
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu_CT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpTinhTrang;
        private DevExpress.XtraEditors.LabelControl lblChungTu;
        private DevExpress.XtraEditors.LabelControl lblNgay_CT;
        private DevExpress.XtraEditors.LabelControl lblSoHieu_CT;
        private DevExpress.XtraEditors.TextEdit txtSoHieu_CT;
        private DevExpress.XtraEditors.DateEdit dateNgay_CT;
        private DevExpress.XtraEditors.LabelControl lblTinhTrang;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraEditors.LabelControl lblNgayGhi;
        private DevExpress.XtraEditors.DateEdit dateNgayGhi;
        private DevExpress.XtraEditors.LabelControl lbltxtDonViTinh;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.SpinEdit txtSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnTinhTrang;
        private DevExpress.XtraEditors.SimpleButton btnAttachment;
    }
}