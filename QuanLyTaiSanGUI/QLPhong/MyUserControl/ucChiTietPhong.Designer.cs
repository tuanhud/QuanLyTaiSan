namespace QuanLyTaiSanGUI.MyUserControl
{
    partial class ucChiTietPhong
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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblHinhPhong = new DevExpress.XtraEditors.LabelControl();
            this.btnImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblViTri = new DevExpress.XtraEditors.LabelControl();
            this.lblTenPhong = new DevExpress.XtraEditors.LabelControl();
            this.txtTenPhong = new DevExpress.XtraEditors.TextEdit();
            this.imgPhong = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.txtMoTaPhong = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblSoDienThoai = new DevExpress.XtraEditors.LabelControl();
            this.lblTenNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.imgNhanVien = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.txtSoDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.txtTenNhanVien = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNhanVien = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTaPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.lblHinhPhong);
            this.groupControl1.Controls.Add(this.btnImage);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnOK);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.lblViTri);
            this.groupControl1.Controls.Add(this.lblTenPhong);
            this.groupControl1.Controls.Add(this.txtTenPhong);
            this.groupControl1.Controls.Add(this.imgPhong);
            this.groupControl1.Controls.Add(this.txtMoTaPhong);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(282, 287);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin phòng";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Location = new System.Drawing.Point(68, 176);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(209, 20);
            this.panelControl1.TabIndex = 15;
            // 
            // lblHinhPhong
            // 
            this.lblHinhPhong.Location = new System.Drawing.Point(7, 24);
            this.lblHinhPhong.Name = "lblHinhPhong";
            this.lblHinhPhong.Size = new System.Drawing.Size(46, 13);
            this.lblHinhPhong.TabIndex = 14;
            this.lblHinhPhong.Text = "Hình ảnh:";
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(194, 24);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 13;
            this.btnImage.Text = "Chọn";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(145, 257);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(64, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 204);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Mô tả:";
            // 
            // lblViTri
            // 
            this.lblViTri.Location = new System.Drawing.Point(7, 176);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(25, 13);
            this.lblViTri.TabIndex = 7;
            this.lblViTri.Text = "Vị trí:";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.Location = new System.Drawing.Point(7, 152);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(55, 13);
            this.lblTenPhong.TabIndex = 6;
            this.lblTenPhong.Text = "Tên phòng:";
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenPhong.Location = new System.Drawing.Point(68, 150);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(209, 20);
            this.txtTenPhong.TabIndex = 1;
            // 
            // imgPhong
            // 
            this.imgPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPhong.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imgPhong.Location = new System.Drawing.Point(68, 24);
            this.imgPhong.Name = "imgPhong";
            this.imgPhong.Size = new System.Drawing.Size(120, 120);
            this.imgPhong.TabIndex = 0;
            this.imgPhong.Text = "imageSlider1";
            // 
            // txtMoTaPhong
            // 
            this.txtMoTaPhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTaPhong.Location = new System.Drawing.Point(68, 202);
            this.txtMoTaPhong.Name = "txtMoTaPhong";
            this.txtMoTaPhong.Size = new System.Drawing.Size(209, 49);
            this.txtMoTaPhong.TabIndex = 5;
            this.txtMoTaPhong.UseOptimizedRendering = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lblSoDienThoai);
            this.groupControl2.Controls.Add(this.lblTenNhanVien);
            this.groupControl2.Controls.Add(this.lblMaNhanVien);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.imgNhanVien);
            this.groupControl2.Controls.Add(this.txtSoDienThoai);
            this.groupControl2.Controls.Add(this.txtTenNhanVien);
            this.groupControl2.Controls.Add(this.txtMaNhanVien);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 287);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(282, 261);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Thông tin nhân viên phụ trách";
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.Location = new System.Drawing.Point(81, 206);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(0, 13);
            this.lblSoDienThoai.TabIndex = 10;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Location = new System.Drawing.Point(81, 180);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(0, 13);
            this.lblTenNhanVien.TabIndex = 9;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.Location = new System.Drawing.Point(81, 152);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(0, 13);
            this.lblMaNhanVien.TabIndex = 8;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(6, 25);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 13);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "Hình ảnh";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(7, 206);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(66, 13);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Số điện thoại:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(6, 180);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 13);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Tên nhân viên:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 152);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 13);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Mã nhân viên:";
            // 
            // imgNhanVien
            // 
            this.imgNhanVien.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imgNhanVien.Location = new System.Drawing.Point(79, 25);
            this.imgNhanVien.Name = "imgNhanVien";
            this.imgNhanVien.Size = new System.Drawing.Size(120, 120);
            this.imgNhanVien.TabIndex = 0;
            this.imgNhanVien.Text = "imageSlider2";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoDienThoai.Enabled = false;
            this.txtSoDienThoai.Location = new System.Drawing.Point(79, 203);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Properties.ReadOnly = true;
            this.txtSoDienThoai.Size = new System.Drawing.Size(198, 20);
            this.txtSoDienThoai.TabIndex = 1;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNhanVien.Enabled = false;
            this.txtTenNhanVien.Location = new System.Drawing.Point(79, 177);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Properties.ReadOnly = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(198, 20);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNhanVien.Enabled = false;
            this.txtMaNhanVien.Location = new System.Drawing.Point(79, 151);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Properties.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(198, 20);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // ucChiTietPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucChiTietPhong";
            this.Size = new System.Drawing.Size(282, 548);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTaPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblViTri;
        private DevExpress.XtraEditors.LabelControl lblTenPhong;
        private DevExpress.XtraEditors.TextEdit txtTenPhong;
        private DevExpress.XtraEditors.Controls.ImageSlider imgPhong;
        private DevExpress.XtraEditors.MemoEdit txtMoTaPhong;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.Controls.ImageSlider imgNhanVien;
        private DevExpress.XtraEditors.LabelControl lblSoDienThoai;
        private DevExpress.XtraEditors.LabelControl lblTenNhanVien;
        private DevExpress.XtraEditors.LabelControl lblMaNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnImage;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblHinhPhong;
        private DevExpress.XtraEditors.TextEdit txtSoDienThoai;
        private DevExpress.XtraEditors.TextEdit txtTenNhanVien;
        private DevExpress.XtraEditors.TextEdit txtMaNhanVien;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;

    }
}
