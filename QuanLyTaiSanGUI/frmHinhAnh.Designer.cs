namespace QuanLyTaiSanGUI
{
    partial class frmHinhAnh
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
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHinhAnh));
            this.galleryControlImage = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.btnImageCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnImageSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnImageUpload = new DevExpress.XtraEditors.SimpleButton();
            this.btnImageDelete = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::QuanLyTaiSanGUI.WaitForm1), true, true);
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnThuVienAnh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlImage)).BeginInit();
            this.galleryControlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // galleryControlImage
            // 
            this.galleryControlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.galleryControlImage.Controls.Add(this.galleryControlClient1);
            this.galleryControlImage.DesignGalleryGroupIndex = 0;
            this.galleryControlImage.DesignGalleryItemIndex = 0;
            // 
            // galleryControlGallery1
            // 
            this.galleryControlImage.Gallery.AllowHoverImages = true;
            this.galleryControlImage.Gallery.AllowMarqueeSelection = true;
            this.galleryControlImage.Gallery.AutoSize = DevExpress.XtraBars.Ribbon.GallerySizeMode.None;
            galleryItemGroup2.Caption = "Danh sách hình ảnh";
            this.galleryControlImage.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup2});
            this.galleryControlImage.Gallery.HoverImageSize = new System.Drawing.Size(200, 200);
            this.galleryControlImage.Gallery.ImageSize = new System.Drawing.Size(100, 100);
            this.galleryControlImage.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.Multiple;
            this.galleryControlImage.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.galleryControlImage.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.galleryControlImage.Gallery.ShowItemText = true;
            this.galleryControlImage.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlImage_Gallery_ItemClick);
            this.galleryControlImage.Gallery.CustomDrawItemImage += new DevExpress.XtraBars.Ribbon.GalleryItemCustomDrawEventHandler(this.galleryControlGallery_CustomDrawItemImage);
            this.galleryControlImage.Location = new System.Drawing.Point(0, 33);
            this.galleryControlImage.Name = "galleryControlImage";
            this.galleryControlImage.Size = new System.Drawing.Size(585, 215);
            this.galleryControlImage.TabIndex = 0;
            this.galleryControlImage.Text = "Gallery Control Image";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControlImage;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(564, 211);
            // 
            // btnImageCancel
            // 
            this.btnImageCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnImageCancel.Image")));
            this.btnImageCancel.Location = new System.Drawing.Point(491, 254);
            this.btnImageCancel.Name = "btnImageCancel";
            this.btnImageCancel.Size = new System.Drawing.Size(75, 23);
            this.btnImageCancel.TabIndex = 1;
            this.btnImageCancel.Text = "Đóng";
            this.btnImageCancel.Click += new System.EventHandler(this.btnImageCancel_Click);
            // 
            // btnImageSelectAll
            // 
            this.btnImageSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnImageSelectAll.Image")));
            this.btnImageSelectAll.Location = new System.Drawing.Point(83, 4);
            this.btnImageSelectAll.Name = "btnImageSelectAll";
            this.btnImageSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnImageSelectAll.TabIndex = 2;
            this.btnImageSelectAll.Text = "Chọn hết";
            this.btnImageSelectAll.Click += new System.EventHandler(this.btnImageSelectAll_Click);
            // 
            // btnImageUpload
            // 
            this.btnImageUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnImageUpload.Image")));
            this.btnImageUpload.Location = new System.Drawing.Point(2, 4);
            this.btnImageUpload.Name = "btnImageUpload";
            this.btnImageUpload.Size = new System.Drawing.Size(75, 23);
            this.btnImageUpload.TabIndex = 3;
            this.btnImageUpload.Text = "Thêm mới";
            this.btnImageUpload.Click += new System.EventHandler(this.btnImageUpload_Click);
            // 
            // btnImageDelete
            // 
            this.btnImageDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnImageDelete.Image")));
            this.btnImageDelete.Location = new System.Drawing.Point(164, 4);
            this.btnImageDelete.Name = "btnImageDelete";
            this.btnImageDelete.Size = new System.Drawing.Size(75, 23);
            this.btnImageDelete.TabIndex = 4;
            this.btnImageDelete.Text = "Xóa";
            this.btnImageDelete.Click += new System.EventHandler(this.btnImageDelete_Click);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxEdit1.EditValue = "Giữ nguyên";
            this.comboBoxEdit1.Location = new System.Drawing.Point(94, 256);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Giữ nguyên",
            "Lớn (800px)",
            "Vừa (400px)",
            "Nhỏ(100px)"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(410, 254);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnThuVienAnh
            // 
            this.btnThuVienAnh.Image = ((System.Drawing.Image)(resources.GetObject("btnThuVienAnh.Image")));
            this.btnThuVienAnh.Location = new System.Drawing.Point(245, 4);
            this.btnThuVienAnh.Name = "btnThuVienAnh";
            this.btnThuVienAnh.Size = new System.Drawing.Size(125, 23);
            this.btnThuVienAnh.TabIndex = 7;
            this.btnThuVienAnh.Text = "Duyệt ảnh đã có";
            this.btnThuVienAnh.Click += new System.EventHandler(this.btnThuVienAnh_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(2, 259);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Kích thước tải ảnh";
            // 
            // frmHinhAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 282);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnThuVienAnh);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.btnImageDelete);
            this.Controls.Add(this.btnImageUpload);
            this.Controls.Add(this.btnImageSelectAll);
            this.Controls.Add(this.btnImageCancel);
            this.Controls.Add(this.galleryControlImage);
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "frmHinhAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hình ảnh";
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlImage)).EndInit();
            this.galleryControlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.SimpleButton btnImageCancel;
        private DevExpress.XtraEditors.SimpleButton btnImageSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnImageUpload;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControlImage;
        private DevExpress.XtraEditors.SimpleButton btnImageDelete;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnThuVienAnh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}