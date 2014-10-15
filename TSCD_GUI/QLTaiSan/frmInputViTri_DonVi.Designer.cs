namespace TSCD_GUI.QLTaiSan
{
    partial class frmInputViTri_DonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputViTri_DonVi));
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.txtSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.lblPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblViTri = new DevExpress.XtraEditors.LabelControl();
            this.lblDonViQL = new DevExpress.XtraEditors.LabelControl();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.lbltxtDonViTinh = new DevExpress.XtraEditors.LabelControl();
            this.lblChungTu = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay_CT = new DevExpress.XtraEditors.LabelControl();
            this.lblSoHieu_CT = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayGhi = new DevExpress.XtraEditors.LabelControl();
            this.txtSoHieu_CT = new DevExpress.XtraEditors.TextEdit();
            this.dateNgay_CT = new DevExpress.XtraEditors.DateEdit();
            this.dateNgayGhi = new DevExpress.XtraEditors.DateEdit();
            this.ucComboBoxDonVi1 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.ucComboBoxViTri2 = new TSCD_GUI.MyUserControl.ucComboBoxViTri();
            this.ucComboBoxViTri1 = new TSCD_GUI.MyUserControl.ucComboBoxViTri();
            this.btnAttachment = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu_CT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(93, 168);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(375, 75);
            this.txtGhiChu.TabIndex = 8;
            this.txtGhiChu.UseOptimizedRendering = true;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(10, 67);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(46, 13);
            this.lblSoLuong.TabIndex = 5;
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
            this.txtSoLuong.Location = new System.Drawing.Point(93, 64);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoLuong.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSoLuong.Properties.Mask.EditMask = "N00";
            this.txtSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtSoLuong.Size = new System.Drawing.Size(291, 20);
            this.txtSoLuong.TabIndex = 4;
            // 
            // lblPhong
            // 
            this.lblPhong.Location = new System.Drawing.Point(10, 92);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(34, 13);
            this.lblPhong.TabIndex = 7;
            this.lblPhong.Text = "Phòng:";
            // 
            // lblViTri
            // 
            this.lblViTri.Location = new System.Drawing.Point(10, 118);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(25, 13);
            this.lblViTri.TabIndex = 8;
            this.lblViTri.Text = "Vị trí:";
            // 
            // lblDonViQL
            // 
            this.lblDonViQL.Location = new System.Drawing.Point(10, 145);
            this.lblDonViQL.Name = "lblDonViQL";
            this.lblDonViQL.Size = new System.Drawing.Size(73, 13);
            this.lblDonViQL.TabIndex = 9;
            this.lblDonViQL.Text = "Đơn vị quản lý:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(9, 171);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(39, 13);
            this.lblGhiChu.TabIndex = 11;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(160, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(241, 249);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lbltxtDonViTinh
            // 
            this.lbltxtDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltxtDonViTinh.Location = new System.Drawing.Point(390, 67);
            this.lbltxtDonViTinh.Name = "lbltxtDonViTinh";
            this.lbltxtDonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lbltxtDonViTinh.TabIndex = 14;
            this.lbltxtDonViTinh.Text = "[Đơn vị tính]";
            // 
            // lblChungTu
            // 
            this.lblChungTu.Location = new System.Drawing.Point(10, 41);
            this.lblChungTu.Name = "lblChungTu";
            this.lblChungTu.Size = new System.Drawing.Size(50, 13);
            this.lblChungTu.TabIndex = 32;
            this.lblChungTu.Text = "Chứng từ:";
            // 
            // lblNgay_CT
            // 
            this.lblNgay_CT.Location = new System.Drawing.Point(259, 41);
            this.lblNgay_CT.Name = "lblNgay_CT";
            this.lblNgay_CT.Size = new System.Drawing.Size(60, 13);
            this.lblNgay_CT.TabIndex = 31;
            this.lblNgay_CT.Text = "Ngày tháng:";
            // 
            // lblSoHieu_CT
            // 
            this.lblSoHieu_CT.Location = new System.Drawing.Point(93, 41);
            this.lblSoHieu_CT.Name = "lblSoHieu_CT";
            this.lblSoHieu_CT.Size = new System.Drawing.Size(39, 13);
            this.lblSoHieu_CT.TabIndex = 30;
            this.lblSoHieu_CT.Text = "Số hiệu:";
            // 
            // lblNgayGhi
            // 
            this.lblNgayGhi.Location = new System.Drawing.Point(10, 15);
            this.lblNgayGhi.Name = "lblNgayGhi";
            this.lblNgayGhi.Size = new System.Drawing.Size(71, 13);
            this.lblNgayGhi.TabIndex = 29;
            this.lblNgayGhi.Text = "Ngày sử dụng:";
            // 
            // txtSoHieu_CT
            // 
            this.txtSoHieu_CT.Location = new System.Drawing.Point(138, 38);
            this.txtSoHieu_CT.Name = "txtSoHieu_CT";
            this.txtSoHieu_CT.Size = new System.Drawing.Size(100, 20);
            this.txtSoHieu_CT.TabIndex = 1;
            // 
            // dateNgay_CT
            // 
            this.dateNgay_CT.EditValue = null;
            this.dateNgay_CT.Location = new System.Drawing.Point(325, 38);
            this.dateNgay_CT.Name = "dateNgay_CT";
            this.dateNgay_CT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay_CT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay_CT.Size = new System.Drawing.Size(114, 20);
            this.dateNgay_CT.TabIndex = 2;
            // 
            // dateNgayGhi
            // 
            this.dateNgayGhi.EditValue = null;
            this.dateNgayGhi.Location = new System.Drawing.Point(93, 12);
            this.dateNgayGhi.Name = "dateNgayGhi";
            this.dateNgayGhi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayGhi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayGhi.Size = new System.Drawing.Size(280, 20);
            this.dateNgayGhi.TabIndex = 0;
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(93, 142);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(375, 20);
            this.ucComboBoxDonVi1.TabIndex = 7;
            // 
            // ucComboBoxViTri2
            // 
            this.ucComboBoxViTri2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucComboBoxViTri2.EditValue = null;
            this.ucComboBoxViTri2.Location = new System.Drawing.Point(93, 116);
            this.ucComboBoxViTri2.Name = "ucComboBoxViTri2";
            this.ucComboBoxViTri2.Phong = null;
            this.ucComboBoxViTri2.Size = new System.Drawing.Size(375, 20);
            this.ucComboBoxViTri2.TabIndex = 6;
            this.ucComboBoxViTri2.ViTri = null;
            // 
            // ucComboBoxViTri1
            // 
            this.ucComboBoxViTri1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucComboBoxViTri1.EditValue = null;
            this.ucComboBoxViTri1.Location = new System.Drawing.Point(93, 90);
            this.ucComboBoxViTri1.Name = "ucComboBoxViTri1";
            this.ucComboBoxViTri1.Phong = null;
            this.ucComboBoxViTri1.Size = new System.Drawing.Size(375, 20);
            this.ucComboBoxViTri1.TabIndex = 5;
            this.ucComboBoxViTri1.ViTri = null;
            // 
            // btnAttachment
            // 
            this.btnAttachment.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachment.Image")));
            this.btnAttachment.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAttachment.Location = new System.Drawing.Point(445, 36);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(23, 23);
            this.btnAttachment.TabIndex = 3;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // frmInputViTri_DonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 278);
            this.Controls.Add(this.btnAttachment);
            this.Controls.Add(this.lblChungTu);
            this.Controls.Add(this.lblNgay_CT);
            this.Controls.Add(this.lblSoHieu_CT);
            this.Controls.Add(this.lblNgayGhi);
            this.Controls.Add(this.txtSoHieu_CT);
            this.Controls.Add(this.dateNgay_CT);
            this.Controls.Add(this.dateNgayGhi);
            this.Controls.Add(this.lbltxtDonViTinh);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblDonViQL);
            this.Controls.Add(this.lblViTri);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.ucComboBoxDonVi1);
            this.Controls.Add(this.ucComboBoxViTri2);
            this.Controls.Add(this.ucComboBoxViTri1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtSoLuong);
            this.MinimumSize = new System.Drawing.Size(470, 316);
            this.Name = "frmInputViTri_DonVi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu_CT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_CT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayGhi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyUserControl.ucComboBoxViTri ucComboBoxViTri1;
        private MyUserControl.ucComboBoxViTri ucComboBoxViTri2;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi1;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.SpinEdit txtSoLuong;
        private DevExpress.XtraEditors.LabelControl lblPhong;
        private DevExpress.XtraEditors.LabelControl lblViTri;
        private DevExpress.XtraEditors.LabelControl lblDonViQL;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.LabelControl lbltxtDonViTinh;
        private DevExpress.XtraEditors.LabelControl lblChungTu;
        private DevExpress.XtraEditors.LabelControl lblNgay_CT;
        private DevExpress.XtraEditors.LabelControl lblSoHieu_CT;
        private DevExpress.XtraEditors.LabelControl lblNgayGhi;
        private DevExpress.XtraEditors.TextEdit txtSoHieu_CT;
        private DevExpress.XtraEditors.DateEdit dateNgay_CT;
        private DevExpress.XtraEditors.DateEdit dateNgayGhi;
        private DevExpress.XtraEditors.SimpleButton btnAttachment;
    }
}